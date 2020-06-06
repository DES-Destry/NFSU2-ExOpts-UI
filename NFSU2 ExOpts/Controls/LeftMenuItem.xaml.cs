using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NFSU2_ExOpts.Controls
{
    public partial class LeftMenuItem : UserControl
    {
        public string ItemHeaderText
        {
            get { return (string)GetValue(ItemHeaderTextProperty); }
            set { SetValue(ItemHeaderTextProperty, value); }
        }

        public static readonly DependencyProperty ItemHeaderTextProperty =
            DependencyProperty.Register("ItemHeaderText", typeof(string), typeof(LeftMenuItem), new PropertyMetadata(string.Empty));




        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(LeftMenuItem), new PropertyMetadata(string.Empty));


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(LeftMenuItem), new PropertyMetadata(null));




        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); Draw(); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(LeftMenuItem), new PropertyMetadata(false));




        public LeftMenuItem()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Draw();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Command?.Execute(sender);
        }

        private void Draw()
        {
            if (IsSelected)
            {
                ImageBorder.Opacity = 1;
                ItemHeader.Foreground = (Brush)Application.Current.FindResource("WhiteBrush");
            }
            else
            {
                ImageBorder.Opacity = 0;
                ItemHeader.Foreground = (Brush)Application.Current.FindResource("TextBoxDisabledBrush");
            }

            ItemHeader.Text = ItemHeaderText;
            ItemImage.Source = new BitmapImage(new Uri(ImageSource, UriKind.Relative));
        }
    }
}
