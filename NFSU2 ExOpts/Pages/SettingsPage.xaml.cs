using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            DataContext = new SettingsPageViewModel();
        }
    }
}
