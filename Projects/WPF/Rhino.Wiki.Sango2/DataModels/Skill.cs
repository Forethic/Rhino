using System.Collections.Generic;

namespace Rhino.Wiki.Sango2.DataModels
{
    public class Skill
    {
        public string Name { get; set; }
        public int Consume { get; set; }
        public string Descritption { get; set; }

        public List<Military> Militaries { get; set; } = new List<Military>();

        public override string ToString() => $"{Name} - {Consume} - {Descritption}";
    }
}