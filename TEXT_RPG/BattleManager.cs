using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Spectre.Console;

namespace TEXT_RPG
{
    internal class BattleManager
    {
        //List<string> monsterInfo = new List<string> { "1,슬라임,1,Normal,10,5,3,30,30,10", "2,빅슬라임,1,Dark,10,5,3,30,30,10" };

        Scene battleScene;
        List<Monster> nowMonsters;
        Player player;
        int lv;
        int hp;
        int exp;
        int turn = 0;
        bool playerTurn=false;
        int monsterCount;
        int OriginHP;
        int pTurn;
        int mTurn;
        List<string> monss = new List<string>{ "mon2", "mon3", "mon1", "mon4" };
        public bool Battle(Player player,List<Monster> mon)
        {
            Init(player,mon);

            for (int i = 0; i < nowMonsters.Count; i++)
            {
                nowMonsters[i].ShowSimple();
            }
            //Console.WriteLine();
            //player.ShowStat();
          
            //Console.Clear();
            InitBattleScene("1번 방");
    
            while (player.IsAlive && nowMonsters.Any(m => (m.IsAlive))) //LINQ
            {
                if (playerTurn)
                {
                    pTurn = 1;
                    PlayerTurn();
                }
                else
                {
                    mTurn = nowMonsters.Count(m=>(m.IsAlive));
                    
                    monsterTurn();
                }
       
            }
            if (player.IsAlive) {
                Victory();
                return true;
            }


            Lose();
            Console.ReadKey();
            return false;

        }
        void Lose()
        {
            string x = "\n\n ";
            x += "Lose!!\n\n";


             x += $"{lv}: {player.Name}\n";
            if (player.CurrentHP < 0) { player.CurrentHP = 0; }
            x += $"{hp}->{player.CurrentHP}\n아무 키나 입력하여 게임 종료";

            battleScene.Text("info", x);



            Console.ReadKey();

        }
        void Victory()
        {
            int gold = 0;
            int exp = 0;
            for (int i = 0; i < nowMonsters.Count; i++) {
                gold += nowMonsters[i].Gold;
                exp += nowMonsters[i].Exp;
            }

            player.Gold += gold;
            player.Getexp(exp);
            string x="\n\n ";
            x+="WIN!!\n\n";
                        
            x+=$"몬스터 {nowMonsters.Count}마리 해결\n\n";
            if(lv!=player.Level)
            x += $"{lv}: {player.Name}->{player.Level}: {player.Name}\n";
            else x += $"{lv}: {player.Name}\n";

            x += $"{hp}->{player.CurrentHP}\n";
            x += $"{exp}->{player.Exp}\n";
            x += $"{gold}원 획득\n";
            if (player.CurrentMP + 10 <= player.MaxMp)
                player.CurrentMP += 10;
            battleScene.Text("info", x);
            CheckQ();
           
            Console.ReadKey();

        }
        void CheckQ()
        {
            List<string> list = new List<string> {"퀘스트 확인","나가기" };
            battleScene.showList(QuestManager.Instance().Quests.Where(a => a.IsActive).ToList(), "chara");
            if (QuestManager.Instance().Quests.Where(a=>a.IsActive).Count() == 0) {
              list = new List<string> { "나가기" };
                if (battleScene.SelectNum(list, "order") != 3)
                    return;
            }
            if(battleScene.SelectNum(list,"order")!=1)
                return;
            while (true)
            {
                Quest quest = battleScene.ScrollMenu(QuestManager.Instance().Quests.Where(a => a.IsActive).ToList(), "chara", "info", 5, 0);
                if (quest == null)
                    break;
                if(!quest.IsClear) continue;
                List<string> menu;
                if (quest.IsClear)
                {
                    menu = new List<string> { "보상받기", "돌아가기" };
                    int i = battleScene.SelectNum(menu, "order");
                    if (i == 1)
                    {
                        QuestManager.Instance().Reward(quest,player);
                        quest.IsComplete = true;
                        QuestManager.Instance().Quests.Remove(quest);
                    }
                }
            }
            

        }

        private void Init(Player _player, List<Monster> mon)
        {
             nowMonsters= new List<Monster>();
            player = _player;
            hp = player.CurrentHP;
            exp = player.Exp;
            lv=player.Level;
            nowMonsters.AddRange(mon);
           

            monsterCount = 0;
            int Pspeed = player.Speed;
            int Espeed = 0;
            foreach (Monster m in nowMonsters)
            {
                Espeed += m.Speed;
            }
            if (Pspeed > Espeed / nowMonsters.Count)
            {
                playerTurn = true;
            }
            else
                playerTurn = false;

            }
        void PlayerTurn()
        {
            //Console.WriteLine($"플레이어턴");
           

            while (pTurn > 0&&nowMonsters.Any(m=>m.IsAlive))
            {
                pTurn--;
              
                player.IsWeak = false;
              
                //player.ShowStat();
                List<string> menu = new List<string>();
                menu.Add("공격");
                menu.Add("아이템");
                bool isRun=true;
                while (isRun)
                {
                    int input = UpdatePlayerScene(menu);



                    switch (input)
                    {
                        case 0:
                            break;
                        case 1:
                            if(AttackMenu())
                                isRun = false;
                            break;
                        case 2:
                            if(ItemMenu())
                                isRun =false; 
                            break;
                    }
                }
            }
            return;
        }
        bool ItemMenu()
        {
            List<Potion> items = player.inventory.OfType<Potion>().ToList();
            if (items.Count == 0) {
                battleScene.Text("info", "사용 가능 아이템 없음\n 아무 키나 입력하여 다음으로");
                Console.ReadKey();
                return false;
            }
            Potion p= battleScene.ScrollMenu(items, "chara", "", 5, 0);
            if(p==null)
                return false;
            string a="아이템 사용";
            if (p.Use(player, out a))
            {
                Thread.Sleep(1000);
                battleScene.Text("info", a+"\n아무 키나 입력하여 다음으로");
                Console.ReadKey();
                return true;
            }
            else
            {
                Thread.Sleep(1000);
                battleScene.Text("info", a+"\n아무 키나 입력하여 다음으로");
                Console.ReadKey();
                return false;
            }
        }
        bool AttackMenu() //공격 메뉴
        {
            bool isEnd = false;
            Skill a=null;
            while (!isEnd){
                 a = battleScene.ScrollMenu(player.skills, "chara", "", 5, 0);
                if (a == null) return false;
                if(player.UseSkill(a))
                    isEnd = true;
                else
                    battleScene.Text("info", "마나 부족");
            }
            
            string txt="";
            int i =Math.Min( a.TargetNum,nowMonsters.Count(m => (m.IsAlive)));
            List<Monster> mons =battleScene.SelectMonL(monss,nowMonsters,"info",i);
            battleScene.showPanelD(monss, nowMonsters);
            foreach (Monster mon in mons)
            {
                Attack(player, mon, a);
                battleScene.Text("chara", player.show(0));
                battleScene.showPanelD(monss, nowMonsters);
            }

            battleScene.showPanelD(monss, nowMonsters);
            playerTurn = false;
            battleScene.Text("info", "아무 키나 입력하여 다음으로");
            Console.ReadKey();
            return true;
       
        }
        void Attack(Unit a,Unit b,Skill s) //true: 플레이어가 공격 false: 적이 공격...  
        {     
                Random random = new Random();
                if (random.Next(0, 100) < a.Evasion)
                {
                    battleScene.Text("info", $"{a.Name}이(가) {b.Name}을(를) 공격했지만 회피!");
                    Thread.Sleep(1000);
                //Console.WriteLine($"{a.Name}이(가) {b.Name}을(를) 공격했지만 회피!");
                return;
                }   
            string x = $"{a.Name} 이(가)  {b.Name}을(를) 공격\n";
            x += $"[bold]{s.Name}![/]\n";
            //Console.Write($"{a.Name} 이(가)  {b.Name}을(를) 공격");
                 if (random.Next(0,100)>s.Critical)
                   x+="[red]-치명타![/]\n";
                Thread.Sleep(1000);
                Random rand = new Random();
                 float calAtk = (s.Damage*a.showAtk()*rand.Next(90,111)/100);
                if (s.Type == b.WeakType)
                {
                        x += ("약점!\n");
                    calAtk *= 1.6f;
                        x += ($"{b.Name}은(는) {(int)calAtk} 데미지를 입었다\n"); ;
                if (!b.IsWeak)
                {
                    Thread.Sleep(1000);
                    b.IsWeak = true;
                    if (b is Monster)
                        pTurn++;
                    if (b is Player)
                        mTurn++;
                    x += ("한번 더\n");
                }
                }
                else
                    x+=($"{b.Name}은(는) {(int)calAtk} 데미지를 입었다");
               
                battleScene.Text("info", x);
                b.TakeDamage((int)calAtk);
            battleScene.Text("chara", player.show(0));
            battleScene.showPanelD(monss, nowMonsters);
            Thread.Sleep(1000);


        }
        void OnMonsterDefeated(Monster monster)
        {
            monsterCount++;
           // nowMonsters.Remove(monster);
        }
        private void monsterTurn()
        {
            turn++;

            int input;
            int i = 0;
            battleScene.Text("info", "적의 차례");
            Thread.Sleep(1000);
            while ( mTurn>0&&nowMonsters.Any(m=>m.IsAlive))
            {
                mTurn--;
                
                i++;
                if (i == nowMonsters.Count)
                    i = 0;
                if (!nowMonsters[i].IsAlive)
                    continue;

                Attack(nowMonsters[i], player, nowMonsters[i].skills[0]);
                if(!player.IsAlive)
                    break;
                nowMonsters[i].IsWeak = false;
                Thread.Sleep(1000);
                battleScene.Text("info", "아무 키나 입력하여 다음으로");
                Console.ReadKey();


            }
            playerTurn = true;
        }


        public void InitBattleScene(string roomInfo)
        {
            Layout battlelayout = new Layout();
            Layout head = new Layout("RoomInfo").Size(3);
            Layout mon1 = new Layout(new Panel("") .Border(BoxBorder.None));
            Layout mon2 = new Layout(new Panel("").Border(BoxBorder.None));
            Layout mon3 = new Layout(new Panel("").Border(BoxBorder.None));
            Layout mon4 = new Layout(new Panel("").Border(BoxBorder.None));

            Layout info = new Layout("RightRight").Ratio(1);
            Layout order = new Layout("order");
            Layout chara = new Layout("DataInfo").Ratio(2);
            battlelayout.SplitRows(
                head, new Layout("Middle").SplitColumns(new Layout().SplitColumns(mon1,mon2,mon3,mon4).Ratio(3), info),
                new Layout("Bottom")
                    .SplitColumns(order, chara)
                );
            Dictionary<string, Layout> temp = new Dictionary<string, Layout> { {"head",head },{"mon1",mon1},{"mon2",mon2}
                ,{"mon4",mon4},{"mon3",mon3},{"info",info },{"order",order },
                {"chara",chara } };
            battleScene = new Scene(battlelayout, "battle", temp);
            battleScene.Text("head", "1층");
            battleScene.Text("info", "");
            while (nowMonsters.Count < monss.Count)
            {
                monss.RemoveAt(monss.Count - 1);
            }
            battleScene.showPanelD(monss, nowMonsters);
            battleScene.Text("chara", player.show(0));
            battleScene.show();
            //Console.ReadKey(true);

        }

        public void PAttackScene(Player player, List<Monster> mons)
        {

        }

        public int UpdatePlayerScene(List<string> menu)
        {
            battleScene.Text("info", "당신의 차례");
            return battleScene.SelectNum(menu, "order");
        } //플레이어 전투시





    }
}
