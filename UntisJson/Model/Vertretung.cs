using FileHelpers;
using Newtonsoft.Json;
using System;
using UntisJson.Converter;

namespace UntisJson.Model
{
    [DelimitedRecord(";")]
    public class Vertretung
    {
        public int? Vertretungsnummer;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset? Datum;

        public int? Stunde;

        public int? Absenznummer;

        [JsonProperty("unterrichtsnummer")]
        public int? Unterrichtsnummer;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string AbsenterLehrer;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string VertretenderLehrer;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Fach;

        public string StatistikKennzeichenFach;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Vertretungsfach;

        public string StatistikKennzeichenVertretungsfach;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Raum;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Vertretungsraum;

        public string StatistikKennzeichen;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(SeparatedValuesConverter))]
        public string[] Klassen;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Absenzgrund;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Text;

        public int? Art;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(SeparatedValuesConverter))]
        public string[] Vertretungsklassen;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        public string Vertretungsart;

        [FieldQuoted('"', QuoteMode.OptionalForRead)]
        [FieldConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset? LetzteAenderung;

        [JsonIgnore]
        public string Footer;
    }
}
