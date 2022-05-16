using Rhino.Wiki.Sango2.DataModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;

namespace Rhino.Wiki.Sango2.StorageDatabase
{
    public class StoreDb
    {
        private const string MilitariesXml = "三国群英传武将表.xml";
        private const string SkillesXml = "三国群英传武将技表.xml";
        private const string GoodsXml = "三国群英传物品表.xml";

        public static StoreDb Instance => _instance ?? (_instance = new StoreDb());
        private static StoreDb _instance;

        public List<Book> Books { get; } = new List<Book>();
        public List<Jewel> Jewels { get; } = new List<Jewel>();
        public List<Horse> Horses { get; } = new List<Horse>();
        public List<Weapon> Weapons { get; } = new List<Weapon>();
        public List<Skill> Skills { get; } = new List<Skill>();
        public List<Military> Militaries { get; } = new List<Military>();

        private StoreDb()
        {
            Read();
        }

        public void Read()
        {
            ReadGoods();
            ReadSkilles();
            ReadMilitaries();
        }

        private void ReadSkilles()
        {
            var root = GetDocumentElement(SkillesXml);
            foreach (XmlNode node in root.ChildNodes)
            {
                Skills.Add(new Skill()
                {
                    Name = node.Attributes["Name"].Value,
                    Consume = int.Parse(node.Attributes["Consume"].Value),
                    Descritption = node.InnerText,
                });
            }
        }

        private XmlElement GetDocumentElement(string xmlName)
        {
            var document = new XmlDocument();

            var uri = new Uri("StorageDatabase\\" + xmlName, UriKind.Relative);
            var streamResourceInfo = Application.GetResourceStream(uri);
            document.Load(streamResourceInfo.Stream);

            return document.DocumentElement;
        }

        private void ReadGoods()
        {
            var root = GetDocumentElement(GoodsXml);
            foreach (XmlNode node in root.ChildNodes)
            {
                switch (node.Name)
                {
                    case "Books":
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "Book")
                            {
                                Books.Add(new Book
                                {
                                    Name = child.Attributes["Name"].Value,
                                    Point = int.Parse(child.Attributes["Point"].Value),
                                    Target = child.Attributes["Target"].Value,
                                });
                            }
                        }
                        break;
                    case "Jewels":
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "Jewel")
                            {
                                Jewels.Add(new Jewel
                                {
                                    Name = child.Attributes["Name"].Value,
                                    Point = int.Parse(child.Attributes["Point"].Value),
                                });
                            }
                        }
                        break;
                    case "Horses":
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "Horse")
                            {
                                var horse = new Horse
                                {
                                    Name = child.Attributes["Name"].Value,
                                    Point = int.Parse(child.Attributes["Point"].Value),
                                };

                                var levelRequriedAttr = child.Attributes["LevelRequried"];
                                if (levelRequriedAttr != null)
                                {
                                    horse.LevelRequired = int.Parse(levelRequriedAttr.Value);
                                }
                                horse.Unable2ReturnIsNotValid = child.Attributes["UnableToReturnIsNotValid"] != null;
                                Horses.Add(horse);
                            }
                        }
                        break;
                    case "Weapons":
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "Weapon")
                            {
                                var weapon = new Weapon
                                {
                                    Name = child.Attributes["Name"].Value,
                                    Point = int.Parse(child.Attributes["Point"].Value),
                                };
                                var levelRequriedAttr = child.Attributes["LevelRequried"];
                                if (levelRequriedAttr != null)
                                {
                                    weapon.LevelRequired = int.Parse(levelRequriedAttr.Value);
                                }
                                Weapons.Add(weapon);
                            }
                        }
                        break;

                }
            }
        }

        public void ReadMilitaries()
        {
            var document = new XmlDocument();

            var uri = new Uri("StorageDatabase\\" + MilitariesXml, UriKind.Relative);
            var info = Application.GetResourceStream(uri);
            document.Load(info.Stream);

            var root = document.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                var military = new Military
                {
                    Id = int.Parse(node.Attributes["Id"].Value),
                    Name = node.Attributes["Name"].Value,
                    Sword = int.Parse(node.Attributes["Sword"].Value),
                    Brains = int.Parse(node.Attributes["Brains"].Value),
                    Bulk = int.Parse(node.Attributes["Bulk"].Value),
                };
                Militaries.Add(military);

                var skillsNode = node.SelectSingleNode("Skills");
                foreach (XmlNode skillNode in skillsNode.ChildNodes)
                {
                    var name = skillNode.Attributes["Name"].Value;
                    var skill = Skills.Find(x => x.Name == name);
                    if (skill != null)
                    {
                        military.Skills.Add(int.Parse(skillNode.Attributes["Level"].Value), skill);
                    }
                }

                //var strategiesNode = node.SelectSingleNode("Strategies");
                //foreach (XmlNode strategyNode in strategiesNode.ChildNodes)
                //{
                //    var name = strategyNode.Attributes["Name"].Value;

                //    if (!Military.AllStrategy.TryGetValue(name, out Strategy strategy))
                //    {
                //        strategy = new Strategy { Name = name };
                //        Military.AllStrategy.Add(name, strategy);
                //    }
                //    strategy.Militaries.Add(military);

                //    military.Strategies.Add(int.Parse(strategyNode.Attributes["Level"].Value), strategy);
                //}
            }
        }
    }
}