using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.StringCalculator
{
    public class Calculator
    {
        public int Add(string items)
        {
            if (string.IsNullOrWhiteSpace(items))
            {
                return 0;
            }
            var delimiters = new List<char> {',', '\n'};

            if (items.StartsWith("//"))
            {
                items = items.Substring(2);
                var delimiter = items.First();
                delimiters.Add(delimiter);
                items = items.Substring(2);
            }

            var values = items.Split(delimiters.ToArray())
                .Select(int.Parse)
                .Where(x => x <= 1000)
                .ToList();

            var negatives = values.Where(x => x < 0).ToList();
            if (negatives.Any())
            {
                throw new ArgumentOutOfRangeException("items", "No negatives allowed - "
                    + string.Join(",", negatives));
            }
            return values.Sum();
        }
    }
}
