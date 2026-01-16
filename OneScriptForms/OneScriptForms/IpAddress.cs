using ScriptEngine.Machine.Contexts;

namespace osf
{
    public class IpAddress
    {
        public ClIpAddress dll_obj;
        public System.Net.IPAddress M_IPaddress;

        public IpAddress(osf.IpAddress p1)
        {
            M_IPaddress = p1.M_IPaddress;
        }

        public IpAddress(string IPstring)
        {
            M_IPaddress = System.Net.IPAddress.Parse(IPstring);
        }

        public IpAddress(System.Net.IPAddress p1)
        {
            M_IPaddress = p1;
        }

        public osf.IpAddress Any
        {
            get { return new IpAddress("0.0.0.0"); }
        }

        public osf.IpAddress BroadCast
        {
            get { return new IpAddress("255.255.255.255"); }
        }

        public System.Net.IPAddress IPaddress
        {
            get { return M_IPaddress; }
        }

        public osf.IpAddress LoopBack
        {
            get { return new IpAddress("127.0.0.1"); }
        }

        public osf.IpAddress None
        {
            get { return new IpAddress("255.255.255.255"); }
        }

        public bool Equals(osf.IpAddress IPaddressObject)
        {
            if (M_IPaddress.ToString() == IPaddressObject.ToString())
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return M_IPaddress.ToString();
        }
    }

    [ContextClass("КлIpАдрес", "ClIpAddress")]
    public class ClIpAddress : AutoContext<ClIpAddress>
    {
        public ClIpAddress(string p1)
        {
            IpAddress IpAddress1 = new IpAddress(p1);
            IpAddress1.dll_obj = this;
            Base_obj = IpAddress1;
        }

        public ClIpAddress(osf.IpAddress p1)
        {
            IpAddress IpAddress1 = p1;
            IpAddress1.dll_obj = this;
            Base_obj = IpAddress1;
        }

        public IpAddress Base_obj;

        [ContextProperty("Замыкание", "LoopBack")]
        public ClIpAddress LoopBack
        {
            get { return (ClIpAddress)OneScriptForms.RevertObj(Base_obj.LoopBack); }
        }

        [ContextProperty("Любой", "Any")]
        public ClIpAddress Any
        {
            get { return (ClIpAddress)OneScriptForms.RevertObj(Base_obj.Any); }
        }

        [ContextProperty("Отсутствие", "None")]
        public ClIpAddress None
        {
            get { return (ClIpAddress)OneScriptForms.RevertObj(Base_obj.None); }
        }

        [ContextProperty("Широковещательный", "BroadCast")]
        public ClIpAddress BroadCast
        {
            get { return (ClIpAddress)OneScriptForms.RevertObj(Base_obj.BroadCast); }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new string ToString()
        {
            return Base_obj.ToString();
        }

        [ContextMethod("Равен", "Equals")]
        public bool Equals(ClIpAddress p1)
        {
            return Base_obj.Equals(p1.Base_obj);
        }
    }
}
