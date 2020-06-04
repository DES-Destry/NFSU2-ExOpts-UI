using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace NFSU2_ExOpts.Controls
{
    public partial class CheckBoxSlot : UserControl
    {
        public string SlotImageSource
        {
            get { return (string)GetValue(SlotImageSourceProperty); }
            set { SetValue(SlotImageSourceProperty, value); }
        }

        public static readonly DependencyProperty SlotImageSourceProperty =
            DependencyProperty.Register("SlotImageSource", typeof(string), typeof(CheckBoxSlot), new PropertyMetadata(string.Empty));




        public string SlotInfoGif
        {
            get { return (string)GetValue(SlotInfoGifProperty); }
            set { SetValue(SlotInfoGifProperty, value); }
        }

        public static readonly DependencyProperty SlotInfoGifProperty =
            DependencyProperty.Register("SlotInfoGif", typeof(string), typeof(CheckBoxSlot), new PropertyMetadata(string.Empty));




        public string SlotHeader
        {
            get { return (string)GetValue(SlotHeaderProperty); }
            set { SetValue(SlotHeaderProperty, value); }
        }

        public static readonly DependencyProperty SlotHeaderProperty =
            DependencyProperty.Register("SlotHeader", typeof(string), typeof(CheckBoxSlot), new PropertyMetadata(string.Empty));




        public string SlotInfo
        {
            get { return (string)GetValue(SlotInfoProperty); }
            set { SetValue(SlotInfoProperty, value); }
        }

        public static readonly DependencyProperty SlotInfoProperty =
            DependencyProperty.Register("SlotInfo", typeof(string), typeof(CheckBoxSlot), new PropertyMetadata(string.Empty));




        public bool SlotIsChecked
        {
            get { return (bool)GetValue(SlotIsCheckedProperty); }
            set { SetValue(SlotIsCheckedProperty, value); }
        }

        public static readonly DependencyProperty SlotIsCheckedProperty =
            DependencyProperty.Register("SlotIsChecked", typeof(bool), typeof(CheckBoxSlot), new PropertyMetadata(false));




        public CheckBoxSlot()
        {
            InitializeComponent();
            this.Height = 64;
        }

        private void ShowInfoButton_Click(object sender, RoutedEventArgs e)
        {
            CircleEase circleEase = new CircleEase();
            circleEase.EasingMode = EasingMode.EaseIn;

            var animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromSeconds(0.8);
            animation.EasingFunction = circleEase;
            animation.From = this.Height;

            if ((string)ShowInfoButton.Content == "  What is it?  ")
            {
                ShowInfoButton.Content = "  Hide  ";
                animation.To = 160;
            }
            else
            {
                ShowInfoButton.Content = "  What is it?  ";
                animation.To = 64;
            }

            this.BeginAnimation(HeightProperty, animation);
        }

        private void SlotCheckBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SlotIsChecked = (bool)(sender as CheckBox).IsChecked;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e) => Draw();

        private void Draw()
        {
            this.SlotImage.Source = new BitmapImage(new Uri(SlotImageSource, UriKind.Relative));
            ImageBehavior.SetAnimatedSource(this.InfoGif, new BitmapImage(new Uri(SlotInfoGif, UriKind.Relative)));
            this.SlotName.Text = SlotHeader;
            this.TextInformation.Text = SlotInfo;
            this.SlotCheckBox.IsChecked = SlotIsChecked;
        }
    }
}
