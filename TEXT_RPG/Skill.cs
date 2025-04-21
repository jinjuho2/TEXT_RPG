using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class Skill
    {
        public string Name; // 스킬 이름
        public string Description; // 설명
        public int MPCost; // 마나 소모량
        public float Damage; // 스킬 데미지

        public Skill(string name, string description, int damage)
        {
            Name = name;
            Description = description;
            Damage = damage;
        }

        public float Cast()
        {
            Console.WriteLine($"{Name} 스킬 사용! 데미지: {Damage}");
            // 실제 게임 로직에서는 여기에 스킬 효과 구현
            return Damage;
        }
    }
}
