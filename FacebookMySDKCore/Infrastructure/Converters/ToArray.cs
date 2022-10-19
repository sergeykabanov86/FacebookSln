using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FacebookMySDKCore.Infrastructure.Converters
{

    internal class ToArray : MultiConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var collection = new System.Windows.Data.CompositeCollection();

            foreach (var v in values)
                collection.Add(v);
            return collection;
        }

        //public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => value as object[];

    }
}
