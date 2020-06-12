using System;
using System.Globalization;
using System.Windows.Data;

namespace NFSU2_ExOpts.Models
{
    [ValueConversion(typeof(string), typeof(bool))]
    class BinaryBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            if ((string)value == "0") return false;
            else if ((string)value == "1") return true;
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            if ((bool)value == false) return "0";
            else if ((bool)value == true) return "1";
            else return null;
        }
    }
}
