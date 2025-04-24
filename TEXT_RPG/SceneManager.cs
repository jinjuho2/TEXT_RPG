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
        Layout Menulayout;
        Layout playerlayout;
        Layout Lobbylayout;
        Layout charaLayout;
        public int SetLobbyScene() //로비 
        {
            Lobbylayout= new Layout();
            Lobbylayout.SplitRows(new Layout(new Panel(
                new FigletText("TEXT MAPLE RPG")).Expand().SquareBorder()).Ratio(3), 
                new Layout("Start").Ratio(1),
                new Layout("End").Ratio(1));
            int index = 0;
            ConsoleKeyInfo key;
            bool isEnd = false;

      
            while (!isEnd)
            {
                if (index == 0)
                {
                    Lobbylayout["Start"].Update(
                 new Panel("[blink]시작[/]").AsciiBorder()
                    .Padding(1, 1));
                    Lobbylayout["End"].Update(
                 new Panel("종료").AsciiBorder()
                    .Padding(1, 1));

                }
                if (index == 1)
                {
                    Lobbylayout["Start"].Update(
                 new Panel("시작").AsciiBorder()
                    .Padding(1, 1));
                    Lobbylayout["End"].Update(
                 new Panel("[blink]종료[/]").AsciiBorder()
                    .Padding(1, 1));
                }
                AnsiConsole.Clear();
                AnsiConsole.Write(Lobbylayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index=1-index;
                        break;

                    case ConsoleKey.DownArrow:
                        index = 1 - index;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
            }

            return index;
        }
        public void CharaLayout()
        {
            charaLayout = new Layout();
            charaLayout.SplitRows(new Layout("menu").Ratio(1), new Layout("name").Ratio(1),new Layout().SplitColumns(new Layout("status").Ratio(3),new Layout("select").Ratio(1)).Ratio(5)
                );
            charaLayout["menu"].Update(new Panel(new Text("이름 입력").Centered()).Expand());
            charaLayout["name"].Update(new Panel(new Text("").Centered()).Expand());
            charaLayout["status"].Update(new Panel(new Text("").Centered()).Expand());
            charaLayout["select"].Update(new Panel(new Text("").Centered()).Expand());
            AnsiConsole.Console.Clear();
            AnsiConsole.Write(charaLayout);
        }
        public string setName()
        {
            ConsoleKeyInfo key;
            string input="";
            while (true) {
                key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Backspace &&input.Length > 0)
            {
                input =input.Remove(input.Length - 1);
                
            }
            else if(key.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if(!char.IsControl(key.KeyChar)&&key.KeyChar != ' ')
                    input+=key.KeyChar;

                AnsiConsole.Console.Clear();
                charaLayout["name"].Update(new Panel(new Text("\n"+input).Centered()).Expand());
                AnsiConsole.Write(charaLayout);

            }
            return input;
        }
        public int SetJob(List<string> menu)
        {
            bool isEnd = false;
            int i=-1;
            while (!isEnd) { 
                i = makeSelect(menu, charaLayout["select"]); 
            }
            return i;
        }
       
        public int MenuLayout()
        {
            var layout = new Layout();

            layout.SplitRows(
                new Layout(new Panel(new Text("MENU").Centered()).Expand()).Size(3),
                new Layout("Middle")
                    .SplitColumns(new Layout().SplitRows(
                        new Layout("dungeon"),
                        new Layout("shop"),new Layout("player"),new Layout("quest")).Ratio(1),new Layout("MAP").Ratio(4))
                );
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            while (!isEnd)
            {
                switch (index)
                {
                    case 1:
                  layout["dungeon"].Update(new Panel("[blink]던전[/]") .Expand()  .Padding(0, 0));
                        layout["shop"].Update(new Panel("상점").Expand().Padding(0, 0));
                        layout["player"].Update(new Panel("플레이어 정보").Expand().Padding(0, 0));
                        layout["quest"].Update(new Panel("퀘스트").Expand().Padding(0, 0));
                        break;
                    case 2:
                        layout["dungeon"].Update(new Panel("던전").Expand().Padding(0, 0));
                        layout["shop"].Update(new Panel("[blink]상점[/]").Expand().Padding(0, 0));
                        layout["player"].Update(new Panel("플레이어 정보").Expand().Padding(0, 0));
                        layout["quest"].Update(new Panel("퀘스트").Expand().Padding(0, 0));
                        break;
                    case 3:
                        layout["dungeon"].Update(new Panel("던전").Expand().Padding(0, 0));
                        layout["shop"].Update(new Panel("상점").Expand().Padding(0, 0));
                        layout["player"].Update(new Panel("[blink]플레이어 정보[/]").Expand().Padding(0, 0));
                        layout["quest"].Update(new Panel("퀘스트").Expand().Padding(0, 0));
                        break;
                    case 4:
                        layout["dungeon"].Update(new Panel("던전").Expand().Padding(0, 0));
                        layout["shop"].Update(new Panel("상점").Expand().Padding(0, 0));
                        layout["player"].Update(new Panel("플레이어 정보").Expand().Padding(0, 0));
                        layout["quest"].Update(new Panel("[blink]퀘스트[/]").Expand().Padding(0, 0));
                        break;
                }
                
                AnsiConsole.Clear();
                AnsiConsole.Write(layout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
                if (index < 1)
                    index = 4;
                if (index > 4)
                    index = 1;
            }
            return index;

        }
        public int PlayerLayout()
        {
           

            playerlayout.SplitRows(
                new Layout(new Panel(new Text("MENU").Centered()).Expand()).Size(3),
                new Layout("Middle")
                    .SplitColumns(new Layout().SplitRows(
                        new Layout("status"),
                        new Layout("item"), new Layout(""), new Layout("")).Ratio(1), new Layout("MAP").Ratio(4))
                );
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            while (!isEnd)
            {
                switch (index)
                {
                    case 1:
                        playerlayout["status"].Update(new Panel("[blink]스테이터스[/]").Expand().Padding(0, 0));
                        playerlayout["item"].Update(new Panel("아이템").Expand().Padding(0, 0));
      
                        break;
                    case 2:
                        playerlayout["status"].Update(new Panel("[blink]스테이터스[/]").Expand().Padding(0, 0));
                        playerlayout["item"].Update(new Panel("아이템").Expand().Padding(0, 0));    
                        break;
                 
                }

                AnsiConsole.Clear();
                AnsiConsole.Write(playerlayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
                if (index < 1)
                    index = 2;
                if (index > 2)
                    index = 1;
            }
            return index;

        }
        private int ScrollMenu(List<Item> items,Layout lay)
        {
            int input=0;
            return input;
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
        private int makeSelect(List<string> menu,Layout layout)
        {
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            while (!isEnd)
            {
                string a = "\n";
                for (int i = 0; i < menu.Count; i++)
                {
                    if (i + 1 == index)
                        a += ("[bold]-> " + i + ": " + menu[i] + "[/]\n\n");
                    else
                        a += (i + ": " + menu[i] + "\n\n");
                }
                layout.Update(
                new Panel(a)
                   .Expand()
                   .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(layout);
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
                if (index < 1)
                    index = menu.Count;
                if (index > menu.Count)
                    index = 1;
            }
            return index;
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
