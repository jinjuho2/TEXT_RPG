using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
   
    internal class Player:Unit
    {
       public Player()
        {
            name = "플레이어";
            maxHp = 100;
            hp = maxHp;
            atk = 5;
            def = 5;
            speed = 5;

        }
        public override void ShowSimple()
        {
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{lvl} {name}");
            Console.WriteLine($"HP {hp}/{maxHp}");
            Console.WriteLine();
        }
    }
}
