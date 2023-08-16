using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using static CustomControlsLibrary.Converters.ConvertorFunctions;

namespace CustomControlsLibrary.Converters
{
    public class StringToDateTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime res;

            if (DateTime.TryParse(value.ToString(), out res))
            {
                return $"{MonthToString(res.Month)} {res.Year}";
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
