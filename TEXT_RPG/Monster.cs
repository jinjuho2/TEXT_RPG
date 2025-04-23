using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Monster:Unit
    {


       
        protected override void Dead()
        {
            base.Dead(); 
            GameManager.Instance().monsterKill++;
        }
       

    }
}
