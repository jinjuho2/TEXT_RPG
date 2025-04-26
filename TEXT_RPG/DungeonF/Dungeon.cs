using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TEXT_RPG;

namespace TEXT_RPG
{
    abstract class Dungeon :IShow
    {
        public int MonsterCount { get; set; }
        public int nowFloor { get; set; }

        public string name;
        public string info;

        public virtual void Init(int i) {
            nowFloor = i;
        }
        

        public abstract bool Run(Player player);
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
        
        //public bool GOBossF(Player player, List<Monster> list)//보스방
        //{
        //    Console.WriteLine("보스방 입장");
        //    bool Win = battleManager.Battle(player);
        //    if (Win)
        //    {
        //        Console.WriteLine("보상줌");
        //        //VictoryScene(player);
        //        return true;
        //    }
        //    else
        //    {
        //        Console.WriteLine("패배");
        //        //LoseScene(player);
        //        return false;
        //    }
        //}
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
        public void GoShopF(Player player)//상점층 추가 필요?
        {
            Console.WriteLine("상점입니다.");
            
        }

        public string show(int mode)
        {
            return name;
        }

        public string showDetail()
        {
            return info;
        }
    }
}
