using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.Potter
{
    public class Basket
    {
        public List<Book> Books { get; set; }
        
        public Basket()
        {
            Books = new List<Book>();
        }

        public Basket(params Book[] books)
        {
            Books = books.ToList();
        }
    }
}
