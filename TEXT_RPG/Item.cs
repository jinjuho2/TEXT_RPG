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
        

        public string name { get; set; }
        public string type { get; set; } // "weapon", "armor", "accessory"
        public float atk { get; set; }
        public float def { get; set; }
        public float critical { get; set; }
        public float dodge { get; set; }
        public int hp { get; set; }
        public int mp { get; set; }
        public int price { get; set; }
        public int level { get; set; }
        public bool isHave { get; set; }
        public bool isEquipped { get; set; }

        public Item(string name, string type ,float atk, float def, 
                    float critical,float dodge, int hp, int mp, 
                    int price, int level, bool isHave, bool isEquipped)
        {
            this.name = name;
            this.type = type;
            this.atk = atk;
            this.def = def;
            this.critical = critical;
            this.dodge = dodge;
            this.hp = hp;
            this.mp = mp;
            this.price = price;
            this.level = level;
            this.isHave = isHave;
            this.isEquipped = isEquipped;
        }

        public void AddItem(Item item)
        {
            items.Add(new );
        }   
       

    }
}
