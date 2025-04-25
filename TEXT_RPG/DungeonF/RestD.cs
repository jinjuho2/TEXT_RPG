using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class RestD
    {
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
    }
}
