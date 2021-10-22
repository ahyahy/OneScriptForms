using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    [ContextClass ("КлУправляемоеСвойство", "ClManagedProperty")]
    public class ClManagedProperty : AutoContext<ClManagedProperty>
    {
        private IValue managedObject;
        private string managedProperty;
        private IValue ratio;

        public ClManagedProperty(IValue p1, string p2, IValue p3 = null)
        {
            managedObject = p1;
            managedProperty = p2;
            ratio = p3;
        }
        
        [ContextProperty("Коэффициент", "Ratio")]
        public IValue Ratio
        {
            get { return ratio; }
            set { ratio = value; }
        }
        
        [ContextProperty("УправляемоеСвойство", "ManagedProperty")]
        public string ManagedProperty
        {
            get { return managedProperty; }
            set { managedProperty = value; }
        }
        
        [ContextProperty("УправляемыйОбъект", "ManagedObject")]
        public IValue ManagedObject
        {
            get { return managedObject; }
            set { managedObject = value; }
        }
        
    }
}
