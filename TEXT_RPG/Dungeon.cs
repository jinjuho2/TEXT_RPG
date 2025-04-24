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

        private Player player;
        private DungeonManager manager;
        //private BattleManager bm;

        public Dungeon(Player _player, DungeonManager _manager)
        {
            player = _player;
            manager = _manager;
        }
        public void EnterFloor(IDungeonFloor floor)
        {
            floor.Enter(player, manager);
        }
    }

    interface IDungeonFloor
    {
        void Enter(Player player, DungeonManager manager);
    }
    class BattleFloor : IDungeonFloor
    {
        public void Enter(Player player, DungeonManager manager)
        {
            Console.WriteLine("전투 층입니다!");
            BattleManager bm = new BattleManager();
            bool isWin = bm.Battle(player);

            if (isWin)
            {
                Console.WriteLine("Victory!");
                Console.WriteLine($"{player.Name} | HP: {player.CurrentHP}");
                manager.Warp();
            }
            else
            {
                Console.WriteLine("You Lose...");
                Console.WriteLine("게임 오버");
                // 필요 시 메인화면으로 돌아가는 로직 추가
            }
        }
    }

    class EventFloor : IDungeonFloor
    {
        private Random rand = new Random();

        public void Enter(Player player, DungeonManager manager)
        {
            Console.WriteLine("이벤트 층에 도착했습니다!");
            Console.WriteLine("무언가 일어납니다...");

            // 5개의 이벤트 배열
            Action<Player>[] events = new Action<Player>[]
            {
            GoldChest,
            PoisonTrap,
            MysteryMerchant,
            StatBoost,
            EmptyRoom
            };

            // 랜덤 선택 및 실행
            int index = rand.Next(events.Length);
            events[index](player); // 선택된 이벤트 실행

            manager.Warp();
        }

        private void GoldChest(Player player)
        {
            Console.WriteLine("✨ 반짝이는 상자를 발견했습니다!");
            Console.WriteLine("골드를 100 얻었습니다!");
            player.Gold += 100;
        }

        private void PoisonTrap(Player player)
        {
            Console.WriteLine("💥 함정! 독 가스가 터졌습니다!");
            int damage = 20;
            player.CurrentHP -= damage;
            Console.WriteLine($"HP가 {damage} 감소했습니다.");
        }

        private void MysteryMerchant(Player player)
        {
            Console.WriteLine("🧙‍♂️ 수상한 상인을 만났습니다.");
            Console.WriteLine("강화석을 공짜로 주고 떠났습니다.");
            player.Items.Add("강화석");
        }

        private void StatBoost(Player player)
        {
            Console.WriteLine("🔮 마법진 위에 섰습니다. 신비한 힘이 당신을 감쌉니다!");
            player.MaxHP += 10;
            Console.WriteLine("최대 체력이 10 증가했습니다!");
        }

        private void EmptyRoom(Player player)
        {
            Console.WriteLine("아무것도 없습니다... 조용합니다.");
        }
    }

    // 보상층
    class RewardFloor : IDungeonFloor//ㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    {
        public void Enter(Player player, DungeonManager manager)
        {
            Console.WriteLine("보상 층입니다.");
            //아이템 배열중 랜덤 하나
            Random random = new Random();
            int fReward = random.Next(300,800);
            player.Gold += fReward;
            Console.WriteLine($"{fReward}골드를 획득하셨습니다.");//+ item

            manager.Warp();
        }
    }

    // 쉼터층
    class RestFloor : IDungeonFloor
    {
//        public void RestFloor()
//                {
//                    if (player.CurrentHP >= player.MaxHP / 2)//플레이어의 현재체력이 50%보다 낮다면 
//                    {
//                        player.CurrentHP += player.MaxHP / 2;
//                        Console.WriteLine("충분한 휴식을 취해 체력이 회복되었습니다.");
//                    }
//                    else//플레이어의 체력이 50% 이상이면? 현재체력 + (최대체력-현재체력) = 풀피
//                    {
//                        player.CurrentHP += (player.MaxHP -= player.CurrentHP);
//                        Console.WriteLine("충분한 휴식을 취해 체력이 모두 회복되었습니다.");
        public void Enter(Player player, DungeonManager manager)
        {
            Console.WriteLine("쉼터에 도착했습니다. 체력을 회복합니다!");

            Random random = new Random();
            int fHeal = random.Next(20, 50);

            if (player.MaxHP > player.CurrentHP + (player.MaxHP/100*fHeal))// 최대체력이 회복될 체력보다 클때
            {
                player.CurrentHP = player.CurrentHP + (player.MaxHP / 100 * fHeal);
                Console.WriteLine($"충분한 휴식을 취해 체력이 {fHeal}%만큼 회복되었습니다.");
            }
            else
            {
                player.CurrentHP = player.MaxHP;
                Console.WriteLine("충분한 휴식을 취해 체력이 모두 회복되었습니다.");


                player.CurrentHP = player.MaxHP;

            
            }
            manager.Warp();
        }

    // 보스층 (옵션)
    class BossFloor : IDungeonFloor
    {
        public void Enter(Player player, DungeonManager manager)
        {
            Console.WriteLine("보스가 등장했습니다!!");
            BattleManager bm = new BattleManager();
            bool isWin = bm.Battle(player, isBoss: true);

            if (isWin)
            {
                Console.WriteLine("보스를 처치했습니다!");
                manager.Warp();
            }
            else
            {
                Console.WriteLine("보스에게 패배했습니다...");
            }
        }
    }

    // 마을층 (옵션)
    class TownFloor : IDungeonFloor
    {
        public void Enter(Player player, DungeonManager manager)
        {
            Console.WriteLine("당신은 마을에 도착했습니다.");
            Console.WriteLine("1. 회복하기\n2. 세이브 하기n3. 다음 층으로 진행");

            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    player.CurrentHP = player.MaxHP;
                    Console.WriteLine("회복되었습니다!");
                    break;
                case 2:
                    Console.WriteLine("");//세이브
                    break;
                case 3:
                    manager.Warp();
                    break;
            }
        }
    }
}






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