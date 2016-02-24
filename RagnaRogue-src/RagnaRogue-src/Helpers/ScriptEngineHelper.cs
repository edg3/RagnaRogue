using RagnaRogue.Mechanics;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaRogue.Helpers
{
    /// <summary>
    /// Helping functions for specific pieces of script hooks and a way to document them with XML comments (hopefully).
    /// 
    /// This should serve as an introductory system for scripting for RagnaRogue
    /// </summary>
    public class ScriptEngineHelper
    {

        /// <summary>
        /// Create a Creature using a script, gives hooks to a full new Creature instance.
        /// </summary>
        /// <example>
        /// Simplest example: new creature from scratch args->(level, strength, dexterity, vitality, agility, intelligence)
        /// <code>
        /// using RagnaRogue.Mechanics;
        /// 
        /// (Global as Creature).SetStats(1,10,10,10,10,10);
        /// </code>
        /// </example>
        /// <example>
        /// Simpl example: new creature from scratch args->(level, strength, dexterity, vitality, agility, intelligence, hitpoints)
        /// <code>
        /// using RagnaRogue.Mechanics;
        /// 
        /// (Global as Creature).SetStats(1,10,10,10,10,10,7);
        /// </code>
        /// </example>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Creature GetCreatureFromScript(string fileName)
        {
            using (var fs = new StreamReader(fileName + ".cs.script"))
            {
                var result= CSharpScriptEngine.Execute(fs.ReadToEnd(), new Creature());
                return result.Variables["Global"].Value as Creature;
            }
        }

        /// <summary>
        /// Run a specific file with an object argument
        /// </summary>
        /// <param name="fileName">The file to run without ".cs.script"</param>
        /// <param name="_obj">The object to pass into "Global"</param>
        public static void RunFile(string fileName, object _obj)
        {
            using (var fs = new StreamReader(fileName + ".cs.script"))
            {
                var result = CSharpScriptEngine.Execute(fs.ReadToEnd(), _obj);
            }
        }
    }
}
