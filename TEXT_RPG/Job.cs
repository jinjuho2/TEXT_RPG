using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Job
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }
        public float Attack {  get; set; }
        public float Defense { get; set; }
        public int speed { get; set; }
        public string skill {  get; set; }
        public List<Skill> SkillList { get; set; }
        public void Init()
        {
            SkillList = new List<Skill>();
            string[] a = skill.Split(',');
            foreach (string n in a)
            {
                SkillList.Add(DataManager.Instance().MakeSkill(int.Parse(n)));
            }

        }
        public string showInfo()
        {
            SkillList = new List<Skill>();
            string[] a = skill.Split(',');
            foreach (string n in a)
            {
                SkillList.Add(DataManager.Instance().MakeSkill(int.Parse(n)));
            }

            string str ="\n";
            str += $"HP: {MaxHP}\n";
            str += $"MP: {MaxMP}\n";
            str += $"ATK: {Attack}\n";
            str += $"DEF: {Defense}\n";
            str += $"SPEED: {speed}\n";
            foreach(Skill s in SkillList)
            {
                str += $"{s.Name}: {s.Description} DMG: {s.Damage} {s.TargetNum}명\n";
            }
            return str;
        }
    }
}
