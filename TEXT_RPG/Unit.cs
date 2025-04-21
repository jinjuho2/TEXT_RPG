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
        
        public TYPE WeakType { get; set; }
        public int Gold { get; set; }
        public bool IsWeak { get; set; }
        
        public bool IsAlive => hp > 0;

        public List<Item> items;
        List<Skill> skills;

        public virtual AttackData Attack()
        {
            Random random = new Random();
          
            int calAtk = random.Next((int)atk*90/100,(int)atk*110/100);
            AttackData ad;
            if (random.Next(0, 100) < 15)
            {
                calAtk = (int)(calAtk * 1.6f);
               
                 ad = new AttackData(calAtk, TYPE.Normal, true);
            }
            else
            {
                     ad = new AttackData(calAtk, TYPE.Normal, false);
            }
            return ad;
        }
        public string GetName()
        {
            return name;
        }
        public virtual bool Damaged(int atkD)
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
