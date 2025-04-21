using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Weapone : Item
    {
        public static List<Weapone> weapons = new List<Weapone>();

        public Weapone(string name, string type, float atk,float critical,
                       int price, int level, bool isHave, bool isEquipped)
            : base(name, type, atk, 0, critical, 0, 0, 0, price, level, isHave, isEquipped)
        {
            this.name = name;
            this.type = type;
            this.atk = atk;
            this.critical = critical;
            this.price = price;
            this.level = level;
            this.isHave = isHave;
            this.isEquipped = isEquipped;
        }

        public void AddWeapon(Weapone weapon)
        {
            weapons.Add(new("나무 지팡이", "지팡이", 5, 0, 100, 1, false, false));
            weapons.Add(new("나무 활", "활", 7, 0, 100, 1, false, false));
            weapons.Add(new("나무 검", "검", 10, 0, 100, 1, false, false));
            weapons.Add(new("철검", "검", 20,  0, 200, 3, false, false));
            weapons.Add(new("은검", "검", 30, 0, 300, 7, false, false));
            weapons.Add(new("금검", "검", 40, 0, 400, 12, false, false));
            weapons.Add(new("다이아몬드 검", "검", 50, 0, 500, 20, false, false));
        }
    }
}
