using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Acessory : Item
    {
        public static List<Acessory> Acessories = new List<Acessory>();

        public Acessory(string name, string type, float atk, float def, int hp, int mp, // 이름 ,타입 ,공격력 ,방어력 ,쳐력 ,마나 ,
                        int price, int level, bool isHave, bool isEquipped, string mainType) //가격,착용레벨,소지 여부, 장착 여부
            : base(name, type, atk, def, 0, 0, hp, mp, 0, 0, price, level, isHave, isEquipped, mainType)
        {
        }


        public static void AddDefaultAcessories() // 기본 악세서리 추가
        {
            Acessories.Add(new Acessory("가죽 반지", "Ring", 5, 0, 0, 0, 100, 1, false, false, "악세서리"));
            Acessories.Add(new Acessory("은 반지", "Ring", 10, 0, 0, 0, 1000, 15, false, false, "악세서리"));
            Acessories.Add(new Acessory("금 반지", "Ring", 15, 0, 0, 0, 3000, 30, false, false, "악세서리"));
            Acessories.Add(new Acessory("다이아몬드 반지", "Ring", 20, 0, 0, 0, 6000, 45, false, false, "악세서리"));
        }
    }
}
