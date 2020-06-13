using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class FixesPage : Page
    {
        public FixesPage()
        {
            InitializeComponent();
            DataContext = new FixesPageViewModel();
        }
    }
}
