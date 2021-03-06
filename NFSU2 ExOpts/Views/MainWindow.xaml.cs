using DESTRY.IO.Debuging;
using NFSU2_ExOpts.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace NFSU2_ExOpts.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Logs.WriteLog("Application has been closed.", "INFO");
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
