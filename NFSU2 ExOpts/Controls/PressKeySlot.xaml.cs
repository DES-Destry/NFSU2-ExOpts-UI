using NFSU2_ExOpts.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NFSU2_ExOpts.Controls
{
    public partial class PressKeySlot : UserControl, ISlot
    {
        public string SlotImageSource
        {
            get { return (string)GetValue(SlotImageSourceProperty); }
            set { SetValue(SlotImageSourceProperty, value); }
        }

        public static readonly DependencyProperty SlotImageSourceProperty =
            DependencyProperty.Register("SlotImageSource", typeof(string), typeof(PressKeySlot), new PropertyMetadata(string.Empty));




        public string SlotInfoGif
        {
            get { return (string)GetValue(SlotInfoGifProperty); }
            set { SetValue(SlotInfoGifProperty, value); }
        }

        public static readonly DependencyProperty SlotInfoGifProperty =
            DependencyProperty.Register("SlotInfoGif", typeof(string), typeof(PressKeySlot), new PropertyMetadata(string.Empty));




        public string SlotHeader
        {
            get { return (string)GetValue(SlotHeaderProperty); }
            set { SetValue(SlotHeaderProperty, value); }
        }

        public static readonly DependencyProperty SlotHeaderProperty =
            DependencyProperty.Register("SlotHeader", typeof(string), typeof(PressKeySlot), new PropertyMetadata(string.Empty));




        public string SlotInfo
        {
            get { return (string)GetValue(SlotInfoProperty); }
            set { SetValue(SlotInfoProperty, value); }
        }

        public static readonly DependencyProperty SlotInfoProperty =
            DependencyProperty.Register("SlotInfo", typeof(string), typeof(PressKeySlot), new PropertyMetadata(string.Empty));




        public string SlotTextContent
        {
            get { return (string)GetValue(SlotTextContentProperty); }
            set { SetValue(SlotTextContentProperty, value); SlotContent.Text = SlotTextContent; }
        }

        public static readonly DependencyProperty SlotTextContentProperty =
            DependencyProperty.Register("SlotTextContent", typeof(string), typeof(PressKeySlot), new FrameworkPropertyMetadata(string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(Slot_TextChangedChangedCallBack)));




        private PressKeyState state;


        public PressKeySlot()
        {
            InitializeComponent();
            state = PressKeyState.None;
        }

        private static void Slot_TextChangedChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PressKeySlot slot = sender as PressKeySlot;

            slot.Grid_Loaded(sender, null);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            BaseSlotsMethods.DrawBase(this);
            SlotContent.Text = SlotTextContent;
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            int vkey = 0;

            if (state == PressKeyState.WaitingKey)
            {
                vkey = KeyInterop.VirtualKeyFromKey(e.Key);
                SlotTextContent = vkey.ToString();

                state = PressKeyState.None;
                StateText.Visibility = Visibility.Collapsed;
            }
        }

        private void GetPressKeyButton_Click(object sender, RoutedEventArgs e)
        {
            state = PressKeyState.WaitingKey;
            StateText.Visibility = Visibility.Visible;
        }

        private void ShowInfoButton_Click(object sender, RoutedEventArgs e)
        {
            BeginAnimation(HeightProperty, BaseSlotsMethods.OpenCloseAnimations(sender as Button, this));
        }
    }
}
