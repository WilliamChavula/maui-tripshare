using System.Globalization;
using tripshare.helpers;

namespace tripshare.converter;

public class DateToPrettyDateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var notificationTime = ((DateTime)value).ToString();

        return notificationTime.Prettify();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

