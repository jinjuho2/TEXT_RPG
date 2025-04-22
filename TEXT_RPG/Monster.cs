using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Monster:Unit
    {


        public Monster(int _ID, string name,int lv,TYPE _weak,float _atk,float _def,int _speed,int _hp,int exp,int gold) {
            ID = _ID;
            Name =name;
            Attack = _atk;
            Defense = _def;
            MaxHp = _hp;
            CurrentHP=MaxHp;

            Level = lv;
      
            Speed = _speed;
            WeakType = _weak;
            IsWeak = false;
            Gold = gold;
            items = new List<Item>();
     

        }
     
    }
}
