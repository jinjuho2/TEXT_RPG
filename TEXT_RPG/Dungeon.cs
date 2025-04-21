using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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

    public void BattleScene()
    {

        //몹렙 / 몬스터 이름 / 몬스터 체력


        Console.WriteLine("[내정보]");
        Console.WriteLine($"LV{Player.level} {Player.name}");
        Console.WriteLine($"{currentHP} / {maxHP}");
        Console.WriteLine($"{currentMP} / {maxMP}");
        Console.WriteLine("");
        Console.WriteLine("1.공격");
        Console.WriteLine("2.스킬");
        Console.WriteLine("3.인벤토리?");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력해 주세요");
        Console.WriteLine(">>");
        Console.ReadLine();

    }

    public void BattleSystem()
    {
        Console.Clear();
        BattleScene();
        //while (Player.currentHP > 0 && Monster.isdead == true || Player.currentHP < 0)
        
            if (Player.currentHP > 0 && Monster.isdead == true)
            {
                
                Console.Clear();
                VictoryScene();
            }
            else if (Player.currentHP < 0)
            {
                
                Console.Clear();
                LoseScene();
            }
        
    }
    public void VictoryScene() // 스크립트 추가로 인한 수정필요
    {
        Console.WriteLine("Battle!! - Result");
        Console.WriteLine("");
        Console.WriteLine("Victory");
        Console.WriteLine("던전에서 몬스터를 n마리 잡으셨습니다.");
        Console.WriteLine($"LV{Player.level} {Player.name}");
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
        Console.WriteLine($"LV{Player.level} {Player.name}");
        Console.WriteLine("(플레이어 해당 층 입장체력 ) -> 0 ");
        Console.WriteLine("");
        Console.WriteLine("0.로비로 나가기");
        Console.WriteLine("");
        Console.WriteLine(">>");
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






































namespace TEXT_RPG
{






    internal class Dungeon
    {
    }
}
