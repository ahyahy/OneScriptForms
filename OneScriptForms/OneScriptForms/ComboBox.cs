using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Windows.Forms;
using System.Reflection;

namespace osf
{
    public class NoKeyUpComboBoxEx : System.Windows.Forms.ComboBox
    {
        public osf.ComboBox M_Object;
        private const int WM_KEYUP = 0x101;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_KEYUP)
            {
                // Игнорировать поднятие клавиши Tab, чтобы избежать проблем с перемещением по колонке, содержащей поле выбора;
                // Иначе невозможно будет с помощью клавиши Tab передать фокус колонке, содержащей поле выбора.
                return;
            }
            base.WndProc(ref m);
        }
    }
    public class ComboBoxEx : System.Windows.Forms.ComboBox
    {
        public osf.ComboBox M_Object;
    }

    public class ComboBox : ListControl
    {
        public ClComboBox dll_obj;
        public string DropDown;
        public ArrayList heights;
        private dynamic m_ComboBox;
        public string SelectedIndexChanged;

        public ComboBox()
        {
            M_ComboBox = new ComboBoxEx();
            M_ComboBox.M_Object = this;
            base.M_ListControl = M_ComboBox;
            SelectedIndexChanged = "";
            DropDown = "";
            heights = new ArrayList();
        }

        public ComboBox(osf.ComboBox p1)
        {
            M_ComboBox = p1.M_ComboBox;
            M_ComboBox.M_Object = this;
            base.M_ListControl = M_ComboBox;
            SelectedIndexChanged = "";
            DropDown = "";
            heights = new ArrayList();
        }

        public ComboBox(osf.NoKeyUpComboBoxEx p1)
        {
            M_ComboBox = (dynamic)((System.Windows.Forms.ComboBox)p1);
            M_ComboBox.M_Object = this;
            base.M_ListControl = M_ComboBox;
            SelectedIndexChanged = "";
            DropDown = "";
            heights = new ArrayList();
        }

        public ComboBox(System.Windows.Forms.ComboBox p1)
        {
            M_ComboBox = (ComboBoxEx)p1;
            M_ComboBox.M_Object = this;
            base.M_ListControl = M_ComboBox;
            SelectedIndexChanged = "";
            DropDown = "";
            heights = new ArrayList();
        }

        //Свойства============================================================

        public int DrawMode
        {
            get { return (int)M_ComboBox.DrawMode; }
            set { M_ComboBox.DrawMode = (System.Windows.Forms.DrawMode)value; }
        }

        public int DropDownStyle
        {
            get { return (int)M_ComboBox.DropDownStyle; }
            set { M_ComboBox.DropDownStyle = (System.Windows.Forms.ComboBoxStyle)value; }
        }

        public int DropDownWidth
        {
            get { return M_ComboBox.DropDownWidth; }
            set { M_ComboBox.DropDownWidth = value; }
        }

        public bool DroppedDown
        {
            get { return M_ComboBox.DroppedDown; }
            set { M_ComboBox.DroppedDown = value; }
        }

        public osf.ArrayList HeightItems
        {
            get { return heights; }
            set { heights = value; }
        }

        public virtual int PreferredHeight
        {
            get { return M_ComboBox.PreferredHeight; }
        }

        public bool IntegralHeight
        {
            get { return M_ComboBox.IntegralHeight; }
            set { M_ComboBox.IntegralHeight = value; }
        }

        public int ItemHeight
        {
            get { return M_ComboBox.ItemHeight; }
            set { M_ComboBox.ItemHeight = value; }
        }

        public osf.ComboBoxObjectCollection Items
        {
            get { return new ComboBoxObjectCollection(M_ComboBox.Items); }
        }

        public dynamic M_ComboBox
        {
            get { return m_ComboBox; }
            set
            {
                m_ComboBox = value;
                ((System.Windows.Forms.ComboBox)m_ComboBox).DropDown += M_ComboBox_DropDown;
                ((System.Windows.Forms.ComboBox)m_ComboBox).SelectedIndexChanged += M_ComboBox_SelectedIndexChanged;
                ((System.Windows.Forms.ComboBox)m_ComboBox).DrawItem += M_ComboBox_DrawItem;
                ((System.Windows.Forms.ComboBox)m_ComboBox).MeasureItem += M_ComboBox_MeasureItem;
            }
        }

        public int MaxDropDownItems
        {
            get { return M_ComboBox.MaxDropDownItems; }
            set { M_ComboBox.MaxDropDownItems = value; }
        }

        public int MaxLength
        {
            get { return M_ComboBox.MaxLength; }
            set { M_ComboBox.MaxLength = value; }
        }

        public int SelectedIndex
        {
            get { return M_ComboBox.SelectedIndex; }
            set { M_ComboBox.SelectedIndex = value; }
        }

        public string SelectedText
        {
            get { return M_ComboBox.SelectedText; }
            set { M_ComboBox.SelectedText = value; }
        }

        public int SelectionLength
        {
            get { return M_ComboBox.SelectionLength; }
            set { M_ComboBox.SelectionLength = value; }
        }

        public int SelectionStart
        {
            get { return M_ComboBox.SelectionStart; }
            set { M_ComboBox.SelectionStart = value; }
        }

        public bool Sorted
        {
            get { return M_ComboBox.Sorted; }
            set { M_ComboBox.Sorted = value; }
        }

        //Методы============================================================

        private void M_ComboBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            dynamic item = M_ComboBox.Items[e.Index];
            System.Type type = item.GetType();
            System.Drawing.Color color1 = M_ComboBox.ForeColor;
            PropertyInfo propertyForeColor = type.GetProperty("ForeColor");
            Color colorForeColor = null;
            if (propertyForeColor != null)
            {
                try
                {
                    colorForeColor = (Color)propertyForeColor.GetValue(Items[e.Index], (object[])null);
                }
                catch
                {
                    colorForeColor = ((ClColor)propertyForeColor.GetValue(Items[e.Index], (object[])null)).Base_obj;
                }
            }
            if ((e.State & System.Windows.Forms.DrawItemState.Disabled) == System.Windows.Forms.DrawItemState.Disabled)
            {
                try
                {
                    if (!colorForeColor.IsEmpty)
                    {
                        color1 = colorForeColor.M_Color;
                    }
                }
                catch
                {
                    color1 = System.Drawing.SystemColors.GrayText;
                }
            }
            else if ((e.State & System.Windows.Forms.DrawItemState.Selected) == System.Windows.Forms.DrawItemState.Selected)
            {
                color1 = System.Drawing.SystemColors.HighlightText;
            }
            else
            {
                try
                {
                    if (!colorForeColor.IsEmpty)
                    {
                        color1 = colorForeColor.M_Color;
                    }
                }
                catch
                {
                }
            }
            string s = "";
            string ObjType = item.GetType().ToString();
            if (ObjType == "System.Data.DataRowView")
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)item;
                try
                {
                    dynamic var1 = drv.Row[M_ComboBox.DisplayMember];
                    System.Type Type1 = var1.GetType();
                    s = Type1.GetCustomAttribute<ContextClassAttribute>().GetName();
                }
                catch
                {
                    if (drv.Row[M_ComboBox.DisplayMember].GetType() == typeof(System.Boolean))
                    {
                        ScriptEngine.Machine.Values.BooleanValue Bool1;
                        if ((System.Boolean)drv.Row[M_ComboBox.DisplayMember])
                        {
                            Bool1 = ScriptEngine.Machine.Values.BooleanValue.True;
                        }
                        else
                        {
                            Bool1 = ScriptEngine.Machine.Values.BooleanValue.False;
                        }
                        s = Bool1.ToString();
                    }
                    else
                    {
                        s = drv.Row[M_ComboBox.DisplayMember].ToString();
                    }
                }
            }
            else if (ObjType == "osf.ListItem")
            {
                try
                {
                    s = ((osf.ListItem)item).Value.GetType().GetCustomAttribute<ContextClassAttribute>().GetName();
                }
                catch
                {
                    s = ((osf.ListItem)item).Text;
                }
            }
            if (s == "")
            {
                PropertyInfo property1 = type.GetProperty(M_ComboBox.DisplayMember);
                if (property1 != null)
                {
                    s = Convert.ToString(property1.GetValue(Items[e.Index]));
                }
                else
                {
                    if (SelectedIndexChanged != "")
                    {
                        try
                        {
                            System.Type Type1 = item.GetType();
                            s = Type1.GetCustomAttribute<ContextClassAttribute>().GetName();
                        }
                        catch
                        {
                            s = item.ToString();
                        }
                    }
                    else
                    {
                        s = item.ToString();
                    }
                }
            }
            e.Graphics.DrawString(s, M_ComboBox.Font, (System.Drawing.Brush)new System.Drawing.SolidBrush(color1), (float)e.Bounds.X, (float)e.Bounds.Y);
        }

        public void M_ComboBox_DropDown(object sender, System.EventArgs e)
        {
            if (DropDown.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = DropDown;
                EventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.DropDown;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    EventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    EventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    EventArgs1.Parameter = null;
                }
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void M_ComboBox_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            dynamic var1 = HeightItems[e.Index];
            try
            {
                e.ItemHeight = Convert.ToInt32(var1.AsString());
            }
            catch
            {
                e.ItemHeight = Convert.ToInt32(var1);
            }
        }

        public void M_ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (SelectedIndexChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = SelectedIndexChanged;
                EventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.SelectedIndexChanged;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    EventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    EventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    EventArgs1.Parameter = null;
                }
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        public void Paste()
        {
            System.Windows.Forms.IDataObject dataObject = System.Windows.Forms.Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(System.Windows.Forms.DataFormats.Text))
            {
                M_ComboBox.Text = Convert.ToString(dataObject.GetData(System.Windows.Forms.DataFormats.Text));
            }
            System.Windows.Forms.Application.DoEvents();
        }

    }

    [ContextClass ("КлПолеВыбора", "ClComboBox")]
    public class ClComboBox : AutoContext<ClComboBox>
    {
        private IValue _Click;
        private IValue _ControlAdded;
        private IValue _ControlRemoved;
        private IValue _DoubleClick;
        private IValue _DropDown;
        private IValue _Enter;
        private IValue _KeyDown;
        private IValue _KeyPress;
        private IValue _KeyUp;
        private IValue _Leave;
        private IValue _LocationChanged;
        private IValue _LostFocus;
        private IValue _MouseDown;
        private IValue _MouseEnter;
        private IValue _MouseHover;
        private IValue _MouseLeave;
        private IValue _MouseMove;
        private IValue _MouseUp;
        private IValue _Move;
        private IValue _Paint;
        private IValue _SelectedIndexChanged;
        private IValue _SizeChanged;
        private IValue _TextChanged;
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClColor foreColor;
        private ClArrayList heights = new ClArrayList();
        private ClComboBoxObjectCollection items;
        private ClCollection tag = new ClCollection();

        public ClComboBox()
        {
            ComboBox ComboBox1 = new ComboBox();
            ComboBox1.dll_obj = this;
            Base_obj = ComboBox1;
            items = new ClComboBoxObjectCollection(Base_obj.Items);
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClComboBox(osf.NoKeyUpComboBoxEx p1)
        {
            ComboBox ComboBox1 = new ComboBox(p1);
            ComboBox1.dll_obj = this;
            Base_obj = ComboBox1;
            items = new ClComboBoxObjectCollection(Base_obj.Items);
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClComboBox(ComboBox p1)
        {
            ComboBox ComboBox1 = p1;
            ComboBox1.dll_obj = this;
            Base_obj = ComboBox1;
            items = new ClComboBoxObjectCollection(Base_obj.Items);
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClArrayList _HeightItems
        {
            get { return heights; }
            set { heights = value; }
        }

        public dynamic Base_obj;

        //Свойства============================================================

        [ContextProperty("ВерсияПродукта", "ProductVersion")]
        public string ProductVersion
        {
            get { return Base_obj.ProductVersion; }
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
            get { return Base_obj.Top; }
            set { Base_obj.Top = value; }
        }

        [ContextProperty("ВыбранноеЗначение", "SelectedValue")]
        public IValue SelectedValue
        {
            get { return (IValue)OneScriptForms.RevertObj(Base_obj.SelectedValue); }
            set { Base_obj.SelectedValue = value; }
        }

        [ContextProperty("ВыделенныйТекст", "SelectedText")]
        public string SelectedText
        {
            get { return Base_obj.SelectedText; }
            set { Base_obj.SelectedText = value; }
        }

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
            set { Base_obj.Height = value; }
        }

        [ContextProperty("ВысотаШрифта", "FontHeight")]
        public int FontHeight
        {
            get { return Convert.ToInt32(Base_obj.FontHeight); }
        }
        
        [ContextProperty("ВысотаЭлемента", "ItemHeight")]
        public int ItemHeight
        {
            get { return Base_obj.ItemHeight; }
            set { Base_obj.ItemHeight = value; }
        }

        [ContextProperty("Границы", "Bounds")]
        public ClRectangle Bounds
        {
            get { return bounds; }
            set 
            {
                bounds = value;
                Base_obj.Bounds = value.Base_obj;
            }
        }

        [ContextProperty("ДвойнаяБуферизация", "DoubleBuffered")]
        public bool DoubleBuffered
        {
            get { return Base_obj.DoubleBuffered; }
            set { Base_obj.DoubleBuffered = value; }
        }

        [ContextProperty("ДвойноеНажатие", "DoubleClick")]
        public IValue DoubleClick
        {
            get
            {
                if (Base_obj.DoubleClick.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _DoubleClick;
                }
                else if (Base_obj.DoubleClick.Contains("osf.ClDictionaryEntry"))
                {
                    return _DoubleClick;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.DoubleClick);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _DoubleClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DoubleClick = "ScriptEngine.HostedScript.Library.DelegateAction" + "DoubleClick";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _DoubleClick = value;
                    Base_obj.DoubleClick = "osf.ClDictionaryEntry" + "DoubleClick";
                }
                else
                {
                    Base_obj.DoubleClick = value.AsString();
                }
            }
        }
        
        [ContextProperty("ДлинаВыделения", "SelectionLength")]
        public int SelectionLength
        {
            get { return Base_obj.SelectionLength; }
            set { Base_obj.SelectionLength = value; }
        }

        [ContextProperty("Доступность", "Enabled")]
        public bool Enabled
        {
            get { return Base_obj.Enabled; }
            set { Base_obj.Enabled = value; }
        }

        [ContextProperty("ЖирныйШрифт", "FontBold")]
        public bool FontBold
        {
            get { return Base_obj.FontBold; }
            set { Base_obj.FontBold = value; }
        }

        [ContextProperty("Захват", "Capture")]
        public bool Capture
        {
            get { return Base_obj.Capture; }
            set { Base_obj.Capture = value; }
        }

        [ContextProperty("ЗначениеЭлемента", "ValueMember")]
        public string ValueMember
        {
            get { return Base_obj.ValueMember; }
            set { Base_obj.ValueMember = value; }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
            set { Base_obj.Name = value; }
        }

        [ContextProperty("ИмяПродукта", "ProductName")]
        public string ProductName
        {
            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
        }
        
        [ContextProperty("ИмяШрифта", "FontName")]
        public string FontName
        {
            get { return Base_obj.FontName; }
            set { Base_obj.FontName = value; }
        }

        [ContextProperty("ИндексВыбранного", "SelectedIndex")]
        public int SelectedIndex
        {
            get { return Base_obj.SelectedIndex; }
            set { Base_obj.SelectedIndex = value; }
        }

        [ContextProperty("ИндексВыбранногоИзменен", "SelectedIndexChanged")]
        public IValue SelectedIndexChanged
        {
            get
            {
                if (Base_obj.SelectedIndexChanged.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _SelectedIndexChanged;
                }
                else if (Base_obj.SelectedIndexChanged.Contains("osf.ClDictionaryEntry"))
                {
                    return _SelectedIndexChanged;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.SelectedIndexChanged);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _SelectedIndexChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.SelectedIndexChanged = "ScriptEngine.HostedScript.Library.DelegateAction" + "SelectedIndexChanged";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _SelectedIndexChanged = value;
                    Base_obj.SelectedIndexChanged = "osf.ClDictionaryEntry" + "SelectedIndexChanged";
                }
                else
                {
                    Base_obj.SelectedIndexChanged = value.AsString();
                }
            }
        }
        
        [ContextProperty("ИспользоватьКурсорОжидания", "UseWaitCursor")]
        public bool UseWaitCursor
        {
            get { return Base_obj.UseWaitCursor; }
            set { Base_obj.UseWaitCursor = value; }
        }

        [ContextProperty("ИсточникДанных", "DataSource")]
        public IValue DataSource
        {
            get { return OneScriptForms.RevertObj(Base_obj.DataSource); }
            set
            {
                try
                {
                    ArrayList ArrayList1 = Base_obj.HeightItems;
                    int count1 = 0;
                    if (value.GetType().ToString() == "osf.ClDataTable")
                    {
                        count1 = ((osf.ClDataTable)value).Base_obj.Rows.Count;
                    }
                    else if (value.GetType().ToString() == "osf.ClArrayList")
                    {
                        count1 = ((osf.ClArrayList)value).Base_obj.Count;
                    }
                    for (int i = 0; i < count1; i++)
                    {
                        ArrayList1.Add(ItemHeight);
                    }
                    Base_obj.DataSource = ((dynamic)value).Base_obj;
                }
                catch
                {
                    Base_obj.DataSource = null;
                }
            }
        }

        [ContextProperty("КлавишаВверх", "KeyUp")]
        public IValue KeyUp
        {
            get
            {
                if (Base_obj.KeyUp.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _KeyUp;
                }
                else if (Base_obj.KeyUp.Contains("osf.ClDictionaryEntry"))
                {
                    return _KeyUp;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.KeyUp);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _KeyUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyUp = "ScriptEngine.HostedScript.Library.DelegateAction" + "KeyUp";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _KeyUp = value;
                    Base_obj.KeyUp = "osf.ClDictionaryEntry" + "KeyUp";
                }
                else
                {
                    Base_obj.KeyUp = value.AsString();
                }
            }
        }
        
        [ContextProperty("КлавишаВниз", "KeyDown")]
        public IValue KeyDown
        {
            get
            {
                if (Base_obj.KeyDown.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _KeyDown;
                }
                else if (Base_obj.KeyDown.Contains("osf.ClDictionaryEntry"))
                {
                    return _KeyDown;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.KeyDown);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _KeyDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyDown = "ScriptEngine.HostedScript.Library.DelegateAction" + "KeyDown";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _KeyDown = value;
                    Base_obj.KeyDown = "osf.ClDictionaryEntry" + "KeyDown";
                }
                else
                {
                    Base_obj.KeyDown = value.AsString();
                }
            }
        }
        
        [ContextProperty("КлавишаНажата", "KeyPress")]
        public IValue KeyPress
        {
            get
            {
                if (Base_obj.KeyPress.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _KeyPress;
                }
                else if (Base_obj.KeyPress.Contains("osf.ClDictionaryEntry"))
                {
                    return _KeyPress;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.KeyPress);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _KeyPress = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyPress = "ScriptEngine.HostedScript.Library.DelegateAction" + "KeyPress";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _KeyPress = value;
                    Base_obj.KeyPress = "osf.ClDictionaryEntry" + "KeyPress";
                }
                else
                {
                    Base_obj.KeyPress = value.AsString();
                }
            }
        }
        
        [ContextProperty("КлиентВысота", "ClientHeight")]
        public int ClientHeight
        {
            get { return Base_obj.ClientHeight; }
            set { Base_obj.ClientHeight = value; }
        }

        [ContextProperty("КлиентПрямоугольник", "ClientRectangle")]
        public ClRectangle ClientRectangle
        {
            get { return clientRectangle; }
        }

        [ContextProperty("КлиентРазмер", "ClientSize")]
        public ClSize ClientSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.ClientSize); }
            set { Base_obj.ClientSize = value.Base_obj; }
        }

        [ContextProperty("КлиентШирина", "ClientWidth")]
        public int ClientWidth
        {
            get { return Base_obj.ClientWidth; }
            set { Base_obj.ClientWidth = value; }
        }

        [ContextProperty("КнопкиМыши", "MouseButtons")]
        public int MouseButtons
        {
            get { return (int)Base_obj.MouseButtons; }
        }

        [ContextProperty("КонтекстноеМеню", "ContextMenu")]
        public ClContextMenu ContextMenu
        {
            get { return (ClContextMenu)OneScriptForms.RevertObj(Base_obj.ContextMenu); }
            set { Base_obj.ContextMenu = value.Base_obj; }
        }

        [ContextProperty("Курсор", "Cursor")]
        public ClCursor Cursor
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Cursor); }
            set { Base_obj.Cursor = value.Base_obj; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return Base_obj.Left; }
            set { Base_obj.Left = value; }
        }

        [ContextProperty("МаксимальнаяДлина", "MaxLength")]
        public int MaxLength
        {
            get { return Base_obj.MaxLength; }
            set { Base_obj.MaxLength = value; }
        }

        [ContextProperty("МаксимумЭлементов", "MaxDropDownItems")]
        public int MaxDropDownItems
        {
            get { return Base_obj.MaxDropDownItems; }
            set { Base_obj.MaxDropDownItems = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("МышьНадЭлементом", "MouseEnter")]
        public IValue MouseEnter
        {
            get
            {
                if (Base_obj.MouseEnter.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseEnter;
                }
                else if (Base_obj.MouseEnter.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseEnter;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseEnter);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseEnter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseEnter = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseEnter";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseEnter = value;
                    Base_obj.MouseEnter = "osf.ClDictionaryEntry" + "MouseEnter";
                }
                else
                {
                    Base_obj.MouseEnter = value.AsString();
                }
            }
        }
        
        [ContextProperty("МышьПокинулаЭлемент", "MouseLeave")]
        public IValue MouseLeave
        {
            get
            {
                if (Base_obj.MouseLeave.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseLeave;
                }
                else if (Base_obj.MouseLeave.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseLeave;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseLeave);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseLeave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseLeave = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseLeave";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseLeave = value;
                    Base_obj.MouseLeave = "osf.ClDictionaryEntry" + "MouseLeave";
                }
                else
                {
                    Base_obj.MouseLeave = value.AsString();
                }
            }
        }
        
        [ContextProperty("Нажатие", "Click")]
        public IValue Click
        {
            get
            {
                if (Base_obj.Click.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Click;
                }
                else if (Base_obj.Click.Contains("osf.ClDictionaryEntry"))
                {
                    return _Click;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Click);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Click = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Click = "ScriptEngine.HostedScript.Library.DelegateAction" + "Click";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Click = value;
                    Base_obj.Click = "osf.ClDictionaryEntry" + "Click";
                }
                else
                {
                    Base_obj.Click = value.AsString();
                }
            }
        }
        
        [ContextProperty("НачалоВыделения", "SelectionStart")]
        public int SelectionStart
        {
            get { return Base_obj.SelectionStart; }
            set { Base_obj.SelectionStart = value; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return Base_obj.Bottom; }
        }

        [ContextProperty("ОсновнойЦвет", "ForeColor")]
        public ClColor ForeColor
        {
            get { return foreColor; }
            set 
            {
                foreColor = value;
                Base_obj.ForeColor = value.Base_obj;
            }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("ОтображениеЭлемента", "DisplayMember")]
        public string DisplayMember
        {
            get { return Base_obj.DisplayMember; }
            set { Base_obj.DisplayMember = value; }
        }

        [ContextProperty("Отсортирован", "Sorted")]
        public bool Sorted
        {
            get { return Base_obj.Sorted; }
            set { Base_obj.Sorted = value; }
        }

        [ContextProperty("ПодборВысоты", "IntegralHeight")]
        public bool IntegralHeight
        {
            get { return Base_obj.IntegralHeight; }
            set { Base_obj.IntegralHeight = value; }
        }

        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
        }
        
        [ContextProperty("Положение", "Location")]
        public ClPoint Location
        {
            get { return (ClPoint)OneScriptForms.RevertObj(Base_obj.Location); }
            set { Base_obj.Location = value.Base_obj; }
        }

        [ContextProperty("ПоложениеИзменено", "LocationChanged")]
        public IValue LocationChanged
        {
            get
            {
                if (Base_obj.LocationChanged.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _LocationChanged;
                }
                else if (Base_obj.LocationChanged.Contains("osf.ClDictionaryEntry"))
                {
                    return _LocationChanged;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.LocationChanged);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _LocationChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LocationChanged = "ScriptEngine.HostedScript.Library.DelegateAction" + "LocationChanged";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _LocationChanged = value;
                    Base_obj.LocationChanged = "osf.ClDictionaryEntry" + "LocationChanged";
                }
                else
                {
                    Base_obj.LocationChanged = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПорядокОбхода", "TabIndex")]
        public int TabIndex
        {
            get { return Base_obj.TabIndex; }
            set { Base_obj.TabIndex = value; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return Base_obj.Right; }
        }

        [ContextProperty("ПредпочтительнаяВысота", "PreferredHeight")]
        public int PreferredHeight
        {
            get { return Base_obj.PreferredHeight; }
        }

        [ContextProperty("ПриВходе", "Enter")]
        public IValue Enter
        {
            get
            {
                if (Base_obj.Enter.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Enter;
                }
                else if (Base_obj.Enter.Contains("osf.ClDictionaryEntry"))
                {
                    return _Enter;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Enter);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Enter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Enter = "ScriptEngine.HostedScript.Library.DelegateAction" + "Enter";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Enter = value;
                    Base_obj.Enter = "osf.ClDictionaryEntry" + "Enter";
                }
                else
                {
                    Base_obj.Enter = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриВыпадении", "DropDown")]
        public IValue DropDown
        {
            get
            {
                if (Base_obj.DropDown.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _DropDown;
                }
                else if (Base_obj.DropDown.Contains("osf.ClDictionaryEntry"))
                {
                    return _DropDown;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.DropDown);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _DropDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DropDown = "ScriptEngine.HostedScript.Library.DelegateAction" + "DropDown";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _DropDown = value;
                    Base_obj.DropDown = "osf.ClDictionaryEntry" + "DropDown";
                }
                else
                {
                    Base_obj.DropDown = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриЗадержкеМыши", "MouseHover")]
        public IValue MouseHover
        {
            get
            {
                if (Base_obj.MouseHover.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseHover;
                }
                else if (Base_obj.MouseHover.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseHover;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseHover);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseHover = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseHover = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseHover";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseHover = value;
                    Base_obj.MouseHover = "osf.ClDictionaryEntry" + "MouseHover";
                }
                else
                {
                    Base_obj.MouseHover = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриНажатииКнопкиМыши", "MouseDown")]
        public IValue MouseDown
        {
            get
            {
                if (Base_obj.MouseDown.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseDown;
                }
                else if (Base_obj.MouseDown.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseDown;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseDown);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseDown = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseDown";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseDown = value;
                    Base_obj.MouseDown = "osf.ClDictionaryEntry" + "MouseDown";
                }
                else
                {
                    Base_obj.MouseDown = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриОтпусканииМыши", "MouseUp")]
        public IValue MouseUp
        {
            get
            {
                if (Base_obj.MouseUp.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseUp;
                }
                else if (Base_obj.MouseUp.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseUp;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseUp);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseUp = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseUp";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseUp = value;
                    Base_obj.MouseUp = "osf.ClDictionaryEntry" + "MouseUp";
                }
                else
                {
                    Base_obj.MouseUp = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПеремещении", "Move")]
        public IValue Move
        {
            get
            {
                if (Base_obj.Move.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Move;
                }
                else if (Base_obj.Move.Contains("osf.ClDictionaryEntry"))
                {
                    return _Move;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Move);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Move = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Move = "ScriptEngine.HostedScript.Library.DelegateAction" + "Move";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Move = value;
                    Base_obj.Move = "osf.ClDictionaryEntry" + "Move";
                }
                else
                {
                    Base_obj.Move = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public IValue MouseMove
        {
            get
            {
                if (Base_obj.MouseMove.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseMove;
                }
                else if (Base_obj.MouseMove.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseMove;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseMove);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseMove = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseMove = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseMove";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseMove = value;
                    Base_obj.MouseMove = "osf.ClDictionaryEntry" + "MouseMove";
                }
                else
                {
                    Base_obj.MouseMove = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПерерисовке", "Paint")]
        public IValue Paint
        {
            get
            {
                if (Base_obj.Paint.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Paint;
                }
                else if (Base_obj.Paint.Contains("osf.ClDictionaryEntry"))
                {
                    return _Paint;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Paint);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Paint = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Paint = "ScriptEngine.HostedScript.Library.DelegateAction" + "Paint";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Paint = value;
                    Base_obj.Paint = "osf.ClDictionaryEntry" + "Paint";
                }
                else
                {
                    Base_obj.Paint = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПотереФокуса", "LostFocus")]
        public IValue LostFocus
        {
            get
            {
                if (Base_obj.LostFocus.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _LostFocus;
                }
                else if (Base_obj.LostFocus.Contains("osf.ClDictionaryEntry"))
                {
                    return _LostFocus;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.LostFocus);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _LostFocus = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LostFocus = "ScriptEngine.HostedScript.Library.DelegateAction" + "LostFocus";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _LostFocus = value;
                    Base_obj.LostFocus = "osf.ClDictionaryEntry" + "LostFocus";
                }
                else
                {
                    Base_obj.LostFocus = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриУходе", "Leave")]
        public IValue Leave
        {
            get
            {
                if (Base_obj.Leave.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Leave;
                }
                else if (Base_obj.Leave.Contains("osf.ClDictionaryEntry"))
                {
                    return _Leave;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Leave);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Leave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Leave = "ScriptEngine.HostedScript.Library.DelegateAction" + "Leave";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Leave = value;
                    Base_obj.Leave = "osf.ClDictionaryEntry" + "Leave";
                }
                else
                {
                    Base_obj.Leave = value.AsString();
                }
            }
        }
        
        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
            set { Base_obj.Size = value.Base_obj; }
        }

        [ContextProperty("РазмерИзменен", "SizeChanged")]
        public IValue SizeChanged
        {
            get
            {
                if (Base_obj.SizeChanged.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _SizeChanged;
                }
                else if (Base_obj.SizeChanged.Contains("osf.ClDictionaryEntry"))
                {
                    return _SizeChanged;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.SizeChanged);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _SizeChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.SizeChanged = "ScriptEngine.HostedScript.Library.DelegateAction" + "SizeChanged";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _SizeChanged = value;
                    Base_obj.SizeChanged = "osf.ClDictionaryEntry" + "SizeChanged";
                }
                else
                {
                    Base_obj.SizeChanged = value.AsString();
                }
            }
        }
        
        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return Convert.ToInt32(Base_obj.FontSize); }
            set { Base_obj.FontSize = value; }
        }
        
        [ContextProperty("Раскрыт", "DroppedDown")]
        public bool DroppedDown
        {
            get { return Base_obj.DroppedDown; }
            set { Base_obj.DroppedDown = value; }
        }

        [ContextProperty("РежимРисования", "DrawMode")]
        public int DrawMode
        {
            get { return (int)Base_obj.DrawMode; }
            set { Base_obj.DrawMode = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("СтильВыпадающегоСписка", "DropDownStyle")]
        public int DropDownStyle
        {
            get { return (int)Base_obj.DropDownStyle; }
            set { Base_obj.DropDownStyle = value; }
        }

        [ContextProperty("Стыковка", "Dock")]
        public int Dock
        {
            get { return (int)Base_obj.Dock; }
            set { Base_obj.Dock = value; }
        }

        [ContextProperty("Сфокусирован", "Focused")]
        public bool Focused
        {
            get { return Base_obj.Focused; }
        }

        [ContextProperty("ТабФокус", "TabStop")]
        public bool TabStop
        {
            get { return Base_obj.TabStop; }
            set { Base_obj.TabStop = value; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ТекстИзменен", "TextChanged")]
        public IValue TextChanged
        {
            get
            {
                if (Base_obj.TextChanged.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _TextChanged;
                }
                else if (Base_obj.TextChanged.Contains("osf.ClDictionaryEntry"))
                {
                    return _TextChanged;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.TextChanged);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _TextChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.TextChanged = "ScriptEngine.HostedScript.Library.DelegateAction" + "TextChanged";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _TextChanged = value;
                    Base_obj.TextChanged = "osf.ClDictionaryEntry" + "TextChanged";
                }
                else
                {
                    Base_obj.TextChanged = value.AsString();
                }
            }
        }
        
        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("Фокусируемый", "CanFocus")]
        public bool CanFocus
        {
            get { return Base_obj.CanFocus; }
        }

        [ContextProperty("ФоновоеИзображение", "BackgroundImage")]
        public ClBitmap BackgroundImage
        {
            get { return new ClBitmap(Base_obj.BackgroundImage); }
            set { Base_obj.BackgroundImage = value.Base_obj; }
        }

        [ContextProperty("ЦветФона", "BackColor")]
        public ClColor BackColor
        {
            get { return backColor; }
            set 
            {
                backColor = value;
                Base_obj.BackColor = value.Base_obj;
            }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

        [ContextProperty("ШиринаВыпадающегоСписка", "DropDownWidth")]
        public int DropDownWidth
        {
            get { return Base_obj.DropDownWidth; }
            set { Base_obj.DropDownWidth = value; }
        }

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get { return (ClFont)OneScriptForms.RevertObj(Base_obj.Font); }
            set 
            {
                Base_obj.Font = value.Base_obj; 
                Base_obj.Font.dll_obj = value;
            }
        }

        [ContextProperty("ЭлементВерхнегоУровня", "TopLevelControl")]
        public IValue TopLevelControl
        {
            get { return OneScriptForms.RevertObj(Base_obj.TopLevelControl); }
        }
        
        [ContextProperty("ЭлементДобавлен", "ControlAdded")]
        public IValue ControlAdded
        {
            get
            {
                if (Base_obj.ControlAdded.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _ControlAdded;
                }
                else if (Base_obj.ControlAdded.Contains("osf.ClDictionaryEntry"))
                {
                    return _ControlAdded;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.ControlAdded);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _ControlAdded = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ControlAdded = "ScriptEngine.HostedScript.Library.DelegateAction" + "ControlAdded";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _ControlAdded = value;
                    Base_obj.ControlAdded = "osf.ClDictionaryEntry" + "ControlAdded";
                }
                else
                {
                    Base_obj.ControlAdded = value.AsString();
                }
            }
        }
        
        [ContextProperty("ЭлементУдален", "ControlRemoved")]
        public IValue ControlRemoved
        {
            get
            {
                if (Base_obj.ControlRemoved.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _ControlRemoved;
                }
                else if (Base_obj.ControlRemoved.Contains("osf.ClDictionaryEntry"))
                {
                    return _ControlRemoved;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.ControlRemoved);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _ControlRemoved = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ControlRemoved = "ScriptEngine.HostedScript.Library.DelegateAction" + "ControlRemoved";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _ControlRemoved = value;
                    Base_obj.ControlRemoved = "osf.ClDictionaryEntry" + "ControlRemoved";
                }
                else
                {
                    Base_obj.ControlRemoved = value.AsString();
                }
            }
        }
        
        [ContextProperty("Элементы", "Items")]
        public ClComboBoxObjectCollection Items
        {
            get
            {
                items.m_obj = this;
                items.heightItems = items.m_obj.Base_obj.HeightItems;
                return items;
            }
        }

        [ContextProperty("ЭлементыУправления", "Controls")]
        public ClControlCollection Controls
        {
            get { return controls; }
        }

        [ContextProperty("Якорь", "Anchor")]
        public int Anchor
        {
            get { return (int)Base_obj.Anchor; }
            set { Base_obj.Anchor = value; }
        }

        //Методы============================================================

        [ContextMethod("Актуализировать", "Refresh")]
        public void Refresh()
        {
            Base_obj.Refresh();
        }
					
        [ContextMethod("Аннулировать", "Invalidate")]
        public void Invalidate()
        {
            Base_obj.Invalidate();
        }
					
        [ContextMethod("ВозобновитьРазмещение", "ResumeLayout")]
        public void ResumeLayout(bool p1 = false)
        {
            Base_obj.ResumeLayout(p1);
        }

        [ContextMethod("ВосстановитьФоновоеИзображение", "ResetBackgroundImage")]
        public void ResetBackgroundImage()
        {
            Base_obj.ResetBackgroundImage();
        }
					
        [ContextMethod("Выбрать", "Select")]
        public void Select()
        {
            Base_obj.Select();
        }
					
        [ContextMethod("ВыполнитьРазмещение", "PerformLayout")]
        public void PerformLayout()
        {
            Base_obj.PerformLayout();
        }
					
        [ContextMethod("Выше", "PlaceTop")]
        public void PlaceTop(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top - Base_obj.Height - p2);
        }
        
        [ContextMethod("ДочернийПоКоординатам", "GetChildAtPoint")]
        public IValue GetChildAtPoint(ClPoint p1)
        {
            return ((dynamic)Base_obj.GetChildAtPoint(p1.Base_obj)).dll_obj;
        }
        
        [ContextMethod("ЗавершитьОбновление", "EndUpdate")]
        public void EndUpdate()
        {
            Base_obj.EndUpdate();
        }
					
        [ContextMethod("Левее", "PlaceLeft")]
        public void PlaceLeft(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left - Base_obj.Width - p2, p3.Top);
        }
        
        [ContextMethod("НаЗаднийПлан", "SendToBack")]
        public void SendToBack()
        {
            Base_obj.SendToBack();
        }
					
        [ContextMethod("НайтиФорму", "FindForm")]
        public ClForm FindForm()
        {
            if (Base_obj.FindForm() != null)
            {
                return Base_obj.FindForm().dll_obj;
            }
            return null;
        }
        
        [ContextMethod("НайтиЭлемент", "FindControl")]
        public IValue FindControl(string p1)
        {
            return OneScriptForms.RevertObj(Base_obj.FindControl(p1));
        }
        
        [ContextMethod("НаПереднийПлан", "BringToFront")]
        public void BringToFront()
        {
            Base_obj.BringToFront();
        }
					
        [ContextMethod("НачатьОбновление", "BeginUpdate")]
        public void BeginUpdate()
        {
            Base_obj.BeginUpdate();
        }
					
        [ContextMethod("Ниже", "PlaceBottom")]
        public void PlaceBottom(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top + p3.Height + p2);
        }
        
        [ContextMethod("Обновить", "Update")]
        public void Update()
        {
            Base_obj.Update();
        }
					
        [ContextMethod("ОбновитьСтили", "UpdateStyles")]
        public void UpdateStyles()
        {
            Base_obj.UpdateStyles();
        }
					
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
					
        [ContextMethod("Показать", "Show")]
        public void Show()
        {
            Base_obj.Show();
        }
					
        [ContextMethod("ПолучитьСтиль", "GetStyle")]
        public bool GetStyle(int p1)
        {
            return Base_obj.GetStyle((System.Windows.Forms.ControlStyles)p1);
        }

        [ContextMethod("Правее", "PlaceRight")]
        public void PlaceRight(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Right + p2, p3.Top);
        }
        
        [ContextMethod("ПриостановитьРазмещение", "SuspendLayout")]
        public void SuspendLayout()
        {
            Base_obj.SuspendLayout();
        }
					
        [ContextMethod("Скрыть", "Hide")]
        public void Hide()
        {
            Base_obj.Hide();
        }
					
        [ContextMethod("СледующийЭлемент", "GetNextControl")]
        public IValue GetNextControl(IValue p1, bool p2)
        {
            return Base_obj.GetNextControl(((dynamic)p1).Base_obj, p2).dll_obj;
        }
        
        [ContextMethod("СоздатьГрафику", "CreateGraphics")]
        public ClGraphics CreateGraphics()
        {
            return new ClGraphics(Base_obj.CreateGraphics());
        }
        
        [ContextMethod("СоздатьЭлемент", "CreateControl")]
        public void CreateControl()
        {
            Base_obj.CreateControl();
        }
					
        [ContextMethod("ТочкаНаКлиенте", "PointToClient")]
        public ClPoint PointToClient(ClPoint p1)
        {
            return new ClPoint(Base_obj.PointToClient(p1.Base_obj));
        }

        [ContextMethod("ТочкаНаЭкране", "PointToScreen")]
        public ClPoint PointToScreen(ClPoint p1)
        {
            return new ClPoint(Base_obj.PointToScreen(p1.Base_obj));
        }

        [ContextMethod("УстановитьГраницы", "SetBounds")]
        public void SetBounds(int p1, int p2, int p3, int p4)
        {
            Base_obj.SetBounds(p1, p2, p3, p4);
        }

        [ContextMethod("УстановитьСтиль", "SetStyle")]
        public void SetStyle(int p1, bool p2)
        {
            Base_obj.SetStyle((System.Windows.Forms.ControlStyles)p1, p2);
        }

        [ContextMethod("Фокус", "Focus")]
        public void Focus()
        {
            Base_obj.Focus();
        }
					
        [ContextMethod("Центр", "Center")]
        public void Center()
        {
            Base_obj.Center();
        }
					
        [ContextMethod("ЭлементУправления", "Control")]
        public IValue Control(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.getControl(p1));
        }
        
        [ContextMethod("Элементы", "Items")]
        public ClListItem Items2(int p1)
        {
            osf.ListItem ListItem1 = new osf.ListItem();
            if (Base_obj.Items[p1].GetType().ToString() == "System.Data.DataRowView")
            {
                osf.DataRowView DataRowView1 = new osf.DataRowView((System.Data.DataRowView)Base_obj.Items[p1]);
                ListItem1.Text = DataRowView1.get_Item(Base_obj.DisplayMember).ToString();
                ListItem1.Value = DataRowView1.get_Item(Base_obj.ValueMember);
            }
            else if (Base_obj.Items[p1].GetType().ToString() == "osf.ListItem")
            {
                ListItem1 = (osf.ListItem)Base_obj.Items[p1];
            }
            else
            {
                ListItem1.Text = Base_obj.Items[p1].ToString();
                ListItem1.Value = Base_obj.Items[p1];
                try
                {
                    ListItem1.ForeColor = ((dynamic)Base_obj.Items[p1]).ForeColor.Base_obj;
                }
                catch
                {
                }
            }
            return new ClListItem(ListItem1);
        }

        [ContextMethod("ЭлементыУправления", "Controls")]
        public IValue Controls2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
        }
    }
}
