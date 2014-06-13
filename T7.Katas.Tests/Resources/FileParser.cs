using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.Tests.Resources
{
    public class FileParser
    {
        public IEnumerable<string> ParseFileIntoWords(string path)
        {
            List<string> words = new List<string>();

            using (var file = new StreamReader(path))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    words.Add(line);
                }

                file.Close();
            }

            return words;
        }
    }
}
