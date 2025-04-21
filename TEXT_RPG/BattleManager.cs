using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class BattleManager
    {
        
        List<Monster> nowMonsters;
        Player player;
        int turn = 0;

        public void Battle(Player player)
        {
            Init(player);
            Console.WriteLine("전투 개시");
            while (player.IsAlive && nowMonsters.Any(m => (m.IsAlive))) //LINQ
            {
                NextTurn();
            }
            if (player.IsAlive) {
                Victory();
            }
     
        }
        void Victory()
        {
            Console.WriteLine("WIN");
        }
        private void Init(Player player)
        {
             nowMonsters= new List<Monster>();
            nowMonsters.Add(new Monster());
            this.player = player;
           
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

            player.ShowSimple();
            Console.WriteLine("전투 개시");
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
            if(input == 0)
                 BattleMenu();
            input--;

            return input;
        }
        void OnMonsterDefeated(Monster monster)
        {
           // nowMonsters.Remove(monster);
        }
        private void NextTurn()
        {
            turn++;
            
         
            int input = BattleMenu();
            if (player.Attack(nowMonsters[input]))
                OnMonsterDefeated(nowMonsters[input]);
            Console.WriteLine("0. 다음");
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("입력 오류");
            }
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
        }
    }
}
