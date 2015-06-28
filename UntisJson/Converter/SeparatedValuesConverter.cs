using FileHelpers;

namespace UntisJson.Converter
{
    public class SeparatedValuesConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            if (string.IsNullOrEmpty(from))
            {
                return null;
            }

            return from.Split('~');
        }
    }
}
