using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace FacebookCore.Infrastructure.Converters
{
    internal abstract class ConverterBase : System.Windows.Markup.MarkupExtension, IValueConverter
    {

        public override object ProvideValue(IServiceProvider sp) => this;



        public abstract object Convert(object value, Type type, object par, CultureInfo c);

        public virtual object ConvertBack(object value, Type type, object par, CultureInfo c)
        {
            throw new NotSupportedException("Обратное преобразование не поддерживается");
        }
    }
}
