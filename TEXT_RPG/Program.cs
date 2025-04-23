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
            var layout = CreateLayout();
            AnsiConsole.Write(layout);
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
        private static Layout CreateLayout()
        {
            var layout = new Layout();

            layout.SplitRows(
                new Layout("Top")
                    .SplitColumns(
                        new Layout("Left")
                            .SplitRows(
                                new Layout("LeftTop"),
                                new Layout("LeftBottom")),
                        new Layout("Right").Ratio(2),
                        new Layout("RightRight").Size(3)),
                new Layout("Bottom"));

            layout["LeftBottom"].Update(
                new Panel("[blink]PRESS ANY KEY TO QUIT[/]")
                    .Expand()
                    .BorderColor(Color.Yellow)
                    .Padding(0, 0));

            layout["Right"].Update(
                new Panel(
                    new Table()
                        .AddColumns("[blue]Qux[/]", "[green]Corgi[/]")
                        .AddRow("9", "8")
                        .AddRow("7", "6")
                        .Expand())
                .Header("A [yellow]Table[/] in a [blue]Panel[/] (Ratio=2)")
                .Expand());

            layout["RightRight"].Update(
                new Panel("Explicit-size-is-[yellow]3[/]")
                    .BorderColor(Color.Yellow)
                    .Padding(0, 0));

            layout["Bottom"].Update(
            new Panel(
                    new FigletText("Hello World"))
                .Header("Some [green]Figlet[/] text")
                .Expand());

            return layout;
        }
        static Panel INFOPanel(List<Monster> mons)
        {
            Panel panel;
            string monInfos = "";
            foreach (Monster mon in mons)
            {
                monInfos += $"{mon.Name} HP:{mon.CurrentHP}/{mon.MaxHp}\n";
            }

            panel = new Panel(new Text(monInfos).Centered()).Expand();

            return panel;
        }
    }
}
