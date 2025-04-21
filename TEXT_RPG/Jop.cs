using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Jop
    {
        public string Name { get; set; } //직업이름
        public int BaseHP { get; set; } //시작HP
        public int BaseMP { get; set; } //시작MP
        public int BaseAttack { get; set; } //시작 공격력
        public int BaseDefense { get; set; } // 시작 방어력
        public List<Skill> JobSkills { get; set; } //가진 스킬 목록


    }
}
