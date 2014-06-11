using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.Potter
{
    public class Register
    {
        public decimal Total(Basket basket)
        {
            var groups = GetGroups(basket);
            return groups.Sum(x => GetGroupPrice(x));
        }

        private int[] GetGroups(Basket basket)
        {
            var countByBook = basket.Books
                .GroupBy(x => x)
                .Select(x => x.Count())
                .ToArray();

            var groups = new int[0];
            
            while (countByBook.Any())
            {
                Array.Resize(ref groups, groups.Length + 1);
                groups[groups.Length-1] = countByBook.Count();
                countByBook = countByBook.Select(x => x - 1).Where(x => x > 0).ToArray();
            }

            //hack.
            while (groups.Any(x => x == 3) && groups.Any(x => x == 5))
            {
                groups[Array.IndexOf(groups, 3)] = 4;
                groups[Array.IndexOf(groups, 5)] = 4;
            }
            return groups.ToArray();
        }

        private decimal GetGroupPrice(int groupCount)
        {
            if (groupCount == 0)
            {
                return 0m;
            }

            switch (groupCount)
            {
                case 2:
                    return 15.2m;
                case 3:
                    return 21.6m;
                case 4:
                    return 25.6m;
                case 5:
                    return 30m;
                default:
                    return 8m;
            }
        }

    }
}
