using FileHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static string ParseSubstitutionsAsJson(string csv)
        {
            var substitutions = ParseSubstitutions(csv);

            return JsonConvert.SerializeObject(substitutions);
        }

        public static IEnumerable<Exam> ParseExam(string csv)
        {
            var engine = new FileHelperEngine(typeof(Exam));

            var result = engine.ReadString(csv) as Exam[];

            return result.AsEnumerable();
        }

        public static string ParseExamAsJson(string csv)
        {
            var exams = ParseExam(csv);

            return JsonConvert.SerializeObject(exams);
        }
    }
}
