// See https://aka.ms/new-console-template for more information

using TEXT_RPG;

namespace TEXTRPG
{
    class Program
    {
        static void Main(String[] args) 
        {
            DataManager.Instance().Init();
            GameManager.Instance().Init();
            
            GameManager.Instance().Run();
        }
    }
}
