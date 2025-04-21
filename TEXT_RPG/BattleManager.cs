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
        Player player;
        int turn = 0;
        bool playerTurn=false;
        int monsterCount;
        int OriginHP;
        public void Battle(Player player)
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
                    BattleMenu();
                }
                else
                {

                    monsterTurn();
                }
            }
            if (player.IsAlive) {
                Victory();
            }
            

        }
        void Victory()
        {
            Console.WriteLine("WIN");
            Console.WriteLine($"몬스터 {monsterCount} 해결");
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.lvl} {player.name}");
            Console.WriteLine($"HP {player.hp}/{player.maxHp}");
            Console.WriteLine();
        }
        private void Init(Player player)
        {
             nowMonsters= new List<Monster>();
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
        int BattleMenu()
        {
            Console.WriteLine("Battle");
           
            int input;
            for (int i = 0; i < nowMonsters.Count; i++)
            {
                nowMonsters[i].ShowSimple();
            }
            Console.WriteLine();

            Console.WriteLine("1. 공격");

            while (!int.TryParse(Console.ReadLine(), out input) || input<0||input>1)
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
            return input;
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
            input--;
            player.Attack(nowMonsters[input]);
            playerTurn = false;
            Console.WriteLine("0. 다음");
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("입력 오류");
            }
            return input;
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
          
         
            for (int i = 0; i < nowMonsters.Count; i++)
            {
                if(nowMonsters[i].IsAlive)
                if (nowMonsters[i].Attack(player))
                {
                    break;
                }
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
