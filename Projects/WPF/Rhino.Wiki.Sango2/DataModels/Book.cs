using System.Collections.Generic;

namespace Rhino.Wiki.Sango2.DataModels
{
    public class Book
    {
        public string Name { get; set; }

        public string Target { get; set; }
        public int Point { get; set; }

        public override string ToString() => $"{Name} - {Target}增加{Point}";
    }

    public class BookEqualComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            if (x == null && y == null) return true;
            else if (x == null || y == null) return false;
            else if (x.Name == y.Name) return true;
            else return false;
        }

        public int GetHashCode(Book book) => book.Name.GetHashCode();
    }
}