using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class LapsControllerPage : Page
    {
        public LapsControllerPage()
        {
            InitializeComponent();
            DataContext = new LapsControllerPageViewModel();
        }
    }
}
