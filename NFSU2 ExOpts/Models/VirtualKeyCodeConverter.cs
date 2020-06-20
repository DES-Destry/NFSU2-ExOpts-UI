using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace NFSU2_ExOpts.Models
{
    [ValueConversion(typeof(string), typeof(string))]
    class VirtualKeyCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "NULL";

            if (int.TryParse(value.ToString(), out int code))
            {
                var key = KeyInterop.KeyFromVirtualKey(code);
                return key.ToString();
            }
            else return "NULL";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
