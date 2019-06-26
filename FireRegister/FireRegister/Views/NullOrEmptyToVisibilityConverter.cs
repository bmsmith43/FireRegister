using System;
using System.Globalization;
using Xamarin.Forms;

namespace FireRegister.Views
{
   public class NullOrEmptyToVisibilityConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return (value is string stringValue) && !string.IsNullOrEmpty(stringValue);
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return null;
      }
   }
}
