using Rhino.Mvvm;
using System.Collections.Generic;
using System.Text;

namespace Rhino.Wiki.Sango2.DataModels
{
    public class Military : NotifyObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sword { get; set; }

        public int Brains { get; set; }

        public int Bulk { get; set; }

        public string Image { get; set; }

        public Dictionary<int, Skill> Skills { get; set; } = new Dictionary<int, Skill>();
        public Dictionary<int, Strategy> Strategies { get; set; } = new Dictionary<int, Strategy>();

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Sword}\t{Brains}\t{Bulk}";
        }

        public string DisplaySkill()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Id} - {Name}\t");
            foreach (var skill in Skills)
            {
                builder.Append($"{skill.Key}-{skill.Value.Name}\t");
            }

            return builder.ToString();
        }

        public string DisplayStrategy()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Id} - {Name}\t");
            foreach (var strategy in Strategies)
            {
                builder.Append($"{strategy.Key}-{strategy.Value.Name}\t");
            }

            return builder.ToString();
        }
    }
}