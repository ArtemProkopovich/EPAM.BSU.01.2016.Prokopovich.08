using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Test
{
    internal class Book : IComparable<Book>
    {
        public string Name;
        public string Author;
        public int PageNumber;

        public int CompareTo(Book other)
        {
            if (other == null)
                throw new ArgumentNullException("");
            if (Name != null)
                return Name.CompareTo(other.Name);
            if (Author != null)
                return Author.CompareTo(other.Author);
            return PageNumber.CompareTo(other.PageNumber);
        }
    }
}
