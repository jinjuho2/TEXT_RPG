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
        public int monsterKill = 5;
        public int currentEquip = 3;                 //이상 4개 변수는 퀘스트매니저에서 쓰는 임시변수

        Dungeon d;
        QuestManager qm;
        Inven iv;
        Shop shop = new Shop();
        public static GameManager instance;
        public static GameManager Instance()
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
        public void Init()
        {
            d = new Dungeon();
            qm = new QuestManager(this);
            ItemManager.InitializIeItem();
            Player.Instance.Name = "임시 주인공";
            Player.Instance.MaxHP = 100;
            Player.Instance.CurrentHP = 100;
            Player.Instance.Attack = 10;
            Player.Instance.Speed = 10;
            Player.Instance.Gold = 5000;
            Player.Instance.WeakType=TYPE.Dark;
            iv=new Inven(); //여기서 인벤에 아이템 추가하고 확인 가능.
        }
        public void MakeName() //이름생성
        {
                Console.WriteLine("이름을 입력해주세요");
            while (true)
            {
                
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
                    case 5:
                        shop.GenerateShopItems();
                        shop.ShowMenu(); //상점 아이템 생성
                        break;

                    case 0:
                    Console.WriteLine("종료");
                    return;
                    

                }
            }

        }

       

        }

       

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
