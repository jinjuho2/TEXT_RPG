using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Shop : ItemManager
    {
        private List<Item> shopItems = new List<Item>(); // 상점에서 판매하는 아이템 목록


        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{Player.Instance.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shopItems.Count; i++)
            {
                var item = shopItems[i];
                bool result = item.IsHave;
                string status = result ? "구매 완료" : "가격 : " + item.Price.ToString();
                string display = "";
                switch (item.Type)
                {
                    case "무기":
                        display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 치명타율 : {item.Critical,-5} | 레벨 : {item.Level,-5} | {status,-5}");
                        Console.WriteLine(display);
                        break;
                    case "갑옷":
                        display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | 방어력 : {item.Def,-5} | 회피율 : {item.Dodge,-5} | 회피율: {item.Level,-5} | {status,-5}");
                        Console.WriteLine(display);
                        break;
                    case "HP":
                        display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | HP 회복량 : {item.RecoverHP,-5} | 가격 : {item.Price,-5}");
                        Console.WriteLine(display);
                        break;
                    case "MP":
                        display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | MP 회복량 : {item.RecoverMP,-5} | 가격 : {item.Price,-5}");
                        Console.WriteLine(display);
                        break;
                }

            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 메인 메뉴");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("메인 메뉴로 돌아가려면 0을 입력하세요: ");
            }
            if (input == 1)
                BuyItem(); // 구매
            else if (input == 2)
                SellItem(); // 판매
            else if (input == 0)
                GameManager.Instance().Run(); // 메인 메뉴로 돌아가기

            
            Thread.Sleep(1000);
        }

        private void BuyItem() // 구매
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
                    switch (item.Type)
                    {
                        case "무기":
                            display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | 공격력 : {item.Atk,-5} | 치명타율 : {item.Critical,-5} | 레벨 : {item.Level,-5} | {status,-5}");
                            Console.WriteLine(display);
                            break;
                        case "갑옷":
                            display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | 방어력 : {item.Def,-5} | 회피율 : {item.Dodge,-5} | 회피율: {item.Level,-5} | {status,-5}");
                            Console.WriteLine(display);
                            break;
                        case "HP":
                            display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | HP 회복량 : {item.RecoverHP,-5} | 가격 : {item.Price,-5}");
                            Console.WriteLine(display);
                            break;
                        case "MP":
                            display = ($"{i + 1}. {item.Name,-15} | {item.Type,-5} | MP 회복량 : {item.RecoverMP,-5} | 가격 : {item.Price,-5}");
                            Console.WriteLine(display);
                            break;
                    }

                }
                Console.WriteLine();
                Console.WriteLine("0. 뒤로 가기");
                Console.Write("구매할 아이템을 입력하세요.: ");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("구매할 아이템을 입력하세요.: ");
                }
                if (input == 0)
                {
                    ShowMenu();
                    return;
                }

                else if (input < 1 || shopItems.Count < input)
                {

                    continue;
                }

                Item selectedItem = shopItems[input - 1];

                if (!selectedItem.IsHave && Player.Instance.Gold >= selectedItem.Price)
                {
                    selectedItem.IsHave = true;
                    Console.WriteLine($"'{selectedItem.Name}' 을(를) 구매했습니다");
                    Player.Instance.Gold -= selectedItem.Price;
                    Thread.Sleep(1000);
                }

                else if (!selectedItem.IsHave && Player.Instance.Gold < selectedItem.Price)
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

        private void SellItem() // 판매
        {
            while (true)
            {
                Console.Clear();
                var ownedItems = ItemManager.Instance().items.Where(x => x.IsHave).ToList();

                if (ownedItems.Count == 0 || ownedItems == null)
                {
                    Console.WriteLine("소지한 아이템이 없습니다.");
                    ShowMenu();
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

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0)
                    {
                        ShowMenu();
                        return;
                    }

                    else if (input >= 1 && input <= ownedItems.Count)
                    {
                        Item selectedItem = ownedItems[input - 1];
                        if (selectedItem.IsEquipped)
                        {
                            Console.WriteLine($"'{selectedItem.Name}'은(는) 장착 중인 아이템입니다. 판매할 수 없습니다.");
                            Thread.Sleep(1000);
                            continue;
                        }
                        selectedItem.IsHave = false;
                        Player.Instance.Gold += (int)(selectedItem.Price * 0.8);
                        Console.WriteLine($"'{selectedItem.Name}' 을(를) 판매했습니다.");
                        Thread.Sleep(1000);
                        continue;
                    }

                }

                else
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                    continue;
                }
            }
        }

        public void GenerateShopItems() // 상점 아이템 생성
        {
            List<Item> allItems = new List<Item>();

            allItems.AddRange(Weapone.Weapons);
            allItems.AddRange(Armor.Armors);
            allItems.AddRange(Potion.Potions);

            Random random = new Random();

            shopItems = allItems.OrderBy(x => random.Next()).Take(5).ToList();
        }
    }
}
