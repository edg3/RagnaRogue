using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Mechanics
{
    [Serializable]
    public class Creature : Component
    {
        public int StStr { get; set; }
        public int StDex { get; set; }
        public int StVit { get; set; }
        public int StInt { get; set; }
        public int StAgi { get; set; }

        public int AtHitPoints { get; set; }
        public int AtLevel { get; set; }

        public int Speed { get; set; }
        public int ArmorClass { get; set; }

        public int Challenge { get; set; }

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

        public Creature Clone()
        {
            return ObjectCopier.Clone<Creature>(this);
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
