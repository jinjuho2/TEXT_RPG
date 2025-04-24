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



        internal class Dungeon
        {
            Player player;
            BattleManager bm;

            public void DungeonRun(Player _player, DungeonManager manager)
            {
                player = _player;
                bm = new BattleManager();
                bool isEnd = false;

                isEnd = false;
                while (!isEnd)
                {                          //이 안에 던전의 문구를 넣으시면 됩니다.
                    bool isWin = bm.Battle(player); //배틀매니저의 실행입니다. 여기에 특정값(ex: 몬스터들,방 특성)들을 넣어주시면 됩니다.
                                                    //또한 배틀씬을 보고 싶지 않은 경우 bm.Battle을 보고 싶은 값으로 변경해주세요 (ex: 승리시 true 패배시 false)
                    if (isWin) //승리시 true 패배시 false. 만약 도주나 다른 값을 넣고 싶으면 말씀해주세요 enum등으로 변경하면 됩니다.
                    {
                        isEnd = true;
                        VictoryScene(manager);
                        //승리시... 기타등등
                    }
                    else
                    {
                        isEnd = true;
                        LoseScene();
                    }
                }

            }

            private void VictoryScene(DungeonManager manager)
            {
                Console.WriteLine("Victory!");
                Console.WriteLine($"{player.Name} | HP: {player.CurrentHP}");
                manager.Warp();
            }

            private void LoseScene()
            {
                Console.WriteLine("You Lose!");
                Console.WriteLine("사망하셨습니다.");
                Console.WriteLine("0. 처음으로 돌아가기");
            }
        }

    }

    //interface IDungeonFloor
    //{
    //    void Enter(Player player, DungeonManager manager);
    //}
    //class BattleFloor : IDungeonFloor
    //{
    //    public void Enter(Player player, DungeonManager manager)
    //    {
    //        Console.WriteLine("전투 층입니다!");
    //        BattleManager bm = new BattleManager();
    //        bool isWin = bm.Battle(player);

//        if (isWin)
//        {
//            Console.WriteLine("Victory!");
//            Console.WriteLine($"{player.Name} | HP: {player.CurrentHP}");
//            manager.Warp();
//        }
//        else
//        {
//            Console.WriteLine("You Lose...");
//            Console.WriteLine("게임 오버");
//            // 필요 시 메인화면으로 돌아가는 로직 추가
//        }
//    }
//}

//    class EventFloor : IDungeonFloor
//    {
//        public void Enter(Player player, DungeonManager manager)
//        {
//            Console.WriteLine("이벤트 층에 도착했습니다!");
//            Console.WriteLine("낡은 상자가 있습니다. 열겠습니까?");
//            Console.WriteLine("1. 연다   2. 그냥 간다");

//            int choice = int.Parse(Console.ReadLine());

//            if (choice == 1)
//            {
//                Random rand = new Random();
//                if (rand.Next(2) == 0)
//                {
//                    Console.WriteLine("상자 안에서 골드를 발견했습니다! +100G");
//                    player.Gold += 100;
//                }
//                else
//                {
//                    Console.WriteLine("함정이 터졌습니다! HP -20");
//                    player.CurrentHP -= 20;
//                }
//            }
//            else
//            {
//                Console.WriteLine("무사히 지나갑니다.");
//            }

//            manager.Warp();
//        }
//    }

//    // 보상층
//    class RewardFloor : IDungeonFloor
//    {
//        public void Enter(Player player, DungeonManager manager)
//        {
//            Console.WriteLine("보상 층입니다!");


//            manager.Warp();
//        }
//    }

//    // 쉼터층
//    class RestFloor : IDungeonFloor
//    {
//        public void Enter(Player player, DungeonManager manager)
//        {
//            Console.WriteLine("쉼터에 도착했습니다. 체력을 회복합니다!");
//            player.CurrentHP = player.MaxHP;

//            manager.Warp();
//        }
//    }

//    // 보스층 (옵션)
//    class BossFloor : IDungeonFloor
//    {
//        public void Enter(Player player, DungeonManager manager)
//        {
//            Console.WriteLine("보스가 등장했습니다!!");
//            BattleManager bm = new BattleManager();
//            bool isWin = bm.Battle(player, isBoss: true);

//            if (isWin)
//            {
//                Console.WriteLine("보스를 처치했습니다!");
//                manager.Warp();
//            }
//            else
//            {
//                Console.WriteLine("보스에게 패배했습니다...");
//            }
//        }
//    }

//    // 마을층 (옵션)
//    class TownFloor : IDungeonFloor
//    {
//        public void Enter(Player player, DungeonManager manager)
//        {
//            Console.WriteLine("당신은 마을에 도착했습니다.");
//            Console.WriteLine("1. 회복하기\n2. 상점 가기\n3. 다음 층으로 진행");

//            int input = int.Parse(Console.ReadLine());
//            switch (input)
//            {
//                case 1:
//                    player.CurrentHP = player.MaxHP;
//                    Console.WriteLine("회복되었습니다!");
//                    break;
//                case 2:
//                    Console.WriteLine("상점은 아직 구현 중입니다.");
//                    break;
//                case 3:
//                    manager.Warp();
//                    break;
//            }
//        }
//    }
//}






//    private void VictoryScene(DungeonManager manager)
//        {
//            Console.WriteLine("Victory!");
//            Console.WriteLine($"{player.Name} | HP: {player.CurrentHP}");
//            manager.Warp();
//        }

//        private void LoseScene()
//        {
//            Console.WriteLine("You Lose!");
//            Console.WriteLine("사망하셨습니다.");
//            Console.WriteLine("0. 처음으로 돌아가기");
//        }
//    }


//}
//public void DungeonRun(Player _player, DungeonManager manager)
//{
//    player = _player;
//    bm = new BattleManager();
//    bool isEnd = false;

//    isEnd = false;
//    while (!isEnd)
//    {                          //이 안에 던전의 문구를 넣으시면 됩니다.
//        bool isWin = bm.Battle(player); //배틀매니저의 실행입니다. 여기에 특정값(ex: 몬스터들,방 특성)들을 넣어주시면 됩니다.
//                                        //또한 배틀씬을 보고 싶지 않은 경우 bm.Battle을 보고 싶은 값으로 변경해주세요 (ex: 승리시 true 패배시 false)
//        if (isWin) //승리시 true 패배시 false. 만약 도주나 다른 값을 넣고 싶으면 말씀해주세요 enum등으로 변경하면 됩니다.
//        {
//            isEnd = true;
//            VictoryScene(manager);
//            //승리시... 기타등등
//        }
//        else
//        {
//            isEnd = true;
//            LoseScene();
//        }
//    }

//}