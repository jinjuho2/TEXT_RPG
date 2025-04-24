using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Quest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Etc { get; set; } //몬스터 ID도 설명 받으므로 자동으로 생성 가능할 수도 있음
        public int CurrentCount { get; set; }
        public int TargetCount { get; set; } //이건 목표 몬스터 개수이고
        public int TargetID { get; set; } //이건 목표 몬스터 아이디인데 합쳐서 딕셔너리화하는 것도 생각해봐야함 몬스터 여러마리 사냥할 경우... 
        public bool IsActive { get; set; }
        public bool IsClear { get; set; }
        public bool IsComplete { get; set; }
        public QuestType Type { get; set; }

        public int? Level { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }

        public bool IsVisible { get; set; }

        public bool IsReward { get; set; }

        public Quest(string _Title, string _Etc,int  _TargetCount,int _targetId,QuestType _type,int _gold,int _exp, int _level)
        {
            Title = _Title;
            Etc = _Etc;
            CurrentCount = _TargetCount;
            TargetCount = _TargetCount;
            TargetID = _targetId;
            IsClear = false;
            IsActive = false;
            Type = _type;
            IsComplete = false;
            Gold = _gold;
            Exp = _exp;
            Level = _level;
        }
        public Quest() { }

    }

    public enum QuestType
    {
        Hunting,
        Stage,
        Hidden
    }
}
