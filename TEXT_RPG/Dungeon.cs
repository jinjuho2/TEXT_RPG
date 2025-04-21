using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Dungeon
    {
        List<Monster> monsters;
        string name;
        public Dungeon()
        {
            monsters = new List<Monster>();
        }
        public void SetMonster(Monster monster)
        {
            monsters.Add(monster);
        }
        public List<Monster> SpawnMonster()
        {
            return monsters;
        }

    }
}
