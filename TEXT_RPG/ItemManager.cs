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
       
        private static ItemManager instance;

        public static ItemManager Instance()
        {
            if (instance == null)
                instance = new ItemManager();
            return instance;
        }


        public void InitializeItems()
        {
            int itemCount = DataManager.Instance().GetItemCount();
            for (int i = 0; i < items.Count; i++)
            {
                items.Add(DataManager.Instance().MakeItem(i));
            }
        }

    }
}
