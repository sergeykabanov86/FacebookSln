using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace FacebookMySDKCore.Infrastructure.Converters
{
    internal abstract class MultiConverterBase : System.Windows.Data.IMultiValueConverter
    {
        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Действие не поддерживается");
        }
    }
}
