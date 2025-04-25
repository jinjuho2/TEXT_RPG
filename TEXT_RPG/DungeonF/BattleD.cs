using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class BattleD : Dungeon
    {
        List<Monster> monsters { get; set; }
        BattleManager bm { get; set; }
        public override void Init(int i)
        {
            base.Init(i);
            bm= new BattleManager();
            monsters = new List<Monster>();
            GetMonsterList();
        }
        public override bool Run(Player player)
        {
            return bm.Battle(player,monsters);

        }
        public void GetMonsterList()//층수에 맞는 몬스터 리스트 생성
        {

           
            Random random = new Random();
            int monsterCounts = random.Next(1, 4);
            int monsterID;
            if (nowFloor >= 1 && nowFloor < 10)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(1, 3);
                    monsters.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
            else if (nowFloor >= 11 && nowFloor <= 20)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(4, 6);
                    monsters.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
            else if (nowFloor >= 21 && nowFloor <= 30)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(7, 9);
                    monsters.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
            else if (nowFloor >= 31 && nowFloor <= 40)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(10, 12);
                    monsters.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
            else if (nowFloor >= 41 && nowFloor <= 50)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(13, 15);
                    monsters.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
           
        }
    }
}
