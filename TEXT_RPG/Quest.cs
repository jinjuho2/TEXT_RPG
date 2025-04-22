using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Quest
    {
        public string Title { get; set; }
        public string Etc { get; set; }
        public int CurrentCount { get; set; }
        public int TargetCount { get; set; }
        public bool IsClear { get; set; }
        public bool IsActive { get; set; }
        public QuestType Type { get; set; }

        public int level;

        public bool IsVisible { get; set; }



    }
    public enum QuestType
    {
        Hunting,
        StageClear,
        Hidden
    }
}
