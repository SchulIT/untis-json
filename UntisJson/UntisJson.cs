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
        public static IEnumerable<Vertretung> ParseSubstitutions(string csv)
        {
            var engine = new FileHelperEngine(typeof(Vertretung));

            var result = engine.ReadString(csv) as Vertretung[];

            return result.AsEnumerable();
        }

        public static string ParseSubstitutionsAsJson(string csv)
        {
            var substitutions = ParseSubstitutions(csv);

            return JsonConvert.SerializeObject(substitutions);
        }
    }
}
