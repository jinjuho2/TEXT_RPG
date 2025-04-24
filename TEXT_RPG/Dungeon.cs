using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TEXT_RPG;
using static TEXT_RPG.DungeonManager;

namespace TEXT_RPG
{
    class Dungeon
    {
        public int MonsterCount { get; set; }

        Monster monster;
        BattleManager battleManager = new BattleManager();

        public List<Monster> GetMonsterList(int nowFloor)//층수에 맞는 몬스터 리스트 생성
        {
            List<Monster> list = new List<Monster>();
            list.Add(DataManager.Instance().makeMonster(1));
            Random random = new Random();
            int monsterCounts = random.Next(1, 4);
            int monsterID;
            if( nowFloor >=1 &&  nowFloor < 10 )
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next( 1, 3 );
                    list.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
            else if (nowFloor >= 11 && nowFloor <= 20)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(4, 6);
                    list.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
            else if (nowFloor >= 21 && nowFloor <= 30)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(7, 9);
                    list.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
            else if (nowFloor >= 31 && nowFloor <= 40)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(10, 12);
                    list.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
            else if (nowFloor >= 41 && nowFloor <= 50)
            {
                for (int i = 0; i < monsterCounts; i++)
                {
                    monsterID = random.Next(13, 15);
                    list.Add(DataManager.Instance().makeMonster(monsterID));
                }
            }
           return list;
        }
        public Monster GetBossMonsterList(int nowFloor)
        { 
            int monsterID;
            if (nowFloor == 10)
            {
                monsterID = 16;
                monster = DataManager.Instance().makeMonster(monsterID);
            }
            else if (nowFloor == 20)
            {
                monsterID = 17;
                monster = DataManager.Instance().makeMonster(monsterID);
            }
            else if (nowFloor == 30)
            {
                monsterID = 18;
                monster = DataManager.Instance().makeMonster(monsterID);
            }
            else if (nowFloor ==40)
            {
                monsterID = 19;
                monster = DataManager.Instance().makeMonster(monsterID);
            }
            else if (nowFloor == 50)
            {
                monsterID = 20;
                monster = DataManager.Instance().makeMonster(monsterID);
            }
            return monster;
        }
        public void GOEventF(Player player)//이벤트방
        {
            Console.WriteLine("이벤트 던전 입장");
            DungeonEvent dungeonEvent = new DungeonEvent();
            Random random = new Random();
            int Num = random.Next(0,5);
            switch(Num)
            {
                case 0:
                    dungeonEvent.TrainingF();
                    break;
                case 1:
                    dungeonEvent.AlterF();
                    break;
                case 2:
                    dungeonEvent.MysteryMerchant();
                    break;
                case 3:
                    dungeonEvent.StatBoost();
                    break;
                case 4:
                    dungeonEvent.NothingF();
                    break;
            }
        }
        public void GoRestF(Player player)//휴식층. 쉼터 아님 주의
        {
            Console.WriteLine("휴식층 입장");
            Random random = new Random();
            int fHeal = random.Next(20, 50);

            if (player.TotalMaxHP > player.CurrentHP + (player.TotalMaxHP / 100 * fHeal))// 최대체력이 회복될 체력보다 클때
            {
                player.CurrentHP = player.CurrentHP + (player.TotalMaxHP / 100 * fHeal);
                Console.WriteLine($"충분한 휴식을 취해 체력이 {fHeal}%만큼 회복되었습니다.");
            }
            else
            {
                player.CurrentHP = player.TotalMaxHP;
                Console.WriteLine("충분한 휴식을 취해 체력이 모두 회복되었습니다.");

                player.CurrentHP = player.TotalMaxHP;
            }
        }
        public bool GOBossF(Player player, List<Monster> list)//보스방
        {
            Console.WriteLine("보스방 입장");
            bool Win = battleManager.Battle(player);
            if (Win)
            {
                Console.WriteLine("보상줌");
                //VictoryScene(player);
                return true;
            }
            else
            {
                Console.WriteLine("패배");
                //LoseScene(player);
                return false;
            }
        }
        public void GORewardF(Player player)//보상방
        {
            Console.WriteLine("보상방 입장");
            ItemManager itemManager = new ItemManager();
            Random random = new Random();
            int itemNum = random.Next(0,itemManager.items.Count);
            Item gift = itemManager.items[itemNum];

            player.GetItem(gift);
        }
        public bool GoBattletF(Player player, List<Monster> list)
        {
            Console.WriteLine("던전 입장");
            //bool Win = battleManager.Battle(player, list);
            //if (Win)
            //{   
            //    Console.WriteLine("보상줌");
            //    VictoryScene(player);
            //    return true;
            //}
            //else
            //{
            //    Console.WriteLine("패배");
            //    LoseScene(player);
            //    return false;
            //}
            return false;

        }
        public void GoSaveF(Player player)//쉼터 = n1층 n은 1~4
        {
            Console.WriteLine("쉼터입니다");
            player.CurrentHP = player.TotalMaxHP;
            Console.WriteLine("충분한 휴식을 취해 체력이 모두 회복되었습니다.");

        }
    }
}
