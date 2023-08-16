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
    public class StringToDateTieMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string result;

            byte param = (byte)values[1];

            DateTime temp;

            if (DateTime.TryParse(values[0].ToString(), out temp))
            {
                switch (param)
                {
                    case 0:

                        return MonthToString(temp.Month) + $" {temp.Year}";
                    case 1:

                        return $"{temp.Year} year";

                    default:

                        return $"{values[2]} - {values[3]}";
                }
            }

            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
