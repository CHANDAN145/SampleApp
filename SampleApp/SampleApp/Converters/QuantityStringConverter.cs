using System;
using System.Globalization;
using Humanizer;
using Xamarin.Forms;

namespace SampleApp.Converters
{
    public class QuantityStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int valueInt && parameter is string parameterString)
            {
                var humanizedString = parameterString.ToQuantity(valueInt);
                return humanizedString;
            }

            if (value is string valueString && parameter is string parameterStrings)
            {
                int.TryParse(valueString, out int valueInts);
                var humanizedString = parameterStrings.ToQuantity(valueInts);
                return humanizedString;
            }

            if (value is TimeSpan valueTimeSpan && parameter is string parameterStringTime)
            {
                if (string.Equals(parameterStringTime, "Time"))
                {
                    var humanizedString = TimeSpan.FromMinutes(valueTimeSpan.TotalMinutes).Humanize(2);
                    return humanizedString;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
