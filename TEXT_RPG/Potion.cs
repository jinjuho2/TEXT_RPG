using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Potion : Item
    {
        public static List<Potion> Potions = new List<Potion>();

        public Potion(Item item) // 이름 ,타입 ,회복량 ,가격, 소지 여부
            : base(item.Name, item.Type, 0, 0, 0, 0, 0, 0, item.RecoverHP??0, item.RecoverMP??0, item.Price??0, 0, item.IsHave, false, item.MainType)
        {

        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public Potion(string name, string type, int recoverHp, int recoverMp, int price, bool isHave,string mainType) // 이름 ,타입 ,회복량 ,가격, 소지 여부
            : base(name, type, 0, 0, 0, 0, 0, 0, recoverHp, recoverMp , price, 0, isHave, false, mainType)
        {

        }

        public static void AddDefaultPotions() // 기본 포션 추가
        {
            Potions.Add(new Potion("빨간 포션", "HP", 50, 0, 50, false, "포션"));
            Potions.Add(new Potion("주황 포션", "HP", 150, 0, 160, false, "포션"));
            Potions.Add(new Potion("하얀 포션", "HP", 300, 0, 330, false, "포션"));
            Potions.Add(new Potion("파란 포션", "MP", 0, 100, 100, false, "포션"));
            Potions.Add(new Potion("마나 엘릭서", "MP", 0, 300, 320, false, "포션"));
=======
       

=======
       

>>>>>>> Stashed changes
        public override string show(int i)
        {
            string display = "";
            if (i==0)
              display = ($"{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");
            else
            {
                if (IsHave)
                    display += ($"[gray]{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 판매완료[/]");
                else
                    display = ($"{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");
<<<<<<< Updated upstream

            }
            return display;
>>>>>>> Stashed changes
        }

=======

            }
            return display;
        }
>>>>>>> Stashed changes
        public void Use(Player player) // 포션 사용
        {
            if (Type == "HP" && player.CurrentHP < player.MaxHP && IsHave)
            {
                player.CurrentHP += RecoverHP?? 0;
                if (player.CurrentHP > player.MaxHP)
                    player.CurrentHP = player.MaxHP;

                Console.WriteLine($"{Name}을 사용하여 HP {RecoverHP} 회복했습니다.");
            }
            else if (Type == "MP" && player.CurrentMP < player.MaxMP && IsHave)
            {
                player.CurrentMP += RecoverMP??0;
                if (player.CurrentMP > player.MaxMP)
                    player.CurrentMP = player.MaxMP;

                Console.WriteLine($"{Name}을 사용하여 MP {RecoverMP} 회복했습니다.");
            }
            else
            {
                Console.WriteLine($"{Name}을 사용할 수 없습니다.");
            }
        }
    }

}
