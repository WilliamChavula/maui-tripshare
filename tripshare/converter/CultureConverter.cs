using System.Globalization;

namespace tripshare.converter;

public class CultureConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var currencyCulture = new CultureInfo("en-US", false);
        var currency = double.Parse(value.ToString()!);
        return currency.ToString("C2", currencyCulture);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}