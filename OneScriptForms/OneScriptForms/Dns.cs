using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass("КлDns", "ClDns")]
    public class ClDns : AutoContext<ClDns>
    {
        public ClDns()
        {
        }

        [ContextMethod("ПолучитьИмяУзла", "GetHostName")]
        public string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }

        [ContextMethod("ПолучитьУзелПоАдресу", "GetHostByAddress")]
        public ClIpHostEntry GetHostByAddress(string p1)
        {
            return new ClIpHostEntry(new IpHostEntry(System.Net.Dns.GetHostEntry(p1)));
        }

        [ContextMethod("ПолучитьУзелПоИмени", "GetHostByName")]
        public ClIpHostEntry GetHostByName(string p1)
        {
            return new ClIpHostEntry(new IpHostEntry(p1));
        }

        [ContextMethod("Разрешить", "Resolve")]
        public ClIpHostEntry Resolve(string p1)
        {
            return new ClIpHostEntry(new IpHostEntry(System.Net.Dns.GetHostEntry(p1)));
        }
    }
}
