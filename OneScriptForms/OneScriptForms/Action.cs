using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    [ContextClass("КлДействие", "ClAction")]
    public class ClAction : AutoContext<ClAction>
    {
        public ClAction(IRuntimeContextInstance script, string methodName, IValue param = null)
        {
            Script = script;
            MethodName = methodName;
            Parameter = param;
        }

        [ContextProperty("ИмяМетода", "MethodName")]
        public string MethodName { get; set; }

        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter { get; set; }

        [ContextProperty("Сценарий", "Script")]
        public IRuntimeContextInstance Script { get; set; }

    }
}
