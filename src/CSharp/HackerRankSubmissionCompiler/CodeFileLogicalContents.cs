using System.Collections.Generic;
using System.IO;

namespace HackerRankSubmissionCompiler
{
    public class CodeFileLogicalContents
    {
        private readonly List<string> usings = new List<string>();
        private readonly List<string> code = new List<string>();

        public List<string> GetUsings()
        {
            return usings;
        }

        public List<string> GetCode()
        {
            return code;
        }

        public void AddUsing(string line)
        {
            if (!usings.Contains(line))
            {
                usings.Add(line);
            }
        }

        public void AddLineOfCode(string line)
        {
            code.Add(line);
        }

        public void ExtractContents(FileInfo fileInfo)
        {
            using (var file = fileInfo.Open(FileMode.Open))
            {
                using (var reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        var readLine = reader.ReadLine();

                        if (readLine.StartsWith("using"))
                        {
                            AddUsing(readLine);
                        }
                        else
                        {
                            AddLineOfCode(readLine);
                        }
                    }
                }
            }
        }
    }
}