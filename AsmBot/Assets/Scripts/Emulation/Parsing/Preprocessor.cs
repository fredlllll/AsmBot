using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Parsing
{
    public static class Preprocessor
    {
        public static List<string> Process(string input)
        {
            string[] lines = input.Trim().Split('\n');

            List<string> processedLines = new List<string>();

            foreach (string rawLine in lines)
            {
                var line = rawLine.Trim();
                if (line.Length == 0 || line.StartsWith(';'))
                {
                    //keep empty lines to keep track of line number
                    processedLines.Add(string.Empty);
                    continue;
                }
                int commentIndex = line.IndexOf(';');
                if (commentIndex != -1)
                {
                    line = line.Substring(0, commentIndex);
                }
                processedLines.Add(line);
            }

            return processedLines;
        }
    }
}
