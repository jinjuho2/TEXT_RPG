using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class DungeonEvent
    {
        public void TrainingF()//수련
        {
            Console.WriteLine("수련 이벤트 입니다.");
        }
        public void AlterF()//제단
        {
            Console.WriteLine("제단 이벤트 입니다.");
        }
        public void MysteryMerchant()//함정
        {
            Console.WriteLine("함정 이벤트 입니다.");
        }
        public void StatBoost()//업적
        {
            Console.WriteLine("히든업적 이벤트 입니다.");
        }
        public void NothingF()//없음
        {
            Console.WriteLine("아무것도 없는 이벤트 입니다.");
        }
    }
}
