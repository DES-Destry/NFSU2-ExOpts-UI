using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class SettingsPresetsPage : Page
    {
        public SettingsPresetsPage()
        {
            InitializeComponent();
            DataContext = new SettingsPresetsPageViewModel();
        }
    }
}
