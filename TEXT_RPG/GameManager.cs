using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class GameManager
    {
        Dungeon d;
        QuestManager qm;
        Inven iv;
        public void Init()
        {
            d = new Dungeon();
            qm = new QuestManager();
            Player.Instance.Name = "임시 주인공";
            Player.Instance.MaxHP = 100;
            Player.Instance.CurrentHP = 100;
            Player.Instance.Attack = 10;
            Player.Instance.Speed = 10;
            Player.Instance.WeakType=TYPE.Dark;
            iv=new Inven(); //여기서 인벤에 아이템 추가하고 확인 가능.
        }
        public void Run() ///임시... 만약 나는 다른 메뉴창 보고 싶지 않을 경우: 그냥 스위치 문 지우고 사용하는 메소드만 남기세요 아니면 프로그램 메인 안에 넣으면 됩니다.
        {
            while (true)
            {
                
                Console.WriteLine("1.퀘스트 매니저 테스트");
                Console.WriteLine("2.던전 테스트");
                Console.WriteLine("3.인벤 테스트");
                Console.WriteLine("4.플레이어 테스트");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 5)
                {
                    Console.WriteLine("입력 오류");
                }

                switch (input)
                {
                    case 1:
                        qm.QuestWindow(); // 퀘스트 매니저 기능 실행
                        break;
                    case 2:
                        d.DungeonRun(); // 던전 매니저 기능 실행
                        break;
                    case 3:
                        
                       iv.ShowInventory(); //인벤 확인
                      break;
                    case 4:
                        while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 4)
                        {
                            Console.WriteLine("입력 오류");
                        }
                        Console.WriteLine("1.플레이어 인벤");
                        Console.WriteLine("2.플레이어 스탯");
                        Console.WriteLine("3.플레이어 스킬");
                        if (input==1)
                        Player.Instance.ShowInventory(); //플레이어 기능들 확인.... 
                        else if(input==2) 
                            Player.Instance.ShowStat();
                        else
                            Player.Instance.ShowSkillList();
                        break;

                    case 0:
                    Console.WriteLine("종료");
                    return;
                    

                }
            }

        }

        //public QuestManager questManager;
        //public GameManager()
        //{
        //    questManager = new QuestManager(this);
        //}
        //public void Start()
        //{
        //    questManager.AddQuest();
        //    bool isRunning = false;
        //    while (!isRunning)
        //    {
        //        Console.WriteLine("1. 입장");
        //        int input = int.Parse(Console.ReadLine());
        //        if (input == 1)
        //        {
        //            isRunning = true;
        //            questManager.QuestWindow();
        //        }
        //        else
        //        {
        //            Console.WriteLine("다시");
        //        }
        //    }
        //}

        //정해진 정답 외에 쳐내는 메서드
        public static int GetValidInput(params int[] validOptions)
        {
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedOption))
                {
                    if (validOptions.Contains(selectedOption))
                    {
                        return selectedOption;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }

            }
        }
    }
}
