using FileHelpers;
using Newtonsoft.Json;
using System;
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

        public static string ParseSubstitutionsAsJson(string csv, Options options)
        {
            var substitutions = ParseSubstitutions(csv);

            var formatting = Formatting.None;

            if (!options.MinifyJson)
            {
                formatting = Formatting.Indented;
            }

            if(options.ExcludeUntisIdZero)
            {
                substitutions = substitutions.Where(x => x.ID > 0);
            }

            if(options.DateThreshold.HasValue)
            {
                var threshold = options.DateThreshold.Value;
                substitutions = substitutions.Where(x => x.Date >= threshold);
            }

            return JsonConvert.SerializeObject(substitutions, formatting);
        }

        public static IEnumerable<Exam> ParseExam(string csvExams)
        {
            var engine = new FileHelperEngine(typeof(Exam));

            var result = engine.ReadString(csvExams) as Exam[];

            foreach(var exam in result)
            {
                exam.Class = GetClassFromName(exam.Name);
            }

            return result.AsEnumerable();
        }

        public static string ParseExamAsJson(string csvExams, Options options)
        {
            var exams = ParseExam(csvExams);

            var formatting = Formatting.None;

            if (!options.MinifyJson)
            {
                formatting = Formatting.Indented;
            }

            if (options.ExcludeUntisIdZero)
            {
                exams = exams.Where(x => x.ID > 0);
            }

            if (options.DateThreshold.HasValue)
            {
                var threshold = options.DateThreshold.Value;
                exams = exams.Where(x => x.Date >= threshold);
            }

            return JsonConvert.SerializeObject(exams, formatting);
        }

        private static string GetClassFromName(string name)
        {
            int shortYear;

            if (name.Length >= 3 && name.Substring(0, 1) == "A" && int.TryParse(name.Substring(1, 2), out shortYear))
            {
                var year = 2000 + shortYear;

                var currentYear = DateTime.Today.Year;
                var currentMonth = DateTime.Today.Month;

                var diff = year - currentYear;

                if (currentMonth < 8)
                {
                    diff++;
                }

                switch (diff)
                {
                    case 1:
                        return "Q2";

                    case 2:
                        return "Q1";

                    case 3:
                        return "EF";

                    default:
                        return null;
                }
            }

            return null;
        }
    }
}
