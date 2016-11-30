using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;

namespace DeVes.Bazaar.Client.SubForms
{
    public partial class ImportPositionForm : BaseSubForm
    {
        public class PositionLvi : ListViewItem
        {
            public BizPosition DataObj { get; set; }

            public PositionLvi(BizPosition position)
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

        private List<PositionLvi> m_globalList = new List<PositionLvi>();
        private DataTable m_importTable = new DataTable();

        private BizSupplierer m_supplier;
        private string m_fileName;

        public ImportPositionForm()
        {
            InitializeComponent();
        }

        private void ImportPositionForm_Load(object sender, EventArgs e)
        {
            foreach (DataRow _row in this.m_importTable.Rows)
            {
                var _bizPos = this.ConvertFromDataRow(_row);
                if (_bizPos != null)
                {
                    this.m_globalList.Add(new PositionLvi(_bizPos));
                    this.m_matlPosLv.Items.Add(new PositionLvi(_bizPos));
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
                        var _posItem = _lvItem as PositionLvi;
                        if (_posItem != null && _posItem.DataObj.PositionNo.ToString() == this.dvTextBox1.Text)
                        {
                            this.ImportLineToSupplier(this.m_matlPosLv.Items[0] as PositionLvi);
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
                else if (this.m_matlPosLv.Items.Count == 1 && this.m_matlPosLv.Items[0] is PositionLvi)
                {
                    this.ImportLineToSupplier(this.m_matlPosLv.Items[0] as PositionLvi);
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

            var _enteredValue = this.dvTextBox1.Text.ToLower().Trim();

            if (!string.IsNullOrEmpty(_enteredValue))
            {
                var _items =
                    from _ in this.m_globalList
                    where _.DataObj.PositionNo.ToString().IndexOf(_enteredValue) >= 0 ||
                          _.DataObj.Material.ToString().ToLower().IndexOf(_enteredValue) >= 0
                    select _;

                foreach (var _row in _items)
                {
                    this.m_matlPosLv.Items.Add(_row);
                }
            }
            else
            {
                foreach (var _row in this.m_globalList)
                {
                    this.m_matlPosLv.Items.Add(_row);
                }
            }
        }

        private void m_matlPosLv_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_matlPosLv.SelectedItems.Count == 1 && this.m_matlPosLv.SelectedItems[0] is PositionLvi)
            {
                this.ImportLineToSupplier(this.m_matlPosLv.SelectedItems[0] as PositionLvi);
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
                catch (Exception _ex)
                {
                    _result = null;
                }
            }

            return _result;
        }
        private bool IsHeadLine(params string[] columnValues)
        {
            var _headValues = new List<string>() { "Nummer", "Bezeichnung", "Kategorie", "Hersteller", "Preis in", "min. Preis" };
            var _columnCount = Math.Min(columnValues.Length, _headValues.Count);
            var _oneIsDiff = false;

            for (var _colIndex = 0; _colIndex < _columnCount; _colIndex++)
            {
                var _colValueToCompate = columnValues[_colIndex];
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

            var _impCols = new List<string>() { "PositionNo", "Material", "Category", "Manufacturer", "PriceMax", "PriceMin" };
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
                        var _columns = _line.Split(new string[] { ";" }, StringSplitOptions.None);
                        if (_columns != null && _columns.Length >= _impCols.Count)
                        {
                            if (!this.IsHeadLine(_columns))
                            {
                                var _hadOneEx = false;
                                var _newRow = this.m_importTable.NewRow();

                                for (var _colIndex = 0; _colIndex < _impCols.Count; _colIndex++)
                                {
                                    try
                                    {
                                        if (_columns[_colIndex] != null && !string.IsNullOrEmpty(_columns[_colIndex].Trim()))
                                        {
                                            var _dataCol = this.m_importTable.Columns[_impCols[_colIndex]];

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
                                    catch (Exception _ex)
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
            catch (Exception _ex)
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
            catch(Exception _ex)
            {
                return false;
            }
            return this.m_importTable.Rows.Count > 0;
        }
        private void ImportLineToSupplier(PositionLvi line)
        {
            if (line == null)
                return;

            try
            {
                var _newPosition = line.DataObj;
                _newPosition.SupplierId = this.m_supplier.SupplierID;

                if (GParams.Instance.BasarCom.PositionGet(_newPosition.PositionNo, true) == null)
                {
                    var _created = false;
                    var _createdSpec = false;

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
            catch(Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }

            this.dvTextBox1.ResetText();
            this.dvTextBox1.Focus();
        }



        public static DialogResult HandleImport(IWin32Window owner, string fileName, BizSupplierer supplier)
        {
            if (System.IO.File.Exists(fileName))
            {
                var _fileInfo = new System.IO.FileInfo(fileName);
                var _frm = new ImportPositionForm();

                if (string.Compare(_fileInfo.Extension, ".csv", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (_frm.ReadPositonCsv(fileName))
                    {
                        _frm.m_fileName = fileName;
                        _frm.m_supplier = supplier;

                        return _frm.ShowDialog(owner);
                    }
                }
                else if (string.Compare(_fileInfo.Extension, ".xml", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (_frm.ReadPositionXml(fileName))
                    {
                        _frm.m_fileName = fileName;
                        _frm.m_supplier = supplier;

                        return _frm.ShowDialog(owner);
                    }
                }
            }
            return DialogResult.None;
        }
    }
}
