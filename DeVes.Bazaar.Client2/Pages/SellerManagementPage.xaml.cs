using DeVes.Extension.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeVes.Bazaar.Client2.Pages
{
    /// <summary>
    /// Interaction logic for SellerManagementPage.xaml
    /// </summary>
    public partial class SellerManagementPage : IPageContainerClient
    {
        public SellerManagementPage()
        {
            InitializeComponent();
        }

        public void PostConstruct(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
