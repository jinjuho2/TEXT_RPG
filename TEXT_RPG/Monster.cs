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
            Attack = 10;
            Defense = 10;
            MaxHp = 30;
            CurrentHP=MaxHp;

            Level = 0;
            Name = "임시몬스터";
            Speed = 3;
            WeakType = TYPE.Normal;
            IsWeak = false;
            Gold = 100;
            items = new List<Item>();
     

        }
     
    }
}
