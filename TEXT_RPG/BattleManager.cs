using System;
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
        int turn = 0;
        bool playerTurn=false;
        int monsterCount;
        int OriginHP;
        int pTurn;
        int mTurn;
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
            return false;
            Thread.Sleep(1000);
            battleScene.Text("info", "아무 키나 입력하여 다음으로");
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
            string x="\n\n\n ";
            x+="WIN!!\n\n";
            x+=$"몬스터 {nowMonsters.Count} 해결\n\n";
   
            x+=$"{gold}원 획득\n";
            battleScene.Text("mon", x);
            
        }
      
        private void Init(Player _player, List<Monster> mon)
        {
             nowMonsters= new List<Monster>();
            player = _player;
            nowMonsters.AddRange(mon);
            for(int i = 0;i < nowMonsters.Count;i++)
            {
                nowMonsters[i].skills.Add(DataManager.Instance().MakeSkill(1));

      
            }

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
                int input = UpdatePlayerScene(menu);
             


                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        AttackMenu(); break;
                }
            }
            return;
        }
        void AttackMenu()
        {
            Monster mon= battleScene.ScrollMenu(nowMonsters, "mon","",5,0);
            Skill a = battleScene.ScrollMenu(player.skills, "chara", "", 5, 0);
            battleScene.Text("chara", player.show(0));
            battleScene.showList(nowMonsters, "mon");
            Attack(player, mon,a);
            playerTurn = false;
         
            Console.ReadKey();
       
        }
        void Attack(Unit a,Unit b,Skill s) //true: 플레이어가 공격 false: 적이 공격...  
        {
           
                Random random = new Random();
                if (random.Next(0, 100) < a.Evasion)
                {
                    battleScene.Text("info", $"{a.Name}이(가) {b.Name}을(를) 공격했지만 회피!");
                    //Console.WriteLine($"{a.Name}이(가) {b.Name}을(를) 공격했지만 회피!");
                    return;

                }
          
            string x = $"{a.Name} 이(가)  {b.Name}을(를) 공격\n";
            //Console.Write($"{a.Name} 이(가)  {b.Name}을(를) 공격");


                 if (random.Next(0,100)>s.Critical)
                    x+="[red]-치명타![/]\n";

                Thread.Sleep(1000);
                 float calAtk = s.Damage*a.showAtk();
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
            battleScene.showList(nowMonsters, "mon");
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
                Console.WriteLine($"{mTurn}");
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
            Layout mon = new Layout().Ratio(3);
            Layout info = new Layout("RightRight").Ratio(1);
            Layout order = new Layout("order");
            Layout chara = new Layout("DataInfo").Ratio(2);
            battlelayout.SplitRows(
                head, new Layout("Middle").SplitColumns(mon, info),
                new Layout("Bottom")
                    .SplitColumns(order, chara)
                );
            Dictionary<string, Layout> temp = new Dictionary<string, Layout> { {"head",head },{"mon",mon},{"info",info },{"order",order },
                {"chara",chara } };
            battleScene = new Scene(battlelayout, "battle", temp);
            battleScene.Text("head", "1층");
            battleScene.Text("info", "");
            battleScene.showList(nowMonsters, "mon");
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
