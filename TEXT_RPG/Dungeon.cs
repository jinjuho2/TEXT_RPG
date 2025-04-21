using System;
using System.Collections.Generic;
using System.Linq;

using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TEXT_RPG;

/*
스토리 진행
파풀라투스가 이상한걸 만들어서 해결하러 간다
가는길에 슬리피우드 신전에 들릴지 말지 선택 - 안들리면 클리어 하기 힘들게? 아니면 퀘스트로 좋은 보상
9층은 보스?
던전 진행하면서 10층은 같은 지역, 10층마다 쉼터겸 마을
던전 클리어시? 탈출or 3개의 방 중 선택가능(선택지 보임 상점도 선택지에
전투중에는 탈출 불가능
11층에서 탈출하면 10층으로 돌아가기 - 탈출하는데 마을귀환 주문서 필요 - 메소 
쉼터를 지나면 다음 지역으로 퀘스트는 모든 쉼터에서 받고, 클리어 가능
한 층에 몬스터는 1~4마리
지역 - 헤네시스 페리온 엘리니아 슬리피우드  저주받은 신전, 루디브리엄    시계탑 최하층     행복한 마을      운영자의 방 - 99층 신 창 섭
                                    ㄴ 퀘스트 하나 넣어주기
*/
//필요한거
//기본 던전 인터페이스
//10층마다 나오는 마을
//쉼터를 제외한 랜덤 방

//기본 던전 인터페이스
//현재 지역
//
//Battle!!

//1 Lv.2 미니언  HP 15
//2 Lv.5 대포미니언 HP 25
//3 LV.3 공허충 Dead

//[내정보]
//Lv .1  Chad(전사)
//HP 100/100 

//0. 취소

//대상을 선택해주세요.
//>>


namespace TEXT_RPG
{






    internal class Dungeon
    {
        
        public string DungeonSelect { get; set; }
        BattleManager bm;
        bool isEnd = false;
        //전투 장면은 배틀씬에서 할 듯합니다 몬스터의 배열과 방 선택등을 구현해주시면 감사하겠습니다.
        //일단 임시로 만들어 보았습니다... 원하는대로 수정하세요
        //던전매니저를 만들고 던전들의 속성을 클래스에서 관리하는 것도 가능할지도...... 그치만 이런식으로 하고 문자열로 나누는 게 더 나을수도 있습니다 자유롭게.
            public void DungeonRun()
            {
            bm= new BattleManager(); //이 앞에 던전 진입시 나오는 문구를 넣으면 됩니다.
            isEnd = false;
            while (!isEnd)
            {                          //이 안에 던전의 문구를 넣으시면 됩니다.
               bool isWin=bm.Battle(); //배틀매니저의 실행입니다. 여기에 특정값(ex: 몬스터들,방 특성)들을 넣어주시면 됩니다.
                                       //또한 배틀씬을 보고 싶지 않은 경우 bm.Battle을 보고 싶은 값으로 변경해주세요 (ex: 승리시 true 패배시 false)
                if (isWin) //승리시 true 패배시 false. 만약 도주나 다른 값을 넣고 싶으면 말씀해주세요 enum등으로 변경하면 됩니다.
                {
                    isEnd=true;
                    //승리시... 기타등등
                }
            }

        }


        //public void BattleScene()
        //{

        //    //몹렙 / 몬스터 이름 / 몬스터 체력


        //    Console.WriteLine("[내정보]");
        //    Console.WriteLine($"LV{Player.level} {Player.name}");
        //    Console.WriteLine($"{currentHP} / {maxHP}");
        //    Console.WriteLine($"{currentMP} / {maxMP}");
        //    Console.WriteLine("");
        //    Console.WriteLine("1.공격");
        //    Console.WriteLine("2.스킬");
        //    Console.WriteLine("3.인벤토리?");
        //    Console.WriteLine("");
        //    Console.WriteLine("원하시는 행동을 입력해 주세요");
        //    Console.WriteLine(">>");
        //    Console.ReadLine();

        //} 

        //public void BattleSystem()
        //{
        //    Console.Clear();
        //    BattleScene();
        //    //while (Player.currentHP > 0 && Monster.isdead == true || Player.currentHP < 0)

        //    if (Player.currentHP > 0 && Monster.isdead == true)
        //    {

        //        Console.Clear();
        //        VictoryScene();
        //    }
        //    else if (Player.currentHP < 0)
        //    {

        //        Console.Clear();
        //        LoseScene();
        //    }

        //}
        public void VictoryScene() // 스크립트 추가로 인한 수정필요
        {
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine("");
            Console.WriteLine("Victory");
            Console.WriteLine("던전에서 몬스터를 n마리 잡으셨습니다.");
            Console.WriteLine($"LV{Player.Instance.Level} {Player.Instance.Level}");
            Console.WriteLine("(플레이어 해당 층 입장체력 ) -> (플레이어 해당 층 클리어 체력 ");// 어캐하지
            Console.WriteLine("");
            Console.WriteLine($"1.{DungeonSelect}으로 진행하기");
            Console.WriteLine($"2.{DungeonSelect}으로 진행하기");
            Console.WriteLine($"3.{DungeonSelect}으로 진행하기");
            Console.WriteLine("");
            Console.WriteLine("0 - 마을귀환주문서 사용하기");
            Console.WriteLine(">>");
        }

        public void LoseScene()
        {
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine("");
            Console.WriteLine("You Lose");
            Console.WriteLine($"LV{Player.Instance.Level} {Player.Instance.Level}");
            Console.WriteLine("(플레이어 해당 층 입장체력 ) -> 0 ");
            Console.WriteLine("");
            Console.WriteLine("0.로비로 나가기");
            Console.WriteLine("");
            Console.WriteLine(">>");
        }
    }
}

//enum DungeonSelect//방 숫자와 몬스터의 수는 상관x 상자방의 확률 조정용
//{
//    상자방 = 1,
//    상점,
//    상점1,
//    약한몬스터,
//    약한몬스터1,
//    약한몬스터2,
//    약한몬스터3,
//    약한몬스터4,
//    일반몬스터,
//    일반몬스터1,
//    일반몬스터2,
//    일반몬스터3,
//    일반몬스터4,
//    엘리트몬스터,
//    엘리트몬스터1
//}




































