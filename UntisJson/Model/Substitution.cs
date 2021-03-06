﻿using FileHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UntisJson.Model
{
    [DelimitedRecord(";")]
    public class Substitution
    {
        public int? ID;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(Csv.DateTimeOffsetConverter))]
        [JsonConverter(typeof(Json.DateTimeOffsetConverter))]
        public DateTimeOffset? Date;

        public int? Lesson;

        [JsonIgnore]
        public int? AbsenceNumber;

        [JsonIgnore]
        public int? LessionNumber;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string AbsenceTeacher;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string ReplacementTeacher;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Subject;

        [JsonIgnore]
        public string StatisticsTagForSubject;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string ReplacementSubject;

        public string StatisticsTagForReplacementSubject;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Rooms;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string ReplacementRoom;

        [JsonIgnore]
        public string StatisticsTag;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(Csv.SeparatedValuesConverter))]
        public List<string> Classes;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string AbsenceReason;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Description;

        public int? Type;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(Csv.SeparatedValuesConverter))]
        public List<string> ReplacementClasses;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string ReplacementType;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(Csv.DateTimeOffsetConverter))]
        public DateTimeOffset? LastChange;

        [JsonIgnore]
        public string Footer;
    }
}
