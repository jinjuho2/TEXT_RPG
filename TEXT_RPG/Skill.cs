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
        public int ID { get; set; }
        public string Name { get; set; } // 스킬 이름
        public string Description { get; set; } // 설명
        public int MPCost { get;set; } // 마나 소모량
        public float Damage { get; set; } // 스킬 데미지
        public TYPE Type { get; set; } // 스킬 타입
        public int TargetNum { get;     set; }// 스킬 타겟 마릿수
        public int Critical { get; set; } //크리티컬 확률

        public Skill (int _Id, string _name, string _description, int _mPCost, float _damage, TYPE _type, int _targetNum, int _critical = 0)
        {
            ID = _Id;
            Name = _name;
            MPCost = _mPCost;
            Description = _description;
            Damage = _damage;
            Type = _type;
            TargetNum = _targetNum;
            Critical = _critical;
        }

        public string show()
        {
            string s = "";
            s=($" {Name} 피해량 : {Damage} 타겟수:{TargetNum} (MP: {MPCost})");
            return s;
        }



    }

}
