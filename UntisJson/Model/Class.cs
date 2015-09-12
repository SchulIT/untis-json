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

        /**
         * We must read the whole rest - otherwise
         * the library will fail to read a row :/
         */ 
        [FieldArrayLength(0, 39)]
        public string[] UnusedFields;
    }
}
