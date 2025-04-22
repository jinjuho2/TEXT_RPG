// See https://aka.ms/new-console-template for more information

using TEXT_RPG;

namespace TEXTRPG
{
    class Program
    {
        static void Main(String[] args) 
        {
            GameManager gm = new GameManager();
            gm.Init();
            gm.Run();
        }
    }
}
