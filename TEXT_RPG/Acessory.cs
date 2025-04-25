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

        public Acessory(Item item) //가격,착용레벨,소지 여부, 장착 여부
           : base(item.Name, item.Type, item.Atk??0, item.Atk??0, 0, 0, item.HP??0, item.MP??0, 0, 0, item.Price??0, item.Level??0, item.IsHave, item.IsEquipped, item.MainType)
        {
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        public Acessory(string name, string type, float atk, float def, int hp, int mp, // 이름 ,타입 ,공격력 ,방어력 ,쳐력 ,마나 ,
                        int price, int level, bool isHave, bool isEquipped, string mainType) //가격,착용레벨,소지 여부, 장착 여부
            : base(name, type, atk, def, 0, 0, hp, mp, 0, 0, price, level, isHave, isEquipped, mainType)
        {
        }
=======
        public override string show(int i)
        {
          
            string display = "";
            if (i == 0)
            {
                if (IsEquipped)
                    display = ($"[red][[E]][/]{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");
                else
                    display = ($"{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");
            }
            else
            {
                if (IsHave)
                    display += ($"[gray]{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 판매완료[/]");
                else
                    display = ($"{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");

=======
        public override string show(int i)
        {
          
            string display = "";
            if (i == 0)
            {
                if (IsEquipped)
                    display = ($"[red][[E]][/]{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");
                else
                    display = ($"{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");
            }
            else
            {
                if (IsHave)
                    display += ($"[gray]{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 판매완료[/]");
                else
                    display = ($"{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");

>>>>>>> Stashed changes
            }
            return display;
        }
        
<<<<<<< Updated upstream
>>>>>>> Stashed changes


        public static void AddDefaultAcessories() // 기본 악세서리 추가
        {
            Acessories.Add(new Acessory("가죽 반지", "Ring", 5, 0, 0, 0, 100, 1, false, false, "악세서리"));
            Acessories.Add(new Acessory("은 반지", "Ring", 10, 0, 0, 0, 1000, 15, false, false, "악세서리"));
            Acessories.Add(new Acessory("금 반지", "Ring", 15, 0, 0, 0, 3000, 30, false, false, "악세서리"));
            Acessories.Add(new Acessory("다이아몬드 반지", "Ring", 20, 0, 0, 0, 6000, 45, false, false, "악세서리"));
        }
=======

>>>>>>> Stashed changes
    }
}
