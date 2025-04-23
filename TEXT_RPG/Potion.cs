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
            : base(item.ID, item.Name, item.Type, 0, 0, 0, 0, 0, 0, item.RecoverHP??0, item.RecoverMP??0, item.Price??0, 0, item.IsHave, false, item.MainType)
        {

        }
        
        

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
