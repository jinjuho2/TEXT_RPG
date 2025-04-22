using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Unit
    {
        public int ID { get; set; } //유닛 별 ID 
        public string Name { get; set; } // 플레이어 이름
        public Jop Job { get; set; } // 플레이어 직업
        public int Level { get; set; } // 플레이어 레벨
        public int Exp { get; set; } // 현재 경험치
        public float Attack { get; set; } // 기본 공격력
        public float Defense { get; set; } // 기본 방어력
        public int MaxHp { get; set; } // 최대 체력
        public int CurrentHP { get; set; } // 현재 체력
        public int MaxMp { get; set; } // 최대 마나
        public int CurrentMP { get; set; } // 현재 마나
        public int Gold { get; set; } // 소지 골드
        public int Speed { get; set; } // 속도... 선턴 잡습니다...
        public bool IsWeak { get; set; } // 약점 찌름 당함...

        public TYPE WeakType { get; set; }
     
        
        public bool IsAlive => CurrentHP > 0;

        public List<Item> items;
        List<Skill> skills;
  
        public virtual AttackData AttackM()
        {
            Random random = new Random();
          
            int calAtk = random.Next((int)Attack*90/100,(int)Attack*110/100);
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
       
        public virtual bool TakeDamage(int atkD)
        {


            CurrentHP -= atkD;
            
            if (CurrentHP <= 0) {
                Dead();
                return true;
            }
            return false;
        }
        public virtual void ShowSimple()
        {
            if (!IsAlive) { 
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Lv.{Level} {Name} 기절");
            Console.ResetColor(); 
          }
            else Console.WriteLine($"Lv.{Level} {Name} HP {CurrentHP}/{MaxHp}");
        }
        private void Dead() {
            Console.WriteLine($"{Name} 기절");
        }

    }
}
