using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Monster:Unit
    {
        public Monster() {
            atk = 10;
            def = 10;
            hp = 30;
            lvl = 0;
            name = "임시몬스터";
            speed = 3;
            WeakType = TYPE.Normal;
            IsWeak = false;
            Gold = 100;
            items = new List<Item>();
            items.Add(new Item());  

        }
     
    }
}
