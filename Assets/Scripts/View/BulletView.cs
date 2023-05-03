using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerMVC
{
    public sealed class BulletView : LevelObjectView
    {
        private int _damagePoint = 10;

        public int DamagePoint { get => _damagePoint; set => _damagePoint = value; }
    }
}
