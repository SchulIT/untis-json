using FileHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UntisJson.Model
{
    [DelimitedRecord(";")]
    public class Exam
    {
        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Name;

        public int? ID;

        public string Description;

        [FieldConverter(typeof(Csv.DateTimeOffsetConverter))]
        [JsonConverter(typeof(Json.DateTimeOffsetConverter))]
        public DateTimeOffset Date;

        public int LessonStart;

        public int LessonEnd;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(Csv.SeparatedValuesConverter))]
        [FieldTrim(TrimMode.Both)]
        public List<string> Courses;

        [JsonIgnore]
        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string CourseId;

        [JsonIgnore]
        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(Csv.SeparatedValuesConverter))]
        [FieldTrim(TrimMode.Both)]
        public List<string> Students;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(Csv.SeparatedValuesConverter), '-', true)]
        public List<string> Invigilators;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(Csv.SeparatedValuesConverter), '-', true)]
        public List<string> Rooms;

        [FieldHidden]
        public string Class;
    }
}
