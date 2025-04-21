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
        
        List<Monster> nowMonsters;
        Unit player;
        int turn = 0;
        bool playerTurn=false;
        int monsterCount;
        int OriginHP;
        int pTurn;
        int mTurn;
        public void Battle(Unit player)
        {
            Init(player);

            for (int i = 0; i < nowMonsters.Count; i++)
            {
                nowMonsters[i].ShowSimple();
            }
            Console.WriteLine();

            player.ShowSimple();
            Console.WriteLine("전투 개시");

          

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
            }
            

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
            Console.WriteLine($"Lv.{player.lvl} {player.name}");
            Console.WriteLine($"HP {player.hp}/{player.maxHp}");
            Console.WriteLine($"{gold}원 획득");
            Console.WriteLine("획득");
        }
        private void Init(Unit player)
        {
             nowMonsters= new List<Monster>();
            nowMonsters.Add(new Monster());
            nowMonsters.Add(new Monster());
            this.player = player;
            monsterCount = 0;
            int Pspeed = player.speed;
            int Espeed = 0;
            foreach (Monster m in nowMonsters)
            {
                Espeed += m.speed;
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
            Console.WriteLine($"플레이어턴");
            while (pTurn > 0&&nowMonsters.Any(m=>m.IsAlive))
            {
                pTurn--;
                Console.WriteLine("Battle");
                player.IsWeak = false;
                int input;
                for (int i = 0; i < nowMonsters.Count; i++)
                {
                    nowMonsters[i].ShowSimple();
                }
                Console.WriteLine();
                player.ShowSimple();
               
                Console.WriteLine("1. 공격");

                while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 1)
                {
                    Console.WriteLine("입력 오류");
                }

                Console.WriteLine("원하시는 행동을 입력해주세요.");
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

            player.ShowSimple();
            Console.WriteLine("대상을 선택해주세요.");
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > nowMonsters.Count
                || !nowMonsters[input - 1].IsAlive)
            {
                Console.WriteLine("입력 오류");
            }
            Attack(player, nowMonsters[input-1]);
            playerTurn = false;
            Console.WriteLine("0. 다음");
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("입력 오류");
            }
           
            return input;
        }
        void Attack(Unit a,Unit b)
        {
            Random random = new Random();
            if (random.Next(0, 100) < 10)
            {
                Console.WriteLine($"{a.name}이(가) {b.GetName()}을(를) 공격했지만 회피!");
                return;

            }
            Console.Write($"{a.name} 이(가)  {b. GetName()}을(를) 공격");

            AttackData ad=a.Attack();
            if(ad.IsCr)
                Console.WriteLine("-치명타!");
            
            Console.WriteLine();
            float calAtk = ad.Damage;
            if (ad.Type == b.WeakType)
            {
                Console.WriteLine("약점!");
                calAtk *= 1.6f;
                Console.WriteLine($"{b.name}은(는) {(int)calAtk} 데미지를 입었다");
                if (!b.IsWeak)
                {
                    b.IsWeak = true;
                    if (b is Monster)
                        pTurn++;
                    if (b is Unit)
                        mTurn++;
                    Console.WriteLine("한번 더");
                }
                
            }
            else
                Console.WriteLine($"{b.name}은(는) {(int)calAtk} 데미지를 입었다");
            b.Damaged((int)calAtk);
        
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
                
                 Attack(nowMonsters[i], player);
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
