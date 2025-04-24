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

        public void StartDungoen(Player player)
        {
            Console.WriteLine("던전에 입장하였습니다.");
            bool isWin = dungeon.GoBattletF(player, dungeon.GetMonsterList(Floor));
            if (isWin)
            {

                Floor++;
                

            }
            else
            {
                
            }
        }

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

