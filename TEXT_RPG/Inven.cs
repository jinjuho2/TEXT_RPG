using Spectre.Console;
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
            var ownedItems = ItemManager.Instance().items.Where(item => item.IsHave).ToList();

            Console.Clear();
            Console.WriteLine($"[아이템 목록]");
            for (int i = 0; i < ownedItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ownedItems[i].Name}");
            }
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 메인 메뉴");
            Console.Write(">> ");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
                {
                Console.WriteLine("다시 입력해주세요.");
                }

            switch (input)
            {
                case 1: ShowEquipment(); break;
                case 0: GameManager.Instance().Run(); break;
            }


        }

        public void ShowEquipment()
        {
            while (true)
            {

                var ownedItems = ItemManager.Instance().items.Where(item => item.IsHave).ToList();
                Console.Clear();
                Console.WriteLine($"[아이템 목록]");
                for (int i = 0; i < ownedItems.Count; i++)
                {
                    var item = ownedItems[i];
                    string result = item.IsEquipped ? "[E]" : "";
                    string display = "";
                    switch (item.Type)
                    {
                        case "무기":
                            display = ($"{i + 1}. {result}{item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 치명타율 : {item.Critical,-5} | 레벨 : {item.Level,-5} ");
                            Console.WriteLine(display);
                            break;
                        case "갑옷":
                            display = ($"{i + 1}. {result}{item.Name,-15} | {item.Type,-5} | 방어력 : {item.Def,-5} | 회피율 : {item.Dodge,-5} | 레벨 : {item.Level,-5}");
                            Console.WriteLine(display);
                            break;
                        case "HP":
                            display = ($"{i + 1}. {result}{item.Name,-15} | {item.Type,-5} | HP 회복량 : {item.RecoverHP,-5} ");
                            Console.WriteLine(display);
                            break;
                        case "MP":
                            display = ($"{i + 1}. {result}{item.Name,-15} | {item.Type,-5} | MP 회복량 : {item.RecoverMP,-5} ");
                            Console.WriteLine(display);
                            break;
                    }
                }
                
                
                Console.WriteLine("장착할 아이템을 선택하세요");
                Console.WriteLine("0. 인벤토리");
                Console.Write(">> ");

                if (!int.TryParse(Console.ReadLine(), out int input)) continue;
                if (input == 0) { ShowInventory(); return; }
                if (input < 1 || input > ownedItems.Count) continue;

                Item selectedItem = ownedItems[input - 1];

                if (selectedItem.IsEquipped)
                {
                    selectedItem.IsEquipped = false;
                    Console.WriteLine($"'{selectedItem.Name}' 을(를) 해제했습니다");
                    Thread.Sleep(1000);
                }
                else
                {
                    foreach (var item in ownedItems)
                    {
                        if (selectedItem.Type == item.Type && item.IsEquipped)
                        {
                            item.IsEquipped = false;
                            Console.WriteLine($"'{item.Name}' 을(를) 해제했습니다");
                        }
                    }
                    selectedItem.IsEquipped = true;
                    Console.WriteLine($"'{selectedItem.Name}' 을(를) 장착했습니다");
                    Thread.Sleep(1000);
                }



            }
        }
    }
}
