using ScriptEngine.Machine.Contexts;
using System.Windows.Forms;

namespace osf
{
    [ContextClass("КлОкноВвода", "ClInputBox")]
    public class ClInputBox : AutoContext<ClInputBox>
    {

        [ContextMethod("Показать", "Show")]
        public string Show(string Prompt, string Title = "", string DefaultResponse = "", int XPos = -1, int YPos = -1)
        {
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Button buttonOk = new System.Windows.Forms.Button();
            System.Windows.Forms.Button buttonCancel = new System.Windows.Forms.Button();

            form.Text = Title;
            label.Text = Prompt;
            textBox.Text = DefaultResponse;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            label.SetBounds(9, 15, 340, 60);
            textBox.SetBounds(12, 110, 425, 20);
            buttonOk.SetBounds(360, 18, 75, 28);
            buttonCancel.SetBounds(360, 52, 75, 28);

            form.Size = new System.Drawing.Size(457, 182);
            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(buttonOk);
            form.Controls.Add(buttonCancel);

            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = (System.Windows.Forms.DialogResult)form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                return textBox.Text;
            }
            return DefaultResponse;
        }
    }
}
