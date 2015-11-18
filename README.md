# HackerRankPlayground.NET

A playground for completing HackerRank challenges in .NET. Working within the confines of the HackerRank plaintext IDE is a bit hard sometimes without static typechecking and I found myself looking at compiler errors and misspellings too often. Not to mention I use Resharper whose organizational help severely cuts down on the manual code cleanliness tasks that take up so much of my time. This library automatically compiles the necessary files into a Submission.txt file in the output folder that I can copy-paste into the IDE when I'm done testing.

## How?

* The Submission Compiler app is extremely simple, it just looks up two levels and finds all files that match the argument (for me, '*.cs' or '*.fs'), does some super simple classification of using statements and code lines, then outputs them in to the current folder as Submission.txt.
* The playground console app references the Submission Compiler to pull the .exe file during the build process.
* A post-build event invokes the SubmissionCompiler.exe and dumps bin/Debug/Submission.txt file.
