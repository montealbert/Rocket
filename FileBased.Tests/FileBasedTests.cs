using NUnit.Framework;
using System.IO;
using System;

namespace FileBased.Tests
{
    public class FileBasedTests
    {

        [TestCase("input001.txt", "output001.txt")]
        [TestCase("input002.txt", "output002.txt")]
        [TestCase("input003.txt", "output003.txt")]
        [TestCase("input004.txt", "output004.txt")]
        [TestCase("input005.txt", "output005.txt")]
        public void TestInputOutPut(string inputfile, string outputfile)
        {
            string folderpath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase))) + @"\test_cases\";
            Solution.Solution.StartEvents(folderpath + @"\" + inputfile);
            using (StreamReader rs1 = File.OpenText(folderpath + inputfile + "_output.txt"))
            {
                using (StreamReader rs2 = File.OpenText(folderpath + outputfile))
                {
                    string actualContents = rs1.ReadToEnd().Replace("\r\n", "\n");
                    string expectedContents = rs2.ReadToEnd().Replace("\r\n", "\n");

                    Assert.AreEqual(expectedContents, actualContents);
                }
            }
        }
    }
}
