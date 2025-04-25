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


        List<Monster> nowMonsters;
        Player player;
        int turn = 0;
        bool playerTurn=false;
        int monsterCount;
        int OriginHP;
        int pTurn;
        int mTurn;
        public bool Battle(Player player)
        {
            Init(player);

            for (int i = 0; i < nowMonsters.Count; i++)
            {
                nowMonsters[i].ShowSimple();
            }
            //Console.WriteLine();
            //player.ShowStat();
          
            //Console.Clear();
      
            

            SceneManager.Instance().InitBattleScene(nowMonsters, "1번 방", player, "전투 시작");
    
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
                Console.WriteLine(nowMonsters.Count(m => (m.IsAlive)));
            }
            if (player.IsAlive) {
                return true;
            }
            return false;
            

        }
        
        void Victory()
        {
            int gold = 0;
            for (int i = 0; i < nowMonsters.Count; i++) {
                gold += nowMonsters[i].Gold;
            }
            Console.WriteLine("WIN");
            Console.WriteLine($"몬스터 {nowMonsters.Count} 해결");
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name}");
            Console.WriteLine($"HP {player.CurrentHP}/{player.MaxHp}");
            Console.WriteLine($"{gold}원 획득");
            Console.WriteLine("획득");
        }
      
        private void Init(Player _player)
        {
             nowMonsters= new List<Monster>();
            player = _player;
            nowMonsters.Add(DataManager.Instance().makeMonster(1));
            nowMonsters[nowMonsters.Count-1].skills.Add(DataManager.Instance().MakeSkill(1));
            nowMonsters.Add(DataManager.Instance().makeMonster(2));
            nowMonsters[nowMonsters.Count - 1].skills.Add(DataManager.Instance().MakeSkill(1));
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
            SceneManager.Instance().InitBattleScene(nowMonsters, "1번 방", player, "당신의 차례");
            Thread.Sleep(100);
            while (pTurn > 0&&nowMonsters.Any(m=>m.IsAlive))
            {
                pTurn--;
              
                player.IsWeak = false;
              
                //player.ShowStat();
                List<string> menu = new List<string>();
                menu.Add("공격");
                menu.Add("아이템");
                int input = SceneManager.Instance().UpdatePlayerScene(menu);
             


                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        input = AttackMenu(); break;
                }
            }
            return;
        }
        int AttackMenu()
        {
            Console.WriteLine("Battle");
            int input;
            for (int i = 0; i < nowMonsters.Count; i++)
            {
                Console.Write($"{i+1}. ");
                nowMonsters[i].ShowSimple();
            }
            Console.WriteLine();

            player.ShowStat();
            Console.WriteLine("대상을 선택해주세요.");
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > nowMonsters.Count
                || !nowMonsters[input - 1].IsAlive)
            {
                Console.WriteLine("입력 오류");
            }
            Skill a = player.UseSkill();

            Attack(player, nowMonsters[input-1],a);
            playerTurn = false;
            Console.WriteLine("0. 다음");
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("입력 오류");
            }
           
            return input;
        }
        void Attack(Unit a,Unit b,Skill s) //true: 플레이어가 공격 false: 적이 공격...  
        {
           
                Random random = new Random();
                if (random.Next(0, 100) < a.Evasion)
                {
                    Console.WriteLine($"{a.Name}이(가) {b.Name}을(를) 공격했지만 회피!");
                    return;

                }
                Console.Write($"{a.Name} 이(가)  {b.Name}을(를) 공격");

           
                if (random.Next(0,100)>s.Critical)
                    Console.Write("-치명타!");

                Console.WriteLine();
                float calAtk = s.Damage;
                if (s.Type == b.WeakType)
                {
                    Console.WriteLine("약점!");
                    calAtk *= 1.6f;
                    Console.WriteLine($"{b.Name}은(는) {(int)calAtk} 데미지를 입었다");
                if (!b.IsWeak)
                {
                    b.IsWeak = true;
                    if (b is Monster)
                        pTurn++;
                    if (b is Player)
                        mTurn++;
                    Console.WriteLine("한번 더");
                }

                }
                else
                Console.WriteLine($"{b.Name}은(는) {(int)calAtk} 데미지를 입었다");
                b.TakeDamage((int)calAtk);


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
            Console.WriteLine($"몬스터턴");
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

                Console.WriteLine("0. 다음");

                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("입력 오류");
                }
          
            }
            playerTurn = true;
        }

     


    }
}
