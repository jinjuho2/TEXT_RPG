using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class BossD : Dungeon
    {
        Monster boss;

        BattleManager bm { get; set; }
        public Monster GetBossMonsterList()
        {
            int monsterID;
            if (nowFloor == 10)
            {
                monsterID = 16;
                boss = DataManager.Instance().makeMonster(monsterID);
            }
            else if (nowFloor == 20)
            {
                monsterID = 17;
                boss = DataManager.Instance().makeMonster(monsterID);
            }
            else if (nowFloor == 30)
            {
                monsterID = 18;
                boss = DataManager.Instance().makeMonster(monsterID);
            }
            else if (nowFloor == 40)
            {
                monsterID = 19;
                boss = DataManager.Instance().makeMonster(monsterID);
            }
            else if (nowFloor == 5)
            {
                monsterID = 20;
                boss = DataManager.Instance().makeMonster(monsterID);
            }
            return boss;
        }

        public override void Init(int i)
        {
            base.Init(i);
            bm = new BattleManager();
            boss = GetBossMonsterList();
            name = "보스 방";
            info = "보스방 입니다.";
          
        }

        public override bool Run(Player player)
        {
            List<Monster> monster = new List<Monster>();
            monster.Add(boss);
            return bm.Battle(player, monster);
        }
    }
}
