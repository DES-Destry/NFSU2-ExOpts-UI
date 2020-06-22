using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace NFSU2_ExOpts.Models
{
    public class BaseSlotsMethods
    {
        public static DoubleAnimation OpenCloseAnimations(Button button, UserControl slot)
        {
            if (button != null && slot != null)
            {
                CircleEase circleEase = new CircleEase();
                circleEase.EasingMode = EasingMode.EaseIn;

                var animation = new DoubleAnimation();
                animation.Duration = TimeSpan.FromSeconds(0.8);
                animation.EasingFunction = circleEase;
                animation.From = slot.Height;

                if ((string)button.Content == "  What is it?  ")
                {
                    button.Content = "  Hide  ";
                    animation.To = 160;
                }
                else
                {
                    button.Content = "  What is it?  ";
                    animation.To = 64;
                }

                return animation;
            }
            else
            {
                return new DoubleAnimation();
            }
        }

        public static void DrawBase(ISlot slot)
        {
            if (slot != null)
            {
                var image = new BitmapImage(new Uri(slot.SlotImageSource, UriKind.Relative));
                var gif = new BitmapImage(new Uri(slot.SlotInfoGif, UriKind.Relative));
                var header = slot.SlotHeader;
                var info = slot.SlotInfo;


                Type slotType = slot.GetType();

                var imageField = slotType.GetField("SlotImage", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(slot);
                imageField.GetType().GetProperty("Source", BindingFlags.Public | BindingFlags.Instance).SetValue(imageField, image);

                var gifField = slotType.GetField("InfoGif", BindingFlags.NonPublic | BindingFlags.Instance);
                ImageBehavior.SetAnimatedSource((Image)gifField.GetValue(slot), gif);

                var nameField = slotType.GetField("SlotName", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(slot);
                nameField.GetType().GetProperty("Text", BindingFlags.Public | BindingFlags.Instance).SetValue(nameField, header);

                var infoField = slotType.GetField("TextInformation", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(slot);
                infoField.GetType().GetProperty("Text", BindingFlags.Public | BindingFlags.Instance).SetValue(infoField, info);
            }
            else
            {
                return;
            }
        }
    }
}
