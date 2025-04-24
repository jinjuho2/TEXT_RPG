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
            var layout = CreateBattleLayout(EnemyPanel(mons),RoomPanel(room),INFOPanel(player),OrderPanel(),DiagLog(a));
            AnsiConsole.Write(layout);
            //Console.ReadKey(true);

        }
        
        public void UpdateBattleScene()
        {
           
        }

        private  Layout CreateBattleLayout(Panel Mon, Panel room, Panel info, Panel Order,Panel dialog)
        {
            var layout = new Layout();

            layout.SplitRows(
                new Layout("RoomInfo").Size(3),
                new Layout("Middle").SplitColumns(                      
                    new Layout("MonInfo").Ratio(3), 
                    new Layout("RightRight").Ratio(1)),
                new Layout("Bottom")
                    .SplitColumns(
                        new Layout("OrderInfo"),
                        new Layout("DataInfo").Ratio(2))
                );
            layout["RoomInfo"].Update(
                room);
            layout["OrderInfo"].Update(
                Order);

            layout["DataInfo"].Update(
             info);

            layout["RightRight"].Update(
                dialog);

            layout["MonInfo"].Update(
            Mon);

            return layout;
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
        static Panel OrderPanel()
        {


            return new Panel("\n 1. 공격\n\n 2. 아이템")
                     .Expand()
                     .Padding(0, 0);
        }
    }
}
