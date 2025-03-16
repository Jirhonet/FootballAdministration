using Microsoft.UI.Xaml.Data;
using System;

namespace FootballAdministration.Converters;

public class NullableIntConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is int intValue)
        {
            return (double)intValue;
        }
        return 0.0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is double doubleValue)
        {
            return doubleValue == 0.0 ? null : (int?)doubleValue;
        }
        return null;
    }
}