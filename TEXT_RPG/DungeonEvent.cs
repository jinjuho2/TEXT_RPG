using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class DungeonEvent
    {
        public void TrainingF(Player player)//수련
        {
           
            Thread.Sleep(2000);
            Console.WriteLine("...");
            Thread.Sleep(1500);
            Console.WriteLine("갑자기 당신의 앞에 허수아비가 나타났습니다.");
            Thread.Sleep(2000);
            Console.WriteLine("깜짝 놀란 당신은 허수아비에 화풀이를 했습니다.");
            Thread.Sleep(1500);
            Console.WriteLine("왠지 몸이 가벼워진것 같습니다.");

            player.ATK += 2;
            player.DEF += 1;
            player.MaxHp += 10;
            Console.WriteLine($"공격력 2 방어력 1 체력 10 상승!");
        }
        public void AlterF(Player player)//제단
        {
            
            Console.WriteLine("당신의 앞에 정체를 알수 없는 제단이 있습니다.");
            Console.WriteLine("고급스러워 보이는 이 제단에 무언가를 바친다면 좋은걸 얻을 수 있을거다.");//여기부터 말투 바뀌는게 맞습니다.
            Console.WriteLine("무엇을 바칠것인가.");
            Console.WriteLine("1. 피를 바친다.(현재체력의 20%)");
            Console.WriteLine("2. 골드를 바친다");
            Console.WriteLine("3. 무시하고 지나간다.");
            Console.WriteLine($"HP = {player.CurrentHP} / {player.TotalMaxHP}");
            Console.WriteLine($"{player.Gold} Gold");
            Console.Write(">> ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("무언가 바치는게 좋아보인다.");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("피를 바쳐라.");
                    Console.WriteLine("당신의 체력이 빠져나가는게 느껴집니다.");//결정 완료시 다시 원래말투로
                    Console.WriteLine($"체력 = {player.CurrentHP / 5}");
                    player.CurrentHP -= (player.CurrentHP / 5);
                    Console.WriteLine($"{player.CurrentHP} / {player.TotalMaxHP}");
                    Console.WriteLine("제단이 당신의 피에 반응합니다!!");
                    Thread.Sleep(2000);
                    Console.WriteLine("제단의 스킬 5000골드 소환!");
                    Console.WriteLine("당신은 5000골드에 깔렸습니다.체력이 1 깎였습니다.");//실제로 적용 안됨 지워도 무관
                    player.Gold += 5000;
                    Console.WriteLine($"{player.Gold} Gold");
                    break;
                case 2:
                    Console.WriteLine("골드를 바쳐라.");
                    Console.WriteLine("부족한 골드는 빚으로 달아두겠다.");
                    Console.WriteLine($"{player.Gold} Gold");
                    Console.WriteLine("1.1000골드");
                    Console.WriteLine("2.2000골드 ");
                    Console.WriteLine("3.5000골드....?");

                    int choice1;
                    while (!int.TryParse(Console.ReadLine(), out choice1) || choice1 < 1 || choice1 > 3)
                    {
                        Console.WriteLine("골드를 바쳐라.");
                    }

                    switch(choice1)
                    {
                        case 1:
                            Console.WriteLine("1000골드 받아간다.");
                            player.Gold -= 1000;
                            Thread.Sleep(2000);
                            Console.WriteLine("제단에 바친 1000골드가 1500골드가 되어 돌아왔습니다.");
                            player.Gold += 1500;

                            break;
                        case 2:
                            Console.WriteLine("2000골드 받아간다.");
                            player.Gold -= 2000;
                            Thread.Sleep(2000);
                            Console.WriteLine("제단에 바친 2000골드가 4000골드가 되어 돌아왔습니다.");
                            player.Gold += 4000;
                            break;
                        case 3:
                            Console.WriteLine("5000골드...?");
                            player.Gold -= 5000;
                            Thread.Sleep(2000);
                            Console.WriteLine("제단에서 발이 나와 재빠르게 도망가기 시작합니다!!");//메소 복사 사기꾼 ?
                            Console.WriteLine("당신은 쫒아갔으나 제단은 끝내 당신의 시야에서 벗어났습니다");
                            Thread.Sleep(2000);
                            Console.WriteLine("당신은 주변을 샅샅이 뒤져보았으나 아무것도 찾지 못하였습니다.");
                            Thread.Sleep(2000);
                            Console.WriteLine(".........");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("당신은 제단의 유혹을 애써 무시하고 나아갑니다.\n당신의 의지가 충만해집니다.");//아무 의미 없음 지워도 무관
                    break;
            }


        }
        public void BoomF(Player player)//함정
        {
            Console.WriteLine(" \"딸깍!\" ");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine("???");
            Console.WriteLine("던전을 걷던 당신의 발 밑에서 수상한 소리가 났습니다..?");
            Console.WriteLine("뭔가 이상함을 느낀 당신은 신중하게 움직입니다...");
            Thread.Sleep(2000);
            Console.WriteLine(" \"쾅!!!\"");
            Thread.Sleep(1000);
            Console.WriteLine("큰 소리와 함께 뒤쪽에서 폭발이 일어났습니다.");
            Console.WriteLine("폭발로 인해 날라간 당신은 부상을 입었습니다");
            Thread.Sleep(1000);
            player.CurrentHP -= (player.CurrentHP / 2);
            Console.WriteLine($"체력이{player.CurrentHP / 2}만큼 감소하였습니다. ");

        }
        public void arrowF(Player player)//함정
        {
            Console.WriteLine(" \"딸깍!\" ");
            Thread.Sleep(1000);
            Console.WriteLine("???");
            Thread.Sleep(500);
            Console.WriteLine(" \"슉.슈슉.슈슉.슉.슉 \"");//화살소리 맞음 아마도
            Console.WriteLine("옆에서 화살이 날라옵니다!!");
            Console.WriteLine("당신은 재빨리 굴러서 피했습니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{player.Name}: 피했죠?");
            Thread.Sleep(1000);
            Console.WriteLine("화살 하나가 어깨에 맞았습니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{player.Name}: 하지만 살았죠?");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            player.CurrentHP -= (player.CurrentHP / 4);
            Console.WriteLine($"체력이{player.CurrentHP / 4}만큼 감소하였습니다. ");
        }
        public void NothingF(Player player)//없음
        {
            Console.WriteLine(" \"딸깍!\" ");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine("???");
            Console.WriteLine("던전을 걷던 당신의 발 밑에서 수상한 소리가 났습니다..?");
            Console.WriteLine("뭔가 이상함을 느낀 당신은 신중하게 움직입니다...");
            Thread.Sleep(2000);
            Console.WriteLine("10분 뒤....");
            Console.WriteLine("당신은 무사히 그 자리를 빠져나왔습니다.");
            Console.WriteLine("그 소리가 무슨소리인지는 아무도 모를 것 입니다... ");
        }
        public void AchieveF(Player player)//업적
        {
            bool isSelected = true;
            Random random = new Random();
            int i = random.Next(0, 2);
            switch (i)
            {
                case 0:
                    Console.WriteLine("[히든 방] 검은 마법사의 흔적 \n\n 방 안에 검은 기운이 피어오르고, 무언가 보이지 않는 힘이 당신을 누른다.\r\n\"이 힘은… 익숙해. 하지만…\"");
                    Thread.Sleep(1000);
                    Console.WriteLine("데몬의 환영: \"넌 이 힘을 이해할 수 있을까?\r\n받아들이면... 달라질 수도 있어.\"\n");
                    Console.WriteLine("1. 힘을 받아들인다. 2. 저항한다");
                    while (isSelected)
                    {
                        int input = int.Parse(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                isSelected = false;
                                QuestManager.Instance().HiddenRoomArcheive(102);
                                Console.WriteLine("어둠의 힘이 몸속에 깃들었습니다.");
                                Thread.Sleep(1000);
                                break;
                            case 2:
                                isSelected = false;
                                QuestManager.Instance().HiddenRoomArcheive(103);
                                Console.WriteLine("데몬의 말을 무시하고 방을 나갔습니다.");
                                Thread.Sleep(1000);
                                break;
                            default:
                                Console.WriteLine("올바른 입력이 아닙니다");
                                Thread.Sleep(1000);
                                break;
                        }
                    }
                    break;


                case 1:
                    Console.WriteLine("[히든 방] 수수께끼의 방 \n\n 방에 들어서니 낯익는 사람이 보인다\r\n\"당신은.. ? !\"");
                    Thread.Sleep(1000);
                    Console.WriteLine("오한별의 환영: \"당신은 이세계에 대해 잘 아십니까 ?\r\n빅뱅이 일어난 시기를 맞춰보세요.\"\n");
                    Console.WriteLine("1. 2011년 5월 . 2. 2009년 11월 3. 2010년 7월");
                    while (isSelected)
                    {
                        int input = int.Parse(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                            case 2:
                                isSelected = false;
                                QuestManager.Instance().HiddenRoomArcheive(104);
                                Console.WriteLine("오한별 : 메알못이군요.");
                                Thread.Sleep(1000);
                                break;
                            case 3:
                                isSelected = false;
                                QuestManager.Instance().HiddenRoomArcheive(105);
                                Console.WriteLine("오한별 : 오호.. 정답입니다!");
                                Thread.Sleep(1000);
                                break;
                            default:
                                Console.WriteLine("올바른 입력이 아닙니다");
                                Thread.Sleep(1000);
                                break;
                        }
                    }
                    break;
            }
            Console.WriteLine("히든업적 이벤트 입니다.");

        }
    }
}


