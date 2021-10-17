using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Threading;

namespace osf
{

    public class FolderBrowserDialog : CommonDialog
    {
        public ClFolderBrowserDialog dll_obj;
        public System.Windows.Forms.FolderBrowserDialog M_FolderBrowserDialog;

        public FolderBrowserDialog()
        {
            M_FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            base.M_CommonDialog = M_FolderBrowserDialog;
            OneScriptForms.AddToHashtable(M_FolderBrowserDialog, this);
        }

        public FolderBrowserDialog(osf.FolderBrowserDialog p1)
        {
            M_FolderBrowserDialog = p1.M_FolderBrowserDialog;
            base.M_CommonDialog = M_FolderBrowserDialog;
        }

        public FolderBrowserDialog(System.Windows.Forms.FolderBrowserDialog p1)
        {
            M_FolderBrowserDialog = p1;
            base.M_CommonDialog = M_FolderBrowserDialog;
        }

        //Свойства============================================================

        public string Description
        {
            get { return M_FolderBrowserDialog.Description; }
            set { M_FolderBrowserDialog.Description = value; }
        }

        public void Reset()
        {
            M_FolderBrowserDialog.Reset();
        }

        public int RootFolder
        {
            get { return (int)M_FolderBrowserDialog.RootFolder; }
            set { M_FolderBrowserDialog.RootFolder = (System.Environment.SpecialFolder)value; }
        }

        public string SelectedPath
        {
            get { return M_FolderBrowserDialog.SelectedPath; }
            set { M_FolderBrowserDialog.SelectedPath = value; }
        }

        public bool ShowNewFolderButton
        {
            get { return M_FolderBrowserDialog.ShowNewFolderButton; }
            set { M_FolderBrowserDialog.ShowNewFolderButton = value; }
        }

        //Методы============================================================

    }

    [ContextClass ("КлДиалогВыбораКаталога", "ClFolderBrowserDialog")]
    public class ClFolderBrowserDialog : AutoContext<ClFolderBrowserDialog>
    {

        public ClFolderBrowserDialog()
        {
            FolderBrowserDialog FolderBrowserDialog1 = new FolderBrowserDialog();
            FolderBrowserDialog1.dll_obj = this;
            Base_obj = FolderBrowserDialog1;
        }
		
        public ClFolderBrowserDialog(FolderBrowserDialog p1)
        {
            FolderBrowserDialog FolderBrowserDialog1 = p1;
            FolderBrowserDialog1.dll_obj = this;
            Base_obj = FolderBrowserDialog1;
        }
        
        public FolderBrowserDialog Base_obj;

        //Свойства============================================================

        [ContextProperty("ВыбранныйПуть", "SelectedPath")]
        public string SelectedPath
        {
            get { return Base_obj.SelectedPath; }
            set { Base_obj.SelectedPath = value; }
        }

        [ContextProperty("КорневойКаталог", "RootFolder")]
        public int RootFolder
        {
            get { return (int)Base_obj.RootFolder; }
            set { Base_obj.RootFolder = value; }
        }

        [ContextProperty("Описание", "Description")]
        public string Description
        {
            get { return Base_obj.Description; }
            set { Base_obj.Description = value; }
        }

        [ContextProperty("ПоказатьКнопкуНовогоКаталога", "ShowNewFolderButton")]
        public bool ShowNewFolderButton
        {
            get { return Base_obj.ShowNewFolderButton; }
            set { Base_obj.ShowNewFolderButton = value; }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }

        //Методы============================================================

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
					
        [ContextMethod("ПоказатьДиалог", "ShowDialog")]
        public IValue ShowDialog()
        {
            int Res1 = 0;
            var thread = new Thread(() => Res1 = (int)Base_obj.ShowDialog());
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return ValueFactory.Create(Res1);
        }
        
        [ContextMethod("Сбросить", "Reset")]
        public void Reset()
        {
            Base_obj.Reset();
        }
    }
}
