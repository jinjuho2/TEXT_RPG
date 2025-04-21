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
        
        public QuestManager()
        {
            Quests = new List<Quest>();
        }

        public void AddQuest()
        {
            Quests.Add(new Quest { Title = "주황버섯을 잡아라!", Etc = "주황버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false, level = 1});
            Quests.Add(new Quest { Title = "뿔버섯을 잡아라!", Etc = "뿔버섯을 10마리 잡으세요", CurrentCount = 0, TargetCount = 10, IsClear = false , level = 1 });
            Quests.Add(new Quest { Title = "초보 여행가", Etc = "타워 10층을 완료하세요",IsClear = false , level = 1 });
        }
        public void ShowQuest(int currentlevel)
        {
            
            foreach (Quest quest in Quests)
            {
                if(currentlevel <= quest.level)
                {
                    Console.WriteLine($"{quest.Title} : {quest.Etc} , {quest.CurrentCount} | {quest.TargetCount}");
                }
            }
        }

        public void QuestClear(QuestType type)
        {
            //player 골드 , 경험치 증가
            //성공한 해당 퀘스트 사라짐
            


        }

        public 


    }
}
