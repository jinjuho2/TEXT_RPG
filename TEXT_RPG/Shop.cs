using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Shop : ItemManager
    {
        public List<Item> shopItems = new List<Item>(); // 상점에서 판매하는 아이템 목록

        public void ShowMenu(Player player)
        {
            player.Gold += 10000;
            player.Level = 30;
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            ShowShopItems();
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 메인 메뉴");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("메인 메뉴로 돌아가려면 0을 입력하세요: ");
            }

            switch (input)
            {
                case 1: BuyItem(player); break;
                case 2: SellItem(player); break;
                case 0: GameManager.Instance().Run(); break;
            }


            Thread.Sleep(1000);
        }

        private void BuyItem(Player player) // 구매
        {
            while (true)
            {
                Console.Clear();

                for (int i = 0; i < shopItems.Count; i++)
                {
                    var item = shopItems[i];
                    bool result = item.IsHave;
                    string status = result ? "구매 완료" : "가격 : " + item.Price.ToString();
                    string display = "";
                    switch (item.MainType)
                    {
                        case "무기":
                            display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 치명타율 : {item.Critical,-5} | 레벨 : {item.Level,-5} | {status,-5}");
                            Console.WriteLine(display);
                            break;
                        case "갑옷":
                            display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | 방어력 : {item.Def,-5} | 회피율 : {item.Dodge,-5} | 레벨 : {item.Level,-5} | {status,-5}");
                            Console.WriteLine(display);
                            break;
                        case "포션":
                            display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | HP 회복량 : {item.RecoverHP,-5} | MP 회복량 : {item.RecoverMP,-5} | 가격 : {item.Price,-5}");
                            Console.WriteLine(display);
                            break;
                        case "악세서리":
                            display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 방어력 : {item.Def,-5} | 치명타율 : {item.Critical,-5} | 회피율 : {item.Dodge,-5} | 레벨 : {item.Level,-5} | {status,-5} ");
                            Console.WriteLine(display);
                            break;
                    }

                }
                Console.WriteLine();
                Console.WriteLine("0. 뒤로 가기");
                Console.Write("구매할 아이템을 입력하세요.: ");
                if (!int.TryParse(Console.ReadLine(), out int input)) continue;
                if (input == 0) { ShowMenu(player); return; }
                if (input < 1 || input > shopItems.Count) continue;

                Item selectedItem = shopItems[input - 1];

                if (!selectedItem.IsHave && player.Gold >= selectedItem.Price)
                {
                    Console.WriteLine("정말 구매하시겠습니까?");
                    Console.WriteLine("1. 예");
                    Console.WriteLine("2. 아니요");

                    if (!int.TryParse(Console.ReadLine(), out int check)) continue;
                    if (check == 1)
                    {
                        selectedItem.IsHave = true;
                        player.inventory.Add(selectedItem);
                        Console.WriteLine($"'{selectedItem.Name}' 을(를) 구매했습니다");
                        player.Gold -= selectedItem.Price ?? 0;
                        Thread.Sleep(1000);
                    }
                    else if (check == 2)
                    {
                        Console.WriteLine("구매 취소");
                        Thread.Sleep(1000);
                        
                    }
                    else
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000); 
                }

                else if (!selectedItem.IsHave && player.Gold < selectedItem.Price)
                {
                    Console.WriteLine($"골드가 부족합니다.");
                    Thread.Sleep(1000);
                }

                else
                {
                    Console.WriteLine($"'{selectedItem.Name}' 을(를) 이미 구매하였습니다.");
                    Thread.Sleep(1000);
                }
            }
        }

        private void SellItem(Player player) // 판매
        {
            while (true)
            {
                Console.Clear();
                var ownedItems = ItemManager.Instance().items.Where(x => x.IsHave).ToList();

                if (ownedItems.Count == 0)
                {
                    Console.WriteLine("소지한 아이템이 없습니다.");
                    Console.WriteLine("상점으로 돌아갑니다");
                    Thread.Sleep(1000);
                    ShowMenu(player);
                    break;
                }

                Console.WriteLine("[소지한 아이템 목록]");
                for (int i = 0; i < ownedItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ownedItems[i].Name} | 가격 : {ownedItems[i].Price * 0.8}");
                }

                Console.WriteLine();
                Console.WriteLine("0. 뒤로 가기");
                Console.Write("판매할 아이템 번호를 입력하세요: ");

                if (!int.TryParse(Console.ReadLine(), out int input)) continue;

                if (input == 0) { ShowMenu(player); return; }

                if (input < 0 || input > ownedItems.Count) continue;

                Item selectedItem = ownedItems[input - 1];

                if (selectedItem.IsEquipped)
                {
                    Console.WriteLine($"'{selectedItem.Name}'은(는) 장착 중인 아이템입니다. 판매할 수 없습니다.");
                }

                else
                {

                    Console.WriteLine("정말 판매하시겠습니까?");
                    Console.WriteLine("1. 예");
                    Console.WriteLine("2. 아니요");

                    if (!int.TryParse(Console.ReadLine(), out int check)) continue;
                    if (check == 1)
                    {
                        selectedItem.IsHave = false;
                        player.inventory.Remove(selectedItem);
                        Console.WriteLine($"'{selectedItem.Name}' 을(를) 판매했습니다");
                        player.Gold += (int)((selectedItem.Price ?? 0) * 0.8f);
                        Thread.Sleep(1000);
                    }
                    else if (check == 2)
                    {
                        Console.WriteLine("구매 취소");
                        Thread.Sleep(1000);

                    }
                    else
                        Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);

                }

                Thread.Sleep(1000);

            }
        }

        public void GenerateShopItems() // 상점 아이템 생성
        {
            List<Item> allItems = ItemManager.Instance().items;


            Random random = new Random();

            shopItems = allItems.OrderBy(x => random.Next()).Take(5).ToList();
        }

        public void ShowShopItems()
        {
            Console.WriteLine("===== 상점 아이템 목록 =====");

            foreach (var item in shopItems)
            {
                string display = "";
                switch (item.MainType)
                {

                    case "무기":
                        display = ($"{item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 치명타율 : {item.Critical,-5} | 레벨 : {item.Level,-5} | 가격 : {item.Price}");
                        Console.WriteLine(display);
                        break;
                    case "갑옷":
                        display = ($"{item.Name,-15} | {item.Type,-5} | 방어력 : {item.Def,-5} | 회피율 : {item.Dodge,-5} | 레벨 : {item.Level,-5} | 가격 : {item.Price}");
                        Console.WriteLine(display);
                        break;
                    case "포션":
                        display = ($"{item.Name,-15} | {item.Type,-5} | HP 회복량 : {item.RecoverHP,-5} | MP 회복량 : {item.RecoverMP,-5} | 가격 : {item.Price,-5}");
                        Console.WriteLine(display);
                        break;
                    case "악세서리":
                        display = ($"{item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 방어력 : {item.Def,-5} | 치명타율 : {item.Critical,-5} | 회피율 : {item.Dodge,-5} | 레벨 : {item.Level,-5} | 가격 : {item.Price} ");
                        Console.WriteLine(display);
                        break;
                }
            }
        }
    }
}
