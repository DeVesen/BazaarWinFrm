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
    public class BrandManagementPresenter : WindowPresenter
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
            this.m_brandItemLst.Add(new BrandItem()
            {
                Id = Guid.NewGuid(),
                Name = "K1"
            });

            this.m_brandItemLst.Add(new BrandItem()
            {
                Id = Guid.NewGuid(),
                Name = "K2"
            });

            this.m_brandItemLst.Add(new BrandItem()
            {
                Id = Guid.NewGuid(),
                Name = "k3"
            });
        }

        private void OnWndClosing()
        {

        }



        private string m_brandInput;
        public string BrandInput
        {
            get { return this.m_brandInput; }
            set
            {
                this.m_brandInput = value; 
                this.RaisePropertyChangedEvent();
            }
        }

        private BrandItem m_selectedItem;
        public BrandItem SelectedItem
        {
            get { return this.m_selectedItem; }
            set
            {
                this.m_selectedItem = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private readonly ObservableCollection<BrandItem> m_brandItemLst = new ObservableCollection<BrandItem>();
        public ObservableCollection<BrandItem> BrandItemLst
        {
            get { return this.m_brandItemLst; }
        }



        public ICommand BrandOnAdd { get { return new DelegateCommand(OnAddBrand); } }

        public ICommand BrandOnRemove { get { return new DelegateCommand(OnRemoveBrand); } }

        public ICommand BandItemSelectionChanged { get { return new RelayCommand(OnBandItemSelectionChanged); } }



        private void OnAddBrand()
        {
            var _item =
                this.m_brandItemLst.FirstOrDefault(
                    p => string.Compare(p.Name, this.BrandInput, StringComparison.OrdinalIgnoreCase) == 0);

            if (_item != null) return;

            this.m_brandItemLst.Add(new BrandItem()
            {
                Id = Guid.NewGuid(),
                Name = this.BrandInput
            });

            this.BrandInput = string.Empty;
        }

        private void OnRemoveBrand()
        {
            if (this.SelectedItem == null) return;

            if (!this.m_brandItemLst.Contains(this.SelectedItem)) return;

            this.m_brandItemLst.Remove(this.SelectedItem);

            this.BrandInput = string.Empty;
        }

        private void OnBandItemSelectionChanged(object args)
        {
            
        }
    }

    public class BrandItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
