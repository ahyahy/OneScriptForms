using ScriptEngine.Machine.Contexts;
using System.Threading;

namespace osf
{
    [ContextClass ("КлОкноВвода", "ClInputBox")]
    public class ClInputBox : AutoContext<ClInputBox>
    {
        
        [ContextMethod("Показать", "Show")]
        public string Show(string p1, string p2, string p3 = "", int p4 = -1, int p5 = -1)
        {
            string str1 = "";
            var thread = new Thread(() =>
            {
                str1 = Microsoft.VisualBasic.Interaction.InputBox(p1, p2, p3, p4, p5);
            }
            );
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return str1;
        }
    }
}
