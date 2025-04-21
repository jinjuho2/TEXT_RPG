using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    enum TYPE
    {
        Normal,Fire,Water,Grass,Dark,Light
    }
    internal class Unit
    {
       public string name;
       public float atk;
       public float def;
       public float maxHp;
       public float hp;
       public float maxMp;
       public float mp;
       public int speed;
       public int lvl;
        
        public bool IsAlive => hp > 0;

        List<Item> items;
        List<Skill> skills;

        public virtual int Attack()
        {
            Random random = new Random();
          
            int calAtk = random.Next((int)atk*90/100,(int)atk*110/100);

            return calAtk;
        }
        public string GetName()
        {
            return name;
        }
        public virtual bool Damaged(float atkD)
        {
            hp -= atkD;
           
            if (hp <= 0) {
                Dead();
                return true;
            }
            return false;
        }
        public virtual void ShowSimple()
        {
            if (!IsAlive) { 
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Lv.{lvl} {name} 기절");
            Console.ResetColor(); 
          }
            else Console.WriteLine($"Lv.{lvl} {name} HP {hp}");
        }
        private void Dead() {
            Console.WriteLine($"{name} 기절");
        }

    }
}
