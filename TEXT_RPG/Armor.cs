using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Armor : Item
    {
        public static List<Armor> Armors = new List<Armor>();

        public Armor(string name, string type, float def, float dodge, int hp, int mp,  // 이름 ,타입 ,방어력 ,회피율 ,쳐력 ,마나 ,
                     int price, int level, bool isHave, bool isEquipped,string mainType)                //가격,착용레벨,소지 여부, 장착 여부
            : base(name, type, 0, def, 0, dodge, hp, mp,0,0 ,price, level, isHave, isEquipped, mainType)
        {
        }

        public static void AddDefaultArmors() // 기본 방어구 추가
        {
            Armors.Add(new Armor("가죽 갑옷", "Armor", 5, 0.1f, 0, 0, 100, 1, false, false, "갑옷"));
            Armors.Add(new Armor("철 갑옷", "Armor", 10, 5f, 20, 20, 200, 3, false, false,"갑옷"));
            Armors.Add(new Armor("은 갑옷", "Armor", 20, 10f, 50, 50, 300, 7, false, false,"갑옷"));
            Armors.Add(new Armor("금 갑옷", "Armor", 30, 20f, 100, 100, 400, 12, false, false,"갑옷"));
        }
    }
}
