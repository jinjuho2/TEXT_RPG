using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Item : ItemManager
    {

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

        public Item(string name, string type ,float atk, float def, //이름 ,타입 ,공격력 ,방어력 ,
                    float critical,float dodge, int hp, int mp,     //치명타 ,회피율 ,쳐력 ,마나 ,
                    int price, int level, bool isHave, bool isEquipped) //가격,착용레벨,소지 여부, 장착 여부
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
