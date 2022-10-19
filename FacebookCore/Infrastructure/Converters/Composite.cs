using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace FacebookCore.Infrastructure.Converters
{
    internal class CompositeConverter : ConverterBase
    {
        [System.Windows.Markup.ConstructorArgument("First")]
        public IValueConverter First { get; set; }

        [System.Windows.Markup.ConstructorArgument("Second")]
        public IValueConverter Second { get; set; }



        #region Construtors
        public CompositeConverter() { }

        public CompositeConverter(IValueConverter first) => First = first;
        public CompositeConverter(IValueConverter first, IValueConverter second) : this(first) => Second = second;
        #endregion

        public override object Convert(object value, Type type, object par, CultureInfo c)
        {
            var result1 = First?.Convert(value, type, par, c) ?? value;
            var result2 = Second?.Convert(value, type, par, c) ?? result1;

            return result2;
        }

        public override object ConvertBack(object value, Type type, object par, CultureInfo c)
        {
            var result2 = Second?.ConvertBack(value, type, par, c) ?? value;
            var result1 = First?.ConvertBack(value, type, par, c) ?? result2;

            return result1;
        }
    }
}
