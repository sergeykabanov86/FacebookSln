using System;
using System.Globalization;


namespace FacebookMySDKCore.Infrastructure.Converters
{
    /// <summary>
    /// Раелизация линейного преобразования f(x) = k*x + b
    /// </summary>
    [System.Windows.Data.ValueConversion(typeof(double), typeof(double))]
    [System.Windows.Markup.MarkupExtensionReturnType(typeof(LinearConverter))]
    internal class LinearConverter : ConverterBase
    {
        [System.Windows.Markup.ConstructorArgument("K")]
        public double K { get; set; } = 1;

        [System.Windows.Markup.ConstructorArgument("B")]
        public double B { get; set; } = 0;


        #region Counstructors

        public LinearConverter()
        {

        }

        public LinearConverter(double K)
        {
            this.K = K;
        }

        public LinearConverter(double K, double B) : this(K)
        {
            this.B = B;
        }

        #endregion



        public override object Convert(object value, Type type, object par, CultureInfo c)
        {
            if (value is null) return null;

            var x = System.Convert.ToDouble(value, c);

            return K * x + B;
        }

        public override object ConvertBack(object value, Type type, object par, CultureInfo c)
        {
            if (value is null) return null;

            var y = System.Convert.ToDouble(value, c);

            return (y - B) / K;
        }



    }
}
