using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Weapone : Item
    {
        public static List<Weapone> Weapons = new List<Weapone>(); // 무기 리스트

        public Weapone(string name, string type, float atk, float critical, // 이름 ,타입 ,공격력 ,방어력 ,
                       int price, int level, bool isHave, bool isEquipped)  //가격,착용레벨,소지 여부, 장착 여부
            : base(name, type, atk, 0, critical, 0, 0, 0,0,0, price, level, isHave, isEquipped)
        {
        }

        public static void AddDefaultWeapons() // 기본 무기 추가
        {
            Weapons.Add(new Weapone("나무 지팡이", "무기", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("은 지팡이", "무기", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("금 지팡이", "무기", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("다이아 지팡이", "무기", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("나무 활", "무기", 7, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("은 활", "무기", 7, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("금 활", "무기", 7, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("다이아 활", "무기", 7, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("나무 검", "무기", 10, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("철검", "무기", 20, 0, 200, 3, false, false));
            Weapons.Add(new Weapone("은검", "무기", 30, 0, 300, 7, false, false));
            Weapons.Add(new Weapone("금검", "무기", 40, 0, 400, 12, false, false));
            Weapons.Add(new Weapone("다이아몬드 검", "무기", 50, 0, 500, 20, false, false));
        }
    }
}
