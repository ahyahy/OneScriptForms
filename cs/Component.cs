namespace osf
{

    public class Component : System.ComponentModel.Component
    {
        public System.ComponentModel.Component M_Component;

        //Свойства============================================================

        public Type Type
        {
            get { return new Type(GetType()); }
        }

        //Методы============================================================

        public new void Dispose()
        {
            M_Component.Dispose();
        }

    }

}
