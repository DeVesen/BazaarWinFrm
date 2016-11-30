using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DVes.Basar.Client.MdiForms.ScreenLists;

namespace DVes.Basar.Client.MdiForms
{
    public class MdiClientManager
    {
        private Dictionary<MdiClients, Form> m_codeToStarted = new Dictionary<MdiClients, Form>();
        private Form m_parentMdiForm = null;

        public enum MdiClients
        {
            Manufacturer,
            Category,
            SupplierManage,
            MaterialInput,
            SearchMaterialInfo,
            Verkauf,
            ReturnToSupplier,
            ScreenList_Summery,
            Settings
        }

        public MdiClientManager(Form parentMdiform)
        {
            this.m_parentMdiForm = parentMdiform;
        }

        public void RunForm(string formCode)
        {
            try
            {
                this.RunForm((MdiClients)Enum.Parse(typeof(MdiClients), formCode));
            }
            catch
            {

            }
        }
        public void RunForm(MdiClients formCode)
        {
            if (this.m_codeToStarted.ContainsKey(formCode))
            {
                this.m_codeToStarted[formCode].BringToFront();
                this.m_codeToStarted[formCode].Focus();
            }
            else
            {
                BaseMdiForm _newForm = null;

                switch (formCode)
                {
                    case MdiClients.Manufacturer:
                        _newForm = new ManufacturerManageForm();
                        break;
                    case MdiClients.Category:
                        _newForm = new MaterialCategoryManageForm();
                        break;
                    case MdiClients.SupplierManage:
                        _newForm = new SupplierManageForm();
                        break;
                    case MdiClients.MaterialInput:
                        _newForm = new MaterialErfassungForm();
                        break;
                    case MdiClients.SearchMaterialInfo:
                        _newForm = new SearchMaterialInfo();
                        break;

                    case MdiClients.Verkauf:
                        _newForm = new MaterialVerkaufForm();
                        break;

                    case MdiClients.ReturnToSupplier:
                        _newForm = new ReturnToSupplier();
                        break;

                    case MdiClients.ScreenList_Summery:
                        _newForm = new ZusammenfassungScreenListForm();
                        break;

                    case MdiClients.Settings:
                        _newForm = new PropertyManageForm();
                        break;
                }

                if (_newForm != null)
                {
                    this.m_codeToStarted[formCode] = _newForm;

                    _newForm.MdiParent = this.m_parentMdiForm;
                    _newForm.WindowState = FormWindowState.Maximized;

                    _newForm.FormClosed += new FormClosedEventHandler(this.OnFormClosed);

                    _newForm.Show();
                }
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (MdiClients _code in this.m_codeToStarted.Keys)
            {
                if (this.m_codeToStarted[_code] == sender)
                {
                    this.m_codeToStarted.Remove(_code);
                    break;
                }
            }
        }
    }
}
