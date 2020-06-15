using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            DataContext = new MenuPageViewModel();
        }
    }
}
