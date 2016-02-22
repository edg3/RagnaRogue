using RagnaRogue.Helpers;
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
            var result = CSharpScriptEngine.Execute("string s = \"Success!\";");
            System.Console.WriteLine("Script Engine Status: " + result.Variables["s"].Value.ToString());

            using (var game = new RagnaRogueGame())
                game.Run();
        }
    }
}