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
        public TYPE Type { get; set; } // 스킬 타입
        public int TargetNum {  get; set; }// 스킬 타겟 마릿수

        public int Critical {  get; set; } //크리티컬 확률



        public Skill MakeSkill(string name, string description, int mPCost, float damage, TYPE type, int targetNum ,int critical)
        {
            return new Skill
            {
                Name = name,
                Description = description,
                MPCost = mPCost,
                Damage = damage,
                Type = type,
                TargetNum = targetNum,
                Critical = critical
            };
            
        }

        public List<Skill> StartWizardSkill()//마법사 기본스킬
        {
            List<Skill> list = new List<Skill>();
            list.Add(MakeSkill("기본공격", "기본 공격이다", 0, 10, TYPE.Normal, 1, 10));
            list.Add(MakeSkill("파이어볼", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1,10));
            list.Add(MakeSkill("파이어볼2", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1,10));
            return list;

        }
        public List<Skill> StartPaladinSkill()//전사 기본스킬
        {
            List<Skill> list = new List<Skill>();
            list.Add(MakeSkill("기본공격", "기본 공격이다", 0, 10, TYPE.Normal, 1, 10));
            list.Add(MakeSkill("파이어볼", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1, 10));
            list.Add(MakeSkill("파이어볼2", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1, 10));
            return list;
        }
        public List<Skill> StartSheepinSkill()//도적 기본스킬
        {
            List<Skill> list = new List<Skill>();
            list.Add(MakeSkill("기본공격", "기본 공격이다", 0, 10, TYPE.Normal, 1, 10));
            list.Add(MakeSkill("파이어볼", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1, 10));
            list.Add(MakeSkill("파이어볼2", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1, 10));
            return list;
        }
        public List<Skill> StartArcherinSkill()//궁수 기본스킬
        {
            List<Skill> list = new List<Skill>();
            list.Add(MakeSkill("기본공격", "기본 공격이다", 0, 10, TYPE.Normal, 1, 10));
            list.Add(MakeSkill("파이어볼", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1, 10));
            list.Add(MakeSkill("파이어볼2", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1, 10));
            return list;
        }
        public List<Skill> StartPirateinSkill()//해적 기본스킬
        {
            List<Skill> list = new List<Skill>();
            list.Add(MakeSkill("기본공격", "기본 공격이다", 0, 10, TYPE.Normal, 1, 10));
            list.Add(MakeSkill("파이어볼", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1, 10));
            list.Add(MakeSkill("파이어볼2", "불덩이를 던지는 간단한 마법이다", 10, 10, TYPE.Fire, 1, 10));
            return list;
        }


    }

}
