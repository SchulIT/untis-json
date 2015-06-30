using FileHelpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UntisJson.Model;

namespace UntisJson
{
    public static class UntisJson
    {
        public static IEnumerable<Substitution> ParseSubstitutions(string csv)
        {
            var engine = new FileHelperEngine(typeof(Substitution));

            var result = engine.ReadString(csv) as Substitution[];

            return result.AsEnumerable();
        }

        public static string ParseSubstitutionsAsJson(string csv, bool minify)
        {
            var substitutions = ParseSubstitutions(csv);

            var formatting = Formatting.None;

            if (!minify)
            {
                formatting = Formatting.Indented;
            }

            return JsonConvert.SerializeObject(substitutions, formatting);
        }

        public static IEnumerable<Exam> ParseExam(string csv)
        {
            var engine = new FileHelperEngine(typeof(Exam));

            var result = engine.ReadString(csv) as Exam[];

            return result.AsEnumerable();
        }

        public static string ParseExamAsJson(string csv, bool minify)
        {
            var exams = ParseExam(csv);

            var formatting = Formatting.None;

            if (!minify)
            {
                formatting = Formatting.Indented;
            }

            return JsonConvert.SerializeObject(exams, formatting);
        }
    }
}
