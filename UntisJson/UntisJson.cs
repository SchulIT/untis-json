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

        public static IEnumerable<Exam> ParseExam(string csvExams, string csvClasses)
        {
            var engine = new FileHelperEngine(typeof(Exam));

            var result = engine.ReadString(csvExams) as Exam[];

            engine = new FileHelperEngine(typeof(Class));
            var classes = engine.ReadString(csvClasses) as Class[];

            foreach(var exam in result)
            {
                var _classes = classes.Where(x => x.Number.ToString() == exam.CourseId);
                
                if(_classes.Any())
                {
                    exam.Classes = _classes.Select(x => x.ClassName).Distinct().ToArray();
                }
            }

            return result.AsEnumerable();
        }

        public static string ParseExamAsJson(string csvExams, string csvClasses, bool minify)
        {
            var exams = ParseExam(csvExams, csvClasses);

            var formatting = Formatting.None;

            if (!minify)
            {
                formatting = Formatting.Indented;
            }

            return JsonConvert.SerializeObject(exams, formatting);
        }
    }
}
