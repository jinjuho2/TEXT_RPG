// See https://aka.ms/new-console-template for more information

using TEXT_RPG;

namespace TEXTRPG
{


    class Program
    {
        static void Main(String[] args) 
        {
            GameManager gm = new GameManager(); //진짜 임시... 나중에 다 고쳐야합니다. 기능 확인 하시라고 넣었어요
            gm.Init();
            gm.Run();


        }


    }
}
