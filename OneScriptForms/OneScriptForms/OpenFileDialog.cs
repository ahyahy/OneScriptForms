using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Threading;

namespace osf
{
    public class OpenFileDialog : FileDialog
    {
        public ClOpenFileDialog dll_obj;
        public System.Windows.Forms.OpenFileDialog M_OpenFileDialog;

        public OpenFileDialog()
        {
            M_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            base.M_FileDialog = M_OpenFileDialog;
            OneScriptForms.AddToHashtable(M_OpenFileDialog, this);
        }

        public OpenFileDialog(osf.OpenFileDialog p1)
        {
            M_OpenFileDialog = p1.M_OpenFileDialog;
            base.M_FileDialog = M_OpenFileDialog;
            OneScriptForms.AddToHashtable(M_OpenFileDialog, this);
        }

        public OpenFileDialog(System.Windows.Forms.OpenFileDialog p1)
        {
            M_OpenFileDialog = p1;
            base.M_FileDialog = M_OpenFileDialog;
            OneScriptForms.AddToHashtable(M_OpenFileDialog, this);
        }

        public override bool CheckFileExists
        {
            get { return M_OpenFileDialog.CheckFileExists; }
            set { M_OpenFileDialog.CheckFileExists = value; }
        }

        public bool ReadOnlyChecked
        {
            get { return M_OpenFileDialog.ReadOnlyChecked; }
            set { M_OpenFileDialog.ReadOnlyChecked = value; }
        }

        public void Reset()
        {
            M_OpenFileDialog.Reset();
        }

        public bool ShowReadOnly
        {
            get { return M_OpenFileDialog.ShowReadOnly; }
            set { M_OpenFileDialog.ShowReadOnly = value; }
        }
    }

    [ContextClass("КлДиалогОткрытияФайла", "ClOpenFileDialog")]
    public class ClOpenFileDialog : AutoContext<ClOpenFileDialog>
    {
        public ClOpenFileDialog()
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.dll_obj = this;
            Base_obj = OpenFileDialog1;
        }

        public ClOpenFileDialog(OpenFileDialog p1)
        {
            OpenFileDialog OpenFileDialog1 = p1;
            OpenFileDialog1.dll_obj = this;
            Base_obj = OpenFileDialog1;
        }

        public OpenFileDialog Base_obj;

        [ContextProperty("ВосстанавливатьКаталог", "RestoreDirectory")]
        public bool RestoreDirectory
        {
            get { return Base_obj.RestoreDirectory; }
            set { Base_obj.RestoreDirectory = value; }
        }

        [ContextProperty("ДобавитьРасширение", "AddExtension")]
        public bool AddExtension
        {
            get { return Base_obj.AddExtension; }
            set { Base_obj.AddExtension = value; }
        }

        [ContextProperty("Заголовок", "Title")]
        public string Title
        {
            get { return Base_obj.Title; }
            set { Base_obj.Title = value; }
        }

        [ContextProperty("ИмяФайла", "FileName")]
        public string FileName
        {
            get { return Base_obj.FileName; }
            set { Base_obj.FileName = value; }
        }

        [ContextProperty("ИндексФильтра", "FilterIndex")]
        public int FilterIndex
        {
            get { return Base_obj.FilterIndex; }
            set { Base_obj.FilterIndex = value; }
        }

        [ContextProperty("НачальныйКаталог", "InitialDirectory")]
        public string InitialDirectory
        {
            get { return Base_obj.InitialDirectory; }
            set { Base_obj.InitialDirectory = value; }
        }

        [ContextProperty("ПоказатьТолькоДляЧтения", "ShowReadOnly")]
        public bool ShowReadOnly
        {
            get { return Base_obj.ShowReadOnly; }
            set { Base_obj.ShowReadOnly = value; }
        }

        [ContextProperty("ПомеченТолькоЧтение", "ReadOnlyChecked")]
        public bool ReadOnlyChecked
        {
            get { return Base_obj.ReadOnlyChecked; }
            set { Base_obj.ReadOnlyChecked = value; }
        }

        [ContextProperty("ПроверятьСуществованиеПути", "CheckPathExists")]
        public bool CheckPathExists
        {
            get { return Base_obj.CheckPathExists; }
            set { Base_obj.CheckPathExists = value; }
        }

        [ContextProperty("ПроверятьСуществованиеФайла", "CheckFileExists")]
        public bool CheckFileExists
        {
            get { return Base_obj.CheckFileExists; }
            set { Base_obj.CheckFileExists = value; }
        }

        [ContextProperty("РазыменоватьСсылки", "DereferenceLinks")]
        public bool DereferenceLinks
        {
            get { return Base_obj.DereferenceLinks; }
            set { Base_obj.DereferenceLinks = value; }
        }

        [ContextProperty("РасширениеПоУмолчанию", "DefaultExt")]
        public string DefaultExt
        {
            get { return Base_obj.DefaultExt; }
            set { Base_obj.DefaultExt = value; }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }

        [ContextProperty("Фильтр", "Filter")]
        public string Filter
        {
            get { return Base_obj.Filter; }
            set { Base_obj.Filter = value; }
        }

        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }

        [ContextMethod("ПоказатьДиалог", "ShowDialog")]
        public IValue ShowDialog()
        {
            ClForm activeForm = null;
            try
            {
                activeForm = OneScriptForms.FirstForm.ActiveForm;
            }
            catch { }

            int Res1 = 0;
            var thread = new Thread(() => Res1 = (int)Base_obj.ShowDialog());
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            IValue val1 = ValueFactory.Create(Res1);
            if (activeForm != null)
            {
                activeForm.Activate();
            }
            return val1;
        }

        [ContextMethod("Сбросить", "Reset")]
        public void Reset()
        {
            Base_obj.Reset();
        }
    }
}
