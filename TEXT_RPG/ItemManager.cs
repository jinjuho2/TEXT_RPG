using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class ItemManager
    {
        public List<Item> items = new List<Item>(); // 아이템 리스트

        public ItemManager() 
        {
            items.AddRange(Weapone.Weapons);
            items.AddRange(Armor.Armors);
            items.AddRange(Potion.Potions);
        }

        private static ItemManager instance;

        public static ItemManager Instance()
        {
            if (instance == null)
                instance = new ItemManager();
            return instance;
        }



        public static void InitializIeItem()
        {
            Acessory.AddDefaultAcessories();
            Weapone.AddDefaultWeapons();
            Armor.AddDefaultArmors();
            Potion.AddDefaultPotions();
        }

    }
}
