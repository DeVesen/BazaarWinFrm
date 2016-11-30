using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;

namespace DeVes.Bazaar.Client.MdiForms.ScreenLists
{
    public partial class ZusammenfassungScreenListForm : BaseScreenListForm
    {
        private ListViewGroup m_notSoldItemsGroup = null;
        private ListViewGroup m_soldItemsGroup = null;
        private ListViewGroup m_summeryGroup = null;

        private double m_soldProceSum = 0.0;

        public ZusammenfassungScreenListForm()
        {
            InitializeComponent();

            this.m_notSoldItemsGroup = this.m_screenLv.Groups.Add("notSoldItemsGroup", "Nicht verkauft:");
            this.m_soldItemsGroup = this.m_screenLv.Groups.Add("soldItemsGroup", "Verkauft:");
            this.m_summeryGroup = this.m_screenLv.Groups.Add("summery", "Zusammengefasst:");
        }

        private void ZusammenfassungScreenListForm_Load(object sender, EventArgs e)
        {

        }

        private void AddSupplierResult(AllPositionResult supplierInfo)
        {
            if (supplierInfo.Positions != null && supplierInfo.Positions.Length > 0)
            {
                foreach (BizPosition _position in supplierInfo.Positions)
                {
                    this.AddListViewLine(supplierInfo.Supplier, _position);
                }
            }
        }
        private void AddListViewLine(BizSupplierer supplier, BizPosition position)
        {
            ListViewItem _lvItem = new ListViewItem(position.PositionNo.ToString());
            _lvItem.SubItems.Add(position.Material);
            _lvItem.SubItems.Add(position.Category);
            _lvItem.SubItems.Add(position.Manufacturer);
            _lvItem.SubItems.Add(position.PriceMax.ToString() + " €");
            _lvItem.SubItems.Add(position.PriceMin.ToString() + " €");
            _lvItem.SubItems.Add(position.SoldFor.ToString() + " €");
            _lvItem.SubItems.Add(position.ReturnedToSupplierAt.ToString());

            if (position.SoldFor.HasValue)
            {
                _lvItem.Group = this.m_soldItemsGroup;
            }
            else
            {
                _lvItem.Group = this.m_notSoldItemsGroup;
            }

            if (position.SoldFor.HasValue)
            {
                this.m_soldProceSum += position.SoldFor.Value;
            }

            this.m_screenLv.Items.Add(_lvItem);
        }
        private void SetSummeryLine(string text, string priceValue)
        {
            ListViewItem _item001 = new ListViewItem("");
            _item001.SubItems.Add(text);
            _item001.SubItems.Add("");
            _item001.SubItems.Add("");
            _item001.SubItems.Add("");
            _item001.SubItems.Add("");
            _item001.SubItems.Add(priceValue + " €");

            _item001.BackColor = Color.AliceBlue;
            _item001.Group = this.m_summeryGroup;
            this.m_screenLv.Items.Add(_item001);
        }
        private void ClearList()
        {
            this.m_notSoldItemsGroup.Items.Clear();
            this.m_soldItemsGroup.Items.Clear();
            this.m_screenLv.Items.Clear();
        }

        public override void RefreshList()
        {
            this.ClearList();
            this.m_soldProceSum = 0.0;

            AllPositionResult[] _allPosResults = GParams.Instance.BasarCom.AllSupplierAndPositions();
            if (_allPosResults != null && _allPosResults.Length > 0)
            {
                foreach (AllPositionResult _info in _allPosResults)
                {
                    this.AddSupplierResult(_info);
                }

                if (this.m_notSoldItemsGroup.Items.Count > 0)
                {
                    this.m_notSoldItemsGroup.Header = string.Format("Nicht verkauft ({0}):", this.m_notSoldItemsGroup.Items.Count);
                }

                if (this.m_soldItemsGroup.Items.Count > 0)
                {
                    this.m_soldItemsGroup.Header = string.Format("Verkauft ({0}):", this.m_soldItemsGroup.Items.Count);
                }

                if (this.m_soldProceSum > 0)
                {
                    this.SetSummeryLine("Einnahmen:", this.m_soldProceSum.ToString());
                    this.SetSummeryLine("Eigenanteil:", (this.m_soldProceSum * GParams.Instance.SystemParameters.ProzSoldGewein / 100).ToString());
                }
            }
        }
    }
}
