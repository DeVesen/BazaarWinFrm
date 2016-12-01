using DeVes.Bazaar.Client2.ViewModels;
using DeVes.Extension.UI.WPF;

namespace DeVes.Bazaar.Client2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var _context = this.DataContext as WindowPresenter;
            if (_context != null)
                _context.Wnd = this;

            var _mainWindowPresenter = this.DataContext as MainWindowPresenter;
            if (_mainWindowPresenter != null)
                _mainWindowPresenter.PageContainerCtrl = this.PageCtrl;
        }
    }
}
