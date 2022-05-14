using System.Collections.Generic;

namespace Rhino.Wiki.Sango2.DataModels
{
    public class Strategy
    {
        public string Name { get; set; }

        public List<Military> Militaries { get; set; } = new List<Military>();
    }
}