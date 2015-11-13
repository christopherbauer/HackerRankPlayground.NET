namespace HackerRankSubmissionCompiler
{
    using System;
    using System.IO;

    class DirectoryHelper
    {
        public static FileInfo[] GetCsFiles(DirectoryInfo sourceDirectory)
        {
            return sourceDirectory.GetFiles("*.cs");
        }

        public static DirectoryInfo GetSourceDirectory()
        {
            return new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent;
        }
    }
}