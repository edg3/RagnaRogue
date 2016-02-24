using RagnaRogue.Helpers;
using RagnaRogue.Mechanics;
using System;

namespace RagnaRogue
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Initialize the script engine
            var result1 = CSharpScriptEngine.Execute("string s = Global.ToString();", "Success!");
            System.Console.WriteLine("Script Engine Status: " + result1.Variables["s"].Value.ToString());

            System.Console.WriteLine("Script Complex Object Test: " + ScriptEngineHelper.GetCreatureFromScript("Scripts/Creatures/prefab").AtHitPoints.ToString());


            using (var game = new RagnaRogueGame())
                game.Run();
        }
    }
}