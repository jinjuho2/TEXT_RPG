using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{

    
    internal class Player 
    {
        private static Player instance;
        public static Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();
                return instance;
            }
        }



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
        public TYPE WeakType { get; set; } //약점 : 리스트가 나을수도

        public string WeaponEquipped { get; set; }// 장착 여부  // 추가
        public string Armor1Equipped { get; set; }// 장착 여부  // 추가
        public string Armor2Equipped { get; set; }// 장착 여부  // 추가
        public string Armor3Equipped { get; set; }// 장착 여부  // 추가
        public string Armor4Equipped { get; set; }// 장착 여부  // 추가


        public bool IsAlive => CurrentHP > 0; //살아있나 확인...


        public List<Item> inventory = new(); // 인벤토리 아이템 리스트
        public List<Skill> skills = new(); // 보유 스킬 리스트

        public void ShowStat() { }
        public void ShowInventory() { }
        public void ShowSkillList()
        {
            Console.WriteLine($"[{Name}]의 스킬 목록:");
            for (int i = 0; i < skills.Count; i++)
            {
                Skill skill = skills[i];
                Console.WriteLine($"{i + 1}. {skill.Name} - {skill.Description} (MP: {skill.MPCost})");
            }
        }
        public void LevelUp() { }
        public void TakeDamage(int damage) { }
        public void Dead()
        {

        }
        //public void UseItem(Item item)
        //{
        //    if(item.Type == "accessory")
        //    {
        //        inventory.Remove(item);
        //        CurrentHp = CurrentHp+item.
        //    }

            
        //}
        public string UseSkill(Skill skill)
        {
            return $"{skill.Type}+{skill.Damage}+{skill.TargetNum}";
        }

        public void GetItem (Item item)
        {
            inventory.Add(item);
        }

        public virtual AttackData AttackM() //공격 메소드... 수정하셔도 괜찮습니다.
        {
            Random random = new Random();

            int calAtk = random.Next((int)Attack * 90 / 100, (int)Attack * 110 / 100); //공격 범위 지정
            AttackData ad;
            if (random.Next(0, 100) < 15) //크리티컬수치 여기서 교체 가능합니다.
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

    }

}
