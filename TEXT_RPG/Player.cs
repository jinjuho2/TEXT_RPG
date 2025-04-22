using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Player

    
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
        public Job Job { get; set; } // 플레이어 직업
        public int Level { get; set; } // 플레이어 레벨
        public int Exp { get; set; } // 현재 경험치

        public float TotalAttack => Attack + CalculateEquippedBonuses().Attack; //최종 공격력
        public float TotalDefense => Defense + CalculateEquippedBonuses().Defense; //최종 방어력
        public float Attack { get; set; } // 기본 공격력
        public float Defense { get; set; } // 기본 방어력

        public int TotalMaxHP => MaxHP + CalculateEquippedBonuses().MaxHP; //최종 최대 체력
        public int MaxHP { get; set; } // 기본 최대 체력
        public int CurrentHP { get; set; } // 현재 체력
        public int TotalMaxMP => MaxMP + CalculateEquippedBonuses().MaxMP; //최종 최대 마나
        public int MaxMP { get; set; } // 기본 최대 마나
        public int CurrentMP { get; set; } // 현재 마나

        public int Gold { get; set; } // 소지 골드
        public float Evasion { get; set; } // 회피율
        public float Critical { get; set; } // 치명타율
        public int Speed { get; set; } // 속도... 선턴 잡습니다...
        public bool IsWeak { get; set; } // 약점 찌름 당함...
        public TYPE WeakType { get; set; } //약점 : 리스트가 나을수도


        public bool IsAlive => CurrentHP > 0; //살아있나 확인...

        public List<Item> equippedItems = new();//착용한 아이템 리스트
        public List<Item> inventory = new(); // 인벤토리 아이템 리스트
        public List<Skill> skills = new(); // 보유 스킬 리스트

        public void ShowStat() //플레이어 스텟 보여주기
        {
            BonusStat bonus = CalculateEquippedBonuses();

            Console.WriteLine($"Lv.{Level}");
            Console.WriteLine($"{Name} ( {Job.Name} )");
            Console.WriteLine($"공격력 : {TotalAttack} (+{bonus.Attack})");
            Console.WriteLine($"방어력 : {TotalDefense} (+{bonus.Defense})");
            Console.WriteLine($"HP : {CurrentHP} / {TotalMaxHP} (+{bonus.MaxHP})");
            Console.WriteLine($"MP : {CurrentMP} / {TotalMaxMP} (+{bonus.MaxMP})");
            Console.WriteLine($"회피율 : {Evasion} (+{bonus.Evasion})");
            Console.WriteLine($"치명타율 : {Critical} (+{bonus.Critical})");
            Console.WriteLine($"Gold : {Gold} G");
        }
        public BonusStat CalculateEquippedBonuses()//플레이어 장착 아이템 능력치 총합 계산
        {
            BonusStat bonus = new();

            foreach (var item in equippedItems)
            {
                switch (item.Type)
                {
                    case "weapon":
                        bonus.Attack += item.Atk;
                        bonus.Critical += item.Critical;
                        break;
                    case "armor":
                        bonus.Defense += item.Def;
                        bonus.Evasion += item.Dodge;
                        bonus.MaxHP += item.HP;
                        bonus.MaxMP += item.MP;
                        break;
                    default:
                        bonus.Evasion += item.Dodge;
                        bonus.Critical += item.Critical;
                        bonus.MaxHP += item.HP;
                        bonus.MaxMP += item.MP;
                        break;
                }
            }

            return bonus;
        }

        public void ShowInventory() { }
        public void ShowSkillList() //플레이어 스킬 목록 표시
        {
            Console.WriteLine($"[{Name}]의 스킬 목록:");
            for (int i = 0; i < skills.Count; i++)
            {
                Skill skill = skills[i];
                Console.WriteLine($"{i + 1}. {skill.Name} - {skill.Description} (MP: {skill.MPCost})");
            }
        }
        public void LevelUp() //플레이어 레벨업
        {
            Level++;
            Attack += 1;
            Defense += 1;
            MaxHP += 1;
            MaxMP += 1;
            CurrentHP = TotalMaxHP;
            CurrentMP = TotalMaxMP;
            //레벨업시 추가 요소 여기다 작성

        }
        public void TakeDamage(int damage) // 플레이어 피격
        {
            CurrentHP -= damage;
            if (CurrentHP < 0)
            {
                Dead();
            }
        }
        public void Dead()//플레이어 죽음
        {
            //마을(타이틀)로 돌아감
            //패널티가 있다면 여기에

        }

        public Skill UseSkill()//스킬 선택 후 사용
        {
            if (skills == null || skills.Count == 0)
            {
                Console.WriteLine("사용 가능한 스킬이 없습니다.");
                return null;
            }
            List<int> validInputs = new List<int>();
            for (int i = 0; i < skills.Count; i++)
            {
                Skill skill = skills[i];
                Console.WriteLine($"{i + 1}. {skill.Name} 피해량 : {(int)TotalAttack * skill.Damage} 타겟수:{skill.TargetNum} (MP: {skill.MPCost})");
                validInputs[i] = i + 1;

            }
            int a = GameManager.GetValidInput(validInputs) - 1;

            return skills[a];
        }

        public void GetItem(Item item)//아이템 획득
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
