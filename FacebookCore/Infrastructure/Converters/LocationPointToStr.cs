using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace FacebookCore.Infrastructure.Converters
{
    [ValueConversion(typeof(Point), typeof(string))]
    internal class LocationPointToStrConverter : ConverterBase
    {
        public override object Convert(object value, Type type, object par, CultureInfo c)
        {
            if (!(value is Point point)) return null;

            return $"Lat:{point.Y};Lon{point.X}";
        }

        public override object ConvertBack(object value, Type type, object par, CultureInfo c)
        {
            //throw new NotSupportedException();

            var str = value as string;

            var components = str.Split(";");
            var lat_str = components[0].Split(":")[1];
            var lon_str = components[1].Split(":")[1];

            return new Point(double.Parse(lon_str), double.Parse(lat_str));
        }
    }
}
