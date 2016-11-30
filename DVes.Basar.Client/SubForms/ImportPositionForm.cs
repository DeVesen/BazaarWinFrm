using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DVes.Basar.Client.IBasarCom;

namespace DVes.Basar.Client.SubForms
{
    public partial class ImportPositionForm : BaseSubForm
    {
        public class PositionLVI : ListViewItem
        {
            public BizPosition DataObj { get; set; }

            public PositionLVI(BizPosition position)
            {
                this.DataObj = position;

                this.Text = position.PositionNo.ToString();
                this.SubItems.Add(position.Material);
                this.SubItems.Add(position.Category);
                this.SubItems.Add(position.Manufacturer);
                this.SubItems.Add(position.PriceMax.ToString());
                this.SubItems.Add(position.PriceMin.ToString());
            }
        }

        private List<PositionLVI> m_globalList = new List<PositionLVI>();
        private DataTable m_importTable = new DataTable();

        private BizSupplierer m_supplier = null;
        private string m_fileName = null;

        public ImportPositionForm()
        {
            InitializeComponent();
        }

        private void ImportPositionForm_Load(object sender, EventArgs e)
        {
            foreach (DataRow _row in this.m_importTable.Rows)
            {
                BizPosition _bizPos = this.ConvertFromDataRow(_row);
                if (_bizPos != null)
                {
                    this.m_globalList.Add(new PositionLVI(_bizPos));
                    this.m_matlPosLv.Items.Add(new PositionLVI(_bizPos));
                }
            }
        }

        private void dvTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (this.m_matlPosLv.Items.Count > 1)
                {
                    foreach (ListViewItem _lvItem in this.m_matlPosLv.Items)
                    {
                        PositionLVI _posItem = _lvItem as PositionLVI;
                        if (_posItem != null && _posItem.DataObj.PositionNo.ToString() == this.dvTextBox1.Text)
                        {
                            this.ImportLineToSupplier(this.m_matlPosLv.Items[0] as PositionLVI);
                            this.PlayGoodSound();
                            break;
                        }
                        else
                        {
                            this.dvTextBox1.Focus();
                            this.dvTextBox1.SelectAll();
                            this.PlayBadSound();
                        }
                    }
                }
                else if (this.m_matlPosLv.Items.Count == 1 && this.m_matlPosLv.Items[0] is PositionLVI)
                {
                    this.ImportLineToSupplier(this.m_matlPosLv.Items[0] as PositionLVI);
                }
                else 
                {
                    this.dvTextBox1.Focus();
                    this.dvTextBox1.SelectAll();
                    this.PlayBadSound();
                }
            }
        }
        private void dvTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.m_matlPosLv.Items.Clear();

            string _enteredValue = this.dvTextBox1.Text.ToLower().Trim();

            if (!string.IsNullOrEmpty(_enteredValue))
            {
                var _items =
                    from I in this.m_globalList
                    where I.DataObj.PositionNo.ToString().IndexOf(_enteredValue) >= 0 ||
                          I.DataObj.Material.ToString().ToLower().IndexOf(_enteredValue) >= 0
                    select I;

                foreach (PositionLVI _row in _items)
                {
                    this.m_matlPosLv.Items.Add(_row);
                }
            }
            else
            {
                foreach (PositionLVI _row in this.m_globalList)
                {
                    this.m_matlPosLv.Items.Add(_row);
                }
            }
        }

        private void m_matlPosLv_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_matlPosLv.SelectedItems.Count == 1 && this.m_matlPosLv.SelectedItems[0] is PositionLVI)
            {
                this.ImportLineToSupplier(this.m_matlPosLv.SelectedItems[0] as PositionLVI);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();


        }




        private BizPosition ConvertFromDataRow(DataRow row)
        {
            BizPosition _result = null;

            if (row != null)
            {
                _result = new BizPosition();

                try
                {
                    _result.SupplierId = GParams.ToString(row["SupplierId"]);

                    _result.PositionNo = GParams.ToInt32(row["PositionNo"]).Value;
                    _result.PositionNoSpecified = true;

                    _result.Material = GParams.ToString(row["Material"]);
                    _result.Category = GParams.ToString(row["Category"]);
                    _result.Manufacturer = GParams.ToString(row["Manufacturer"]);

                    _result.PriceMin = GParams.ToDouble(row["PriceMin"]);
                    _result.PriceMinSpecified = true;
                    _result.PriceMax = GParams.ToDouble(row["PriceMax"]).Value;
                    _result.PriceMaxSpecified = true;

                    _result.Memo = GParams.ToString(row["Memo"]);
                }
                catch (Exception ex)
                {
                    _result = null;
                }
            }

            return _result;
        }
        private bool IsHeadLine(params string[] columnValues)
        {
            List<string> _headValues = new List<string>() { "Nummer", "Bezeichnung", "Kategorie", "Hersteller", "Preis in", "min. Preis" };
            int _columnCount = System.Math.Min(columnValues.Length, _headValues.Count);
            bool _oneIsDiff = false;

            for (int _colIndex = 0; _colIndex < _columnCount; _colIndex++)
            {
                string _colValueToCompate = columnValues[_colIndex];
                if (_colValueToCompate.Length > _headValues[_colIndex].Length)
                    _colValueToCompate = _colValueToCompate.Substring(0, _headValues[_colIndex].Length);

                if (string.Compare(_colValueToCompate, _headValues[_colIndex], StringComparison.OrdinalIgnoreCase) != 0)
                {
                    _oneIsDiff = true;
                }
            }

            return !_oneIsDiff;
        }
        private bool ReadPositonCsv(string filePath)
        {
            this.m_importTable.TableName = "Positions";
            this.m_importTable.Columns.Add("SupplierId", typeof(string));
            this.m_importTable.Columns.Add("PositionNo", typeof(int));
            this.m_importTable.Columns.Add("Material", typeof(string));
            this.m_importTable.Columns.Add("Category", typeof(string));
            this.m_importTable.Columns.Add("Manufacturer", typeof(string));
            this.m_importTable.Columns.Add("PriceMin", typeof(double));
            this.m_importTable.Columns.Add("PriceMax", typeof(double));
            this.m_importTable.Columns.Add("Memo", typeof(string));

            List<string> _impCols = new List<string>() { "PositionNo", "Material", "Category", "Manufacturer", "PriceMax", "PriceMin" };
            System.IO.StreamReader _streamReader = null;

            try
            {
                _streamReader = new System.IO.StreamReader(filePath);
                string _line = null;

                do
                {
                    _line = _streamReader.ReadLine();

                    if (_line != null && !string.IsNullOrEmpty(_line.Trim()))
                    {
                        string[] _columns = _line.Split(new string[] { ";" }, StringSplitOptions.None);
                        if (_columns != null && _columns.Length >= _impCols.Count)
                        {
                            if (!this.IsHeadLine(_columns))
                            {
                                bool _hadOneEx = false;
                                DataRow _newRow = this.m_importTable.NewRow();

                                for (int _colIndex = 0; _colIndex < _impCols.Count; _colIndex++)
                                {
                                    try
                                    {
                                        if (_columns[_colIndex] != null && !string.IsNullOrEmpty(_columns[_colIndex].Trim()))
                                        {
                                            DataColumn _dataCol = this.m_importTable.Columns[_impCols[_colIndex]];

                                            if (_dataCol.DataType.FullName == typeof(string).FullName)
                                            {
                                                _newRow[_impCols[_colIndex]] = _columns[_colIndex];
                                            }
                                            else if (_dataCol.DataType.FullName == typeof(int).FullName)
                                            {
                                                _newRow[_impCols[_colIndex]] = Convert.ToInt32(_columns[_colIndex]);
                                            }
                                            else if (_dataCol.DataType.FullName == typeof(double).FullName)
                                            {
                                                _newRow[_impCols[_colIndex]] = Convert.ToDouble(_columns[_colIndex]);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        _hadOneEx = true;
                                        break;
                                    }
                                }

                                if (!_hadOneEx)
                                {
                                    this.m_importTable.Rows.Add(_newRow);
                                }
                            }
                        }
                    }

                } while (_line != null);
            }
            catch (Exception ex)
            {

            }

            if (_streamReader != null)
            {
                _streamReader.Close();
                _streamReader.Dispose();
                _streamReader = null;
            }

            return this.m_importTable.Rows.Count > 0;
        }
        private bool ReadPositionXml(string filePath)
        {
            this.m_importTable.TableName = "Positions";
            this.m_importTable.Columns.Add("SupplierId", typeof(string));
            this.m_importTable.Columns.Add("PositionNo", typeof(int));
            this.m_importTable.Columns.Add("Material", typeof(string));
            this.m_importTable.Columns.Add("Category", typeof(string));
            this.m_importTable.Columns.Add("Manufacturer", typeof(string));
            this.m_importTable.Columns.Add("PriceMin", typeof(double));
            this.m_importTable.Columns.Add("PriceMax", typeof(double));
            this.m_importTable.Columns.Add("Memo", typeof(string));

            try
            {
                this.m_importTable.ReadXml(filePath);
            }
            catch(Exception ex)
            {
                return false;
            }
            return this.m_importTable.Rows.Count > 0;
        }
        private void ImportLineToSupplier(PositionLVI line)
        {
            if (line == null)
                return;

            try
            {
                BizPosition _newPosition = line.DataObj;
                _newPosition.SupplierId = this.m_supplier.SupplierID;

                if (GParams.Instance.BasarCom.PositionGet(_newPosition.PositionNo, true) == null)
                {
                    bool _created = false;
                    bool _createdSpec = false;

                    GParams.Instance.BasarCom.PositionCreate(_newPosition, out _created, out _createdSpec);

                    if (_created && _createdSpec)
                    {
                        this.m_globalList.Remove(line);
                        this.PlayConfirmedSound();
                    }
                    else
                    {
                        this.PlayBadSound();
                        MessageBox.Show("Position konnte nicht erstellt werden");
                    }
                }
                else
                {
                    this.PlayBadSound();
                    MessageBox.Show("Positionsnummer existiert bereits!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.dvTextBox1.ResetText();
            this.dvTextBox1.Focus();
        }



        public static DialogResult HandleImport(IWin32Window owner, string FileName, BizSupplierer supplier)
        {
            if (System.IO.File.Exists(FileName))
            {
                System.IO.FileInfo _fileInfo = new System.IO.FileInfo(FileName);
                ImportPositionForm _frm = new ImportPositionForm();

                if (string.Compare(_fileInfo.Extension, ".csv", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (_frm.ReadPositonCsv(FileName))
                    {
                        _frm.m_fileName = FileName;
                        _frm.m_supplier = supplier;

                        return _frm.ShowDialog(owner);
                    }
                }
                else if (string.Compare(_fileInfo.Extension, ".xml", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (_frm.ReadPositionXml(FileName))
                    {
                        _frm.m_fileName = FileName;
                        _frm.m_supplier = supplier;

                        return _frm.ShowDialog(owner);
                    }
                }
            }
            return DialogResult.None;
        }
    }
}
