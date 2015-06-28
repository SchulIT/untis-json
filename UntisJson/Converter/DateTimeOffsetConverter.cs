using FileHelpers;
using System;

namespace UntisJson.Converter
{
    public class DateTimeOffsetConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            var year = int.Parse(from.Substring(0, 4));
            var month = int.Parse(from.Substring(4, 2));
            var day = int.Parse(from.Substring(6, 2));

            var hour = 0;
            var minutes = 0;
            var seconds = 0;

            if (from.Length > 8)
            {
                hour = int.Parse(from.Substring(8, 2));
            }

            if (from.Length > 10)
            {
                minutes = int.Parse(from.Substring(10, 2));
            }

            if (from.Length > 12)
            {
                seconds = int.Parse(from.Substring(12, 2));
            }

            return new DateTimeOffset(year, month, day, hour, minutes, seconds, DateTimeOffset.Now.Offset);
        }
    }
}
