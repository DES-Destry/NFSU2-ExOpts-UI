using System.Windows;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Controls
{
    public partial class CheckBoxSlot : UserControl, ISlot
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
            DependencyProperty.Register("SlotIsChecked", typeof(bool), typeof(CheckBoxSlot), new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(Slot_IsSelectedChangedChangedCallBack)));




        public CheckBoxSlot()
        {
            InitializeComponent();
        }

        private void ShowInfoButton_Click(object sender, RoutedEventArgs e)
        {
            BeginAnimation(HeightProperty, BaseSlotsMethods.OpenCloseAnimations(sender as Button, this));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            BaseSlotsMethods.DrawBase(this);
            SlotCheckBox.IsChecked = SlotIsChecked;
        }

        private static void Slot_IsSelectedChangedChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as CheckBoxSlot).Grid_Loaded(sender, null);
        }

        private void SlotCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            SlotIsChecked = (bool)(sender as CheckBox).IsChecked;
        }
    }
}
