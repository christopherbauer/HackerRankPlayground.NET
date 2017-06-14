using System.IO;

namespace HackerRankSubmissionCompiler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sourceDirectory = DirectoryHelper.GetSourceDirectory();
            var csharpFiles = DirectoryHelper.GetCsFiles(sourceDirectory);
            var fileContents = new CodeFileLogicalContents();
            foreach (var csharpFile in csharpFiles)
            {
                fileContents.ExtractContents(csharpFile);
            }
            
            WriteCombinedSubmissionFile(fileContents);
        }

        private static void WriteCombinedSubmissionFile(CodeFileLogicalContents codeFileLogicalContents)
        {
            using (var file = new FileStream("Submission.txt", FileMode.Create))
            {
                using (var writer = new StreamWriter(file))
                {
                    foreach (var line in codeFileLogicalContents.GetUsings())
                    {
                        writer.WriteLine(line);
                    }
                    foreach (var line in codeFileLogicalContents.GetCode())
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}