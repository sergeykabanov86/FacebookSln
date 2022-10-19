using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace FacebookCore.Infrastructure.Converters
{
    internal class RatioConverter : ConverterBase
    {
        [System.Windows.Markup.ConstructorArgument("K")]
        public double K { get; set; } = 1.0;





        public RatioConverter(double K) => this.K = K;

        public RatioConverter() { }

        public override object Convert(object value, Type type, object par, CultureInfo c)
        {
            if (value is null) return null;

            var d = System.Convert.ToDouble(value, c);

            return d * K;
        }

        public override object ConvertBack(object value, Type type, object par, CultureInfo c)
        {
            if (value is null) return null;
            if (string.IsNullOrEmpty(value as string)) return 0;

            var d = System.Convert.ToDouble(value, c);

            return d / K;
        }
    }
}
