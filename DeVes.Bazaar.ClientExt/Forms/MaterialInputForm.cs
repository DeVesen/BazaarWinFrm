using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DVes.Basar.Data.Biz;
using DVes.Barsar.ClientExt.CustControls;
using DVes.Basar.Data;

namespace DVes.Barsar.ClientExt.Forms
{
    public partial class MaterialInputForm : BaseToolForm
    {
        private Guid SupplierId
        {
            get
            {
                return Guid.Empty;
            }
        }
        private BizPosition ActualEditPosition
        {
            get
            {
                if (this.m_selPosSaveEditBtn.Tag is PositionLVI)
                {
                    return ((PositionLVI)this.m_selPosSaveEditBtn.Tag).DataObj;
                }
                return null;
            }
        }

        private List<Control> PosInputSeq
        {
            get
            {
                List<Control> _resList = new List<Control>();

                _resList.Add(this.m_posNrTb);
                _resList.Add(this.m_posTitelTb);

                _resList.Add(this.m_posCatCb);
                _resList.Add(this.m_herstellerCb);

                _resList.Add(this.m_posMaxPriceTb);
                _resList.Add(this.m_posMinPriceTb);

                return _resList;
            }
        }

        public MaterialInputForm()
        {
            InitializeComponent();
        }

        private void MaterialInputForm_Load(object sender, EventArgs e)
        {
            this.RefreshPositionList();
        }

        private void OnInputCtrlKeyUp(object sender, KeyEventArgs e)
        {
            Control _actual = sender as Control;
            if (_actual != null)
            {
                this.m_selPosSaveNewBtn.Enabled = this.ActualEditPosition == null && this.HasMinForNextPos();
                this.m_selPosSaveEditBtn.Enabled = this.ActualEditPosition != null && this.HasMinForNextPos();

                if (e.KeyCode == Keys.Return)
                {
                    int _currentIndex = this.PosInputSeq.IndexOf(_actual);

                    if (this.PosInputSeq.Count > _currentIndex + 1)
                    {
                        this.PosInputSeq[_currentIndex + 1].Focus();
                    }
                    else if (this.ActualEditPosition == null)
                    {
                        this.m_selPosSaveNewBtn_Click(sender, e);
                    }
                    else if (this.ActualEditPosition != null)
                    {
                        this.m_selPosSaveEditBtn_Click(sender, e);
                    }
                }
            }
        }
        private void OnInputCtrlSelChangeCommited(object sender, EventArgs e)
        {
            this.m_selPosSaveNewBtn.Enabled = this.ActualEditPosition == null && this.HasMinForNextPos();
            this.m_selPosSaveEditBtn.Enabled = this.ActualEditPosition != null && this.HasMinForNextPos();
        }



        private void m_clearPosCtrlsBtn_Click(object sender, EventArgs e)
        {
            foreach (Control _ctrl in this.PosInputSeq)
            {
                if (_ctrl is DVTextBox)
                {
                    ((DVTextBox)_ctrl).ResetText();
                }
                else if (_ctrl is DVComboBox)
                {
                    ((DVComboBox)_ctrl).SelectedIndex = -1;
                    ((DVComboBox)_ctrl).SelectedItem = null;
                }
            }

            this.m_posNrTb.ReadOnly = false;

            this.PosInputSeq[0].Focus();

            this.m_selPosSaveNewBtn.Enabled = false;
            this.m_selPosSaveEditBtn.Tag = null;
            this.m_selPosSaveEditBtn.Enabled = false;
            this.m_selPosRemoveBtn.Enabled = false;
            this.m_copyLineBtn.Enabled = false;
        }

        private void m_selPosSaveNewBtn_Click(object sender, EventArgs e)
        {
            if (!this.HasMinForNextPos())
            {
                return;
            }

            BizPosition _positionToChange = new BizPosition();
            this.ScreenToBiz(ref _positionToChange);

            try
            {
                if (GParams.Instance.Position.PositionGet(_positionToChange.PositionNo) == null)
                {
                    _positionToChange.SupplierId = this.SupplierId;
                    if (GParams.Instance.Position.PositionCreate(_positionToChange))
                    {
                        this.m_clearPosCtrlsBtn_Click(sender, e);

                        this.RefreshPositionList();
                    }
                    else
                    {
                        MessageBox.Show("Speichern der Position war nicht möglich!");
                    }
                }
                else
                {
                    MessageBox.Show("Position existiert bereits");
                    this.m_posNrTb.Focus();
                    this.m_posNrTb.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_selPosSaveEditBtn_Click(object sender, EventArgs e)
        {
            if (!this.HasMinForNextPos())
            {
                return;
            }

            BizPosition _positionToChange = this.ActualEditPosition;
            this.ScreenToBiz(ref _positionToChange);

            try
            {
                if (GParams.Instance.Position.PositionUpdate(_positionToChange))
                {
                    this.m_clearPosCtrlsBtn_Click(sender, e);

                    this.RefreshPositionList();
                }
                else
                {
                    MessageBox.Show("Speichern der Änderung war nicht möglich!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_copyLineBtn_Click(object sender, EventArgs e)
        {
            this.m_selPosSaveNewBtn.Enabled = false;
            this.m_selPosSaveEditBtn.Tag = null;
            this.m_selPosSaveEditBtn.Enabled = false;
            this.m_copyLineBtn.Enabled = false;
            this.m_selPosRemoveBtn.Enabled = false;

            this.m_posNrTb.ReadOnly = false;
            this.m_posNrTb.ResetText();
            this.m_posNrTb.Focus();
        }

        private void m_selPosRemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_matlPosLv.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Position(en) wirklich löschen?", "Löschen...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (ListViewItem _lvItem in this.m_matlPosLv.SelectedItems)
                        {
                            PositionLVI _toRemoveLine = _lvItem as PositionLVI;

                            if (_toRemoveLine != null)
                            {
                                GParams.Instance.Position.PositionRemove(_toRemoveLine.DataObj.PositionNo);
                            }
                        }

                        this.m_clearPosCtrlsBtn_Click(sender, e);

                        this.RefreshPositionList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_matlPosLv_Click(object sender, EventArgs e)
        {
            if (this.m_matlPosLv.SelectedItems.Count == 1 && this.m_matlPosLv.SelectedItems[0] is PositionLVI)
            {
                this.m_selPosSaveEditBtn.Tag = this.m_matlPosLv.SelectedItems[0] as PositionLVI;

                this.BizToScreen(this.ActualEditPosition);

                this.m_selPosSaveNewBtn.Enabled = false;

                this.m_selPosSaveEditBtn.Enabled = true;
                this.m_copyLineBtn.Enabled = true;
                this.m_selPosRemoveBtn.Enabled = true;

                this.m_posNrTb.ReadOnly = true;
                this.m_posTitelTb.Focus();
            }
            else
            {
                this.m_selPosSaveEditBtn.Tag = null;
                this.m_selPosSaveEditBtn.Enabled = false;
                this.m_copyLineBtn.Enabled = false;
                this.m_selPosRemoveBtn.Enabled = this.m_matlPosLv.SelectedItems.Count > 0;
                this.m_posNrTb.ReadOnly = false;

                if (this.m_matlPosLv.SelectedItems.Count > 0)
                {
                    foreach (Control _ctrl in this.PosInputSeq)
                    {
                        if (_ctrl is DVTextBox)
                        {
                            ((DVTextBox)_ctrl).ResetText();
                        }
                        else if (_ctrl is DVComboBox)
                        {
                            ((DVComboBox)_ctrl).SelectedIndex = -1;
                            ((DVComboBox)_ctrl).SelectedItem = null;
                        }
                    }
                }
            }
        }


        public void RefreshPositionList()
        {
            this.m_matlPosLv.Items.Clear();

            try
            {
                BizPosition[] _positionArray = GParams.Instance.Position.PositionGet(this.SupplierId);

                if (_positionArray != null && _positionArray.Length > 0)
                {
                    foreach (BizPosition _position in _positionArray)
                    {
                        this.m_matlPosLv.Items.Add(new PositionLVI(_position));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool HasMinForNextPos()
        {
            bool _result = true;

            foreach (Control _ctrl in this.PosInputSeq)
            {
                if (_ctrl is DVTextBox)
                {
                    _result = _result && (((DVTextBox)_ctrl).HasValueAndLikeWish || !((DVTextBox)_ctrl).IsMargin);
                }
                else if (_ctrl is DVComboBox)
                {
                    _result = _result && (((DVComboBox)_ctrl).SelectedItem != null || !((DVComboBox)_ctrl).IsMargin);
                }
            }

            return _result;
        }
        private void ScreenToBiz(ref BizPosition positionBiz)
        {
            positionBiz.PositionNo = GParams.ToInt32(this.m_posNrTb.Text).Value;
            positionBiz.Material = this.m_posTitelTb.Text;

            positionBiz.Category = this.m_posCatCb.Text;
            positionBiz.Manufacturer = this.m_herstellerCb.Text;

            positionBiz.PriceMax = GParams.ToDouble(this.m_posMaxPriceTb.Text).Value;
            positionBiz.PriceMin = GParams.ToDouble(this.m_posMinPriceTb.Text);

            positionBiz.Memo = this.m_posDescTb.Text;
        }
        private void BizToScreen(BizPosition positionBiz)
        {
            this.m_posNrTb.Text = positionBiz.PositionNo.ToString();
            this.m_posTitelTb.Text = positionBiz.Material;

            this.m_posCatCb.Text = positionBiz.Category;
            this.m_herstellerCb.Text = positionBiz.Manufacturer;

            this.m_posMaxPriceTb.Text = positionBiz.PriceMax.ToString();
            this.m_posMinPriceTb.Text = positionBiz.PriceMin.ToString();

            this.m_posDescTb.Text = positionBiz.Memo;
        }




        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            try
            {
                BizManufacturer[] _allManufs = GParams.Instance.MasterData.ManufacturerGetAll();
                if (_allManufs != null && _allManufs.Length > 0)
                {
                    foreach (BizManufacturer _manufItem in _allManufs)
                    {
                        this.m_herstellerCb.Items.Add(new DvComboBoxItem(null, _manufItem.Designation, _manufItem));
                    }
                }

                BizMaterialCategory[] _allCateg = GParams.Instance.MasterData.MaterialCategoryGetAll();
                if (_allCateg != null && _allCateg.Length > 0)
                {
                    foreach (BizMaterialCategory _categItem in _allCateg)
                    {
                        this.m_posCatCb.Items.Add(new DvComboBoxItem(null, _categItem.Designation, _categItem));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

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
}
