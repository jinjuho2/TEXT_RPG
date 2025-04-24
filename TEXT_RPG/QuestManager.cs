using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
        private static QuestManager instance;
        public static QuestManager Instance()
        {
            if (instance == null)
                instance = new QuestManager();
            return instance;
        }
        public QuestManager()//게임매니저에서 퀘스트 매니저를 부르는 거라 상호 참조할 필요는 없는데요 
        {                    //만약 게임 매니저의 값이 필요하시다면 메소드를 통해 가져오던가 게임매니저를 싱글톤으로 바꾸는 게 낫겠습니다     
            
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
              
                    }
                    else if (select <= Quests.Count)
                    {
                        DetailQuest(select);
                        isRunning = false;
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
                        isRunning = false;
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
                                QuestWindow();
                                break;
                            case 2:
                                QuestWindow();
                                isRunning = false;
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
                                QuestWindow();
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
                            Quests[index].IsComplete = true;
                            Quests.RemoveAt(index);
                            Console.WriteLine("삭제됨");
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
                if (Achieves[index].IsClear == false && Achieves[index].IsVisible == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{Achieves[index].Title} \n\n{Achieves[index].Etc} {Achieves[index].CurrentCount} / {Achieves[index].TargetCount} \n");
                    Console.ResetColor();
                }
                else if(Achieves[index].IsVisible == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"??? \n\n??? ??? / ??? \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{Achieves[index].Title} \n\n{Achieves[index].Etc} {Achieves[index].CurrentCount} / {Achieves[index].TargetCount} \n");
                }
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
        public void AddQuest()                                                                             //퀘스트 목록 추가
        {
            if (GameManager.Instance().playerLevel >= 1 && addQuest_1 == false)                                                 //조건만족시 한번만발동
            {
                Quests.AddRange(DataManager.Instance().FindQuest(1));
                Console.WriteLine($"퀘스트 {Quests.Count}개 추가");
                Thread.Sleep(1000);
                addQuest_1 = true;
            }
            if (GameManager.Instance().playerLevel >= 2 && addQuest_2 == false)
            {
                int currentQuestsCount = Quests.Count;
                Quests.AddRange(DataManager.Instance().FindQuest(2));
                Console.WriteLine($"퀘스트 {Quests.Count - currentQuestsCount}개 추가");
                Thread.Sleep(1000);
                addQuest_2 = true;
            }

        }
        public void AddAchieve()       //업적은 자동수락 자동진행 처음엔 안보이다가 진행도가 50%이상일때 목록에 보임
        {
            if (addAchieve == false)
            {
                Achieves.AddRange(DataManager.Instance().FindQuest(0));
                
                addAchieve = true;
            }
        }


        public void ShowQuest(int index = -1)                                          //퀘스트 목록 보이기,index 매개변수 0으로 호출시 퀘스트넘버 보임
        {
            int level = GameManager.Instance().playerLevel;
            int counter = index >= 0 ? index : -1;
            foreach (Quest quest in Quests)
            {
                if (quest.IsComplete == true) continue;
                //if(quest.Type == QuestType.Hidden && quest.IsVisible == true)
                //{
                //    Console.WriteLine($"{quest.Title} : {quest.Etc} ");
                //}
                if (quest.Level <= level)
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
                        case QuestType.Stage:
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
                string questNum = counter >= 0 ? $"{counter + 1}." : "";
                if (achieve.IsVisible == true)                                                  
                {
                    
                    if (achieve.IsClear == false)                                  //클리어 안했을시
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"{questNum}. {achieve.Title} : {achieve.CurrentCount}/{achieve.TargetCount}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{questNum}. {achieve.Title} - 완료 ");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{questNum}. ???");
                    Console.ResetColor();
                }
                counter++;
            }
        }
        public void DeadCheck(int id)                                                                       //몬스터가 죽었을때 호출
        {

            foreach (Quest quest in Quests)
            {
                if (quest.TargetID == id && quest.IsActive == true)                                        //퀘스트의 타겟id와 같고 그 퀘스트가 진행중(수락상태)일때
                {
                    quest.CurrentCount++;
                    Console.WriteLine($"[Quest] {quest.Title} 진행도 상승 {quest.CurrentCount} / {quest.TargetCount}");
                    Thread.Sleep(1000);
                }
            }

        }

        
        public void CheckQuest()                                                                                //호출할때마다 현재 퀘스트or업적 클리어 체크, 마을에서 호출
        {
            foreach (Quest quest in Quests)
            {
                if (!quest.IsActive || quest.IsClear)
                    continue;

                switch (quest.Type)
                {
                    case QuestType.Hunting:
                        if (quest.CurrentCount >= quest.TargetCount)
                        {
                            ClearQuest(quest);
                        }
                        break;
                    case QuestType.Stage:
                        //quest.CurrentCount = Floor.Instance().highFloor;
                        if (GameManager.Instance().currentStage >= quest.TargetCount)
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
                        if (GameManager.Instance().equipCountByLevel.ContainsKey(achieve.TargetID))
                        {
                            achieve.CurrentCount = GameManager.Instance().equipCountByLevel[achieve.TargetID];
                            if (achieve.CurrentCount >= achieve.TargetCount)                            //퀘스트(업적)달성시
                            {
                                ClearQuest(achieve);
                            }
                            else if (achieve.CurrentCount > achieve.TargetCount / 2 && achieve.IsVisible == false)                    //업적이 진행도가 50%이상이고 보이지않는상태일시
                            {
                                achieve.IsVisible = true;
                                Console.WriteLine($"{achieve.Title} 업적 활성화");
                                Thread.Sleep(1000);
                            }
                        }
                
                        break;
                }
            }
        }
        public void ClearQuest(Quest Quests)                                                                            //퀘스트,업적 클리어시 호출
        {
            if (Quests.Type == QuestType.Hunting || Quests.Type == QuestType.Stage)
            {
                if (Quests.Level == 0)
                {
                    Quests.IsClear = true;            //완료표시
                    Console.WriteLine($"{Quests.Title} 퀘스트완료");
                    Thread.Sleep(1000);

                }
                else if (Quests.Level == 1)
                {
                    //player 골드 , 경험치 중량증가
                }
                else if (Quests.Level == 2)
                {
                    //player 골드 , 경험치 대량증가
                }
            }
            else if(Quests.Type == QuestType.Hidden && Quests.IsClear == false)
            {
                
                Quests.IsClear = true;
                Console.WriteLine($"{Quests.Title} 업적 완료");
                Thread.Sleep(1000);
            }


        }
        public void Reward(Quest Quests)
        {
            if (Quests.Level == 0)
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
