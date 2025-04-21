using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Armor : Item
    {
        public static List<Armor> armors = new List<Armor>();
        public Armor(string name, string type, float def, float dodge, int hp, int mp,
                     int price, int level, bool isHave, bool isEquipped)
            : base(name, type, 0, def, 0, dodge, hp, mp, price, level, isHave, isEquipped)
        {
            this.name = name;
            this.type = type;
            this.def = def;
            this.hp = hp;
            this.mp = mp;
            this.dodge = dodge;
            this.price = price;
            this.level = level;
            this.isHave = isHave;
            this.isEquipped = isEquipped;
        }
        public void AddArmor(Armor armor)
        {
            armors.Add(new("가죽 갑옷", "갑옷", 5, 0.1f,0,0, 100, 1, false, false));
            armors.Add(new("철 갑옷", "갑옷", 10, 5f,20,20, 200, 3, false, false));
            armors.Add(new("은 갑옷", "갑옷", 20, 10f,50,50 ,300, 7, false, false));
            armors.Add(new("금 갑옷", "갑옷", 30, 20f,100,100, 400, 12, false, false));
        }
    }
}
