using System.Collections.Generic;

namespace Rhino.Wiki.Sango2.DataModels
{
    public class Jewel
    {
        public string Name { get; set; }
        public int Point { get; set; }

        public override string ToString() => $"{Name} - 增加忠诚度 {Point}";
    }

    public class JewelEqualComparer : IEqualityComparer<Jewel>
    {
        public bool Equals(Jewel x, Jewel y)
        {
            if (x == null && y == null) return true;
            else if (x == null || y == null) return false;
            else if (x.Name == y.Name) return true;
            else return false;
        }

        public int GetHashCode(Jewel jewel) => jewel.Name.GetHashCode();
    }
}