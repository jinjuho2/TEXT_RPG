using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Item :IShow
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // 무기 하위 계열
        public float? Atk { get; set; }
        public float? Def { get; set; }
        public float? Critical { get; set; }
        public float? Dodge { get; set; }
        public int? HP { get; set; }
        public int? MP { get; set; }
        public int? Price { get; set; }
        public int? Level { get; set; }
        public bool IsHave { get; set; }
        public bool IsEquipped { get; set; }
        public int? RecoverHP { get; set; }
        public int? RecoverMP { get; set; }
        public string MainType { get; set; } // "weapon", "armor", "accessory" - 메인 무기 타입

        public Item() { } // 기본 생성자

        public Item(int id , string name, string type ,float atk, float def, //이름 ,타입 ,공격력 ,방어력 ,
                    float critical,float dodge, int hp, int mp,     //치명타 ,회피율 ,쳐력 ,마나 ,
                    int recoverHP , int recoverMP, int price, int level,
                    bool isHave, bool isEquipped, string mainType) //가격,착용레벨,소지 여부, 장착 여부 ,메인 무기 타입
        {
            this.ID = id;
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
            this.RecoverHP = recoverHP;
            this.RecoverMP = recoverMP;
            this.MainType = mainType;
        }

        public virtual string show()
        {
            string x;
            
            return Name;
        }
        public virtual string showS()
        {

            return Name;
        }

    }
}
