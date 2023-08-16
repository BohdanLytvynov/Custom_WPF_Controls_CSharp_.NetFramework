using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace CustomControlsLibrary.WPFConverters
{
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime temp;

            if ((DateTime.TryParse(value.ToString(), out temp)))
                return temp.ToShortDateString();

            return DependencyProperty.UnsetValue;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime temp;

            if (DateTime.TryParse(value.ToString(), out temp))
                return temp;

            return DependencyProperty.UnsetValue;
        }
    }
}
