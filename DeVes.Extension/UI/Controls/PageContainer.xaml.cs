using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DeVes.Extension.Common;

namespace DeVes.Extension.UI.Controls
{
    /// <summary>
    /// Interaction logic for PageContainer.xaml
    /// </summary>
    public partial class PageContainer
    {
        private Dictionary<string, IPageContainerClient> m_pages = new Dictionary<string, IPageContainerClient>();


        public IPageContainerClient this[string key]
        {
            get { return this.Get(key); }
            set { this.Set(key, value); }
        }


        public PageContainer()
        {
            InitializeComponent();
        }


        public void Set(string key, IPageContainerClient clientPage)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            var _page = clientPage as Page;
            if (_page == null) throw new Exception("'clientPage' is not based from 'System.Windows.Controls.Page'");

            lock (this.m_pages)
            {
                this.m_pages[key] = clientPage;

                _page.Width = this.ViewFrame.Width;
                _page.Height = this.ViewFrame.Height;
            }
        }

        public IPageContainerClient Get(string key)
        {
            lock (this.m_pages)
            {
                return this.m_pages[key];
            }
        }

        public bool Contains(string key)
        {
            lock (this.m_pages)
            {
                return this.m_pages.ContainsKey(key);
            }
        }

        public bool Contains(IPageContainerClient clientPage)
        {
            lock (this.m_pages)
            {
                return this.m_pages.ContainsValue(clientPage);
            }
        }

        public void Remove(string key)
        {
            if (DeVesValidator.IsNullState(key)) return;

            lock (this.m_pages)
            {
                if (this.m_pages.ContainsKey(key))
                {
                    this.m_pages.Remove(key);
                }
            }
        }

        public void Remove(IPageContainerClient clientPage)
        {
            if (DeVesValidator.IsNullState(clientPage)) return;

            lock (this.m_pages)
            {
                if (!this.m_pages.ContainsValue(clientPage)) return;

                var _pairs = this.m_pages.Where(p => Equals(p.Value, clientPage)).ToArray();

                if (!_pairs.Any()) return;

                foreach (var _pair in _pairs)
                    this.m_pages.Remove(_pair.Key);
            }
        }

        public void RemoveAll()
        {
            lock (this.m_pages)
            {
                this.m_pages.Clear();
            }
        }


        public void SetVisible(string key, object parameter = null)
        {
            if (DeVesValidator.IsNullState(key)) return;

            lock (this.m_pages)
            {
                if (!this.m_pages.ContainsKey(key)) return;
                if (Equals(this.ViewFrame.Content, this.m_pages[key])) return;

                this.ViewFrame.Content = this.m_pages[key];

                this.m_pages[key].PostConstruct(parameter);
            }
        }

        public void ClearVisible()
        {
            lock (this.m_pages)
            {
                this.ViewFrame.Content = null;
            }
        }
    }


    public interface IPageContainerClient
    {
        void PostConstruct(object parameter);
    }
}
