using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                DataObj = position;

                Text = position.PositionNo.ToString();
                SubItems.Add(position.Material);
                SubItems.Add(position.Category);
                SubItems.Add(position.Manufacturer);
                SubItems.Add(position.PriceMax.ToString());
                SubItems.Add(position.PriceMin.ToString());
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
            m_lbErrorMsg.ResetText();

            foreach (DataRow _row in m_importTable.Rows)
            {
                var _bizPos = ConvertFromDataRow(_row);
                if (_bizPos != null)
                {
                    m_globalList.Add(new PositionLvi(_bizPos));
                    m_matlPosLv.Items.Add(new PositionLvi(_bizPos));
                }
            }
        }

        private void dvTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            m_lbErrorMsg.ResetText();
            m_lbErrorMsg.BackColor = Color.Transparent;

            if (e.KeyCode == Keys.Return)
            {
                if (m_matlPosLv.Items.Count > 1)
                {
                    foreach (ListViewItem _lvItem in m_matlPosLv.Items)
                    {
                        var _posItem = _lvItem as PositionLvi;
                        if (_posItem != null && _posItem.DataObj.PositionNo.ToString() == dvTextBox1.Text)
                        {
                            ImportLineToSupplier(m_matlPosLv.Items[0] as PositionLvi);
                            PlayGoodSound();
                            break;
                        }
                        else
                        {
                            dvTextBox1.Focus();
                            dvTextBox1.SelectAll();
                            PlayBadSound();
                        }
                    }
                }
                else if (m_matlPosLv.Items.Count == 1 && m_matlPosLv.Items[0] is PositionLvi)
                {
                    ImportLineToSupplier(m_matlPosLv.Items[0] as PositionLvi);
                }
                else
                {
                    var _posNum = 0;
                    if (!int.TryParse(dvTextBox1.Text, out _posNum))
                        _posNum = 0;

                    if (GParams.Instance.BasarCom.PositionGet(_posNum, true) == null)
                    {
                        m_lbErrorMsg.Text = @"Positionsnummer nicht gefunden!";
                    }
                    else
                    {
                        m_lbErrorMsg.Text = @"Positionsnummer existiert bereits!";
                    }
                    m_lbErrorMsg.BackColor = Color.FromArgb(255, 255, 100, 100);

                    dvTextBox1.Focus();
                    dvTextBox1.SelectAll();
                    PlayBadSound();
                }
            }
        }
        private void dvTextBox1_TextChanged(object sender, EventArgs e)
        {
            m_matlPosLv.Items.Clear();

            var _enteredValue = dvTextBox1.Text.ToLower().Trim();

            if (!string.IsNullOrEmpty(_enteredValue))
            {
                var _items =
                    from _ in m_globalList
                    where _.DataObj.PositionNo.ToString().IndexOf(_enteredValue) >= 0 ||
                          _.DataObj.Material.ToString().ToLower().IndexOf(_enteredValue) >= 0
                    select _;

                foreach (var _row in _items)
                {
                    m_matlPosLv.Items.Add(_row);
                }
            }
            else
            {
                foreach (var _row in m_globalList)
                {
                    m_matlPosLv.Items.Add(_row);
                }
            }
        }

        private void m_matlPosLv_DoubleClick(object sender, EventArgs e)
        {
            if (m_matlPosLv.SelectedItems.Count == 1 && m_matlPosLv.SelectedItems[0] is PositionLvi)
            {
                ImportLineToSupplier(m_matlPosLv.SelectedItems[0] as PositionLvi);
                OnSyncListWithDbBtnClick(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();


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
            m_importTable.TableName = "Positions";
            m_importTable.Columns.Add("SupplierId", typeof(string));
            m_importTable.Columns.Add("PositionNo", typeof(int));
            m_importTable.Columns.Add("Material", typeof(string));
            m_importTable.Columns.Add("Category", typeof(string));
            m_importTable.Columns.Add("Manufacturer", typeof(string));
            m_importTable.Columns.Add("PriceMin", typeof(double));
            m_importTable.Columns.Add("PriceMax", typeof(double));
            m_importTable.Columns.Add("Memo", typeof(string));

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
                            if (!IsHeadLine(_columns))
                            {
                                var _hadOneEx = false;
                                var _newRow = m_importTable.NewRow();

                                for (var _colIndex = 0; _colIndex < _impCols.Count; _colIndex++)
                                {
                                    try
                                    {
                                        if (_columns[_colIndex] != null && !string.IsNullOrEmpty(_columns[_colIndex].Trim()))
                                        {
                                            var _dataCol = m_importTable.Columns[_impCols[_colIndex]];

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
                                    m_importTable.Rows.Add(_newRow);
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

            return m_importTable.Rows.Count > 0;
        }
        private bool ReadPositionXml(string filePath)
        {
            m_importTable.TableName = "Positions";
            m_importTable.Columns.Add("SupplierId", typeof(string));
            m_importTable.Columns.Add("PositionNo", typeof(int));
            m_importTable.Columns.Add("Material", typeof(string));
            m_importTable.Columns.Add("Category", typeof(string));
            m_importTable.Columns.Add("Manufacturer", typeof(string));
            m_importTable.Columns.Add("PriceMin", typeof(double));
            m_importTable.Columns.Add("PriceMax", typeof(double));
            m_importTable.Columns.Add("Memo", typeof(string));

            try
            {
                m_importTable.ReadXml(filePath);
            }
            catch(Exception _ex)
            {
                return false;
            }
            return m_importTable.Rows.Count > 0;
        }
        private void ImportLineToSupplier(PositionLvi line)
        {
            if (line == null)
                return;

            try
            {
                var _newPosition = line.DataObj;
                _newPosition.SupplierId = m_supplier.SupplierId;

                if (GParams.Instance.BasarCom.PositionGet(_newPosition.PositionNo, true) == null)
                {
                    var _created = false;
                    var _createdSpec = false;

                    GParams.Instance.BasarCom.PositionCreate(_newPosition, out _created, out _createdSpec);

                    if (_created && _createdSpec)
                    {
                        m_lbErrorMsg.Text = @"Position angenommen...";
                        m_lbErrorMsg.BackColor = Color.FromArgb(255, 100, 255, 100);

                        m_globalList.Remove(line);
                        PlayConfirmedSound();
                    }
                    else
                    {
                        m_lbErrorMsg.Text = @"Positionsnummer existiert bereits!";
                        m_lbErrorMsg.BackColor = Color.FromArgb(255, 100, 255, 100);

                        m_globalList.Remove(line);
                        PlayBadSound();
                    }
                }
                else
                {
                    m_lbErrorMsg.Text = @"Positionsnummer existiert bereits!";
                    m_lbErrorMsg.BackColor = Color.FromArgb(255, 255, 100, 100);

                    m_globalList.Remove(line);
                    PlayBadSound();
                }
            }
            catch(Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }

            dvTextBox1.Focus();
            dvTextBox1.SelectAll();
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

        private void OnSyncListWithDbBtnClick(object sender, EventArgs e)
        {
            m_globalList = m_globalList
                .Where(p => GParams.Instance.BasarCom.PositionGet(p.DataObj.PositionNo, true) == null)
                .ToList();

            dvTextBox1_TextChanged(sender, e);
        }
    }
}
