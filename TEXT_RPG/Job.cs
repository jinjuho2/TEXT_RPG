using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Job
    {
        Skill skill = new Skill();
        public string Name { get; set; } //직업이름
        public int BaseHP { get; set; } //시작HP
        public int BaseMP { get; set; } //시작MP
        public int BaseAttack { get; set; } //시작 공격력
        public int BaseDefense { get; set; } // 시작 방어력
        public List<Skill> JobSkills { get; set; } //가진 스킬 목록

        public Job MakeJob(string name, int baseHP, int baseMP, int baseAttack, int baseDefense, List<Skill> jobSkills)
        {
            return new Job
            {
                Name = name,
                BaseHP = baseHP,
                BaseMP = baseMP,
                BaseAttack = baseAttack,
                BaseDefense = baseDefense,
                JobSkills = jobSkills,
            };
        }
        public void ApplyTo(Player player)
        {
            player.Job = this;
            player.MaxHP = BaseHP;
            player.MaxMP = BaseMP;
            player.Attack = BaseAttack;
            player.Defense = BaseDefense;
            player.skills = JobSkills;
        }

        public void StartWizard()
        {
            Job wizard = MakeJob("마법사", 10, 20, 10, 10, skill.StartWizardSkill());
            wizard.ApplyTo(Player.Instance);
        }
        public void StartPalad()
        {
            Job wizard = MakeJob("전사", 10, 20, 10, 10, skill.StartPaladinSkill());
            wizard.ApplyTo(Player.Instance);
        }
        public void StartSheep()
        {
            Job wizard = MakeJob("도적", 10, 20, 10, 10, skill.StartSheepinSkill());
            wizard.ApplyTo(Player.Instance);
        }
        public void StartArcher()
        {
            Job wizard = MakeJob("궁수", 10, 20, 10, 10, skill.StartArcherinSkill());
            wizard.ApplyTo(Player.Instance);
        }
        public void StartPiratein()
        {
            Job wizard = MakeJob("해적", 10, 20, 10, 10, skill.StartPirateinSkill());
            wizard.ApplyTo(Player.Instance);
        }
    }

}
