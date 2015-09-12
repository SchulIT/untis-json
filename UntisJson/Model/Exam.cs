using FileHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        [FieldConverter(typeof(SeparatedValuesConverter))]
        [FieldTrim(TrimMode.Both)]
        public List<string> Courses;

        [JsonIgnore]
        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string CourseId;

        [JsonIgnore]
        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(SeparatedValuesConverter))]
        [FieldTrim(TrimMode.Both)]
        public List<string> Students;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(SeparatedValuesConverter), '-', true)]
        public List<string> Invigilators;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(SeparatedValuesConverter), '-', true)]
        public List<string> Rooms;

        [FieldHidden]
        public List<string> Classes;
    }
}
