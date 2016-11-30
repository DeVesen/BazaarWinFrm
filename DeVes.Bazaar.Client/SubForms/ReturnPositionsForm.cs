using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;

namespace DeVes.Bazaar.Client.SubForms
{
    public partial class ReturnPositionsForm : BaseSubForm
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

        public ReturnPositionsForm()
        {
            InitializeComponent();
        }

        private void ImportPositionForm_Load(object sender, EventArgs e)
        {
            this.ReLoadhRestScreen(null);
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
                            this.ReturnLineToSupplier(this.m_matlPosLv.Items[0] as PositionLvi);
                            this.PlayGoodSound();
                            break;
                        }
                        else
                        {
                            this.PlayBadSound();
                        }
                    }
                }
                else if (this.m_matlPosLv.Items.Count == 1 && this.m_matlPosLv.Items[0] is PositionLvi)
                {
                    if (((PositionLvi)this.m_matlPosLv.Items[0]).DataObj.PositionNo == this.dvTextBox1.IntValue)
                    {
                        this.ReturnLineToSupplier(this.m_matlPosLv.Items[0] as PositionLvi);
                        this.PlayGoodSound();
                    }
                    else
                    {
                        this.PlayBadSound();
                    }
                }
                else
                {
                    this.PlayBadSound();
                }

                this.dvTextBox1.Focus();
                this.dvTextBox1.SelectAll();
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
                this.ReturnLineToSupplier(this.m_matlPosLv.SelectedItems[0] as PositionLvi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void m_confirmAllBtn_Click(object sender, EventArgs e)
        {
            foreach (var _lvItem in this.m_globalList)
            {
                try
                {
                    var _posToReturn = GParams.Instance.BasarCom.PositionGet(_lvItem.DataObj.PositionNo, true);
                    if (_posToReturn != null)
                    {
                        if (_posToReturn.ReturnedToSupplierAt.HasValue && _posToReturn.ReturnedToSupplierAtSpecified)
                        {
                            //MessageBox.Show("Positionsnummer wurde verkauft!");
                        }
                        else
                        {
                            _posToReturn.ReturnedToSupplierAt = DateTime.Now;

                            var _updateDone = false;
                            var _updateDoneSpec = false;

                            GParams.Instance.BasarCom.PositionUpdate(_posToReturn, out _updateDone, out _updateDoneSpec);

                            bool _v1 = false, _v2 = false;
                            GParams.Instance.BasarCom.SetSupplierToReturned(_posToReturn.SupplierId, true, true, out _v1, out _v2);

                            if (!(_updateDone && _updateDoneSpec))
                            {
                                //MessageBox.Show("Fehler beim eintragen der Rückgabe...");
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Positionsnummer existiert nicht!");
                    }
                }
                catch (Exception _ex)
                {
                    MessageBox.Show(_ex.Message);
                }
            }

            if (this.ReLoadhRestScreen(null) > 0)
            {
                this.dvTextBox1.ResetText();
                this.dvTextBox1.Focus();
            }
            else
            {
                this.Close();
            }
        }



        private int ReLoadhRestScreen(BizPosition[] positions)
        {
            if (positions == null)
            {
                positions = GParams.Instance.BasarCom.GetNotSoldNotReturnedPositions(this.m_supplier.SupplierID);
            }
            else if (positions.Length <= 0)
            {
                positions = GParams.Instance.BasarCom.GetNotSoldNotReturnedPositions(this.m_supplier.SupplierID);
            }

            this.m_globalList.Clear();
            this.m_matlPosLv.Items.Clear();

            if (positions != null && positions.Length > 0)
            {
                foreach (var _position in positions)
                {
                    this.m_globalList.Add(new PositionLvi(_position));
                    this.m_matlPosLv.Items.Add(new PositionLvi(_position));
                }
            }

            return (positions != null) ? positions.Length : 0;
        }
        private void ReturnLineToSupplier(PositionLvi line)
        {
            if (line == null)
                return;

            try
            {
                var _newPosition = line.DataObj;
                _newPosition.SupplierId = this.m_supplier.SupplierID;

                var _posToReturn = GParams.Instance.BasarCom.PositionGet(_newPosition.PositionNo, true);
                if (_posToReturn != null)
                {
                    if (_posToReturn.ReturnedToSupplierAt.HasValue && _posToReturn.ReturnedToSupplierAtSpecified)
                    {
                        MessageBox.Show("Positionsnummer wurde verkauft!");
                    }
                    else
                    {
                        _posToReturn.ReturnedToSupplierAt = DateTime.Now;

                        var _updateDone = false;
                        var _updateDoneSpec = false;

                        GParams.Instance.BasarCom.PositionUpdate(_posToReturn, out _updateDone, out _updateDoneSpec);

                        bool _v1 = false, _v2 = false;
                        GParams.Instance.BasarCom.SetSupplierToReturned(_posToReturn.SupplierId, true, true, out _v1, out _v2);

                        if (!(_updateDone && _updateDoneSpec))
                        {
                            MessageBox.Show("Fehler beim eintragen der Rückgabe...");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Positionsnummer existiert nicht!");
                }
            }
            catch(Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }

            if (this.ReLoadhRestScreen(null) > 0)
            {
                this.dvTextBox1.ResetText();
                this.dvTextBox1.Focus();
            }
            else
            {
                this.PlayConfirmedSound();
                System.Threading.Thread.Sleep(500);
                this.PlayConfirmedSound();
                this.Close();
            }
        }

        public static DialogResult HandleReturn(IWin32Window owner, BizSupplierer supplier, BizPosition[] positions)
        {
            var _frm = new ReturnPositionsForm();
            _frm.m_supplier = supplier;

            if (_frm.ReLoadhRestScreen(positions) > 0)
            {
                _frm.ShowDialog(owner);
                return DialogResult.OK;
            }
            return DialogResult.Abort;
        }
    }
}
