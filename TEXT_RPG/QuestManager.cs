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
        bool questOpen = false;
        public List<Quest> Quests { get; set; }

        private GameManager gameManager;
        public QuestManager(GameManager gm)//게임매니저에서 퀘스트 매니저를 부르는 거라 상호 참조할 필요는 없는데요 
        {                    //만약 게임 매니저의 값이 필요하시다면 메소드를 통해 가져오던가 게임매니저를 싱글톤으로 바꾸는 게 낫겠습니다     
            gameManager = gm;
            Quests = new List<Quest>();
        }

        public void QuestWindow()
        {
            if (!questOpen)
            {
                AddQuest();
                questOpen = true;
            }
            
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("-퀘스트창-\n");
                ShowQuest(2);
                Console.WriteLine("\n 1. 퀘스트 수주 \n 2. 퀘스트 취소 \n 0.나가기");
                int input = int.Parse(Console.ReadLine());
                switch(input)
                {
                    case 0:
                    isRunning = false;
                    gameManager.Run();
                    break; //로 해도 괜찮을듯합니다...
                    case 1:
                        isRunning = false;
                        AcceptQuest();
                        break;
                    case 2:
                        isRunning = false;
                        CancelQuest();
                        break;
                    default:
                        Console.WriteLine("올바른 입력이 아닙니다");
                        Thread.Sleep(1000);
                        break;
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
                ShowQuest(2, 0);
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
                ShowQuest(2, 0);
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
            Quests.Add(new Quest { Title = "주황버섯을 잡아라!", Etc = "주황버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsActive = false ,IsClear = false, level = 1, Type = QuestType.Hunting});
            Quests.Add(new Quest { Title = "뿔버섯을 잡아라!", Etc = "뿔버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsActive = false,IsClear = false , level = 1 ,Type = QuestType.Hunting });
            Quests.Add(new Quest { Title = "초보 여행가", Etc = "타워 10층을 완료하세요", IsActive = false ,IsClear = false , level = 1 , Type = QuestType.StageClear });

            Quests.Add(new Quest { Title = "ㅇ버섯을 잡아라!", Etc = "주황버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 2, Type = QuestType.Hunting });
            Quests.Add(new Quest { Title = "ㄷ섯을 잡아라!", Etc = "뿔버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 2, Type = QuestType.Hunting });
            Quests.Add(new Quest { Title = "중급 여행가", Etc = "타워 20층을 완료하세요", IsClear = false, level = 2, Type = QuestType.StageClear });
        }
        
        public void ShowQuest(int currentlevel,int index = -1)
        {
            int counter = index >= 0 ? index : -1;
            foreach (Quest quest in Quests)
            {
                if(quest.level <= currentlevel)
                {
                    string questNum = counter >= 0 ? $"{counter + 1}." : "";
                    string questStatus = quest.IsActive ? "[진행중]" : "";
                    switch (quest.Type)
                    {
                        case QuestType.Hunting:
                            Console.WriteLine($"{questStatus} {questNum}{quest.Title} : {quest.Etc} ");
                            if (quest.IsActive == true) Console.WriteLine($"진행상황 : {quest.CurrentCount} / {quest.TargetCount}");
                            break;
                        case QuestType.StageClear:
                            Console.WriteLine($"{questStatus} {questNum}{quest.Title} : {quest.Etc} ");
                            break;
                        case QuestType.ItemEvent:

                            break;
                        case QuestType.Hidden:

                            break;
                    }
                    if (counter >= 0)
                        counter++;
                }
            }
        }
        public void CheckQuest(Player player)
        {
            foreach (Quest quest in Quests)
            {
                if (!quest.IsActive || quest.IsClear)
                    continue;

                switch (quest.Type)
                {
                    //case QuestType.Hunting:
                    //    if (player.MonsterKillCount >= quest.TargetCount)
                    //    {
                    //        ClearQuest(quest);
                    //    }
                    //    break;
                    //case QuestType.StageClear:
                    //    if (player.CurrentStage >= quest.TargetCount)
                    //    {
                    //        ClearQuest(quest);
                    //    }
                    //    break;
                }
            }
        }
        public void ClearQuest(Quest Quests)
        {
            
            if(Quests.level == 1)
            {
                //player 골드 , 경험치 소량증가
            }
            else if (Quests.level == 2)
            {
                //player 골드 , 경험치 중량증가
            }
            else if (Quests.level == 3)
            {
                //player 골드 , 경험치 대량증가
            }


        }



    }
}
