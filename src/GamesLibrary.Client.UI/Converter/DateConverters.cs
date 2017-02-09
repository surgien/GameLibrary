using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace GamesLibrary.Client.UI
{
    class ReleaseDayNumberDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is DateTime)
                {
                    var date = ((DateTime)value);
                    return date.Day.ToString() + "/" + date.Month.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to convert: " + ex);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
