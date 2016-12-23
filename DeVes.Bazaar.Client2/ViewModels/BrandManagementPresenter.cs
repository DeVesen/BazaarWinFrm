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
            this.OnRefreshManuf();
        }

        private void OnWndClosing()
        {

        }



        private readonly TextBoxPresenter m_categoryInput = new TextBoxPresenter();
        public TextBoxPresenter CategoryInput
        {
            get { return this.m_categoryInput; }
        }

        private BizMaterialCategory m_selectedItem;
        public BizMaterialCategory SelectedItem
        {
            get { return this.m_selectedItem; }
            set
            {
                this.m_selectedItem = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private readonly ObservableCollectionEx<BizMaterialCategory> m_categoryItemLst = new ObservableCollectionEx<BizMaterialCategory>();
        public ObservableCollectionEx<BizMaterialCategory> CategoryItemLst
        {
            get { return this.m_categoryItemLst; }
        }



        public ICommand CategoryOnAdd { get { return new DelegateCommand(OnAddCategory); } }

        public ICommand CategoryOnRemove { get { return new DelegateCommand(OnRemoveCategory); } }

        public ICommand CategoryItemSelectionChanged { get { return new RelayCommand(OnCategoryItemSelectionChanged); } }



        private bool DoSelectItem(string name)
        {
            var _element =
                this.CategoryItemLst.FirstOrDefault(
                    p => string.Compare(p.Designation, name, StringComparison.OrdinalIgnoreCase) == 0);

            this.SelectedItem = _element;

            return (_element != null);
        }



        private void OnAddCategory()
        {
            if (this.DoSelectItem(this.CategoryInput.Text)) return;

            var _newItem = new BizMaterialCategory()
            {
                Id = Guid.NewGuid(),
                Designation = this.CategoryInput.Text
            };

            MaterialCategoryProxi.Instance.MaterialCategoryCreate(_newItem);
            this.OnRefreshManuf();

            this.DoSelectItem(_newItem.Designation);

            this.CategoryInput.ResetText();
            this.CategoryInput.SetFocus();
        }

        private void OnRefreshManuf()
        {
            var _serverList = MaterialCategoryProxi.Instance.MaterialCategoryGetAll();

            if (!_serverList.Any())
            {
                this.CategoryItemLst.Clear();
                return;
            }

            foreach (var _bizManufacturer in _serverList.Where(p => this.CategoryItemLst.All(z => z.Id != p.Id)))
            {
                this.CategoryItemLst.Add(_bizManufacturer);
            }

            foreach (var _bizManufacturer in this.CategoryItemLst.Where(p => _serverList.All(z => z.Id != p.Id)).ToArray())
            {
                this.CategoryItemLst.Remove(_bizManufacturer);
            }

            CategoryItemLst.Sort(p => p.Designation);
        }

        private void OnRemoveCategory()
        {
            if (this.SelectedItem == null) return;

            if (!this.CategoryItemLst.Contains(this.SelectedItem)) return;

            MaterialCategoryProxi.Instance.MaterialCategoryRemove(this.SelectedItem);

            this.OnRefreshManuf();

            this.CategoryInput.ResetText();
            this.CategoryInput.SetFocus();
        }

        private void OnCategoryItemSelectionChanged(object args)
        {
            if (this.SelectedItem != null)
                this.CategoryInput.ResetText();
        }
    }
}
