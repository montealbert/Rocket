using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Solution
{
    public static class Console2
    {
        public static StreamReader currentFile;
        public static StreamWriter outputFile;

        public static void setCurrentFile(string filename)
        {
            if (currentFile != null)
            {
                currentFile.Close();
                outputFile.Close();
            }
            currentFile = new StreamReader(filename);
            outputFile = new StreamWriter(filename + "_output.txt", false);
            outputFile.AutoFlush = true;
        }

        public static string ReadLine()
        {
            if (currentFile != null)
            {
                return currentFile.ReadLine();
            }
            return "";
        }

        public static void WriteLine(string input)
        {
            outputFile.WriteLine(input);
        }

        public static void CloseCurrentFiles()
        {
            if (currentFile != null)
            {
                currentFile.Close();
                outputFile.Close();
            }
        }
    }
}
