using FileHelpers;
using Newtonsoft.Json;
using System;
using UntisJson.Converter;

namespace UntisJson.Model
{
    [DelimitedRecord(";")]
    public class Exam
    {
        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Name;

        public int? ID;

        public string Description;

        [FieldConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset Date;

        public int LessonStart;

        public int LessonEnd;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Course;

        [JsonIgnore]
        public string CourseId;

        [JsonIgnore]
        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(SeparatedValuesConverter))]
        [FieldTrim(TrimMode.Both)]
        public string[] Students;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(SeparatedValuesConverter), '-', true)]
        public string[] Invigilators;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(SeparatedValuesConverter), '-', true)]
        public string[] Rooms;
    }
}
