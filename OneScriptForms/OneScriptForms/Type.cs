using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class Type
    {
        public bool IsSubclassOf(osf.Type p1)
        {
            return M_Type.IsSubclassOf(p1.M_Type);
        }
        public System.Type M_Type;

        public Type(string p1)
        {
            M_Type = System.Type.GetType(p1, false, true);
        }

        public Type(System.Type p1)
        {
            M_Type = p1;
        }

        public bool IsClass
        {
            get { return M_Type.IsClass; }
        }

        public string Name
        {
            get { return M_Type.Name; }
        }

        public bool IsInstanceOfType(osf.Type p1)
        {
            return M_Type.IsInstanceOfType(p1.M_Type);
        }

        public override string ToString()
        {
            return M_Type.ToString();
        }
    }

    [ContextClass("КлТип", "ClType")]
    public class ClType : AutoContext<ClType>
    {
        public ClType(IValue p1)
        {
            dynamic Type1 = null;
            if (p1.SystemType.Name == "Строка")
            {
                string p2 = p1.AsString();
                try
                {
                    if (p2 == "System.Drawing.Bitmap")
                    {
                        Type1 = (new System.Drawing.Bitmap(10, 10)).GetType();
                    }
                    else
                    {
                        Type1 = osf.OneScriptForms.GetTypeFromName(p2);
                    }
                }
                catch { }
                if (Type1 != null)
                {
                    Base_obj = Type1;
                    return;
                }
                if (p2.Contains("osf."))
                {
                    try
                    {
                        var a = Assembly.GetExecutingAssembly();
                        var allTypes = a.GetTypes();
                        foreach (var type1 in allTypes)
                        {
                            string str1 = "";
                            string str2 = "";
                            try
                            {
                                str1 = type1.GetCustomAttribute<ContextClassAttribute>().GetName();
                                str2 = type1.GetCustomAttribute<ContextClassAttribute>().GetAlias();
                            }
                            catch { }
                            if (type1.ToString() == p2)
                            {
                                Type1 = new Type(type1);
                                break;
                            }
                            else
                            {
                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        var a = Assembly.GetExecutingAssembly();
                        var allTypes = a.GetTypes();
                        foreach (var type1 in allTypes)
                        {
                            string str1 = "";
                            string str2 = "";
                            try
                            {
                                str1 = type1.GetCustomAttribute<ContextClassAttribute>().GetName();
                                str2 = type1.GetCustomAttribute<ContextClassAttribute>().GetAlias();
                            }
                            catch { }
                            if (str1.Replace("Кл", "") == p2 || str2.Replace("Cl", "") == p2)
                            {
                                Type1 = new Type(type1);
                                break;
                            }
                            else
                            {
                            }
                        }
                    }
                    catch { }
                }
            }
            else
            {
                Type1 = new Type(p1.GetType());
            }
            Base_obj = Type1;
        }

        public dynamic Base_obj;

        [ContextProperty("Имя", "Имя")]
        public string Name1
        {
            get
            {
                string str1 = "";
                if (this.ToString().Contains("osf."))
                {
                    var a = Assembly.GetExecutingAssembly();
                    var allTypes = a.GetTypes();
                    foreach (var type1 in allTypes)
                    {
                        try
                        {
                            str1 = type1.GetCustomAttribute<ContextClassAttribute>().GetName();
                            if (type1.ToString() == this.ToString())
                            {
                                break;
                            }
                        }
                        catch { }
                    }
                    str1 = str1.Replace("Кл", "");
                }
                return str1;
            }
        }

        [ContextProperty("Name", "Name")]
        public string Name2
        {
            get
            {
                string str1 = "";
                if (this.ToString().Contains("osf."))
                {
                    var a = Assembly.GetExecutingAssembly();
                    var allTypes = a.GetTypes();
                    foreach (var type1 in allTypes)
                    {
                        try
                        {
                            str1 = type1.GetCustomAttribute<ContextClassAttribute>().GetAlias();
                            if (type1.ToString() == this.ToString())
                            {
                                break;
                            }
                        }
                        catch { }
                    }
                    str1 = str1.Replace("Cl", "");
                }
                return str1;
            }
        }

        [ContextProperty("ЭтоКласс", "IsClass")]
        public bool IsClass
        {
            get { return Base_obj.IsClass; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public override string ToString()
        {
            return Base_obj.ToString();
        }

        [ContextMethod("ЭтоПодкласс", "IsSubclassOf")]
        public bool IsSubclassOf(ClType p1)
        {
            string str1 = Base_obj.ToString();
            string str2 = p1.Base_obj.ToString();
            System.Type Type1 = System.Type.GetType(str1.Replace("osf.Cl", "osf."));
            System.Type Type2 = System.Type.GetType(str2.Replace("osf.Cl", "osf."));
            return Type1.IsSubclassOf(Type2);
        }

        [ContextMethod("ЭтоЭкземплярТипа", "IsInstanceOfType")]
        public bool IsInstanceOfType(IValue p1)
        {
            string str1 = Base_obj.ToString();
            System.Type Type1 = System.Type.GetType(str1.Replace("osf.Cl", "osf."));
            return Type1.IsInstanceOfType(((dynamic)p1).Base_obj);
        }
    }
}
