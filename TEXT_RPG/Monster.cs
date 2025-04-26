using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Monster:Unit
    {


        public Monster clone()
        {
            Monster clone = (Monster)this.MemberwiseClone();
           
            return clone;
        }
        protected override void Dead()
        {
            base.Dead(); 
        }
       

    }
}
