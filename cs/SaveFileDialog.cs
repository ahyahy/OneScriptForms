using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Threading;

namespace osf
{

    public class SaveFileDialog : FileDialog
    {
        public ClSaveFileDialog dll_obj;
        public System.Windows.Forms.SaveFileDialog M_SaveFileDialog;

        public SaveFileDialog()
        {
            M_SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            base.M_FileDialog = M_SaveFileDialog;
            OneScriptForms.AddToHashtable(M_SaveFileDialog, this);
        }

        public SaveFileDialog(System.Windows.Forms.SaveFileDialog p1)
        {
            M_SaveFileDialog = p1;
            base.M_FileDialog = M_SaveFileDialog;
            OneScriptForms.AddToHashtable(M_SaveFileDialog, this);
        }

        public SaveFileDialog(osf.SaveFileDialog p1)
        {
            M_SaveFileDialog = p1.M_SaveFileDialog;
            base.M_FileDialog = M_SaveFileDialog;
            OneScriptForms.AddToHashtable(M_SaveFileDialog, this);
        }

        //Свойства============================================================

        public bool CreatePrompt
        {
            get { return M_SaveFileDialog.CreatePrompt; }
            set { M_SaveFileDialog.CreatePrompt = value; }
        }

        public bool OverwritePrompt
        {
            get { return M_SaveFileDialog.OverwritePrompt; }
            set { M_SaveFileDialog.OverwritePrompt = value; }
        }

        public void Reset()
        {
            M_SaveFileDialog.Reset();
        }

        //Методы============================================================

    }

    [ContextClass ("КлДиалогСохраненияФайла", "ClSaveFileDialog")]
    public class ClSaveFileDialog : AutoContext<ClSaveFileDialog>
    {

        public ClSaveFileDialog()
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.dll_obj = this;
            Base_obj = SaveFileDialog1;
        }
		
        public ClSaveFileDialog(SaveFileDialog p1)
        {
            SaveFileDialog SaveFileDialog1 = p1;
            SaveFileDialog1.dll_obj = this;
            Base_obj = SaveFileDialog1;
        }
        
        public SaveFileDialog Base_obj;

        //Свойства============================================================

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

        [ContextProperty("ПодтверждениеПерезаписи", "OverwritePrompt")]
        public bool OverwritePrompt
        {
            get { return Base_obj.OverwritePrompt; }
            set { Base_obj.OverwritePrompt = value; }
        }

        [ContextProperty("ПодтверждениеСоздания", "CreatePrompt")]
        public bool CreatePrompt
        {
            get { return Base_obj.CreatePrompt; }
            set { Base_obj.CreatePrompt = value; }
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
