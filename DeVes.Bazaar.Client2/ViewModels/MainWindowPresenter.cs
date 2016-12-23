using System.Windows.Input;
using DeVes.Bazaar.Client2.Content;
using DeVes.Bazaar.Client2.Pages;
using DeVes.Extension.UI.Controls;
using DeVes.Extension.UI.WPF;

namespace DeVes.Bazaar.Client2.ViewModels
{
    public class MainWindowPresenter : WindowPresenter
    {
        public ICommand WndLoad
        {
            get { return new DelegateCommand(OnWndLoad); }
        }

        public ICommand WndClosing
        {
            get { return new DelegateCommand(OnWndClosing); }
        }


        public ICommand SearchMaterial
        {
            get { return new DelegateCommand(OnSearchMaterial); }
        }

        public ICommand MaterialManagement
        {
            get { return new DelegateCommand(OnMaterialManagement); }
        }

        public ICommand Selling
        {
            get { return new DelegateCommand(OnSelling); }
        }

        public ICommand ReturnToSeller
        {
            get { return new DelegateCommand(OnReturnToSeller); }
        }


        public ICommand SellerManagement
        {
            get { return new DelegateCommand(OnSellerManagement); }
        }

        public ICommand BrandManagement
        {
            get { return new DelegateCommand(OnBrandManagement); }
        }

        public ICommand ManufacturerManagement
        {
            get { return new DelegateCommand(OnManufacturerManagement); }
        }


        public PageContainer PageContainerCtrl { get; set; }



        private void OnWndLoad()
        {
            MaterialCategoryProxi.Inistialize();
            MaterialManufacturerProxi.Inistialize();
        }

        private void OnWndClosing()
        {

        }



        private void OnSearchMaterial()
        {
            
        }

        private void OnMaterialManagement()
        {
            if (!this.PageContainerCtrl.Contains("MaterialManagePage"))
                this.PageContainerCtrl.Set("MaterialManagePage", new MaterialManagementPage());

            this.PageContainerCtrl.SetVisible("MaterialManagePage");
        }

        private void OnSelling()
        {
            if (!this.PageContainerCtrl.Contains("SellingPage"))
                this.PageContainerCtrl.Set("SellingPage", new SellingPage());

            this.PageContainerCtrl.SetVisible("SellingPage");
        }

        private void OnReturnToSeller()
        {
            if (!this.PageContainerCtrl.Contains("ReturnToSellerPage"))
                this.PageContainerCtrl.Set("ReturnToSellerPage", new ReturnToSellerPage());

            this.PageContainerCtrl.SetVisible("ReturnToSellerPage");
        }



        private void OnSellerManagement()
        {
            if (!this.PageContainerCtrl.Contains("SellerManagePage"))
                this.PageContainerCtrl.Set("SellerManagePage", new SellerManagementPage());

            this.PageContainerCtrl.SetVisible("SellerManagePage");
        }

        private void OnBrandManagement()
        {
            if (!this.PageContainerCtrl.Contains("BrandManagePage"))
                this.PageContainerCtrl.Set("BrandManagePage", new BrandManagementPage());

            this.PageContainerCtrl.SetVisible("BrandManagePage");
        }

        private void OnManufacturerManagement()
        {
            if (!this.PageContainerCtrl.Contains("ManufManagePage"))
                this.PageContainerCtrl.Set("ManufManagePage", new ManufacturerManagementPage());

            this.PageContainerCtrl.SetVisible("ManufManagePage");
        }
    }
}
