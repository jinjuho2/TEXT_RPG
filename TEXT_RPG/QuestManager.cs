using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class QuestManager
    {
        public List<Quest> Quests { get; set; }

        private GameManager gameManager;
        public QuestManager(GameManager gameManager)
        {
            this.gameManager = gameManager;
            Quests = new List<Quest>();
        }

        public void QuestWindow()
        {
            bool isRunning = false;
            while (!isRunning)
            {
                Console.WriteLine("퀘스트창");
                ShowQuest(1);
                Console.WriteLine("고르셈 \n 0.나가기");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    isRunning = true;
                    gameManager.Start();
                }
                else if (input <= Quests.Count)
                {
                    Quests[input].IsActive = true;

                }
            }


        }

        public void AddQuest()
        {
            Quests.Add(new Quest { Title = "주황버섯을 잡아라!", Etc = "주황버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 1, Type = QuestType.Hunting});
            Quests.Add(new Quest { Title = "뿔버섯을 잡아라!", Etc = "뿔버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false , level = 1 ,Type = QuestType.Hunting });
            Quests.Add(new Quest { Title = "초보 여행가", Etc = "타워 10층을 완료하세요",IsClear = false , level = 1 , Type = QuestType.StageClear });

            Quests.Add(new Quest { Title = "ㅇ버섯을 잡아라!", Etc = "주황버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 2, Type = QuestType.Hunting });
            Quests.Add(new Quest { Title = "ㄷ섯을 잡아라!", Etc = "뿔버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 2, Type = QuestType.Hunting });
            Quests.Add(new Quest { Title = "중급 여행가", Etc = "타워 20층을 완료하세요", IsClear = false, level = 2, Type = QuestType.StageClear });
        }
        
        public void ShowQuest(int currentlevel)
        {
            
            foreach (Quest quest in Quests)
            {
                if(quest.level <= currentlevel && quest.IsClear == false)
                {
                    switch (quest.Type)
                    {
                        case QuestType.Hunting:
                            Console.WriteLine($"{quest.Title} : {quest.Etc} ");
                            break;
                        case QuestType.StageClear:
                            Console.WriteLine($"{quest.Title} : {quest.Etc} ");
                            break;
                        case QuestType.ItemEvent:

                            break;
                        case QuestType.Hidden:

                            break;
                    }
                }
            }
        }

        public void QuestClear(QuestType type)
        {
            //player 골드 , 경험치 증가
            //성공한 해당 퀘스트 사라짐
            


        }



    }
}
