using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    enum TYPE
    {
        Normal, Fire, Water, Grass, Dark, Light
    }
    internal class Skill
    {
        public string Name { get; set; } // 스킬 이름
        public string Description { get; set; } // 설명
        public int MPCost { get; set; } // 마나 소모량
        public float Damage { get; set; } // 스킬 데미지
        public string Type { get; set; } // 스킬 데미지
        public int TargetNum {  get; set; }// 스킬 타겟 마릿수

        public Skill(string name, string description, int damage)
        {
            Name = name;
            Description = description;
            Damage = damage;
        }

        public void MakeSkill(string name, string description, int mPCost, float damage, string Type, int TargetNum)
        {
            Name = name;
            Description = description;
            MPCost = mPCost;
            Damage = damage;
        }
        


    }
    
}
