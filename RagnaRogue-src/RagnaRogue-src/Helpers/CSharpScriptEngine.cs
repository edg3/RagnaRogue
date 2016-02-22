using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.Scripting.CSharp;
using System;


namespace RagnaRogue.Helpers
{
    public class CSharpScriptEngine
    {
        private static Script _previousInput;
        private static Lazy<object> _nextInputState = new Lazy<object>();
        public static ScriptState Execute(string code)
        {
            var script = CSharpScript.Create(code, ScriptOptions.Default).WithPrevious(_previousInput);
            var endState = script.RunAsync(_nextInputState.Value);
            _previousInput = endState.Script;
            _nextInputState = new Lazy<object>(() => endState);
            return endState;
        }
    }
}
