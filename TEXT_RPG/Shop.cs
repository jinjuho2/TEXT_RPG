using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Shop : ItemManager
    {
        public Shop shopw = new Shop(); // 상점 클래스
        private List<Item> shopItems = new List<Item>(); // 상점에서 판매하는 아이템 목록

        public void GenerateShopItems() // 상점 아이템 생성
       
        {
            List<Item> allItems = new List<Item>();

            allItems.AddRange(Weapone.Weapons);
            allItems.AddRange(Armor.Armors);
            allItems.AddRange(Potion.Potions);

            Random random = new Random();

            shopItems = allItems.OrderBy(x => random.Next()).Take(5).ToList();
        }
        public  void ShowMenu()
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
                Console.WriteLine($"{i + 1}. {shopItems[i].Name} | {shopItems[i].Type} | {shopItems[i].Price}");
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            BuyItem();
            Console.WriteLine("2. 아이템 판매");
            SellItem();
            Console.WriteLine("0. 메인 메뉴");
        }

        private void BuyItem() // 구매
        {
            var items = ItemManager.Instance().items;

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].Name}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("0. 뒤로 가기");
                Console.Write("구매할 아이템을 입력하세요.: ");
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                {
                    ShowMenu();
                    return;
                }

                else if (input < 1 || items.Count < input)
                {
                    
                    continue;
                }

                Item selectedItem = items[input - 1];

                if (!selectedItem.IsHave && Player.Instance.Gold >= selectedItem.Price)
                {
                    selectedItem.IsHave = true;
                    Console.WriteLine($"'{selectedItem.Name}' 을(를) 구매했습니다");
                    Player.Instance.Gold -= selectedItem.Price;
                }

                else if (!selectedItem.IsHave && Player.Instance.Gold < selectedItem.Price)
                {
                    Console.WriteLine($"골드가 부족합니다.");
                    
                }

                else
                {
                    Console.WriteLine($"'{selectedItem.Name}' 을(를) 이미 구매하였습니다.");
                    
                }
            }
        }

        private void SellItem() // 판매
        {
            while (true)
            {
                Console.Clear();

                var ownedItems = ItemManager.Instance().items.Where(item => item.IsHave).ToList();

                if (ownedItems.Count == 0)
                {
                    Console.WriteLine("소지한 아이템이 없습니다.");
                    ShowMenu();
                    return;
                }

                Console.WriteLine("[소지한 아이템 목록]");
                for (int i = 0; i < ownedItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ownedItems[i].Name}");
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
                            
                            continue;
                        }
                        selectedItem.IsHave = false;
                        Player.Instance.Gold += (int)(selectedItem.Price * 0.85f);
                        Console.WriteLine($"'{selectedItem.Name}' 을(를) 판매했습니다.");
                        
                        continue;
                    }

                    else
                    {
                        
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



    }
}
