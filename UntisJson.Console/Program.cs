using System.IO;
using UntisJson.Console.Parameters;

namespace UntisJson.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            var parser = new CommandLine.Parser();

            if (!parser.ParseArguments(args, options))
            {
                System.Console.WriteLine("Command line parameters wrong...");
                System.Console.WriteLine(options.GetUsage());
                System.Environment.Exit(1);
            }

            var input = Path.GetFullPath(options.InputFile);
            var output = string.IsNullOrEmpty(options.OutputFile) ? null : Path.GetFullPath(options.OutputFile);

            var csv = string.Empty;

            if (!File.Exists(input))
            {
                System.Console.WriteLine(string.Format("File {0} does not exist", input));
                System.Environment.Exit(1);
            }

            if (options.Verbose)
            {
                System.Console.WriteLine(string.Format("reading file {0}", input));
            }

            using (var reader = new StreamReader(input))
            {
                csv = reader.ReadToEnd();
            }

            if (options.Verbose)
            {
                System.Console.WriteLine("parsing file...");
            }

            var json = string.Empty;

            if (options.Type == "substitutions")
            {
                json = UntisJson.ParseSubstitutionsAsJson(csv, options.Minify);
            }
            else if (options.Type == "exams")
            {
                json = UntisJson.ParseExamAsJson(csv, options.Minify);
            }
            else
            {
                System.Console.WriteLine("Unknown input type specified");
                System.Environment.Exit(1);
            }

            if (options.Verbose)
            {
                System.Console.WriteLine("Parsing finished.");
                System.Console.WriteLine("Writing output...");
            }

            if (!string.IsNullOrEmpty(output))
            {
                using (var writer = new StreamWriter(output))
                {
                    writer.Write(json);
                }
            }
            else
            {
                System.Console.WriteLine(json);
            }

            if (options.Verbose)
            {
                System.Console.WriteLine("Finished.");
            }
        }
    }
}
