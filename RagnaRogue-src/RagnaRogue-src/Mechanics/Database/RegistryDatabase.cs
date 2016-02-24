using RagnaRogue.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Mechanics.Database
{
    public class RegistryDatabase
    {
        private RegistryDatabase()
        {

        }

        private static RegistryDatabase _instance;

        public static RegistryDatabase Instance
        {
            get
            {
                if (null == _instance) _instance = new RegistryDatabase();
                return _instance;
            }
        }

        public struct CreatureRegistry
        {
            public Creature Cloneable { get; set; }
        }

        public Dictionary<string, CreatureRegistry> CreatureData = new Dictionary<string, CreatureRegistry>();

        public void RegisterCreature(string scriptLocation)
        {
            CreatureRegistry reg = new CreatureRegistry();
            reg.Cloneable = ScriptEngineHelper.GetCreatureFromScript(scriptLocation);
            CreatureData.Add(scriptLocation, reg);
        }

        public override string ToString()
        {
            return "DBCount: " + CreatureData.Count;
        }
    }
}
