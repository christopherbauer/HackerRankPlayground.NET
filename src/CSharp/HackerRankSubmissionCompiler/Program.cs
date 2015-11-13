using System;
using System.Collections.Generic;
using System.IO;

namespace HackerRankSubmissionCompiler
{
    using System.Runtime.InteropServices.WindowsRuntime;

    class Program
    {
        public class CodeFileLogicalContents
        {
            private readonly List<string> usings = new List<string>();
            private readonly List<string> code = new List<string>();

            public List<string> GetUsings()
            {
                return this.usings;
            }

            public List<string> GetCode()
            {
                return this.code;
            }

            public void AddUsing(string line)
            {
                if (!this.usings.Contains(line))
                {
                    this.usings.Add(line);
                }
            }

            public void AddLineOfCode(string line)
            {
                code.Add(line);
            }
        }

        static void Main(string[] args)
        {
            var sourceDirectory = DirectoryHelper.GetSourceDirectory();
            var csharpFiles = DirectoryHelper.GetCsFiles(sourceDirectory);
            var fileContents = new Program.CodeFileLogicalContents();
            foreach (var csharpFile in csharpFiles)
            {
                fileContents = ExtractContents(csharpFile);
            }
            
            WriteCombinedSubmissionFile(fileContents);
        }

        private static void WriteCombinedSubmissionFile(Program.CodeFileLogicalContents codeFileLogicalContents)
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

        private static CodeFileLogicalContents ExtractContents(FileInfo fileInfo)
        {
            var fileContents = new Program.CodeFileLogicalContents();
            using (var file = fileInfo.Open(FileMode.Open))
            {
                using (var reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        var readLine = reader.ReadLine();

                        if (readLine.StartsWith("using"))
                        {
                            fileContents.AddUsing(readLine);
                        }
                        else
                        {
                            fileContents.AddLineOfCode(readLine);
                        }
                    }
                }
            }
            return fileContents;
        }
    }
}