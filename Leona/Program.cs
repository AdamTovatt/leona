using Leona.Models;
using Leona.Models.Drawing;
using System.Diagnostics;

namespace Leona
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string? codePath;

            if (args.Length > 0)
            {
                codePath = args[0];
            }
            else
            {
                Console.WriteLine("Enter a file path:");
                codePath = Console.ReadLine();
            }

            bool success = await ConvertCodeToImageAsync(codePath);

            if (!success)
            {
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        private static async Task<bool> ConvertCodeToImageAsync(string? codePath)
        {
            if (codePath == null)
            {
                Console.WriteLine("Error: No file path was provided.");
                return false;
            }

            if (!File.Exists(codePath))
            {
                Console.WriteLine("Error: File does not exist.");
                return false;
            }

            string fileContent = File.ReadAllText(codePath);

            Turtle turtle = new Turtle();

            ParseTree parseTree = turtle.Parse(fileContent);

            if (parseTree.SyntaxException != null)
            {
                Console.WriteLine(parseTree.SyntaxException.Message);
                return false;
            }

            Picture? picture = null;

            await Task.Run(() => { picture = turtle.GetPicture(parseTree); });

            string outputPath = GetOutPutPathFromCodePath(codePath);
            picture!.WriteToFile(outputPath);

            OpenImage(outputPath);

            return true;
        }

        private static string GetOutPutPathFromCodePath(string codePath)
        {
            string withoutFileExtension = codePath.Substring(0, codePath.LastIndexOf('.'));
            return withoutFileExtension + ".bmp";
        }

        private static void OpenImage(string filename)
        {
            Process process = new Process();

            process.StartInfo = new ProcessStartInfo(filename) { UseShellExecute = true };

            process.Start();
        }
    }
}