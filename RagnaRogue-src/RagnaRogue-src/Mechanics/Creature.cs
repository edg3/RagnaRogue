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

        public int Speed { get; private set; }
        public int ArmorClass { get; private set; }

        public int Challenge { get; private set; }

        private List<Race> _races = new List<Race>();

        public List<Race> Alliances
        {
            get { return _races; }
        }

        private Dictionary<Sense, int> _senses = new Dictionary<Sense, int>();

        public Dictionary<Sense, int> Senses
        {
            get { return _senses; }
        }

        private List<Language> _languages = new List<Language>();

        public List<Language> Languages
        {
            get { return _languages; }
        }


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

        public void SetSpeed(int speed)
        {
            Speed = speed;
        }

        public void SetArmorClass(int ac)
        {
            ArmorClass = ac;
        }

        public void AddAlliance(Race _toAdd)
        {
            Alliances.Add(_toAdd);
        }

        public void AddSense(Sense _toAdd, int val)
        {
            Senses.Add(_toAdd, val);
        }

        public void AddLanguage(Language _toAdd)
        {
            Languages.Add(_toAdd);
        }

        public void SetChallenge(int xp)
        {
            Challenge = xp;
        }

    }
}
