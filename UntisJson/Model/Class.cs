using FileHelpers;

namespace UntisJson.Model
{
    [DelimitedRecord(";")]
    public class Class
    {
        public int Number;

        public int? WeeklyNumber;

        public int? WeeklyNumberClass;

        public int? WeeklyNumberTeacher;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string ClassName;
    }
}
