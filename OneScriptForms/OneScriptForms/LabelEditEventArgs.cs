using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class LabelEditEventArgs : EventArgs
    {
        public bool CancelEdit = false;
        public new ClLabelEditEventArgs dll_obj;
        public int Item = -1;
        public string Label = "";
        public string Type = "BeforeLabelEdit";

        //Свойства============================================================

        //Методы============================================================

        public override bool PostEvent()
        {
            if (CancelEdit)
            {
                return true;
            }
            ListView ListView1 = (ListView)Sender;
            ListViewEx ListViewEx1 = ListView1.M_ListView;
            if (Type == "BeforeLabelEdit")
            {
                ListViewEx1.BeforeLabelEdit -= ListView1.M_ListView_BeforeLabelEdit;
                ListViewEx1.Items[Item].BeginEdit();
                ListViewEx1.BeforeLabelEdit += ListView1.M_ListView_BeforeLabelEdit;
            }
            if (Type == "AfterLabelEdit")
            {
                ListViewEx1.Items[Item].Text = Label;
            }
            return true;
        }

    }

    [ContextClass ("КлРедактированиеНадписиАрг", "ClLabelEditEventArgs")]
    public class ClLabelEditEventArgs : AutoContext<ClLabelEditEventArgs>
    {

        public ClLabelEditEventArgs()
        {
            LabelEditEventArgs LabelEditEventArgs1 = new LabelEditEventArgs();
            LabelEditEventArgs1.dll_obj = this;
            Base_obj = LabelEditEventArgs1;
        }
		
        public ClLabelEditEventArgs(LabelEditEventArgs p1)
        {
            LabelEditEventArgs LabelEditEventArgs1 = p1;
            LabelEditEventArgs1.dll_obj = this;
            Base_obj = LabelEditEventArgs1;
        }
        
        public LabelEditEventArgs Base_obj;

        //Свойства============================================================

        [ContextProperty("Надпись", "Label")]
        public string Label
        {
            get { return Base_obj.Label; }
        }

        [ContextProperty("ОтменаРедактирования", "CancelEdit")]
        public bool CancelEdit
        {
            get { return Base_obj.CancelEdit; }
            set { Base_obj.CancelEdit = value; }
        }

        [ContextProperty("Элемент", "Item")]
        public int Item
        {
            get { return Base_obj.Item; }
        }

        //Методы============================================================

    }
}
