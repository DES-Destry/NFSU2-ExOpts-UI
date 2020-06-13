using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class MiscPage : Page
    {
        public MiscPage()
        {
            InitializeComponent();
            DataContext = new MiscPageViewModel();
        }
    }
}
