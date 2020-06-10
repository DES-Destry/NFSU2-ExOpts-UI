using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class OpponentsControllersPage : Page
    {
        public OpponentsControllersPage()
        {
            InitializeComponent();
            DataContext = new OpponentsControllersPageViewModel();
        }
    }
}
