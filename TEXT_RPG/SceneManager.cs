using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class SceneManager
    {
        private static SceneManager instance;
        public static SceneManager Instance()
        {
            if (instance == null)
                instance = new SceneManager();
            return instance;
        }
        Layout battlelayout;
        
        
        private Layout InvenLayout()
        {
            var layout = new Layout();

            layout.SplitRows(
                new Layout("RoomInfo").Size(3),
                new Layout("Middle")
                    .SplitColumns(
                        new Layout("Menu"),
                        new Layout("Info").Ratio(2))
                );
            layout["RoomInfo"].Update(
                new Panel(new Text("Room 1").Centered())
                     .Expand()
                     .BorderColor(Color.Yellow)
                     .Padding(0, 0));




            return layout;
        }

        public void InitBattleScene(List<Monster> mons,string room,Player player,string a)
        {
            AnsiConsole.Clear();
            CreateBattleLayout(EnemyPanel(mons),RoomPanel(room),INFOPanel(player),DiagLog(a));
            AnsiConsole.Write(battlelayout);
            //Console.ReadKey(true);

        }
        
        public void UpdateBattleScene(Player player)
        {
            
        }
        public int UpdatePlayerScene(List<string> menu)
        {
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            while (!isEnd)
            {
                string a="\n";
                for(int i=0;i<menu.Count; i++)
                {
                    if (i + 1 == index)
                        a += ("[bold]-> "+i+": " + menu[i] + "[/]\n\n");
                    else
                        a += (i + ": " + menu[i]+"\n\n");
                }
                battlelayout["OrderInfo"].Update(
                new Panel(a)
                   .Expand()
                   .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(battlelayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index++;
                    break;

                    case ConsoleKey.DownArrow:
                        index--;
                    break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                } 
                if(index<1)
                    index=menu.Count;
                if(index>menu.Count)
                    index=1;
            }
            return index;
        }

        private  void CreateBattleLayout(Panel Mon, Panel room, Panel info, Panel dialog)
        {
            battlelayout = new Layout();

            battlelayout.SplitRows(
                new Layout("RoomInfo").Size(3),
                new Layout("Middle").SplitColumns(                      
                    new Layout("MonInfo").Ratio(3), 
                    new Layout("RightRight").Ratio(1)),
                new Layout("Bottom")
                    .SplitColumns(
                        new Layout("OrderInfo"),
                        new Layout("DataInfo").Ratio(2))
                );
            battlelayout["RoomInfo"].Update(
                room);
            battlelayout["OrderInfo"].Update(
                new Panel("")
                     .Expand()
                     .Padding(0, 0));

            battlelayout["DataInfo"].Update(
             info);

            battlelayout["RightRight"].Update(
                dialog);

            battlelayout["MonInfo"].Update(
            Mon);

         
        }
        static Panel DiagLog(string a)
        {
            return new Panel(new Text(a).Centered())
                     .Expand()
                     .BorderColor(Color.Red)
                     .Padding(0, 0);
        }
        static Panel EnemyPanel(List<Monster> mons)
        {
            Panel panel;
            string monInfos = "\n";
            foreach (Monster mon in mons)
            {
                monInfos += $"{mon.Name} HP:{mon.CurrentHP}/{mon.MaxHp}\n\n";
            }

            panel = new Panel(new Text(monInfos).Centered()).Expand();

            return panel;
        }
        static Panel RoomPanel(string room)
        {
            return new Panel(new Text("Room 1").Centered())
                     .Expand()
                     .BorderColor(Color.Yellow)
                     .Padding(0, 0);
        }
        static Panel INFOPanel(Player player)
        {


            return new Panel($"\n{player.Name}({player.Job.ToString()}) HP: {player.CurrentHP}/{player.MaxHP} 마나: {player.CurrentMP}/{player.MaxMP} ")
                     .Expand()
                     .Padding(0, 0);
        }
      
    }
}
