using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    [ContextClass ("КлЕжегодныеДаты", "ClAnnuallyBoldedDates")]
    public class ClAnnuallyBoldedDates : AutoContext<ClAnnuallyBoldedDates>
    {
        public osf.MonthCalendar M_MonthCalendar;

        public System.DateTime[] M_Object
        {
            get { return M_MonthCalendar.AnnuallyBoldedDates; }
            set { M_MonthCalendar.AnnuallyBoldedDates = value; }
        }
        
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return M_Object.Length; }
        }
        
        [ContextMethod("Добавить", "Add")]
        public IValue Add(IValue p1)
        {
            DateTime[] DateTime2 = new DateTime[M_Object.Length + 1];
            M_Object.CopyTo(DateTime2, 0);
            System.DateTime p2 = p1.AsDate();
            DateTime2[M_Object.Length] = new System.DateTime(p2.Year, p2.Month, p2.Day, p2.Hour, p2.Minute, p2.Second);
            M_Object = DateTime2;
            return p1;
        }
        
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            M_Object = new DateTime[0];
        }
        
        [ContextMethod("Элемент", "Item")]
        public IValue Item(int p1)
        {
            return ValueFactory.Create(M_Object[p1]);
        }
    }
}
