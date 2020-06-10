using System.Collections.ObjectModel;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Controls
{
    public partial class SelectorSlot : UserControl, ISlot
    {
        public string SlotImageSource
        {
            get { return (string)GetValue(SlotImageSourceProperty); }
            set { SetValue(SlotImageSourceProperty, value); }
        }

        public static readonly DependencyProperty SlotImageSourceProperty =
            DependencyProperty.Register("SlotImageSource", typeof(string), typeof(SelectorSlot), new PropertyMetadata(string.Empty));




        public string SlotInfoGif
        {
            get { return (string)GetValue(SlotInfoGifProperty); }
            set { SetValue(SlotInfoGifProperty, value); }
        }

        public static readonly DependencyProperty SlotInfoGifProperty =
            DependencyProperty.Register("SlotInfoGif", typeof(string), typeof(SelectorSlot), new PropertyMetadata(string.Empty));




        public string SlotHeader
        {
            get { return (string)GetValue(SlotHeaderProperty); }
            set { SetValue(SlotHeaderProperty, value); }
        }

        public static readonly DependencyProperty SlotHeaderProperty =
            DependencyProperty.Register("SlotHeader", typeof(string), typeof(SelectorSlot), new PropertyMetadata(string.Empty));




        public string SlotInfo
        {
            get { return (string)GetValue(SlotInfoProperty); }
            set { SetValue(SlotInfoProperty, value); }
        }

        public static readonly DependencyProperty SlotInfoProperty =
            DependencyProperty.Register("SlotInfo", typeof(string), typeof(SelectorSlot), new PropertyMetadata(string.Empty));




        public ObservableCollection<string> ItemSource
        {
            get { return (ObservableCollection<string>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(ObservableCollection<string>), typeof(SelectorSlot), new FrameworkPropertyMetadata(new ObservableCollection<string>(),
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(Slot_ItemSourceChangedCallBack)));




        public int CurrentItem
        {
            get { return (int)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); }
        }

        public static readonly DependencyProperty CurrentItemProperty =
            DependencyProperty.Register("CurrentItem", typeof(int), typeof(SelectorSlot), new FrameworkPropertyMetadata(0,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(Slot_CurrentItemChangedCallBack)));




        public SelectorSlot()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            BaseSlotsMethods.DrawBase(this);
            SlotContent.ItemSource = ItemSource;
            SlotContent.CurrentItem = CurrentItem;
            SlotContent.CurrentItemChanged += SlotContent_CurrentItemChanged;
        }

        private void SlotContent_CurrentItemChanged(object sender)
        {
            CurrentItem = SlotContent.CurrentItem;
        }

        private static void Slot_CurrentItemChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as SelectorSlot).Grid_Loaded(sender, null);
        }

        private static void Slot_ItemSourceChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as SelectorSlot).Grid_Loaded(sender, null);
        }

        private void ShowInfoButton_Click(object sender, RoutedEventArgs e)
        {
            BeginAnimation(HeightProperty, BaseSlotsMethods.OpenCloseAnimations(sender as Button, this));
        }
    }
}
