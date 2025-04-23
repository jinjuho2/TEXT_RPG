using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TEXT_RPG.Dungeon;

namespace TEXT_RPG
{
    internal class Floor
    {

        public int floornum = 1;


        private static Floor instance;
        public static Floor Instance()
        {
            if (instance == null)
                instance = new Floor();
            return instance;
        }


        //public void FloorManager()
        //{
        //    if (floornum >= 1 && floornum <= 9)
        //    {

        //    }
        //    else if (floornum == 10)//머쉬맘
        //    {

        //    }
        //    else if (floornum == 11)//슬리피우드
        //    {

        //    }
        //    else if (floornum >= 12 && floornum <= 19)
        //    {

        //    }
        //    else if (floornum == 20)//주니어발록
        //    {

        //    }
        //    else if (floornum == 21)//엘나스
        //    {

        //    }
        //    else if (floornum >= 22 && floornum <= 29)
        //    {

        //    }
        //    else if (floornum == 30)//자쿰
        //    {

        //    }
        //    else if (floornum == 31)//리프레
        //    {

        //    }
        //    else if (floornum >= 32 && floornum <= 39)
        //    {

        //    }
        //    else if (floornum == 40)//혼테일
        //    {

        //    }
        //    else if (floornum == 41)//행복한 마을
        //    {

        //    }
        //    else if (floornum >= 42 && floornum <= 49)
        //    {

        //    }
        //    else if (floornum == 50)//신창섭
        //    {

        //    }
        //    else if (floornum == 51)//엔딩?
        //    {

        //    }
        //}
    }

}

//public void WarpManager(int DungeonEnum)//던전의 워프매니저 백업용
//{
//    Dungeonenum dungeon = (Dungeonenum)DungeonEnum;



//    if (DungeonEnum == 1)
//    {
//        Console.Clear();
//        Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//        chestWarp();

//    }
//    else if (DungeonEnum == 2)
//    {
//        Console.Clear();
//        Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//        shopWarp();
//    }
//    else if (DungeonEnum >= 3 && DungeonEnum <= 6)
//    {
//        Console.Clear();
//        Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//        weakmobWarp();
//    }
//    else if (DungeonEnum >= 7 && DungeonEnum <= 11)
//    {
//        Console.Clear();
//        Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//        commonmobWarp();
//    }
//    else if (DungeonEnum >= 12 && DungeonEnum <= 13)
//    {
//        Console.Clear();
//        Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//        elitemobWarp();
//    }
//    else if (DungeonEnum == 14)
//    {
//        Console.Clear();
//        Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//        eventWarp();
//    }
//    else
//    {
//        Console.Clear();
//        Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//        RestFloor();
//    }

//}