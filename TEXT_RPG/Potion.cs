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


        public Potion(string name, string type, int recoverHp, int recoverMp, int price, bool isHave) // 이름 ,타입 ,회복량 ,가격, 소지 여부
            : base(name, type, 0, 0, 0, 0, 0, 0, recoverHp, recoverMp , price, 0, isHave, false)
        {

        }

        public static void AddDefaultPotions() // 기본 포션 추가
        {
            Potions.Add(new Potion("빨간 포션", "HP", 50, 0, 50, false));
            Potions.Add(new Potion("주황 포션", "HP", 150, 0, 160, false));
            Potions.Add(new Potion("하얀 포션", "HP", 300, 0, 330, false));
            Potions.Add(new Potion("파란 포션", "MP", 0, 100, 100, false));
            Potions.Add(new Potion("마나 엘릭서", "MP", 0, 300, 320, false));
        }

        public void Use() // 포션 사용
        {
            if (Type == "HP" && Player.Instance.CurrentHP < Player.Instance.MaxHP && IsHave)
            {
                Player.Instance.CurrentHP += RecoverHP;
                if (Player.Instance.CurrentHP > Player.Instance.MaxHP)
                    Player.Instance.CurrentHP = Player.Instance.MaxHP;

                Console.WriteLine($"{Name}을 사용하여 HP {RecoverHP} 회복했습니다.");
            }
            else if (Type == "MP" && Player.Instance.CurrentMP < Player.Instance.MaxMP && IsHave)
            {
                Player.Instance.CurrentMP += RecoverMP;
                if (Player.Instance.CurrentMP > Player.Instance.MaxMP)
                    Player.Instance.CurrentMP = Player.Instance.MaxMP;

                Console.WriteLine($"{Name}을 사용하여 MP {RecoverMP} 회복했습니다.");
            }
            else
            {
                Console.WriteLine($"{Name}을 사용할 수 없습니다.");
            }
        }
    }

}
