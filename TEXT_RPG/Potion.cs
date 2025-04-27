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
       
        public Potion(Item item) // 이름 ,타입 ,회복량 ,가격, 소지 여부
            : base(item.ID, item.Name, item.Type, 0, 0, 0, 0, 0, 0, item.RecoverHP??0, item.RecoverMP??0, item.Price??0, 0, item.IsHave, false, item.MainType)
        {

        }

   

        public override string show(int i)
        {
            string display = "";
            if (i==0)
              display = ($"{Name,-15} | {Type,-5} | 회복량 : {RecoverHP,-5} | 마나 회복량 : {RecoverMP,-5} | 가격 : {Price} ");
            else
            {
                if (IsHave)
                    display += ($"[gray]{Name,-15} | 회복량 : {RecoverHP,-5} | 마나 회복량 : {RecoverMP,-5} | 판매완료[/]");
                else
                    display = ($"{Name,-15} | {Type,-5} | 회복량 : {RecoverHP,-5} | 마나 회복량 : {RecoverMP,-5} | 가격 : {Price} ");

            }
            return display;
        
        }
        public bool Use(Player player, out string a) // 포션 사용
        {
            if (Type == "HP" && player.CurrentHP < player.MaxHp && IsHave)
            {
                player.CurrentHP += RecoverHP?? 0;
                if (player.CurrentHP > player.MaxHp)
                    player.CurrentHP = player.MaxHp;

                 a=($"{Name}을 사용하여 HP {RecoverHP} 회복했습니다.");
                return true;
            }
            else if (Type == "MP" && player.CurrentMP < player.MaxMp && IsHave)
            {
                player.CurrentMP += RecoverMP??0;
                if (player.CurrentMP > player.MaxMp)
                    player.CurrentMP = player.MaxMp;

                a=($"{Name}을 사용하여 MP {RecoverMP} 회복했습니다.");
                return true;
            }
            else
            {
                a=($"{Name}을 사용할 수 없습니다.");
                return false;
            }
        }
    }

}
