using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    [ContextClass ("КлМатематика", "ClMath")]
    public class ClMath : AutoContext<ClMath>
    {
        
        [ContextProperty("Е", "E")]
        public double E
        {
            get { return System.Math.E; }
        }

        [ContextProperty("Пи", "PI")]
        public double PI
        {
            get { return System.Math.PI; }
        }
        
        [ContextMethod("АКосинус", "Acos")]
        public double Acos(double p1)
        {
            return System.Math.Acos(p1);
        }
        
        [ContextMethod("АСинус", "Asin")]
        public double Asin(double p1)
        {
            return System.Math.Asin(p1);
        }
        
        [ContextMethod("АТангенс", "Atan")]
        public double Atan(double p1)
        {
            return System.Math.Atan(p1);
        }
        
        [ContextMethod("АТангенс2", "Atan2")]
        public double Atan2(double p1, double p2)
        {
           return System.Math.Atan2(p1, p2);
        }
        
        [ContextMethod("ГКосинус", "Cosh")]
        public double Cosh(double p1)
        {
            return System.Math.Cosh(p1);
        }
        
        [ContextMethod("ГСинус", "Sinh")]
        public double Sinh(double p1)
        {
            return System.Math.Sinh(p1);
        }
        
        [ContextMethod("ГТангенс", "Tanh")]
        public double Tanh(double p1)
        {
            return System.Math.Tanh(p1);
        }
        
        [ContextMethod("ККорень", "Sqrt")]
        public double Sqrt(double p1)
        {
            return System.Math.Sqrt(p1);
        }
        
        [ContextMethod("Косинус", "Cos")]
        public double Cos(double p1)
        {
            return System.Math.Cos(p1);
        }
        
        [ContextMethod("Логарифм", "Log")]
        public double Log(double p1)
        {
            return System.Math.Log(p1);
        }
        
        [ContextMethod("Логарифм10", "Log10")]
        public double Log10(double p1)
        {
            return System.Math.Log10(p1);
        }
        
        [ContextMethod("НаибольшееЦелое", "Floor")]
        public double Floor(double p1)
        {
            return System.Math.Floor(p1);
        }
        
        [ContextMethod("НаименьшееЦел", "Ceiling")]
        public double Ceiling(double p1)
        {
            return System.Math.Ceiling(p1);
        }
        
        [ContextMethod("Окр", "Round")]
        public double Round(double p1, int p2)
        {
            return System.Math.Round(p1, p2);
        }
        
        [ContextMethod("Синус", "Sin")]
        public double Sin(double p1)
        {
            return System.Math.Sin(p1);
        }
        
        [ContextMethod("Случайное", "Random")]
        public double Random()
        {
            return OneScriptForms.Random.NextDouble();
        }
        
        [ContextMethod("Степень", "Pow")]
        public double Pow(double p1, double p2)
        {
            return System.Math.Pow(p1, p2);
        }
        
        [ContextMethod("Тангенс", "Tan")]
        public double Tan(double p1)
        {
            return System.Math.Tan(p1);
        }
        
        [ContextMethod("Четное", "Even")]
        public IValue Even(IValue p1)
        {
            if (p1.AsNumber() - (System.Math.Floor(p1.AsNumber())) > 0)
            {
                return null;
            }
            return ValueFactory.Create((p1.AsNumber() % 2) == 0);
        }

        [ContextMethod("Экспонента", "Exp")]
        public double Exp(double p1)
        {
            return System.Math.Exp(p1);
        }
    }
}
