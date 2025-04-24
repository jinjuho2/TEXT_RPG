using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TEXT_RPG
{
    internal class GameManager
    {
        public int playerLevel = 2;
        public int currentStage = 11;
        
        public int currentEquip = 3;
        public int deadId ;


        private static GameManager instance;
        public static GameManager Instance()
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }

        private Dungeon dungeon;
        private QuestManager questManager;
        private Inven inven;
        private Shop shop;
        private Player player;

        public void Init() //시작전
        {
            ItemManager.Instance().InitializeItems();
            dungeon = new Dungeon();
            questManager = new QuestManager();
            inven = new Inven();
            shop = new Shop();
            player = new Player();
            MakeName();
            ChooseJob();
            
        }
        public void MakeName() //이름생성
        {
            Console.WriteLine("이름을 입력해주세요");
            while (true)
            {
                string name = Console.ReadLine()?.Trim();

                Console.WriteLine($"정말 {name}이 맞습니까?");
                Console.WriteLine("1. 예");
                Console.WriteLine("2. 아니오");

                int selectNum = GetValidInput(new List<int> { 1, 2 });

                if (selectNum == 1)
                {
                    player.Name = name;
                    break;
                }
                else
                {
                    Console.WriteLine("다시 입력해주세요.");
                }
            }
        }
        public void ChooseJob()
        {
           
            
                int confirm = 0;
                int selectNum=0;
                while (confirm == 1)
                {
                    Console.WriteLine("직업을 선택해 주세요");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 궁수");
                Console.WriteLine("3. 마법사");
                Console.WriteLine("4. 도적");
                Console.WriteLine("5. 해적");

                selectNum = GetValidInput(new List<int> { 1, 2, 3, 4, 5 });

                // 선택한 직업명 가져오기
                string jobName = GetJobName(selectNum);
                
                    Console.WriteLine($"\n정말 [{jobName}]이 맞습니까?");
                    Console.WriteLine("1. 예");
                    Console.WriteLine("2. 아니오");

                    confirm = GetValidInput(new List<int> { 1, 2 });
                }
              
                Dictionary<string,object> jobd=DataManager.Instance().giveJob(selectNum);
                player.SetJob(jobd);
                   
                Console.WriteLine($"[{player.Job}] 직업이 선택되었습니다!");
                 
            
        }

        private string GetJobName(int selectNum)
        {
            return selectNum switch
            {
                1 => "전사",
                2 => "궁수",
                3 => "마법사",
                4 => "도적",
                5 => "해적",
                _ => "알 수 없는 직업"
            };
        }
        public void Run() ///임시... 만약 나는 다른 메뉴창 보고 싶지 않을 경우: 그냥 스위치 문 지우고 사용하는 메소드만 남기세요 아니면 프로그램 메인 안에 넣으면 됩니다.
        {
            while (true)
            {
                
                QuestManager.Instance().CheckQuest();
                Console.Clear();
                Console.WriteLine("1.퀘스트 매니저 테스트");
                Console.WriteLine("2.던전 테스트");
                Console.WriteLine("3.인벤 테스트");
                Console.WriteLine("4.플레이어 테스트");
                Console.WriteLine("5.상점 테스트");

                int input;
                while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 6)
                {
                    Console.WriteLine("입력 오류");
                }

                switch (input)
                {
                    case 1:
                        QuestManager.Instance().QuestInit(); // 퀘스트 매니저 기능 실행
                        break;
                    case 2:
                        dungeon.DungeonRun(player); // 던전 매니저 기능 실행
                        break;
                    case 3:
                        inven.ShowInventory(); //인벤 확인
                        break;
                    case 4:
                        Console.WriteLine("1.플레이어 인벤");
                        Console.WriteLine("2.플레이어 스탯");
                        Console.WriteLine("3.플레이어 스킬");
                        while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 6)
                        {
                            Console.WriteLine("입력 오류");
                        }
                        if (input == 1)
                            inven.ShowInventory(); //플레이어 기능들 확인.... 
                        else if (input == 2)
                            player.ShowStat();
                        else
                            player.ShowSkillList();
                        break;
                    case 5:
                        shop.GenerateShopItems();
                        shop.ShowMenu(player); //상점 아이템 생성
                        break;

                    case 0:
                        Console.WriteLine("종료");
                        return;


                }
            }

        }



        //정해진 정답 외에 쳐내는 메서드
        public static int GetValidInput(List<int> validOptions)
        {
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedOption))
                {
                    if (validOptions.Contains(selectedOption))
                    {
                        return selectedOption;
                    }
                }

                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
            }
        }
    }
}
