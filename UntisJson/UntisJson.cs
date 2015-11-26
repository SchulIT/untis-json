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

            engine = new FileHelperEngine(typeof(Lesson));
            var classes = engine.ReadString(csvClasses) as Lesson[];

            foreach(var exam in result)
            {
                exam.Class = GetClassFromName(exam.Name);
                
                if(!string.IsNullOrEmpty(exam.Class))
                {
                    exam.Teachers = classes.Where(x => !string.IsNullOrEmpty(x.Teacher) && x.Number.ToString() == exam.CourseId && x.ClassName == exam.Class && exam.Courses.Contains(x.Subject)).Select(x => x.Teacher).Distinct().ToList();
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

        private static string GetClassFromName(string name)
        {
            int shortYear;

            if (name.Length >= 3 && name.Substring(0, 1) == "A" && int.TryParse(name.Substring(1, 2), out shortYear))
            {
                var year = 2000 + shortYear;

                var currentYear = DateTime.Today.Year;
                var currentMonth = DateTime.Today.Month;

                var diff = year - currentYear;

                if (currentYear < 8)
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
