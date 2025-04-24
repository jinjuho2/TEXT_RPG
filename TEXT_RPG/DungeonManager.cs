using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Spectre.Console;

namespace TEXT_RPG
{
    internal class DungeonManager
    {
        public int Floor = 0;

        Dungeon dungeon;
        Player player;

        //public void StartDungoen(Player player)
        //{
        //    Console.WriteLine("던전에 입장하였습니다.");
        //    bool isWin = dungeon.GoBattletF(player, dungeon.GetMonsterList(Floor));
        //    if (isWin)
        //    {

        //        Floor++;


        //        SetRandomDungeons();

        //        Console.WriteLine($"1. {((DungeonType)selectedDungeons[0])} 으로 진행");
        //        Console.WriteLine($"2. {((DungeonType)selectedDungeons[1])} 으로 진행");
        //        Console.WriteLine($"3. {((DungeonType)selectedDungeons[2])} 으로 진행");
        //        Console.WriteLine("0 - 마을귀환주문서 사용");
        //        Console.Write(">> ");

        //        Floor.Instance().nowFloor++;
        //        Floor.Instance().CheckHighFloor();

        //        string inputStr = Console.ReadLine();
        //        if (int.TryParse(inputStr, out int input))
        //        {
        //            switch (input)
        //            {
        //                case 1:
        //                    HandleDungeon(selectedDungeons[0]);
        //                    break;
        //                case 2:
        //                    HandleDungeon(selectedDungeons[1]);
        //                    break;
        //                case 3:
        //                    HandleDungeon(selectedDungeons[2]);
        //                    break;
        //                case 0:
        //                    Console.WriteLine("마을로 귀환합니다.");
        //                    Floor.Instance().nowFloor = Floor.Instance().nowFloor - (Floor.Instance().nowFloor % 10) + 1;
        //                    TownWarp();
        //                    break;
        //                default:
        //                    Console.WriteLine("입력 오류");
        //                    break;
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //}

        public bool DungeonRun(int floor)//던전을 한번 실행한다
        {
            dungeon = new Dungeon();
            Random rnd = new Random();
            int dungeonNum = rnd.Next(1, 100);
            bool isWin;

            if (dungeonNum >= 0 && dungeonNum < 45)//전투방
            {
                isWin = dungeon.GoBattletF(player, dungeon.GetMonsterList(floor));

            }
            else if(dungeonNum>=45 && dungeonNum < 75)//이벤트방?
            {
                dungeon.GOEventF(player);
                return true;
            }
            else if(dungeonNum >= 75 && dungeonNum <90 )//휴식방
            {
                dungeon.GoRestF(player);
                return true;
            }
            else //보상방
            {
                dungeon.GORewardF(player);
                return true;
            }
            return isWin;
        }
        public void ChoiceDungeon()//선택지를 3개주어지게 하는 메서드
        {

            Random rnd = new Random();
            int dungeonNum = rnd.Next(1, 100);
            string[] arr = new string [3];

            for (int i = 0; i < 3; i++)
            {
                string message;
                if (dungeonNum >= 0 && dungeonNum < 45)//전투방
                {
                    Console.WriteLine("전투방 입니다.");
                    message = "전투방";
                    
                }
                else if (dungeonNum >= 45 && dungeonNum < 75)//이벤트방?
                {
                    Console.WriteLine("이벤트방 입니다.");
                    message = "이벤트방";
                }
                else if (dungeonNum >= 75 && dungeonNum < 90)//휴식방
                {
                    Console.WriteLine("휴식방 입니다.");
                    message = "휴식방";
                }
                else //보상방
                {
                    Console.WriteLine("보상방입니다");
                    message = "보상방";
                }
               arr[i] = message;
            }
            foreach (string str in arr)
            {
                Console.WriteLine(str);
            }
        }




    }
}

