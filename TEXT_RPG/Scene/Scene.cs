using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TEXT_RPG
{
    internal class Scene
    {
        Layout mainLayout; //레이아웃
        string name;
        Dictionary<string,Layout> layouts; //패널들
        public Scene(Layout layout, string name, Dictionary<string, Layout> panels)
        {
            this.name = name;
            layouts= panels;
            mainLayout = layout;

        }
        public void show()
        {
            AnsiConsole.Console.Clear();
            AnsiConsole.Write(mainLayout);
        }
        public int SelectPanel(List<string> temp,List<string> menu)
        {
            int index = 1;
            ConsoleKeyInfo key;
            List<Layout> a=new List<Layout>();
            foreach (var item in temp)
            {
                a.Add(layouts[item]);
            }
            bool isEnd = false;
            while (!isEnd)
            {
                for (int i = 0; i < a.Count; i++) {
                    if (i == index-1) {
                        a[i].Update(

                     new Panel("[bold]>"+menu[i]+"[/]").Expand().Padding(0, 0));
                    }
                    else
                        a[i].Update(
                     new Panel(menu[i]).Expand().Padding(0, 0));
                }
                show();
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
                    index = a.Count;
                if (index > a.Count)
                    index = 1;
            }

            return index;
        }
        public void Text(string name,string txt)
        {
            layouts[name].Update(new Panel(new Text(txt).Centered()).Expand());
            
        }
        public int SelectNum(List<string> menu,string name)
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
                        a += ("[bold]>" + menu[i] + "[/]\n\n");
                    else
                        a += ( menu[i] + "\n\n");
                }
                layouts[name].Update(
                new Panel(a)
                   .Expand()
                   .Padding(0, 0));
                show();
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
                    index = menu.Count;
                if (index > menu.Count)
                    index = 1;
            }
            return index;
        }
        public void ResetScrollMenu<T>(List<T> list, string name, int size, int mode) where T : IShow
        {
            int index = 0;


            int page = 1;

            int num = 5;
            int maxIndex = list.Count;
            int maxPage = maxIndex / num + 1;
            if (maxIndex % num == 0)
                maxPage--;
          
           
                string txt = "";
                if (maxIndex > page * num)
                {
                    for (int i = (page - 1) * num; i < page * num; i++)
                    {
                        if (index == i)
                            txt += "[bold]->" + list[i].show(mode) + "[/]\n";
                        else
                            txt += list[i].show(mode) + "\n";
                    }
                }
                else
                {
                    for (int i = (page - 1) * num; i < maxIndex; i++)
                    {
                        if (index == i)
                            txt += "[bold]->" + list[i].show(mode) + "[/]\n";
                        else
                            txt += list[i].show(mode) + "\n";
                    }
                }
               
                layouts[name].Update(
                  new Panel(txt)
                     .Expand()
                     .Padding(0, 0));
                show();

             




            
            return;

        }
        public T ScrollMenu<T>(List<T> list, string name, string detail, int size, int mode) where T : IShow
        {
            int index = 0;
           

            int page = 1;

            int num = 5;
            int maxIndex = list.Count;
            int maxPage = maxIndex / num + 1;
            if (maxIndex % num == 0)
                maxPage--;
            ConsoleKeyInfo key;
            bool isRun = true;
            while (isRun)
            {
                string txt = "";
                if (maxIndex > page*num)
                {
                    for (int i = (page - 1) * num; i < page * num; i++)
                    {
                        if (index == i)
                            txt += "[bold]->" + list[i].show(mode) + "[/]\n";
                        else
                            txt += list[i].show(mode) + "\n";
                    }
                }
                else
                {
                    for (int i = (page - 1) * num; i < maxIndex; i++)
                    {
                        if (index == i)
                            txt += "[bold]->" + list[i].show(mode) + "[/]\n";
                        else
                            txt += list[i].show(mode) + "\n";
                    }
                }
                if (detail != "")
                {
                    layouts[detail].Update(
                   new Panel(list[index].showDetail())
                      .Expand()
                      .Padding(0, 0));
                }
                layouts[name].Update(
                  new Panel(txt)
                     .Expand()
                     .Padding(0, 0));
                show();
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < maxIndex-1)
                            index++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (page > 1)
                        {

                            page--;
                            index = (page - 1) * num;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (page < maxPage)
                            page++;
                        index = (page - 1) * num;
                        break;
                    case ConsoleKey.Backspace:
                        isRun = false;
                        return default;
                        break;
                    case ConsoleKey.Enter:
                        isRun = false;
                        break;
                }




            }
            return list[index];

        }
      

    }
}
