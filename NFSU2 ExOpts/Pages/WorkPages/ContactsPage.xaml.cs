using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class ContactsPage : Page
    {
        public ContactsPage()
        {
            InitializeComponent();
            DataContext = new ContactsViewModel();
        }
    }
}
