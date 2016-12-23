using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeVes.Bazaar.Client2.BasarComServiceReference;
using DeVes.Bazaar.Client2.Content;
using DeVes.Extension.UI.Controls;
using DeVes.Extension.UI.PresenterHelper;
using DeVes.Extension.UI.WPF;

namespace DeVes.Bazaar.Client2.ViewModels
{
    public class ManufacturerManagementPresenter : WindowPresenter
    {
        public ICommand WndLoad
        {
            get { return new DelegateCommand(OnWndLoad); }
        }

        public ICommand WndClosing
        {
            get { return new DelegateCommand(OnWndClosing); }
        }



        private void OnWndLoad()
        {
            this.OnRefreshManuf();
        }

        private void OnWndClosing()
        {

        }



        private readonly TextBoxPresenter m_manufacturerInput = new TextBoxPresenter();
        public TextBoxPresenter ManufacturerInput
        {
            get { return this.m_manufacturerInput; }
        }

        private BizManufacturer m_selectedItem;
        public BizManufacturer SelectedItem
        {
            get { return this.m_selectedItem; }
            set
            {
                this.m_selectedItem = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private readonly ObservableCollectionEx<BizManufacturer> m_manufacturerItemLst = new ObservableCollectionEx<BizManufacturer>();
        public ObservableCollectionEx<BizManufacturer> ManufacturerItemLst
        {
            get { return this.m_manufacturerItemLst; }
        }



        public ICommand ManufOnAdd { get { return new DelegateCommand(OnAddManuf); } }

        public ICommand ManufOnRemove { get { return new DelegateCommand(OnRemoveManuf); } }

        public ICommand ManufItemSelectionChanged { get { return new RelayCommand(OnManufItemSelectionChanged); } }



        private bool DoSelectItem(string name)
        {
            this.SelectedItem = this.ManufacturerItemLst.FirstOrDefault(p => string.Compare(p.Designation, name, StringComparison.OrdinalIgnoreCase) == 0);
            return this.SelectedItem != null;
        }



        private void OnAddManuf()
        {
            if (this.DoSelectItem(this.ManufacturerInput.Text)) return;

            var _newItem = new BizManufacturer()
            {
                Id = Guid.NewGuid(),
                Designation = this.ManufacturerInput.Text
            };

            MaterialManufacturerProxi.Instance.MaterialManufacturerCreate(_newItem);
            this.OnRefreshManuf();

            this.DoSelectItem(_newItem.Designation);

            this.ManufacturerInput.ResetText();
            this.ManufacturerInput.SetFocus();
        }

        private void OnRefreshManuf()
        {
            var _serverList = MaterialManufacturerProxi.Instance.MaterialManufacturerGetAll();

            if (!_serverList.Any())
            {
                this.ManufacturerItemLst.Clear();
                return;
            }

            foreach (var _bizManufacturer in _serverList.Where(p => this.ManufacturerItemLst.All(z => z.Id != p.Id)))
            {
                this.ManufacturerItemLst.Add(_bizManufacturer);
            }

            foreach (var _bizManufacturer in this.ManufacturerItemLst.Where(p => _serverList.All(z => z.Id != p.Id)).ToArray())
            {
                this.ManufacturerItemLst.Remove(_bizManufacturer);
            }

            ManufacturerItemLst.Sort(p => p.Designation);
        }

        private void OnRemoveManuf()
        {
            if (this.SelectedItem == null) return;

            if (!this.ManufacturerItemLst.Contains(this.SelectedItem)) return;

            MaterialManufacturerProxi.Instance.MaterialManufacturerRemove(this.SelectedItem);

            this.OnRefreshManuf();

            this.ManufacturerInput.ResetText();
            this.ManufacturerInput.SetFocus();
        }

        private void OnManufItemSelectionChanged(object args)
        {
            if (this.SelectedItem != null)
                this.ManufacturerInput.ResetText();
        }
    }
}
