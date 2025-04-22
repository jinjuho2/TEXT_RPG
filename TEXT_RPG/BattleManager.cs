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
        List<string> monsterInfo = new List<string> { "1,슬라임,1,Normal,10,5,3,30,30,10", "2,빅슬라임,1,Dark,10,5,3,30,30,10" };


        List<Monster> nowMonsters;
 
        int turn = 0;
        bool playerTurn=false;
        int monsterCount;
        int OriginHP;
        int pTurn;
        int mTurn;
        public bool Battle()
        {
            Init();

            for (int i = 0; i < nowMonsters.Count; i++)
            {
                nowMonsters[i].ShowSimple();
            }
            Console.WriteLine();

            Player.Instance.ShowStat();
            Console.WriteLine("전투 개시");

          

            while (Player.Instance.IsAlive && nowMonsters.Any(m => (m.IsAlive))) //LINQ
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
            if (Player.Instance.IsAlive) {
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
            Console.WriteLine($"Lv.{Player.Instance.Level} {Player.Instance.Name}");
            Console.WriteLine($"HP {Player.Instance.CurrentHP}/{Player.Instance.MaxHP}");
            Console.WriteLine($"{gold}원 획득");
            Console.WriteLine("획득");
        }
        bool setMonster(int i)
        {
            i--;
            if (i < 0 || i >=monsterInfo.Count)
                return false;
            string[] x = monsterInfo[i].Split(',');
            nowMonsters.Add(new Monster(int.Parse(x[0]), x[1],int.Parse( x[2]), (TYPE)Enum.Parse(typeof(TYPE), x[3]), float.Parse(x[4]), 
                float.Parse(x[5]), int.Parse(x[6]), int.Parse(x[7]), int.Parse(x[8]), int.Parse(x[9])));
            return true;
        }
        private void Init()
        {
             nowMonsters= new List<Monster>();
            
            setMonster(1);
            setMonster(2);

            monsterCount = 0;
            int Pspeed = Player.Instance.Speed;
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
            Console.WriteLine($"플레이어턴");
            while (pTurn > 0&&nowMonsters.Any(m=>m.IsAlive))
            {
                pTurn--;
                Console.WriteLine("Battle");
                Player.Instance.IsWeak = false;
                int input;
                for (int i = 0; i < nowMonsters.Count; i++)
                {
                    nowMonsters[i].ShowSimple();
                }
                Console.WriteLine();
                Player.Instance.ShowStat();


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

            Player.Instance.ShowStat();
            Console.WriteLine("대상을 선택해주세요.");
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > nowMonsters.Count
                || !nowMonsters[input - 1].IsAlive)
            {
                Console.WriteLine("입력 오류");
            }
            Attack(true, nowMonsters[input-1]);
            playerTurn = false;
            Console.WriteLine("0. 다음");
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("입력 오류");
            }
           
            return input;
        }
        void Attack(bool x,Unit b) //true: 플레이어가 공격 false: 적이 공격...  
        {
            if (x) {
                Random random = new Random();
                if (random.Next(0, 100) < 10)
                {
                    Console.WriteLine($"{Player.Instance.Name}이(가) {b.Name}을(를) 공격했지만 회피!");
                    return;

                }
                Console.Write($"{Player.Instance.Name} 이(가)  {b.Name}을(를) 공격");

                AttackData ad = Player.Instance.AttackM();
                if (ad.IsCr)
                    Console.WriteLine("-치명타!");

                Console.WriteLine();
                float calAtk = ad.Damage;
                if (ad.Type == b.WeakType)
                {
                    Console.WriteLine("약점!");
                    calAtk *= 1.6f;
                    Console.WriteLine($"{b.Name}은(는) {(int)calAtk} 데미지를 입었다");
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
                    Console.WriteLine($"{b.Name}은(는) {(int)calAtk} 데미지를 입었다");
                b.TakeDamage((int)calAtk);
            }
            else
            {
                Random random = new Random();
                if (random.Next(0, 100) < 10)
                {
                    Console.WriteLine($"{b.Name}이(가) {Player.Instance.Name}을(를) 공격했지만 회피!");
                    return;

                }
                Console.Write($"{b.Name} 이(가)  {Player.Instance.Name}을(를) 공격");

                AttackData ad = b.AttackM();
                if (ad.IsCr)
                    Console.WriteLine("-치명타!");

                Console.WriteLine();
                float calAtk = ad.Damage;
                if (ad.Type == Player.Instance.WeakType)
                {
                    Console.WriteLine("약점!");
                    calAtk *= 1.6f;
                    Console.WriteLine($"{Player.Instance.Name}은(는) {(int)calAtk} 데미지를 입었다");
                    if (!Player.Instance.IsWeak)
                    {
                        Player.Instance.IsWeak = true;
                            mTurn++;
                        Console.WriteLine("한번 더");
                    }

                }
                else
                    Console.WriteLine($"{Player.Instance.Name}은(는) {(int)calAtk} 데미지를 입었다");
                Player.Instance.TakeDamage((int)calAtk);
            }
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
                
                 Attack(false,nowMonsters[i]);
                if(!Player.Instance.IsAlive)
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
