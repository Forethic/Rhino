using System.Collections.Generic;

namespace Rhino.Wiki.Sango2.DataModels
{
    public class Weapon
    {
        public string Name { get; set; }
        public int LevelRequired { get; set; }
        public int Point { get; set; }

        public override string ToString() => $"{Name} - 武力+{Point}点" + (LevelRequired > 0 ? $" - 等级要求：{LevelRequired}" : "");

    }

    public class WeaponEqualComparer : IEqualityComparer<Weapon>
    {
        public bool Equals(Weapon x, Weapon y)
        {
            if (x == null && y == null) return true;
            else if (x == null || y == null) return false;
            else if (x.Name == y.Name) return true;
            else return false;
        }
        public int GetHashCode(Weapon weapon) => weapon.Name.GetHashCode();
    }
}