using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.Scripting.CSharp;
using System;
using System.Collections.Generic;

namespace RagnaRogue.Helpers
{
    public class CSharpScriptEngine
    {
        static CSharpScriptEngine()
        {
            List<string> namespaces = new List<string>();

            namespaces.Add("Object");
            namespaces.Add("RagnaRogue");
            namespaces.Add("RagnaRogue.Helpers");
            namespaces.Add("RagnaRogue.Mechanics");

            ScriptSystemOptions = ScriptOptions.Default;
            ScriptSystemOptions.AddNamespaces(namespaces);
        }

        public class __ScrGlobal
        {
            public object Global;
        }

        public static ScriptOptions ScriptSystemOptions;

        private static Script _previousInput;
        public static ScriptState Execute(string code, object _opt)
        {
            __ScrGlobal _global = new __ScrGlobal();
            _global.Global = _opt;
            var script = CSharpScript.Create(code, ScriptSystemOptions).WithPrevious(_previousInput);
            var endState = script.RunAsync(_global);
            _previousInput = endState.Script;
            return endState;
        }
    }
}
