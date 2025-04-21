using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class ItemManager
    {
        public ItemManager() { }
        private static ItemManager instance;
        public static ItemManager Instance()
        {
            if (instance == null)
                instance = new ItemManager();
            return instance;
        }

        public List<Item> items = new List<Item>(); // 아이템 리스트
    }
}
