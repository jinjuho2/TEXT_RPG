using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Player
    {
        public string Name; // 플레이어 이름
        public Jop Job; // 플레이어 직업
        public int Level; // 플레이어 레벨
        public int Exp; // 현재 경험치
        public float Attack; // 기본 공격력
        public float Defense; // 기본 방어력
        public int MaxHp; // 최대 체력
        public int CurrentHp; // 현재 체력
        public int MaxMp; // 최대 마나
        public int CurrentMp; // 현재 마나
        public int Gold; // 소지 골드


        public List<Item> Inventory = new(); // 인벤토리 아이템 리스트
        public List<Skill> Skills = new(); // 보유 스킬 리스트

        public void ShowStat() { }
        public void ShowInventory() { }
        public void ShowSkillList()
        {
            Console.WriteLine($"[{Name}]의 스킬 목록:");
            for (int i = 0; i < Skills.Count; i++)
            {
                Skill skill = Skills[i];
                Console.WriteLine($"{i + 1}. {skill.Name} - {skill.Description} (MP: {skill.MPCost})");
            }
        }
        public void LevelUp() { }
        public void TakeDamage(int damage) { }
        public void AttackMonster(Monster monster) { }
        public void UseItem(Item item) { }
        public void UseSkill(Skill skill, Monster target) { }


    }
}
