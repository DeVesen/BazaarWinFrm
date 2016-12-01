using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeVes.Extension.UI.Controls;
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
            this.m_manufacturerItemLst.Add(new ManufItem()
            {
                Id = Guid.NewGuid(),
                Name = "H1"
            });

            this.m_manufacturerItemLst.Add(new ManufItem()
            {
                Id = Guid.NewGuid(),
                Name = "H2"
            });

            this.m_manufacturerItemLst.Add(new ManufItem()
            {
                Id = Guid.NewGuid(),
                Name = "H3"
            });
        }

        private void OnWndClosing()
        {

        }



        private string m_manufacturerInput;
        public string ManufacturerInput
        {
            get { return this.m_manufacturerInput; }
            set
            {
                this.m_manufacturerInput = value; 
                this.RaisePropertyChangedEvent();
            }
        }

        private ManufItem m_selectedItem;
        public ManufItem SelectedItem
        {
            get { return this.m_selectedItem; }
            set
            {
                this.m_selectedItem = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private readonly ObservableCollection<ManufItem> m_manufacturerItemLst = new ObservableCollection<ManufItem>();
        public ObservableCollection<ManufItem> ManufacturerItemLst
        {
            get { return this.m_manufacturerItemLst; }
        }



        public ICommand ManufOnAdd { get { return new DelegateCommand(OnAddManuf); } }

        public ICommand ManufOnRemove { get { return new DelegateCommand(OnRemoveManuf); } }

        public ICommand ManufItemSelectionChanged { get { return new RelayCommand(OnManufItemSelectionChanged); } }



        private void OnAddManuf()
        {
            var _item =
                this.m_manufacturerItemLst.FirstOrDefault(
                    p => string.Compare(p.Name, this.ManufacturerInput, StringComparison.OrdinalIgnoreCase) == 0);

            if (_item != null) return;

            this.m_manufacturerItemLst.Add(new ManufItem()
            {
                Id = Guid.NewGuid(),
                Name = this.ManufacturerInput
            });

            this.ManufacturerInput = string.Empty;
        }

        private void OnRemoveManuf()
        {
            if (this.SelectedItem == null) return;

            if (!this.m_manufacturerItemLst.Contains(this.SelectedItem)) return;

            this.m_manufacturerItemLst.Remove(this.SelectedItem);

            this.ManufacturerInput = string.Empty;
        }

        private void OnManufItemSelectionChanged(object args)
        {
            
        }
    }

    public class ManufItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
