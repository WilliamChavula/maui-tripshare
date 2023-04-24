using System;
using System.Globalization;

namespace tripshare.converter
{
    public class StringToLowerCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentTheme = Application.Current.RequestedTheme;

            if (currentTheme == AppTheme.Dark)
                return $"{value.ToString().ToLower()}_light.png";
            else
                return $"{value.ToString().ToLower()}_dark.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

