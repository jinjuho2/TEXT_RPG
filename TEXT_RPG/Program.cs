// See https://aka.ms/new-console-template for more information

using Spectre.Console;
using Spectre.Console.Rendering;
using System.Diagnostics;
using System.Text;
using TEXT_RPG;

namespace TEXTRPG
{
    class Program
    {
        static void Main(String[] args) 
        {
            Console.OutputEncoding = Encoding.UTF8;
            DataManager.Instance().Init();

            GameManager.Instance().Init();

            GameManager.Instance().Run();
        }
        
    }
}
