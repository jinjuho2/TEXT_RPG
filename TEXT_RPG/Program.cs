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
            DataManager.Instance().Init();
            test();
      
            
            //GameManager.Instance().Init();
            
            //GameManager.Instance().Run();
        }
        static void test()
        {
            List<Monster> enm=new List<Monster>();
            enm.Add(DataManager.Instance().makeMonster(1));
            enm.Add(DataManager.Instance().makeMonster(2));
            AnsiConsole.Write(EnemyPanel(enm));
        }
        static Panel EnemyPanel(List<Monster> mons)
        {
            Panel panel;
            string monInfos="";
            foreach (Monster mon in mons) {
                monInfos+=$"{mon.Name} HP:{mon.CurrentHP}/{mon.MaxHp}\n";  
            }
          
            panel = new Panel(new Text(monInfos).Centered()).Expand();
            
            return panel;
        }
    }
}
