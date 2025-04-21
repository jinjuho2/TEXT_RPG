using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Unit
    {
        protected string name;
       protected float atk;
       protected float def;
        protected float maxHp;
        protected float hp;
        protected float mP;
        protected int turn;
        protected int lvl;
        public bool IsAlive => hp > 0;

        List<Item> items;
        List<Skill> skill;

        public bool Attack(Unit enemy)
        {
            Console.WriteLine($"{name}이(가) {enemy.GetName()}을(를) 공격");
            Random random = new Random();
            int calAtk = random.Next((int)atk*90/100,(int)atk*110/100);
            return enemy.Damaged(calAtk);
        }
        public string GetName()
        {
            return name;
        }
        public bool Damaged(float atkD)
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
