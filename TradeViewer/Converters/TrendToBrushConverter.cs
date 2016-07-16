using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using TradeViewer.Core;

namespace TradeViewer.Converters
{
    public class TrendToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Trend trend = (Trend) value;

            switch (trend)
            {
                case Trend.Up:
                    return Brushes.Green;
                case Trend.Down:
                    return Brushes.Red;
                default:
                    return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}