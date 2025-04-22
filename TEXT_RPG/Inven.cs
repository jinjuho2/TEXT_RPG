using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Inven : ItemManager
    {
        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine($"[아이템 목록]");
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 메인 메뉴");
            Console.Write(">> ");

            if (int.TryParse(Console.ReadLine(), out int input))
                if (input == 1)
                    ShowEquipment();
                
                else
                    Console.WriteLine("다시 입력해주세요.");

        }

        public void ShowEquipment()
        {
            Console.Clear();
            Console.WriteLine($"[아이템 목록]");
            Console.WriteLine("\n1. 인벤토리");
            Console.WriteLine("0. 메인 메뉴");
            Console.Write(">> ");

            while (true)
            {
                int input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    ShowInventory();
                    break;
                }
               
                else
                    Console.WriteLine("다시 입력해주세요.");
            }
        }
    }
}
