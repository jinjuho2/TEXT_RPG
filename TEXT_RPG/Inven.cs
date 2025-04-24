using System;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Reflection.Emit;
namespace TEXT_RPG
{
    internal class Inven 
    {


        public void ShowInventory(Player player)
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
                case 1: ShowEquipment(player); break;
                case 0: GameManager.Instance().Run(); break;
            }

            if (int.TryParse(Console.ReadLine(), out input))
                if (input == 1)
                    ShowEquipment(player);

                else
                    Console.WriteLine("다시 입력해주세요.");

        }

        public void ShowEquipment(Player player)
        {
            while (true)
            {

                var ownedItems = ItemManager.Instance().items.Where(item => item.IsHave).ToList();
                Console.Clear();
                Console.WriteLine($"[아이템 목록]");
                for (int i = 0; i < ownedItems.Count; i++)
                {
                    var item = ownedItems[i];
                    string result = item.IsEquipped ? "[E]" : " ";
                    string display = "";
                    switch (item.MainType)
                    {

                        case "무기":
                            display = ($"{result}{i + 1}. {item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 치명타율 : {item.Critical,-5} | 레벨 : {item.Level,-5} | 가격 : {item.Price}");
                            Console.WriteLine(display);
                            break;
                        case "갑옷":
                            display = ($"{result}{i + 1}. {item.Name,-15} | {item.Type,-5} | 방어력 : {item.Def,-5} | 회피율 : {item.Dodge,-5} | 레벨 : {item.Level,-5} | 가격 : {item.Price}");
                            Console.WriteLine(display);
                            break;
                        case "포션":
                            display = ($"{item.Name,-15} | {item.Type,-5} | HP 회복량 : {item.RecoverHP,-5} | MP 회복량 : {item.RecoverMP,-5} | 가격 : {item.Price,-5}");
                            Console.WriteLine(display);
                            break;
                        case "악세서리":
                            display = ($"{result}{i + 1}. {item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 방어력 : {item.Def,-5} | 치명타율 : {item.Critical,-5} | 회피율 : {item.Dodge,-5} | 레벨 : {item.Level,-5} | 가격 : {item.Price} ");
                            Console.WriteLine(display);
                            break;
                    }
                }


                Console.WriteLine("장착할 아이템을 선택하세요");
                Console.WriteLine("0. 인벤토리");
                Console.Write(">> ");

                if (!int.TryParse(Console.ReadLine(), out int input)) continue;
                if (input == 0) { ShowInventory(player); return; }
                if (input < 1 || input > ownedItems.Count) continue;

                Item selectedItem = ownedItems[input - 1];

                int? nullableLevel = selectedItem.Level;

                if (selectedItem.IsEquipped)
                {

                    selectedItem.IsEquipped = false;


                    UpdateEquipCount(selectedItem.Level, 1);
                    Console.WriteLine($"'{selectedItem.Name}' 을(를) 해제했습니다");
                    Thread.Sleep(1000);
                }

                else if (selectedItem.Level > player.Level)
                {
                    Console.WriteLine($"레벨이 부족하여 '{selectedItem.Name}' 을(를) 장착할 수 없습니다");
                    Thread.Sleep(1000);
                }
                else
                {
                    foreach (var item in ownedItems)
                    {
                        if (selectedItem.MainType == "갑옷")
                        {
                            if (item.Type == selectedItem.Type && item.IsEquipped)
                            {
                                item.IsEquipped = false;
                                UpdateEquipCount(item.Level, -1);
                                Console.WriteLine($"'{item.Name}' 을(를) 해제했습니다");
                            }

                        }
                        else if (selectedItem.MainType == item.MainType && item.IsEquipped && selectedItem.MainType != "갑옷")
                        {
                            item.IsEquipped = false;
                            UpdateEquipCount(item.Level, -1);
                            Console.WriteLine($"'{item.Name}' 을(를) 해제했습니다");
                        }
                    }
                    selectedItem.IsEquipped = true;
                    UpdateEquipCount(selectedItem.Level, 1);
                    Console.WriteLine($"'{selectedItem.Name}' 을(를) 장착했습니다");
                    Thread.Sleep(1000);
                }



            }
        }
        
        void UpdateEquipCount(int? level, int delta)
        {
            if (!level.HasValue) return;

            int lv = level.Value;

            if (GameManager.Instance().equipCountByLevel.ContainsKey(lv))
                GameManager.Instance().equipCountByLevel[lv] += delta;
            else
                GameManager.Instance().equipCountByLevel[lv] = Math.Max(0, delta);
        }
    }
}
