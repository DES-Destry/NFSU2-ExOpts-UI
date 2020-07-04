using System.Windows;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Controls
{
    public partial class ErrorMessage : UserControl
    {
        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }

        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.Register("ErrorText", typeof(string), typeof(ErrorMessage), new FrameworkPropertyMetadata(string.Empty));




        public ErrorMessage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = ErrorText;
        }
    }
}
