using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Mechanics
{
    public class Creature : Component
    {
        public int StStr { get; private set; }
        public int StDex { get; private set; }
        public int StVit { get; private set; }
        public int StInt { get; private set; }
        public int StAgi { get; private set; }

        public int AtHitPoints { get; private set; }
        public int AtLevel { get; private set; }

        public void SetStats(int _lvl, int _str, int _dex, int _vit, int _agi, int _int)
        {
            AtLevel = _lvl;
            StStr = _str;
            StDex = _dex;
            StVit = _vit;
            StInt = _int;
            StAgi = _agi;

            FullHeal();
        }

        public void FullHeal()
        {
            AtHitPoints = Math.Max(1, StVit / 2 - 5) * 8 + 2;
        }

        public void SetStats(int _lvl, int _str, int _dex, int _vit, int _agi, int _int, int _hp)
        {
            AtLevel = _lvl;
            StStr = _str;
            StDex = _dex;
            StVit = _vit;
            StInt = _int;
            StAgi = _agi;

            AtHitPoints = _hp;
        }
    }
}
