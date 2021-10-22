namespace osf
{
    public class Component : System.ComponentModel.Component
    {
        public System.ComponentModel.Component M_Component;

        public Type Type
        {
            get { return new Type(GetType()); }
        }

        public new void Dispose()
        {
            M_Component.Dispose();
        }
    }
}
