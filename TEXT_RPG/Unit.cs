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

        public virtual bool Attack(Unit enemy)
        {
            Random random = new Random();
            if (random.Next(0, 100) < 10)
            {
                Console.Write($"{name}이(가) {enemy.GetName()}을(를) 공격했지만 회피!");
                return false;
                
            }
            Console.Write($"{name}이(가) {enemy.GetName()}을(를) 공격");
        
            int calAtk = random.Next((int)atk*90/100,(int)atk*110/100);
            if (random.Next(0, 100) < 15)
            {
                calAtk =(int)(calAtk* 1.6f);
                Console.WriteLine("-치명타!");
            }
            Console.WriteLine();
            return enemy.Damaged(calAtk);
        }
        public string GetName()
        {
            return name;
        }
        public virtual bool Damaged(float atkD)
        {
            hp -= atkD;
            Console.WriteLine($"{name}은(는) {atkD} 데미지를 입었다");
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
