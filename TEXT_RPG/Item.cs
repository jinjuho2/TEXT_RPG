using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Item
    {
        public static List<Item> items = new List<Item>();
        

        public string Name { get; set; }
        public string Type { get; set; } // "weapon", "armor", "accessory"
        public float Atk { get; set; }
        public float Def { get; set; }
        public float Critical { get; set; }
        public float Dodge { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Price { get; set; }
        public int Level { get; set; }
        public bool IsHave { get; set; }
        public bool IsEquipped { get; set; }

        public Item(string name, string type ,float atk, float def, 
                    float critical,float dodge, int hp, int mp, 
                    int price, int level, bool isHave, bool isEquipped)
        {
            this.Name = name;
            this.Type = type;
            this.Atk = atk;
            this.Def = def;
            this.Critical = critical;
            this.Dodge = dodge;
            this.HP = hp;
            this.MP = mp;
            this.Price = price;
            this.Level = level;
            this.IsHave = isHave;
            this.IsEquipped = isEquipped;
        }


    }
}
