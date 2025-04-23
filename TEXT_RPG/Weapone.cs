using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Weapone : Item
    {
        public static List<Weapone> Weapons = new List<Weapone>(); // 무기 리스트

        
        public Weapone(Item item)  //가격,착용레벨,소지 여부, 장착 여부
           : base(item.ID,item.Name, item.Type, item.Atk??0, 0, item.Critical??0, 0, 0, 0, 0, 0, item.Price ?? 0, item.Level ?? 0, item.IsHave, item.IsEquipped, item.MainType)
        {
        }

    }
}
