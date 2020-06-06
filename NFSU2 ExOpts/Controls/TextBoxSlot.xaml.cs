using System.Windows;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Controls
{
    public partial class TextBoxSlot : UserControl, ISlot
    {
        public string SlotImageSource
        {
            get { return (string)GetValue(SlotImageSourceProperty); }
            set { SetValue(SlotImageSourceProperty, value); }
        }

        public static readonly DependencyProperty SlotImageSourceProperty =
            DependencyProperty.Register("SlotImageSource", typeof(string), typeof(TextBoxSlot), new PropertyMetadata(string.Empty));




        public string SlotInfoGif
        {
            get { return (string)GetValue(SlotInfoGifProperty); }
            set { SetValue(SlotInfoGifProperty, value); }
        }

        public static readonly DependencyProperty SlotInfoGifProperty =
            DependencyProperty.Register("SlotInfoGif", typeof(string), typeof(TextBoxSlot), new PropertyMetadata(string.Empty));




        public string SlotHeader
        {
            get { return (string)GetValue(SlotHeaderProperty); }
            set { SetValue(SlotHeaderProperty, value); }
        }

        public static readonly DependencyProperty SlotHeaderProperty =
            DependencyProperty.Register("SlotHeader", typeof(string), typeof(TextBoxSlot), new PropertyMetadata(string.Empty));




        public string SlotInfo
        {
            get { return (string)GetValue(SlotInfoProperty); }
            set { SetValue(SlotInfoProperty, value); }
        }

        public static readonly DependencyProperty SlotInfoProperty =
            DependencyProperty.Register("SlotInfo", typeof(string), typeof(TextBoxSlot), new PropertyMetadata(string.Empty));




        public string SlotTextContent
        {
            get { return (string)GetValue(SlotTextContentProperty); }
            set { SetValue(SlotTextContentProperty, value); }
        }

        public static readonly DependencyProperty SlotTextContentProperty =
            DependencyProperty.Register("SlotTextContent", typeof(string), typeof(TextBoxSlot), new PropertyMetadata(string.Empty));




        public TextBoxSlot()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            BaseSlotsMethods.DrawBase(this);
            SlotContent.Text = SlotTextContent;
        }

        private void ShowInfoButton_Click(object sender, RoutedEventArgs e)
        {
            BeginAnimation(HeightProperty, BaseSlotsMethods.OpenCloseAnimations(sender as Button, this));
        }

        private void SlotContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            SlotTextContent = (sender as TextBox).Text;
        }
    }
}
