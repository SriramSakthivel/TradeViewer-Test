using System;
using System.Globalization;
using System.Windows.Data;

namespace TradeViewer.Converters
{
    public class EmptyToZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal number = (decimal)value;
            return (number == 0M) ? string.Empty : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal number;
            decimal.TryParse(value.ToString(), out number);
            return number;
        }
    }
}