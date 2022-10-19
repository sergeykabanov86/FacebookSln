using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using System.Linq;

namespace FacebookMySDKCore.Infrastructure.Common
{
    [System.Windows.Markup.MarkupExtensionReturnType(typeof(int[]))]
    internal class StringToIntArray : System.Windows.Markup.MarkupExtension
    {
        [ConstructorArgument("Str")]
        public string Str { get; set; }

        [ConstructorArgument("Separator")]
        public char Separator { get; set; } = ';';

        public StringToIntArray()
        {

        }

        public StringToIntArray(string s) => this.Str = s;

        public StringToIntArray(string s, char separator) : this(s)
        {
            Separator = separator;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Str)) return null;

            return Str.Split(new char[] { Separator })
                      .Select(i => int.Parse(i))
                      .ToArray();
        }
    }
}
