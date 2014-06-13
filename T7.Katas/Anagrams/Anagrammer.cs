using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.Anagrams
{
    public class Anagrammer
    {
        public IEnumerable<IEnumerable<string>> FindAnagrams(IEnumerable<string> words)
        {
            if (words == null)
            {
                throw new ArgumentNullException("words");
            }

            var sorted = new Dictionary<string, List<string>>();
            foreach (var word in words)
            {
                var letters = new string(word
                    .ToLower()
                    .OrderBy(x => x)
                    .Where(char.IsLetterOrDigit)
                    .ToArray());
                if (sorted.ContainsKey(letters))
                {
                    sorted[letters].Add(word);
                }
                else
                {
                    sorted.Add(letters, new List<string>(){word});
                }
            }

            return sorted.Select(x =>
                x.Value);

            //return new List<List<string>>();
        }
    }
}
