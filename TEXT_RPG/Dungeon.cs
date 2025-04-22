using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

던전 진행 

던전 클리어시? 탈출or 3개의 방 중 선택가능(선택지 보임 상점도 선택지에
전투중에는 탈출 불가능
11층에서 탈출하면 10층으로 돌아가기 - 탈출하는데 마을귀환 주문서 필요 - 메소 
쉼터를 지나면 다음 지역으로 퀘스트는 모든 쉼터에서 받고, 클리어 가능
한 층에 몬스터는 1~4마리

*/
/*
보스 : 머쉬맘, 주니어 발록 ,자쿰 ,혼테일 , 신창섭 
50층으로 줄이고
1~9층 헤네시스
11~20층 슬리피우드 - 저주받은 신전
21~30층 엘나스 - 폐광
31~40층  리프레 - 생명의 동굴
41~50층 행복한 마을 or 개발자의 공간 

1 헤네시스
11슬리피우드
21엘나스           마을
31리프레
41행복한마을
n1층_n9층 아래 만든 3택1방식 (상자,상점,몬스터,이벤트
n0층 - 보스 


층 클리어시 15개의 리스트중 랜덤 3개 고르고 출력, 플레이어가 3개중 1개를 고르는 로직은 일단완성

n0층마다 보스방으로 가는 로직?, n1층마다 마을로 가는 로직? 3택1방식에서 워프시켜줄 메서드, -워프 메서드는 완성했지만 다음전투같은거로 연결 은 해놨지만 몬스터 등급에 따른 차이 없음

이넘에 있는 방들 구현 - 
 */


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
            bm = new BattleManager(); //이 앞에 던전 진입시 나오는 문구를 넣으면 됩니다.
            isEnd = false;
            while (!isEnd)
            {                          //이 안에 던전의 문구를 넣으시면 됩니다.
                bool isWin = bm.Battle(); //배틀매니저의 실행입니다. 여기에 특정값(ex: 몬스터들,방 특성)들을 넣어주시면 됩니다.
                                          //또한 배틀씬을 보고 싶지 않은 경우 bm.Battle을 보고 싶은 값으로 변경해주세요 (ex: 승리시 true 패배시 false)
                if (isWin) //승리시 true 패배시 false. 만약 도주나 다른 값을 넣고 싶으면 말씀해주세요 enum등으로 변경하면 됩니다.
                {
                    isEnd = true;
                    VictoryScene();
                    //승리시... 기타등등
                }
            }

        }
        public enum Dungeonenum//상자방의 확률 조정용
        {
            상자방 = 1,
            상점,
            약한몬스터,
            약한몬스터1,
            약한몬스터2,
            약한몬스터3,
            일반몬스터,
            일반몬스터1,
            일반몬스터2,
            일반몬스터3,
            일반몬스터4,
            엘리트몬스터,
            엘리트몬스터1,
            이벤트,
            휴식

        }


        private List<int> selectedDungeons = new List<int>();

        public void DungeonSet()//던전 리스트를 랜덤하게 바꿔주는 메서드
        {

            Random rand = new Random();

            selectedDungeons = Enumerable.Range(1, 15)                  // Linq에서 제공하는 메서드. 1~15 사이의 리스트 만들기
                                          .OrderBy(x => rand.Next())    // .OrderBy = ()를 기준으로 무작위 정렬   x => rand.Next() = 각 항목에 대해 난수부여, 난수를 기준으로 순서를 섞기
                                          .Take(3)                      // 섞인 리스트에서 앞에 ()개수만 가져온다
                                          .ToList();                    //IEnumerable<int>을 List<int>로 변환 저장할 수 있게 함.
        }

        public void WarpManager(int DungeonEnum)//워프 추가 필요 // 일단 몬스터는 완료
        {
            Dungeonenum dungeon = (Dungeonenum)DungeonEnum;

            Console.WriteLine($"{dungeon} 층으로 이동합니다.");

            if (DungeonEnum == 1)
            {
                Console.Clear();
                
                chestWarp();
                
            }
            else if (DungeonEnum == 2)
            {
                Console.Clear();
                
                shopWarp();
            }
            else if (DungeonEnum >= 3 && DungeonEnum <= 6)
            {
                Console.Clear();
                
                weakmobWarp();
            }
            else if (DungeonEnum >= 7 && DungeonEnum <= 11)
            {
                Console.Clear();
                
                commonmobWarp();
            }
            else if (DungeonEnum >= 12 && DungeonEnum <= 13)
            {
                Console.Clear();
                
                elitemobWarp();
            }
            else if (DungeonEnum == 14 )
            {
                Console.Clear();
                
                eventWarp();
            }
            else
            {
                Console.Clear() ;

                RestFloor();
            }

        }

        public void VictoryScene()
        {
            Console.WriteLine("");
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine("");
            Console.WriteLine("Victory");
            Console.WriteLine("던전에서 몬스터를 n마리 잡으셨습니다.");
            Console.WriteLine($"LV{Player.Instance.Level} {Player.Instance.Name}");
            Console.WriteLine($"(플레이어 해당 층 입장체력 ) -> ({Player.Instance.CurrentHP})");// 해당 층 입장체력 어캐하지
            Console.WriteLine("");

            DungeonSet();

            Console.WriteLine($"1.{(Dungeonenum)selectedDungeons[0]}으로 진행하기");
            Console.WriteLine($"2.{(Dungeonenum)selectedDungeons[1]}으로 진행하기");
            Console.WriteLine($"3.{(Dungeonenum)selectedDungeons[2]}으로 진행하기");
            Console.WriteLine("");
            Console.WriteLine("0 - 마을귀환주문서 사용하기");
            Console.WriteLine(">>");


            ChooseNext();
        }
        public  void ChooseNext()
        {
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    WarpManager(selectedDungeons[0]);
                    break;
                case 2:
                    WarpManager(selectedDungeons[1]);
                    break;
                case 3:
                    WarpManager(selectedDungeons[2]);
                    break;
                case 0:
                    Console.WriteLine("마을귀환주문서를 사용하였습니다.");
                    Console.WriteLine("마을로 돌아갑니다.");
                    Thread.Sleep(1000);
                    //마을로 돌아가는 메서드
                    break;
                default:
                    Console.WriteLine("입력 오류");
                    break;
            }
        }
        // 층이 보스, 마을층이 아닐때만 이렇게, 보스층 , 마을은 별도 추가
            
        public void LoseScene()
        {
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine("");
            Console.WriteLine("You Lose");
            Console.WriteLine($"LV{Player.Instance.Level} {Player.Instance.Name}");
            Console.WriteLine("(플레이어 해당 층 입장체력 ) -> 0 ");
            Console.WriteLine("");
            Console.WriteLine("사망하셨습니다.");
            Console.WriteLine("0.처음으로 돌아가기");
            Console.WriteLine("");
            Console.WriteLine(">>");
        }


        public void chestWarp()
        {
            Console.WriteLine("상자 층 입니다");
        }
        public void eventWarp()
        {
            Console.WriteLine("이벤트 층 입니다.");
        }
        public void restWarp()
        {
            Console.WriteLine("휴식의 층 입니다.");
        }
        public void shopWarp()
        {
            Console.WriteLine("상점 층 입니다.");
        }
        public void weakmobWarp()
        {
            Console.WriteLine("약한 몬스터 층 입니다.");
            DungeonRun();
        }
        public void commonmobWarp()
        {
            Console.WriteLine("몬스터 층 입니다.");
            DungeonRun();
        }
        public void elitemobWarp()
        {
            Console.WriteLine("엘리트 몬스터 층 입니다.");
            DungeonRun();
        }
        public void townWarp()// 마을은 로비 복사?해서 조금씩 고치면 될거같은데
        {
            Console.WriteLine("마을입니다");
        }
        public void RestFloor()
        {
            if (Player.Instance.CurrentHP >= Player.Instance.MaxHP / 2)//플레이어의 현재체력이 50%보다 낮다면 
            {
                Player.Instance.CurrentHP += Player.Instance.MaxHP / 2;
                Console.WriteLine("충분한 휴식을 취해 체력이 회복되었습니다.");
            }
            else//플레이어의 체력이 50% 이상이면? 현재체력 + (최대체력-현재체력) = 풀피
            {
                Player.Instance.CurrentHP += (Player.Instance.MaxHP -= Player.Instance.CurrentHP);
                Console.WriteLine("충분한 휴식을 취해 체력이 모두 회복되었습니다.");
            }
        }





        class Floor
        {
            public int Floornum = 1;

            //                                          일반적인 방법으로 1에서부터 + 1       = 마귀주를 썼을때 층수/10 나머지를 버리고 +1한 층수로 이동? 
            //10의자리와 1의자리를 분리한 다음 1의자리 /10의 %값이 0이면 10의자리 숫자 +1?    = 마귀주를 썼을때 10의자리 숫자-1하고  이동
            //                           보스층을 n9층으로 바꾸고 마을을 n0층으로 바꾼다면?   = 마귀주 사용시 일의자리 지워버리고 이동?    아 근데 50층에 딱 신 창 섭이 나오면 좋을거 같긴한데

        }













        
         

    }
}




//    public void Warp()
//    {
//        for (int i = 0; i < 99; i++)
//        {
//            if(//층을 올라가면(로비 포함) )
//            {

//            }
//            else(//죽으면)
//            {

//            }
//        }
//    }



//}



















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
































