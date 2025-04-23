using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Acessory : Item
    {
        public static List<Acessory> Acessories = new List<Acessory>();

        public Acessory(Item item) //가격,착용레벨,소지 여부, 장착 여부
           : base(item.ID, item.Name, item.Type, item.Atk??0, item.Def??0,
                 0, 0,item.HP??0,item.MP ?? 0,0,0,item.Price??0, item.Level ?? 0,
                 item.IsHave, item.IsEquipped, item.MainType)
        {
        }


        
    }
}
