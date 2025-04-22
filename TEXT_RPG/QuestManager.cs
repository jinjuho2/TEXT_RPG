using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class QuestManager
    {
       
        bool addQuest_1 = false;
        bool addQuest_2 = false;
        bool addQuest_3 = false;


        public List<Quest> Quests { get; set; }

        private GameManager gameManager;
        public QuestManager(GameManager gm)//게임매니저에서 퀘스트 매니저를 부르는 거라 상호 참조할 필요는 없는데요 
        {                    //만약 게임 매니저의 값이 필요하시다면 메소드를 통해 가져오던가 게임매니저를 싱글톤으로 바꾸는 게 낫겠습니다     
            gameManager = gm;
            Quests = new List<Quest>();
        }

        public void QuestInit()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. 퀘스트 \n 2. 히든업적 \n 0.나가기 \n");
                Console.WriteLine("원하시는 입력을 선택해주세요.");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        isRunning = false;
                        gameManager.Run();
                        break; //로 해도 괜찮을듯합니다...
                    case 1:
                        isRunning = false;
                        QuestWindow();
                        break;
                    case 2:
                        isRunning = false;
                        HiddenWindow();
                        break;
                    default:
                        Console.WriteLine("올바른 입력이 아닙니다");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
        public void QuestWindow()
        {
           
            AddQuest();
           
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("-퀘스트창-\n");
                ShowQuest();
                Console.WriteLine("원하시는 퀘스트를 선택해주세요 \n 0.나가기");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int select))
                {
                    if (select == 0)
                    {
                        isRunning = false;
                        QuestWindow();
                    }
                    
                    //case 1:
                    //    isRunning = false;
                    //    AcceptQuest();
                    //    break;
                    //case 2:
                    //    isRunning = false;
                    //    CancelQuest();
                    //    break;
                    //case 3:
                    //    isRunning = false;
                    //    CheckQuest();
                    //    break;
                    //default:
                    //    Console.WriteLine("올바른 입력이 아닙니다");
                    //    Thread.Sleep(1000);
                    //    break;
                }
                
            }


        }
        void AcceptQuest()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("-퀘스트창- '수주' \n");
                ShowQuest(0);
                Console.WriteLine("\n 수주할 퀘스트를 고르세요.\n 0.나가기");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int select))
                {
                    if (select == 0)
                    {
                        isRunning = false;
                        QuestWindow();
                    }
                    else if (select <= Quests.Count)
                    {
                        if (!Quests[select - 1].IsActive)                                       //수주상태가 아니면 활성화
                        {
                            Quests[select - 1].IsActive = true;
                        }
                        else
                        {
                            Console.WriteLine("이미 수주중인 퀘스트입니다!");
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("올바른 입력이 아닙니다");
                        Thread.Sleep(1000);
                    }
                }
            }
        }
        

        void CancelQuest()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("-퀘스트창- '취소' \n");
                ShowQuest(0);
                Console.WriteLine("\n 취소할 퀘스트를 고르세요.\n 0.나가기");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int select))
                {
                    if (select == 0)
                    {
                        isRunning = false;
                        QuestWindow();
                    }
                    else if (select <= Quests.Count)
                    {
                        if (Quests[select - 1].IsActive)
                        {
                            Quests[select - 1].IsActive = false;
                        }
                        else
                        {
                            Console.WriteLine("수주한 퀘스트가 아닙니다!");
                            Thread.Sleep(1000);
                        }
                                      
                    }
                    else
                    {
                        Console.WriteLine("올바른 입력이 아닙니다");
                        Thread.Sleep(1000);
                    }
                }
            }
        }


        void AddQuest()                                                 
        {
            if (gameManager.playerLevel == 1 && addQuest_1 == false)
            {
                Quests.Add(new Quest { Title = "주황버섯을 잡아라!", Etc = "주황버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsActive = false, IsClear = false, level = 0, Type = QuestType.Hunting });
                Quests.Add(new Quest { Title = "뿔버섯을 잡아라!", Etc = "뿔버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsActive = false, IsClear = false, level = 0, Type = QuestType.Hunting });
                Quests.Add(new Quest { Title = "초보 여행가", Etc = "타워 10층을 완료하세요", CurrentCount = 0, TargetCount = 10, IsActive = false, IsClear = false, level = 0, Type = QuestType.StageClear });
                Quests.Add(new Quest { Title = "Start From The Bottom", Etc = "Lv1 장비 풀세트 착용", CurrentCount = 0, TargetCount = 5, IsActive = true, IsClear = false, level = 0, Type = QuestType.Hidden, IsVisible = false });
                addQuest_1 = true;
            }
            else if (gameManager.playerLevel == 2 && addQuest_2 == false)
            {

                Quests.Add(new Quest { Title = "ㅇ버섯을 잡아라!", Etc = "주황버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 1, Type = QuestType.Hunting });
                Quests.Add(new Quest { Title = "ㄷ섯을 잡아라!", Etc = "뿔버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 1, Type = QuestType.Hunting });
                Quests.Add(new Quest { Title = "중급 여행가", Etc = "타워 20층을 완료하세요", IsClear = false, level = 1, Type = QuestType.StageClear });
                addQuest_2 = true;
            }
        }
        
        public void ShowQuest(int index = -1)                                          //clearFloor 매개변수를 player의 클리어 층수변수로 설정, 1층당 1씩 증가 ,index 매개변수 0으로 호출시 퀘스트넘버 보임
        {
            int level = gameManager.currentStage / 10;
            int counter = index >= 0 ? index : -1;                                                   
            foreach (Quest quest in Quests)
            {
                //if(quest.Type == QuestType.Hidden && quest.IsVisible == true)
                //{
                //    Console.WriteLine($"{quest.Title} : {quest.Etc} ");
                //}
                if(quest.level <= level)
                {
                    string questNum = counter >= 0 ? $"{counter + 1}." : "";
                    string questStatus;

                    if(quest.IsActive == true)
                    {
                        if(quest.IsClear == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            questStatus = "[완료]";
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            questStatus = "[진행중]";
                        }
                        Console.Write(questStatus); 
                        Console.ResetColor();       
                        Console.Write(" ");
                    }
                    else
                    {
                        questStatus = "";
                    }

                        switch (quest.Type)
                        {
                            case QuestType.Hunting:
                                Console.WriteLine($"{questNum}{quest.Title} : {quest.Etc} ");
                                if (quest.IsActive == true) Console.WriteLine($"진행상황 : {quest.CurrentCount} / {quest.TargetCount}");
                                break;
                            case QuestType.StageClear:
                                Console.WriteLine($"{questNum}{quest.Title} : {quest.Etc} ");
                            if (quest.IsActive == true) Console.WriteLine($"진행상황 : {quest.CurrentCount}층 / {quest.TargetCount}층");
                            break;
                        }
                    if (counter >= 0)
                        counter++;
                }
            }
        }
        public void CheckQuest()                                                                                //마을 갈때마다 호출
        {
            foreach (Quest quest in Quests)
            {
                if (!quest.IsActive || quest.IsClear)
                    continue;

                switch (quest.Type)
                {
                    case QuestType.Hunting:
                        quest.CurrentCount = gameManager.monsterKill;
                        if (gameManager.monsterKill >= quest.TargetCount)
                        {
                            ClearQuest(quest);
                        }
                        break;
                    case QuestType.StageClear:
                        quest.CurrentCount = gameManager.currentStage;
                        if (gameManager.currentStage >= quest.TargetCount)
                        {
                            ClearQuest(quest);
                        }
                        break;
                    case QuestType.Hidden:
                        quest.CurrentCount = gameManager.currentEquip;
                        if (gameManager.currentEquip >= quest.TargetCount)
                        {
                            ClearQuest(quest);
                        }
                        break;
                }
            }
        }
        public void ClearQuest(Quest Quests)
        {
            
            if(Quests.level == 0)
            {
                //player 골드 , 경험치 소량증가
                Quests.IsClear = true;
                if (Quests.Type == QuestType.Hidden) Quests.IsVisible = true;
                Console.WriteLine($"{Quests.Title} 퀘스트완료");
                Thread.Sleep(1000);

            }
            else if (Quests.level == 1)
            {
                //player 골드 , 경험치 중량증가
            }
            else if (Quests.level == 2)
            {
                //player 골드 , 경험치 대량증가
            }


        }
        void HiddenWindow()
        {

        }



    }
}
