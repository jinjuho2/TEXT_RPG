using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class RestD : Dungeon
    {
        Scene restScene;
        public void GoRestF(Player player)//휴식층. 쉼터 아님 주의
        {
            Console.WriteLine("휴식층 입장");
            Random random = new Random();
            int fHeal = random.Next(20, 50);

            if (player.TotalMaxHP > player.CurrentHP + (player.TotalMaxHP / 100 * fHeal))// 최대체력이 회복될 체력보다 클때
            {
                player.CurrentHP = player.CurrentHP + (player.TotalMaxHP / 100 * fHeal);
                Console.WriteLine($"충분한 휴식을 취해 체력이 {fHeal}%만큼 회복되었습니다.");
            }
            else
            {
                player.CurrentHP = player.TotalMaxHP;
                Console.WriteLine("충분한 휴식을 취해 체력이 모두 회복되었습니다.");

                player.CurrentHP = player.TotalMaxHP;
            }
        }
        public override void Init(int i)
        {
            base.Init(i);
    
            name = "휴식 방";
            info = "휴식 방 입니다.";

        }
        public void InitScene()
        {

            Layout head = new Layout("head").Ratio(1);
            Layout info = new Layout("Text").Ratio(3);
            Layout temp = new Layout();
            Layout order = new Layout("Order").Ratio(2);
            Dictionary<string, Layout> temp2 = new Dictionary<string, Layout>
            {  { "head", head },{ "order",order},{ "info",info} };
            temp = new Layout();
            temp.SplitRows(head,info,order);
            restScene = new Scene(temp, "Dungeon", temp2);

            restScene.show();

        }

        public override bool Run(Player player)
        {
            InitScene();
            restScene.Text("info", $"휴식 공간 입니다. \n 휴식을 취하세요\n {player.showDetail()}");
            List<string> menu = new List<string> {"쉬기" };
            int i = restScene.SelectNum(menu, "order");
            if (player.CurrentHP + 10 > player.TotalMaxHP)
                player.CurrentHP = player.TotalMaxHP;
            else
                player.CurrentHP += 10;
            if (player.CurrentMP + 10 > player.TotalMaxMP)
                player.CurrentMP = player.TotalMaxMP;
            else
                player.CurrentMP += 10;
            return true;
        }
    }
}
