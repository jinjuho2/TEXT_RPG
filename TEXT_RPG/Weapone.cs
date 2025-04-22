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
            Weapons.Add(new Weapone("나무 스태프",   "Staff", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("위저드 스태프", "Staff", 15, 0, 1000, 15, false, false));
            Weapons.Add(new Weapone("이블윙즈", "Staff", 30, 0, 3000, 30, false, false));
            Weapons.Add(new Weapone("케이그", "Staff", 60, 0, 6000, 45, false, false));
            Weapons.Add(new Weapone("사냥꾼의 활","Bow", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("라이덴",      "Bow", 15, 0, 1000, 15, false, false));
            Weapons.Add(new Weapone("봉황위궁",    "Bow", 30, 0, 3000, 30, false, false));
            Weapons.Add(new Weapone("골든 니스록", "Bow", 60, 0, 6000, 45, false, false));
            Weapons.Add(new Weapone("검",          "Sword", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("카알 대검",    "Sword", 15, 0, 1000, 15, false, false));
            Weapons.Add(new Weapone("화염의 카타나","Sword", 30, 0, 3000, 30, false, false));
            Weapons.Add(new Weapone("라투핸드",     "Sword", 60, 0, 6000, 45, false, false));
            Weapons.Add(new Weapone("가니어",       "Adae", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("메바",        "Adae", 15, 0, 1000, 15, false, false));
            Weapons.Add(new Weapone("다크 보닌",    "Adae", 30, 0, 3000, 30, false, false));
            Weapons.Add(new Weapone("흑갑충",       "Adae", 60, 0, 6000, 45, false, false));
            Weapons.Add(new Weapone("피스톨",       "Gun", 5, 0, 100, 1, false, false));
            Weapons.Add(new Weapone("콜드 마인드",  "Gun", 15, 0, 1000, 15, false, false));
            Weapons.Add(new Weapone("슈팅스타",     "Gun", 30, 0, 3000, 30, false, false));
            Weapons.Add(new Weapone("피스메이커",   "Gun", 60, 0, 6000, 45, false, false));
        }
    }
}
