using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class DungeonManager
    {
        private List<int> selectedDungeons = new List<int>();
        private Player player;
        private Dungeon dungeon;
        public enum DungeonType
        {
            상자방 = 1,
            상점,
            약한몬스터,
            약한몬스터1,
            약한몬스터2,
            약한몬스터3,
            일반몬스터,
            일반몬스터1,
            일반몬스터2,
            일반몬스터3,
            일반몬스터4,
            엘리트몬스터,
            엘리트몬스터1,
            이벤트,
            휴식
        }
        public void StartDungeon(Player _player)
        {
            player = _player;
            Warp();
        }
        private void SetRandomDungeons()
        {
            Random random = new Random();
            selectedDungeons = Enumerable.Range(1, 15)
                                         .OrderBy(x => random.Next())
                                         .Take(3)
                                         .ToList();
        }
        
        public void Warp()
        {

            dungeon = new Dungeon();

            SetRandomDungeons();

            Console.WriteLine($"1. {((DungeonType)selectedDungeons[0])} 으로 진행");
            Console.WriteLine($"2. {((DungeonType)selectedDungeons[1])} 으로 진행");
            Console.WriteLine($"3. {((DungeonType)selectedDungeons[2])} 으로 진행");
            Console.WriteLine("0 - 마을귀환주문서 사용");
            Console.Write(">> ");

            //Floor.Instance().nowFloor++;
            //Floor.Instance().CheckHighFloor();

            string inputStr = Console.ReadLine();
            if (int.TryParse(inputStr, out int input))
            {
                switch (input)
                {
                    case 1:
                        HandleDungeon(selectedDungeons[0]);
                        break;
                    case 2:
                        HandleDungeon(selectedDungeons[1]);
                        break;
                    case 3:
                        HandleDungeon(selectedDungeons[2]);
                        break;
                    case 0:
                        Console.WriteLine("마을로 귀환합니다.");
                        Floor.Instance().nowFloor = Floor.Instance().nowFloor - (Floor.Instance().nowFloor % 10) + 1;
                        TownWarp();
                        break;
                    default:
                        Console.WriteLine("입력 오류");
                        break;
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해 주세요");
            }
        }

        private void HandleDungeon(int dungeonCode)
        {
            DungeonType type = (DungeonType)dungeonCode;
            Floor.Instance().nowFloor++;
            Floor.Instance().CheckHighFloor();
            Console.Clear();
            Console.WriteLine($"{type} 층으로 이동합니다.");
            Console.WriteLine($"현재 {Floor.Instance().nowFloor}입니다");
            switch (type)
            {
                case DungeonType.상자방:
                    Console.WriteLine("상자 층 입니다.");
                    break;
                case DungeonType.상점:
                    Console.WriteLine("상점 층 입니다.");
                    break;
                case DungeonType.이벤트:
                    Console.WriteLine("이벤트 층 입니다.");
                    break;
                case DungeonType.휴식:
                    RestFloor();
                    Warp();
                    break;
                case DungeonType.약한몬스터:
                case DungeonType.약한몬스터1:
                case DungeonType.약한몬스터2:
                case DungeonType.약한몬스터3:
                case DungeonType.일반몬스터:
                case DungeonType.일반몬스터1:
                case DungeonType.일반몬스터2:
                case DungeonType.일반몬스터3:
                case DungeonType.일반몬스터4:
                case DungeonType.엘리트몬스터:
                case DungeonType.엘리트몬스터1:
                    Console.WriteLine($"{type} 몬스터 층 입니다.");
                    dungeon.DungeonRun(player, this);
                    break;
                default:
                    Console.WriteLine("미지의 층입니다.");
                    break;
            }
        }

        public void RestFloor()
        {
            if (player.CurrentHP >= player.MaxHP / 2)
            {
                player.CurrentHP += player.MaxHP / 2;
            }
            else
            {
                player.CurrentHP += (player.MaxHP - player.CurrentHP);
            }
            Console.WriteLine("휴식을 취했습니다.");
        }

        public void TownWarp()
        {
            Console.WriteLine("마을입니다.");
            Floor.Instance().nowFloor = 0;
            // TODO: 마을 UI 처리
        }
    }
    internal class Floor
    {
        private static Floor instance;

        private Floor() { }
        public static Floor Instance()
        {
            if (instance == null)
                instance = new Floor();
            return instance;
        }

        public int highFloor;//최고층수
        public int nowFloor;//현재층수
                            //나우플로어 ++
                            //if나우플로어>=하이플로어 = 하이 = 나우

        public void CheckHighFloor()
        {
            if (highFloor <= nowFloor)
            {
                highFloor = nowFloor;
            }
        }
        class Town : Floor
            {
                string townname;

                public void EnterTown()
                {
                    Console.WriteLine($"현재 {nowFloor}층, {townname} 입니다.");
                    Console.WriteLine("");
                    Console.WriteLine("무엇을 하시겠습니까?");
                    Console.WriteLine("1.상태보기.");
                    Console.WriteLine("2.상점가기");
                    Console.WriteLine("3.퀘스트창 확인하기");
                    Console.WriteLine("4.회복하기");
                    Console.WriteLine("");
                    Console.WriteLine("0.다음층으로 가기");

                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:
                        //RestFloor();
                        break;
                        case 0:
                            //Warp();
                            break;
                    }
                }
            }
        }
    }


