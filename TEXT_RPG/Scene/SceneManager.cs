using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
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
        Scene startScene;
        Scene charaMakeScene;
        Scene questScene;
       
        Scene menuScene;
        Scene playerScene;
        Scene shopScene;
        
        

      
     

        public int InitStartScene() //로비 씬 시작 
        {

            Layout temp = new Layout();
            Layout show = new Layout(new Panel(
              new FigletText("TEXT MAPLE RPG")).Expand().SquareBorder()).Ratio(3);
            Layout btn1 = new Layout("Start").Ratio(1);
            Layout btn2 = new Layout("Load").Ratio(1);
            Layout btn3 = new Layout("End").Ratio(1);
            temp.SplitRows(show, btn1, btn2,btn3);
            Dictionary<string, Layout> temp2 = new Dictionary<string, Layout> { { "show", show }, { "btn1", btn1 }, { "btn2", btn2 },{"btn3",btn3 } };

            startScene = new Scene(temp,"start",temp2);
            List<string> menu= new List<string> { "시작","불러오기","종료"};
            List<string> a = new List<string> { "btn1", "btn2","btn3" };
            int index = startScene.SelectPanel(a,menu);
           

            return index;
        }

        public void InitCharaMake() //캐릭터 선택 창
        {
            Layout temp = new Layout();
            Layout info = new Layout("status").Ratio(3);
            Layout select = new Layout("select").Ratio(1);
            Layout text = new Layout("name");
            Layout head = new Layout("menu").Ratio(1);
            Dictionary<string, Layout> temp2 = new Dictionary<string, Layout> { { "info", info }, { "select", select }, { "text", text },{ "head",head} };
            temp.SplitRows(head, text.Ratio(1),new Layout().SplitColumns(info,select).Ratio(5)
                );
            charaMakeScene = new Scene(temp, "charamake", temp2);
            charaMakeScene.Text("head", "이름 입력");
            charaMakeScene.Text("select", "");
            charaMakeScene.Text("info", "");
            charaMakeScene.Text("text", "");
            charaMakeScene.show();
        }
        public string setName() //이름 설정
        {
            ConsoleKeyInfo key;
            string input="";
            while (true) {
                key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Backspace &&input.Length > 0)
            {
                input =input.Remove(input.Length - 1);
                
            }
            else if(key.Key == ConsoleKey.Enter&&input!="")
            {
                break;
            }
            else if(!char.IsControl(key.KeyChar)&&key.KeyChar != ' ')
                    input+=key.KeyChar;

                charaMakeScene.Text("text", "\n" + input);
                charaMakeScene.show();              

            }
            return input;
        }
        public Job SetJob(List<Job> jobs) //직업설정
        {
            charaMakeScene.Text("head","직업 선택");
            Job t = null;
            while (t == null)
            {
                t=charaMakeScene.ScrollMenu(jobs, "select", "info", 5, 0);
            }
            return t;
            
        }

      
        public void InitQuest()
        {
            Layout temp = new Layout();
            Layout info = new Layout("questList").Ratio(5);
            Layout order = new Layout("Order").Ratio(2);
        
            Dictionary<string, Layout> temp2 = new Dictionary<string, Layout> { { "info", info }, { "order", order } };
            temp.SplitRows(
                new Layout(new Panel(new Text("퀘스트").Centered()).Expand()).Size(3),
                info , order );
            questScene = new Scene(temp, "quest", temp2);
           
        }
        public int SelectQMenu()
        {
         
            List<string> menu = new List<string>();
            menu.Add("퀘스트");
            menu.Add("히든 업적");
            menu.Add("뒤로");

            return questScene.SelectNum(menu, "order");
        }

        public Quest SelectQuest()
        {
          
            return questScene.ScrollMenu(QuestManager.Instance().Quests, "info", "", 5, 0);
        
        
        }
        public Quest SelectAchieve()
        {

            return questScene.ScrollMenu(QuestManager.Instance().Achieves, "info", "", 5, 1);


        }

        public void confirmQuest(Quest quest)
        {
          
            List<string> menu;
            if (quest.IsClear)
            {
                menu = new List<string> { "보상받기", "돌아가기" };
                int i = questScene.SelectNum(menu, "order");
                if (i == 1)
                {
                    //QuestManager.Instance().Reward(quest);
                    quest.IsComplete = true;
                    QuestManager.Instance().Quests.Remove(quest);
                }
            }
            else
            {
                if (!quest.IsActive)
                {
                    menu = new List<string> { "수락", "거절" };

                    int i = questScene.SelectNum(menu, "order");
                    if (i == 1)
                        quest.IsActive = true;
                }
                else
                {
                    menu = new List<string> { "포기하기", "돌아가기" };

                    int i = questScene.SelectNum(menu, "order");
                    if (i == 1)
                        quest.IsActive = false;
                }
            }

        }
        public void InitMenu()
        {
            Layout temp = new Layout();
            Layout btn1 = new Layout("dungeon");
            Layout btn2 = new Layout("shop");
            Layout btn3 = new Layout("player");
            Layout btn4 = new Layout("quest");
            Layout show = new Layout("MAP").Ratio(4);
            Dictionary<string, Layout> temp2 = new Dictionary<string, Layout> 
            { { "btn1", btn1 }, { "btn2", btn2 }, { "btn3", btn3 }, { "btn4", btn4 },{ "show",show} };
            temp.SplitRows(
                new Layout(new Panel(new Text("MENU").Centered()).Expand()).Size(3),
                new Layout("Middle")
                    .SplitColumns(new Layout().SplitRows(
                       btn1 ,btn2
                        ,btn3,btn4 ).Ratio(1),show )
                );
            menuScene = new Scene(temp, "charamake", temp2);
          
            menuScene.show();
        }
        public int MenuSelect() //메뉴
        {

            List<string> menu = new List<string> { "던전", "상점", "스테이터스", "퀘스트" };
            List<string> btns = new List<string> { "btn1", "btn2", "btn3", "btn4" };

            return menuScene.SelectPanel(btns, menu);

        }
        public void InitPlayer()
        {
            Layout temp = new Layout();
            Layout btn1 = new Layout("dungeon");
            Layout btn2 = new Layout("shop");
            Layout btn3 = new Layout("player");
            Layout btn4 = new Layout("quest");
            Layout show = new Layout("MAP").Ratio(4);
            Dictionary<string, Layout> temp2 = new Dictionary<string, Layout>
            { { "btn1", btn1 }, { "btn2", btn2 }, { "btn3", btn3 }, { "btn4", btn4 },{ "show",show} };
            temp.SplitRows(
                new Layout(new Panel(new Text("MENU").Centered()).Expand()).Size(3),
                new Layout("Middle")
                    .SplitColumns(new Layout().SplitRows(
                       btn1, btn2
                        , btn3, btn4).Ratio(1), show)
                );
            playerScene = new Scene(temp, "charamake", temp2);

            playerScene.show();
        }
        public int SelectPlayerLayout() //플레이어 정보 확인
        {
            List<string> menu = new List<string> { "스테이터스", "아이템", "스킬", "뒤로" };
            List<string> btns = new List<string> { "btn1", "btn2", "btn3", "btn4" };
            return menuScene.SelectPanel(btns, menu);
        }

      

        public void InitShop() //샵 레이아웃
        {

            Layout temp = new Layout();
            Layout info = new Layout("questList").Ratio(5);
            Layout order = new Layout("Order").Ratio(2);

            Dictionary<string, Layout> temp2 = new Dictionary<string, Layout> { { "info", info }, { "order", order } };
            temp.SplitRows(
                new Layout(new Panel(new Text("shop").Centered()).Expand()).Size(3),
                info, order);
            shopScene = new Scene(temp, "quest", temp2);

  
        }
      
        public int SelectShop() //선택
        {
            
            List<string> menu = new List<string>();
            menu.Add("구매");
            menu.Add("판매");
            menu.Add("뒤로");
            return shopScene.SelectNum(menu, "order");
           
        }
       
        public int ShopSellConfirm(string message)
        {
            
            List<String> menu = new List<String>();
           
            menu.Add("네");
            menu.Add("아니오");
            return shopScene.SelectNum(menu, "order");
        }
              public void StatLayout(Player player) //플레이어 스테이터스 보여줌
            {
            playerScene.Text("show", player.showInfo());
            playerScene.show();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                    break;
            }


        }
        public void PSkillLayout(Player player) //스킬 보여줌
        {
            playerScene.Text("show", player.ShowSkillListS());
            playerScene.show();
           
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                    break;
            }
        }
      
            public Item ShopBuy(Shop shop)
        {
            
            return shopScene.ScrollMenu(shop.shopItems,"info","",5,1);
        } //상점
         public void ShopResult<T>(string message,List<T> list) where T : IShow //팔렸을때
        {
            shopScene.Text("order", message);
            shopScene.ResetScrollMenu(list, "info", 5, 1);
            shopScene.show();
            Thread.Sleep(1000);
        }
       public Item ShopSell(Player player)
        {
            
            return shopScene.ScrollMenu(player.inventory, "info", "", 5, 0);
        }
        public Item InvenLayout(Player player) //인벤토리 보여줌 클릭한 물체의 인덱스 보내줌
        {
            
            return playerScene.ScrollMenu(player.inventory,"show","",5,0);
        }
      
       
     

      
      
    
      
    
      
    }
}
