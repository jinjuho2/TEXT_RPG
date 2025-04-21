using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class AttackData
    {
        public float Damage { get; set; }
        public TYPE Type { get; set; }
        public bool IsCr { get; set; }
        public AttackData(float _Damage, TYPE _type, bool _IsCr) {
            Damage = _Damage;
            Type = _type;
            IsCr = _IsCr;
        
        }
    }
}
