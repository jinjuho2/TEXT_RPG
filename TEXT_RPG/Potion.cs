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
        public static List<Potion> potions = new List<Potion>();

        public int recoverHP { get; set; }
        public int recoverMP { get; set; }

        public Potion(string name, string type, int recoverHP, int recoverMP, int price, bool isHave)
            : base(name, type, 0, 0, 0, 0, 0, 0, price, 0, isHave, false)

        {
            this.recoverHP = recoverHP;
            this.recoverMP = recoverMP;
        }

        public void AddPotion(Potion potion)
        {
            potions.Add(new("빨간 포션", "HP", 50, 0, 50, false));
            potions.Add(new("주황 포션", "HP", 150, 0, 160, false));
            potions.Add(new("하얀 포션", "HP", 300, 0, 330, false));
            potions.Add(new("파란 포션", "MP", 0, 100, 100, false));
            potions.Add(new("마나 엘릭서", "MP", 0, 300, 320, false));
        }

        public void hpPotionUse(Player player)
        {
            if (player.maxHp > player.hp && ishave && potions.type == "MP")
            {
                player.hp += recoverHP;
                if (player.hp > player.maxHp)
                    player.hp = player.maxHp;

                Console.WriteLine($"{name}을 사용하여 HP를 {recoverHP}만큼 회복하였습니다.");
            }

            else
                Console.WriteLine($"{name}을 사용할 수 없습니다.");
        }

        public void mpPotionUse(Player player)
        {
            if (player.maxMp > player.mp && ishave && potions.type == "MP")
            {
                player.mp += recoverMP;
                if (player.mp > player.maxMp)
                    player.mp = player.maxMp;

                Console.WriteLine($"{name}을 사용하여 MP를 {recoverMP}만큼 회복하였습니다.");
            }
            else
                Console.WriteLine($"{name}을 사용할 수 없습니다.");
        }
    }

}
