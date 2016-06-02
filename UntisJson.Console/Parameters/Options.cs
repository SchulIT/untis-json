using CommandLine;
using CommandLine.Text;

namespace UntisJson.Console.Parameters
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input file")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = false, DefaultValue = null, HelpText = "Output file. If not specified, output will be printed to stdout")]
        public string OutputFile { get; set; }

        [Option('t', "type", Required = true, HelpText = "Type of input file - can either be 'exams' or 'substitutions'")]
        public string Type { get; set; }

        [Option('v', "verbose", Required = false, HelpText = "Print details during execution")]
        public bool Verbose { get; set; }

        [Option('m', "minify", Required = false, HelpText = "Indicates whether the resulting JSON string will be minified or not")]
        public bool Minify { get; set; }

        [Option('e', "exclude0", Required = false, HelpText = "Flag whether to exclude Untis IDs 0")]
        public bool ExcludeZero { get; set; }

        [Option('u', "usethreshold", Required = false, HelpText = "Flag whether to exclude old items")]
        public bool UseThreshold { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this);
        }
    }
}
