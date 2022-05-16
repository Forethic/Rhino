using System.Collections.Generic;

namespace Rhino.Wiki.Sango2.DataModels
{
    public class Horse
    {
        public string Name { get; set; }
        public int LevelRequired { get; set; }
        public int Point { get; set; }
        public bool Unable2ReturnIsNotValid { get; set; } = false;

        public override string ToString() => $"{Name} - 速度提升{Point}点" + (LevelRequired == 0 ? "" : $" - 等级要求：{LevelRequired}") + (Unable2ReturnIsNotValid ? " 无法退兵无效" : "");
    }

    public class HorseEqualComparer : IEqualityComparer<Horse>
    {
        public bool Equals(Horse x, Horse y)
        {
            if (x == null && y == null) return true;
            else if (x == null || y == null) return false;
            else if (x.Name == y.Name) return true;
            else return false;
        }

        public int GetHashCode(Horse horse) => horse.Name.GetHashCode();
    }
}