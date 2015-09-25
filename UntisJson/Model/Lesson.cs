using FileHelpers;

namespace UntisJson.Model
{
    [DelimitedRecord(";")]
    public class Lesson
    {
        public int Number;

        public int? WeeklyNumber;

        public int? WeeklyNumberClass;

        public int? WeeklyNumberTeacher;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string ClassName;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Teacher;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Subject;

        /**
         * We must read the whole rest - otherwise
         * the library will fail to read a row :/
         */
        [FieldArrayLength(0, 37)]
        public string[] UnusedFields;
    }
}
