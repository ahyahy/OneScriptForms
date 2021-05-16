using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace osf
{
    public class ListBoxEx : System.Windows.Forms.ListBox
    {
        public osf.ListBox M_Object;
    }

    public class ListBox : ListControl
    {
        public ClListBox dll_obj;
        public ListBoxEx M_ListBox;
        public osf.Color M_SelectedBackColor;
        public osf.Color M_SelectedForeColor;
        public string M_SelectedIndexChanged;

        public ListBox()
        {
            M_ListBox = new ListBoxEx();
            M_ListBox.M_Object = this;
            base.M_ListControl = M_ListBox;
            M_ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            M_ListBox.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
            M_ListBox.DrawItem += M_ListBox_DrawItem;
            M_ListBox.MeasureItem += M_ListBox_MeasureItem;
            M_ListBox.FontChanged += M_ListBox_FontChanged;
            M_ListBox.ItemHeight = FontHeight;
            M_SelectedForeColor = new Color(SystemColors.HighlightText);
            M_SelectedBackColor = new Color(SystemColors.Highlight);
            M_SelectedIndexChanged = "";
        }

        public ListBox(System.Windows.Forms.ListBox p1)
        {
            M_ListBox = (ListBoxEx)p1;
            M_ListBox.M_Object = this;
            base.M_ListControl = M_ListBox;
            M_ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            M_ListBox.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
            M_ListBox.DrawItem += M_ListBox_DrawItem;
            M_ListBox.MeasureItem += M_ListBox_MeasureItem;
            M_ListBox.FontChanged += M_ListBox_FontChanged;
            M_ListBox.ItemHeight = FontHeight;
            M_SelectedForeColor = new Color(SystemColors.HighlightText);
            M_SelectedBackColor = new Color(SystemColors.Highlight);
            M_SelectedIndexChanged = "";
        }

        public ListBox(osf.ListBox p1)
        {
            M_ListBox = p1.M_ListBox;
            M_ListBox.M_Object = this;
            base.M_ListControl = M_ListBox;
            M_ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            M_ListBox.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
            M_ListBox.DrawItem += M_ListBox_DrawItem;
            M_ListBox.MeasureItem += M_ListBox_MeasureItem;
            M_ListBox.FontChanged += M_ListBox_FontChanged;
            M_ListBox.ItemHeight = FontHeight;
            M_SelectedForeColor = new Color(SystemColors.HighlightText);
            M_SelectedBackColor = new Color(SystemColors.Highlight);
            M_SelectedIndexChanged = "";
        }

        //Свойства============================================================

        public int BorderStyle
        {
            get { return (int)M_ListBox.BorderStyle; }
            set { M_ListBox.BorderStyle = (System.Windows.Forms.BorderStyle)value; }
        }

        public int ColumnWidth
        {
            get { return M_ListBox.ColumnWidth; }
            set { M_ListBox.ColumnWidth = value; }
        }

        public int HorizontalExtent
        {
            get { return M_ListBox.HorizontalExtent; }
            set { M_ListBox.HorizontalExtent = value; }
        }

        public bool HorizontalScrollbar
        {
            get { return M_ListBox.HorizontalScrollbar; }
            set
            {
                System.Drawing.Graphics g = M_ListBox.CreateGraphics();
                int hzSize = (int)g.MeasureString(M_ListBox.Items[M_ListBox.Items.Count - 1].ToString(), M_ListBox.Font).Width;
                M_ListBox.HorizontalExtent = hzSize + 10;
                M_ListBox.HorizontalScrollbar = value;
            }
        }

        public bool IntegralHeight
        {
            get { return M_ListBox.IntegralHeight; }
            set { M_ListBox.IntegralHeight = value; }
        }

        public int ItemHeight
        {
            get { return M_ListBox.ItemHeight; }
            set { M_ListBox.ItemHeight = value; }
        }

        public osf.ListBoxObjectCollection Items
        {
            get { return new ListBoxObjectCollection(M_ListBox.Items); }
        }

        public bool MultiColumn
        {
            get { return M_ListBox.MultiColumn; }
            set { M_ListBox.MultiColumn = value; }
        }

        public bool ScrollAlwaysVisible
        {
            get { return M_ListBox.ScrollAlwaysVisible; }
            set { M_ListBox.ScrollAlwaysVisible = value; }
        }

        public int SelectedIndex
        {
            get { return M_ListBox.SelectedIndex; }
            set { M_ListBox.SelectedIndex = value; }
        }

        public string SelectedIndexChanged
        {
            get { return M_SelectedIndexChanged; }
            set { M_SelectedIndexChanged = value; }
        }

        public osf.ListBoxSelectedIndexCollection SelectedIndices
        {
            get { return new ListBoxSelectedIndexCollection(M_ListBox.SelectedIndices); }
        }

        public object SelectedItem
        {
            get { return M_ListBox.SelectedItem; }
            set
            {
                M_ListBox.SelectedItem = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.ListBoxSelectedObjectCollection SelectedItems
        {
            get { return new ListBoxSelectedObjectCollection(M_ListBox.SelectedItems); }
        }

        public int SelectionMode
        {
            get { return (int)M_ListBox.SelectionMode; }
            set { M_ListBox.SelectionMode = (System.Windows.Forms.SelectionMode)value; }
        }

        public bool Sorted
        {
            get { return M_ListBox.Sorted; }
            set { M_ListBox.Sorted = value; }
        }

        public int TopIndex
        {
            get { return M_ListBox.TopIndex; }
            set { M_ListBox.TopIndex = value; }
        }

        public bool UseTabStops
        {
            get { return M_ListBox.UseTabStops; }
            set { M_ListBox.UseTabStops = value; }
        }

        //Методы============================================================

        public bool GetSelected(int index)
        {
            return M_ListBox.GetSelected(index);
        }

        public void M_ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            dynamic item = M_ListBox.Items[e.Index];
            System.Type type = item.GetType();
            System.Drawing.Color color1 = M_ListBox.ForeColor;
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
            string s = item.ToString();
            System.Data.DataRowView drv;
            try
            {
                drv = (System.Data.DataRowView)item;
            }
            catch
            {
                drv = null;
            }
            if (drv != null)
            {
                s = drv[M_ListBox.DisplayMember].ToString();
            }
            else
            {
                PropertyInfo property1 = type.GetProperty(M_ListBox.DisplayMember);
                if (property1 != null)
                {
                    s = Convert.ToString(property1.GetValue(Items[e.Index], (object[])null));
                }
            }
            e.Graphics.DrawString(s, M_ListBox.Font, (System.Drawing.Brush)new System.Drawing.SolidBrush(color1), (float)e.Bounds.X, (float)e.Bounds.Y);
        }

        public void M_ListBox_FontChanged(object sender, System.EventArgs e)
        {
            M_ListBox.ItemHeight = ((osf.Control)M_ListBox.M_Object).FontHeight;
        }

        public void M_ListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ((osf.Control)M_ListBox.M_Object).FontHeight;
        }

        private void M_ListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (M_SelectedIndexChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = M_SelectedIndexChanged;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        public void SetSelected(int index, bool value)
        {
            M_ListBox.SetSelected(index, value);
        }

    }

    [ContextClass ("КлПолеСписка", "ClListBox")]
    public class ClListBox : AutoContext<ClListBox>
    {
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClColor foreColor;
        private ClListBoxObjectCollection items;
        private ClListBoxSelectedIndexCollection selectedIndices;
        private ClCollection tag = new ClCollection();

        public ClListBox()
        {
            ListBox ListBox1 = new ListBox();
            ListBox1.dll_obj = this;
            Base_obj = ListBox1;
            bounds = new ClRectangle(Base_obj.Bounds);
            selectedIndices = new ClListBoxSelectedIndexCollection(Base_obj.SelectedIndices);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            items = new ClListBoxObjectCollection(Base_obj.Items);
            items.M_obj = this;
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClListBox(ListBox p1)
        {
            ListBox ListBox1 = p1;
            ListBox1.dll_obj = this;
            Base_obj = ListBox1;
            bounds = new ClRectangle(Base_obj.Bounds);
            selectedIndices = new ClListBoxSelectedIndexCollection(Base_obj.SelectedIndices);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            items = new ClListBoxObjectCollection(Base_obj.Items);
            items.M_obj = this;
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public ListBox Base_obj;

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

        [ContextProperty("ВыбранныеЭлементы", "SelectedItems")]
        public ClListBoxSelectedObjectCollection SelectedItems
        {
            get { return new ClListBoxSelectedObjectCollection(Base_obj.SelectedItems, this); }
        }
        
        [ContextProperty("ВыбранныйЭлемент", "SelectedItem")]
        public IValue SelectedItem
        {
            get
            {
                if (Base_obj.DataSource != null)
                {
                    if (Base_obj.DataSource is osf.ArrayList)
                    {
                        return (ClListItem)Base_obj.SelectedItem;
                    }
                    if (Base_obj.DataSource is osf.DataTable || Base_obj.DataSource is osf.DataView)
                    {
                        DataRowView DataRowView1 = new DataRowView((System.Data.DataRowView)Base_obj.SelectedItem);
                        ListItem ListItem1 = new ListItem();
                        ListItem1.Text = DataRowView1.get_Item(Base_obj.DisplayMember).ToString();
                        ListItem1.Value = DataRowView1.get_Item(Base_obj.ValueMember);
                        return new ClListItem(ListItem1);
                    }
                }
                return OneScriptForms.RevertObj(Base_obj.SelectedItem);
            }
            set
            {
                if (Base_obj.DataSource == null)
                {
                    Base_obj.SelectedItem = ((dynamic)value).Base_obj;
                }
            }
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

        [ContextProperty("ГоризонтальнаяМера", "HorizontalExtent")]
        public int HorizontalExtent
        {
            get { return Base_obj.HorizontalExtent; }
            set { Base_obj.HorizontalExtent = value; }
        }

        [ContextProperty("ГоризонтальнаяПрокрутка", "HorizontalScrollbar")]
        public bool HorizontalScrollbar
        {
            get { return Base_obj.HorizontalScrollbar; }
            set { Base_obj.HorizontalScrollbar = value; }
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

        [ContextProperty("ДвойноеНажатие", "DoubleClick")]
        public string DoubleClick
        {
            get { return Base_obj.DoubleClick; }
            set { Base_obj.DoubleClick = value; }
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

        [ContextProperty("ИндексВерхнего", "TopIndex")]
        public int TopIndex
        {
            get { return Base_obj.TopIndex; }
            set { Base_obj.TopIndex = value; }
        }

        [ContextProperty("ИндексВыбранного", "SelectedIndex")]
        public int SelectedIndex
        {
            get { return Base_obj.SelectedIndex; }
            set { Base_obj.SelectedIndex = value; }
        }

        [ContextProperty("ИндексВыбранногоИзменен", "SelectedIndexChanged")]
        public string SelectedIndexChanged
        {
            get { return Base_obj.SelectedIndexChanged; }
            set { Base_obj.SelectedIndexChanged = value; }
        }

        [ContextProperty("ИндексыВыбранных", "SelectedIndices")]
        public ClListBoxSelectedIndexCollection SelectedIndices
        {
            get { return selectedIndices; }
        }

        [ContextProperty("ИспользоватьКурсорОжидания", "UseWaitCursor")]
        public bool UseWaitCursor
        {
            get { return Base_obj.UseWaitCursor; }
            set { Base_obj.UseWaitCursor = value; }
        }

        [ContextProperty("ИспользоватьТабулятор", "UseTabStops")]
        public bool UseTabStops
        {
            get { return Base_obj.UseTabStops; }
            set { Base_obj.UseTabStops = value; }
        }

        [ContextProperty("ИсточникДанных", "DataSource")]
        public IValue DataSource
        {
            get { return OneScriptForms.RevertObj(Base_obj.DataSource); }
            set
            {
                try
                {
                    Base_obj.DataSource = ((dynamic)value).Base_obj;
                }
                catch
                {
                    Base_obj.DataSource = null;
                }
            }
        }

        [ContextProperty("КлавишаВверх", "KeyUp")]
        public string KeyUp
        {
            get { return Base_obj.KeyUp; }
            set { Base_obj.KeyUp = value; }
        }

        [ContextProperty("КлавишаВниз", "KeyDown")]
        public string KeyDown
        {
            get { return Base_obj.KeyDown; }
            set { Base_obj.KeyDown = value; }
        }

        [ContextProperty("КлавишаНажата", "KeyPress")]
        public string KeyPress
        {
            get { return Base_obj.KeyPress; }
            set { Base_obj.KeyPress = value; }
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

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("Многоколоночное", "MultiColumn")]
        public bool MultiColumn
        {
            get { return Base_obj.MultiColumn; }
            set { Base_obj.MultiColumn = value; }
        }

        [ContextProperty("МышьНадЭлементом", "MouseEnter")]
        public string MouseEnter
        {
            get { return Base_obj.MouseEnter; }
            set { Base_obj.MouseEnter = value; }
        }

        [ContextProperty("МышьПокинулаЭлемент", "MouseLeave")]
        public string MouseLeave
        {
            get { return Base_obj.MouseLeave; }
            set { Base_obj.MouseLeave = value; }
        }

        [ContextProperty("Нажатие", "Click")]
        public string Click
        {
            get { return Base_obj.Click; }
            set { Base_obj.Click = value; }
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
        public string LocationChanged
        {
            get { return Base_obj.LocationChanged; }
            set { Base_obj.LocationChanged = value; }
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

        [ContextProperty("ПриВходе", "Enter")]
        public string Enter
        {
            get { return Base_obj.Enter; }
            set { Base_obj.Enter = value; }
        }

        [ContextProperty("ПриЗадержкеМыши", "MouseHover")]
        public string MouseHover
        {
            get { return Base_obj.MouseHover; }
            set { Base_obj.MouseHover = value; }
        }

        [ContextProperty("ПриНажатииКнопкиМыши", "MouseDown")]
        public string MouseDown
        {
            get { return Base_obj.MouseDown; }
            set { Base_obj.MouseDown = value; }
        }

        [ContextProperty("ПриОтпусканииМыши", "MouseUp")]
        public string MouseUp
        {
            get { return Base_obj.MouseUp; }
            set { Base_obj.MouseUp = value; }
        }

        [ContextProperty("ПриПеремещении", "Move")]
        public string Move
        {
            get { return Base_obj.Move; }
            set { Base_obj.Move = value; }
        }

        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public string MouseMove
        {
            get { return Base_obj.MouseMove; }
            set { Base_obj.MouseMove = value; }
        }

        [ContextProperty("ПриПерерисовке", "Paint")]
        public string Paint
        {
            get { return Base_obj.Paint; }
            set { Base_obj.Paint = value; }
        }

        [ContextProperty("ПриПотереФокуса", "LostFocus")]
        public string LostFocus
        {
            get { return Base_obj.LostFocus; }
            set { Base_obj.LostFocus = value; }
        }

        [ContextProperty("ПриУходе", "Leave")]
        public string Leave
        {
            get { return Base_obj.Leave; }
            set { Base_obj.Leave = value; }
        }

        [ContextProperty("ПрокруткаВсегдаОтображается", "ScrollAlwaysVisible")]
        public bool ScrollAlwaysVisible
        {
            get { return Base_obj.ScrollAlwaysVisible; }
            set { Base_obj.ScrollAlwaysVisible = value; }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
            set { Base_obj.Size = value.Base_obj; }
        }

        [ContextProperty("РазмерИзменен", "SizeChanged")]
        public string SizeChanged
        {
            get { return Base_obj.SizeChanged; }
            set { Base_obj.SizeChanged = value; }
        }

        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return Convert.ToInt32(Base_obj.FontSize); }
            set { Base_obj.FontSize = value; }
        }
        
        [ContextProperty("РежимВыбора", "SelectionMode")]
        public int SelectionMode
        {
            get { return (int)Base_obj.SelectionMode; }
            set { Base_obj.SelectionMode = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("СтильГраницы", "BorderStyle")]
        public int BorderStyle
        {
            get { return (int)Base_obj.BorderStyle; }
            set { Base_obj.BorderStyle = value; }
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
        public string TextChanged
        {
            get { return Base_obj.TextChanged; }
            set { Base_obj.TextChanged = value; }
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

        [ContextProperty("ШиринаКолонки", "ColumnWidth")]
        public int ColumnWidth
        {
            get { return Base_obj.ColumnWidth; }
            set { Base_obj.ColumnWidth = value; }
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
        public string ControlAdded
        {
            get { return Base_obj.ControlAdded; }
            set { Base_obj.ControlAdded = value; }
        }

        [ContextProperty("ЭлементУдален", "ControlRemoved")]
        public string ControlRemoved
        {
            get { return Base_obj.ControlRemoved; }
            set { Base_obj.ControlRemoved = value; }
        }

        [ContextProperty("Элементы", "Items")]
        public ClListBoxObjectCollection Items
        {
            get { return items; }
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
					
        [ContextMethod("Выбран", "GetSelected")]
        public bool GetSelected(int p1)
        {
            return Base_obj.GetSelected(p1);
        }

        [ContextMethod("ВыбранныеЭлементы", "SelectedItems")]
        public IValue SelectedItems2(int p1)
        {
            osf.ListItem ListItem1 = new osf.ListItem();
            if (Base_obj.SelectedItems[p1].GetType().ToString() == "System.Data.DataRowView")
            {
                osf.DataRowView DataRowView1 = new osf.DataRowView((System.Data.DataRowView)Base_obj.SelectedItems[p1]);
                ListItem1.Text = DataRowView1.get_Item(Base_obj.DisplayMember).ToString();
                ListItem1.Value = DataRowView1.get_Item(Base_obj.ValueMember);
            }
            else if (Base_obj.SelectedItems[p1].GetType().ToString() == "osf.ListItem")
            {
                ListItem1 = (osf.ListItem)Base_obj.SelectedItems[p1];
            }
            else
            {
                ListItem1.Text = Base_obj.SelectedItems[p1].ToString();
                ListItem1.Value = Base_obj.SelectedItems[p1];
                try
                {
                    ListItem1.ForeColor = ((dynamic)Base_obj.SelectedItems[p1]).ForeColor.Base_obj;
                }
                catch
                {
                }
            }
            return new ClListItem(ListItem1);
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
					
        [ContextMethod("ИндексыВыбранных", "SelectedIndices")]
        public int SelectedIndices2(int p1)
        {
            return Base_obj.SelectedIndices[p1];
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
					
        [ContextMethod("НаПереднийПлан", "BringToFront")]
        public void BringToFront()
        {
            Base_obj.BringToFront();
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

        [ContextMethod("УстановитьВыбор", "SetSelected")]
        public void SetSelected(int p1, bool p2)
        {
            Base_obj.SetSelected(p1, p2);
        }

        [ContextMethod("УстановитьГраницы", "SetBounds")]
        public void SetBounds(int p1, int p2, int p3, int p4)
        {
            Base_obj.SetBounds(p1, p2, p3, p4);
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
