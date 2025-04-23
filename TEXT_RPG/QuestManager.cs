using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TEXT_RPG
{
    internal class QuestManager
    {

        bool addQuest_1 = false;
        bool addQuest_2 = false;
        bool addQuest_3 = false;
        bool addAchieve = false;

        public List<Quest> Quests { get; set; }
        public List<Quest> Achieves { get; set; }

        private GameManager gameManager;
        public QuestManager(GameManager gm)//게임매니저에서 퀘스트 매니저를 부르는 거라 상호 참조할 필요는 없는데요 
        {                    //만약 게임 매니저의 값이 필요하시다면 메소드를 통해 가져오던가 게임매니저를 싱글톤으로 바꾸는 게 낫겠습니다     
            gameManager = gm;
            Quests = new List<Quest>();
            Achieves = new List<Quest>();
        }

        public void QuestInit()
        {
            AddQuest();
            AddAchieve();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. 퀘스트 \n2. 히든업적 \n0. 나가기 \n");
                Console.WriteLine("원하시는 입력을 선택해주세요.");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        isRunning = false;
                        break; //로 해도 괜찮을듯합니다...
                    case 1:
                        isRunning = false;
                        QuestWindow();
                        break;
                    case 2:
                        isRunning = false;
                        AchieveWindow();
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

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("-퀘스트창-\n");
                ShowQuest(0);
                Console.WriteLine("원하시는 퀘스트를 선택해주세요 \n0.나가기");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int select))
                {
                    if (select == 0)
                    {
                        isRunning = false;
                        QuestInit();
                    }
                    else if (select <= Quests.Count)
                    {
                        DetailQuest(select);
                    }
                    else
                    {
                        Console.WriteLine("올바른 입력이 아닙니다");
                        Thread.Sleep(1000);
                    }
                }
            }
        }
        void AchieveWindow()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("-업적-\n");
                ShowAchieve(0);
                Console.WriteLine("\n업적을 선택해주세요. \n0.나가기");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int select))
                {
                    if (select == 0)
                    {
                        isRunning = false;
                        QuestInit();
                    }
                    else if (select <= Achieves.Count)
                    {
                        DetailAchieve(select);
                    }
                    else
                    {
                        Console.WriteLine("올바른 입력이 아닙니다");
                        Thread.Sleep(1000);
                    }
                }
            }
        }
        void DetailQuest(int select)                                                            //퀘스트목록에서 퀘스트 선택시
        {
            int index = select - 1;
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"{Quests[index].Title} \n\n{Quests[index].Etc} {Quests[index].CurrentCount} / {Quests[index].TargetCount} \n");
                if (Quests[index].IsClear == false )                                                
                {
                    if (Quests[index].IsActive == false)                                                                            //완료상태가 아니고 활성화 상태도 아닐시
                    {
                        Console.WriteLine("\n1. 수락 2. 거절 \n");
                        int input = int.Parse(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                isRunning = false;
                                Quests[index].IsActive = true;
                                Console.WriteLine("퀘스트가 수락되었습니다!");
                                Thread.Sleep(1000);
                                break;
                            case 2:
                                isRunning = false;
                                QuestWindow();
                                break;
                            default:
                                Console.WriteLine("올바른 입력이 아닙니다");
                                Thread.Sleep(1000);
                                break;
                        }
                    }
                    else if(Quests[index].IsActive == true)                                                                         //완료상태 아니고 활성화 상태일시
                    {
                        Console.WriteLine("\n1. 포기하기 2. 돌아가기 \n");
                        int input = int.Parse(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                isRunning = false;
                                Quests[index].IsActive = false;
                                Console.WriteLine("퀘스트를 포기했습니다..");
                                Thread.Sleep(1000);
                                break;
                            case 2:
                                isRunning = false;
                                QuestWindow();
                                break;
                            default:
                                Console.WriteLine("올바른 입력이 아닙니다");
                                Thread.Sleep(1000);
                                break;
                        }
                    }
                } 
                else                                                                                                                //완료 상태일시
                {
                    Console.WriteLine("\n1. 보상받기 2. 돌아가기 \n");
                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            isRunning = false;
                            Reward(Quests[index]);
                            Quests.RemoveAt(index);
                            Thread.Sleep(1000);
                            break;
                        case 2:
                            isRunning = false;
                            QuestWindow();
                            break;
                        default:
                            Console.WriteLine("올바른 입력이 아닙니다");
                            Thread.Sleep(1000);
                            break;
                    }
                }
            }
        }

        //void CancelQuest()
        //{
        //    bool isRunning = true;
        //    while (isRunning)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("-퀘스트창- '취소' \n");
        //        ShowQuest(0);
        //        Console.WriteLine("\n 취소할 퀘스트를 고르세요.\n 0.나가기");
        //        string? input = Console.ReadLine();
        //        if (int.TryParse(input, out int select))
        //        {
        //            if (select == 0)
        //            {
        //                isRunning = false;
        //                QuestWindow();
        //            }
        //            else if (select <= Quests.Count)
        //            {
        //                if (Quests[select - 1].IsActive)
        //                {
        //                    Quests[select - 1].IsActive = false;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("수주한 퀘스트가 아닙니다!");
        //                    Thread.Sleep(1000);
        //                }

        //            }
        //            else
        //            {
        //                Console.WriteLine("올바른 입력이 아닙니다");
        //                Thread.Sleep(1000);
        //            }
        //        }
        //    }
        //}

        public void DetailAchieve(int select)
        {
            int index = select - 1;
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                if(Achieves[index].IsClear == false) Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{Achieves[index].Title} \n\n{Achieves[index].Etc} {Achieves[index].CurrentCount} / {Achieves[index].TargetCount} \n");
                Console.ResetColor();
                if (Achieves[index].IsClear == true && Achieves[index].IsReward == false) Console.WriteLine("1. 보상받기 \n");                              //업적달성시 보상받기 텍스트보임
                Console.WriteLine("0. 돌아가기 \n");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        isRunning = false;
                        AchieveWindow();
                        break;
                    case 1:
                        if(Achieves[index].IsClear == true && Achieves[index].IsReward == false)
                        {
                            //보상받기
                            Achieves[index].IsReward = true;
                            Console.WriteLine("보상을 받았습니다.");
                        }
                        else
                        {
                            Console.WriteLine("올바른 입력이 아닙니다.");
                        }
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("올바른 입력이 아닙니다");
                        Thread.Sleep(1000);
                        break;
                }
            }

        }
        void AddQuest()                                                                             //퀘스트 목록 추가
        {
            if (gameManager.playerLevel >= 1 && addQuest_1 == false)
            {
                Quests.Add(new Quest { Title = "슬라임을 잡아라!", Etc = "슬라임을 5마리 잡으세요 \n - 주황버섯 10마리 처치", CurrentCount = 0, TargetCount = 5, IsActive = false, IsClear = false, level = 0, Type = QuestType.Hunting });
                Quests.Add(new Quest { Title = "스톤골렘을 잡아라!", Etc = "스톤골렘을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsActive = false, IsClear = false, level = 0, Type = QuestType.Hunting });
                Quests.Add(new Quest { Title = "초보 여행가", Etc = "타워 10층을 완료하세요", CurrentCount = 0, TargetCount = 10, IsActive = false, IsClear = false, level = 0, Type = QuestType.StageClear });
                addQuest_1 = true;
            }
            if (gameManager.playerLevel >= 2 && addQuest_2 == false)
            {
                Quests.Add(new Quest { Title = "좀비 버섯을 잡아라!", Etc = "좀비 버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 1, Type = QuestType.Hunting });
                Quests.Add(new Quest { Title = "미노타우르스를 잡아라!", Etc = "미노타우르스를 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 1, Type = QuestType.Hunting });
                Quests.Add(new Quest { Title = "중급 여행가", Etc = "타워 20층을 완료하세요", IsClear = false, level = 1, Type = QuestType.StageClear });
                addQuest_2 = true;
            }
        }
        void AddAchieve()       //업적은 자동수락 자동진행 처음엔 안보이다가 진행도가 50%이상일때 목록에 보임
        {
            if (addAchieve == false)
            {
                Achieves.Add(new Quest { Title = "메린이", Etc = "초급(가명) 장비 풀세트 착용", CurrentCount = 0, TargetCount = 5, IsActive = true, IsClear = false, IsVisible = false, Type = QuestType.Hidden });
                Achieves.Add(new Quest { Title = "메청년", Etc = "중급(가명) 장비 풀세트 착용", CurrentCount = 0, TargetCount = 5, IsActive = true, IsClear = false, IsVisible = false, Type = QuestType.Hidden });
                Achieves.Add(new Quest { Title = "메노인", Etc = "고급(가명) 장비 풀세트 착용", CurrentCount = 0, TargetCount = 5, IsActive = true, IsClear = false, IsVisible = false, Type = QuestType.Hidden });

                addAchieve = true;
            }
        }


        public void ShowQuest(int index = -1)                                          //퀘스트 목록 보이기,index 매개변수 0으로 호출시 퀘스트넘버 보임
        {
            int level = gameManager.currentStage / 10;
            int counter = index >= 0 ? index : -1;
            foreach (Quest quest in Quests)
            {
                //if(quest.Type == QuestType.Hidden && quest.IsVisible == true)
                //{
                //    Console.WriteLine($"{quest.Title} : {quest.Etc} ");
                //}
                if (quest.level <= level)
                {
                    string questNum = counter >= 0 ? $"{counter + 1}." : "";
                    string questStatus;

                    if (quest.IsActive == true)
                    {
                        if (quest.IsClear == true)
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
                            Console.WriteLine($"{questNum}{quest.Title}");
                            if (quest.IsActive == true) Console.WriteLine($"진행상황 : {quest.CurrentCount}마리 / {quest.TargetCount}마리");
                            Console.WriteLine("\n");
                            break;
                        case QuestType.StageClear:
                            Console.WriteLine($"{questNum}{quest.Title}");
                            if (quest.IsActive == true) Console.WriteLine($"진행상황 : {quest.CurrentCount}층 / {quest.TargetCount}층");
                            Console.WriteLine("\n");
                            break;
                    }
                    if (counter >= 0)
                        counter++;
                }
            }
        }
        public void ShowAchieve(int index = -1)                                                                     //업적 목록 보이기
        {
            int counter = index >= 0 ? index : -1;
            foreach (Quest achieve in Achieves)
            {
                if (achieve.IsVisible == true)                                                  
                {
                    string questNum = counter >= 0 ? $"{counter + 1}." : "";
                    if (achieve.IsClear == false)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine($"{questNum}. {achieve.Title} : {achieve.CurrentCount}/{achieve.TargetCount}");
                    Console.ResetColor();
                    counter++;
                }
            }
        }
        public void CheckQuest()                                                                                //호출할때마다 현재 퀘스트or업적 클리어 체크
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
                    
                }
            }
            foreach (Quest achieve in Achieves)
            {
                switch (achieve.Type)
                {
                    case QuestType.Hidden:
                        achieve.CurrentCount = gameManager.currentEquip;
                        if (achieve.CurrentCount >= achieve.TargetCount)
                        {
                            ClearQuest(achieve);
                        }
                        else if (achieve.CurrentCount > achieve.TargetCount / 2)
                        {
                            achieve.IsVisible = true;
                            Console.WriteLine($"{achieve.Title} 업적 활성화");
                            Thread.Sleep(1000);
                        }
                        break;
                }
            }
        }
        public void ClearQuest(Quest Quests)                                                                            //퀘스트,업적 클리어시 호출
        {
            if (Quests.Type == QuestType.Hunting || Quests.Type == QuestType.StageClear)
            {
                if (Quests.level == 0)
                {
                    Quests.IsClear = true;            //완료표시
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
            else if(Quests.Type == QuestType.Hidden)
            {
                
                Quests.IsClear = true;
                Console.WriteLine($"{Quests.Title} 업적 완료");
                Thread.Sleep(1000);
            }


        }
        public void Reward(Quest Quests)
        {
            if (Quests.level == 0)
            {
                //player 골드 , 경험치 소량증가
                Console.WriteLine($"{Quests.Title} 보상받기 완료");
                Thread.Sleep(1000);

            }
            if (Quests.Type == QuestType.Hidden)
            {

            }
        }
        

    }
}
