using System.ComponentModel;
using System.Globalization;

namespace Test {
    internal class Program {
        static void Main(string[] args) {
            string? pointAsString = "100, 200";
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Point));
            if (pointAsString == null) return;
            Point? point = (Point?)converter.ConvertFromString(pointAsString);
            Console.WriteLine(point);

            Point point2 = new(40, 60);
            converter = TypeDescriptor.GetConverter(typeof(Point));
            pointAsString = converter.ConvertToString(point2);
            Console.WriteLine(pointAsString);
        }
    }

    [TypeConverter(typeof(PointTypeConverter))]
    public class Point {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public override string ToString() => $"{X}, {Y}";
    }

    public class PointTypeConverter : TypeConverter {
        // 문자열에서 Point로 변환 가능한지 체크.
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        // Point에서 다른 타입으로 변환 가능한지 체크.
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) {
            if (destinationType == typeof(string)) return true;
            return base.CanConvertTo(context, destinationType);
        }

        // 문자열에서 Point로 실제 변환 로직.
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) {
            if (value is string) {
                string[] v = ((string)value).Split(',');
                return new Point(int.Parse(v[0]), int.Parse(v[1]));
            }
            return base.ConvertFrom(context, culture, value);
        }

        // Point에서 문자열로 실제 변환 로직.
        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) {
            if (destinationType == typeof(string) && value is Point point) {
                return point.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

}