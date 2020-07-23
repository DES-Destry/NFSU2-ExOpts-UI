using ExOpts_Installer.ViewModels;
using System.Windows.Controls;

namespace ExOpts_Installer.Pages
{
    public partial class UpdatesPage : Page
    {
        public UpdatesPage()
        {
            InitializeComponent();
            DataContext = new UpdatesViewModel();
        }
    }
}
