﻿using System;
using System.Collections;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class ListViewEx : System.Windows.Forms.ListView
    {
        public osf.ListView M_Object;
    }

    public class ListView : Control
    {
        public string AfterLabelEdit;
        public bool AllowSorting;
        public string BeforeLabelEdit;
        public string ColumnClick;
        public ClListView dll_obj;
        public string ItemActivate;
        public string ItemCheck;
        public ListViewEx M_ListView;
        public string SelectedIndexChanged;
        public osf.ColumnHeader SortedColumn;
        public int SortOrder;

        public ListView()
        {
            M_ListView = new ListViewEx();
            M_ListView.M_Object = this;
            base.M_Control = M_ListView;
            M_ListView.AfterLabelEdit += M_ListView_AfterLabelEdit;
            M_ListView.ColumnClick += M_ListView_ColumnClick;
            M_ListView.SelectedIndexChanged += M_ListView_SelectedIndexChanged;
            M_ListView.ItemCheck += M_ListView_ItemCheck;
            M_ListView.ItemActivate += M_ListView_ItemActivate;
            M_ListView.BeforeLabelEdit += M_ListView_BeforeLabelEdit;
            SortedColumn = null;
            AllowSorting = true;
            Sorting = (int)System.Windows.Forms.SortOrder.None;
            AfterLabelEdit = "";
            BeforeLabelEdit = "";
            SelectedIndexChanged = "";
            ColumnClick = "";
            ItemCheck = "";
            ItemActivate = "";
        }

        public ListView(osf.ListView p1)
        {
            M_ListView = p1.M_ListView;
            M_ListView.M_Object = this;
            base.M_Control = M_ListView;
            M_ListView.AfterLabelEdit += M_ListView_AfterLabelEdit;
            M_ListView.ColumnClick += M_ListView_ColumnClick;
            M_ListView.SelectedIndexChanged += M_ListView_SelectedIndexChanged;
            M_ListView.ItemCheck += M_ListView_ItemCheck;
            M_ListView.ItemActivate += M_ListView_ItemActivate;
            M_ListView.BeforeLabelEdit += M_ListView_BeforeLabelEdit;
            SortedColumn = null;
            AllowSorting = true;
            Sorting = (int)System.Windows.Forms.SortOrder.None;
            AfterLabelEdit = "";
            BeforeLabelEdit = "";
            SelectedIndexChanged = "";
            ColumnClick = "";
            ItemCheck = "";
            ItemActivate = "";
        }

        public ListView(System.Windows.Forms.ListView p1)
        {
            M_ListView = (ListViewEx)p1;
            M_ListView.M_Object = this;
            base.M_Control = M_ListView;
            M_ListView.AfterLabelEdit += M_ListView_AfterLabelEdit;
            M_ListView.ColumnClick += M_ListView_ColumnClick;
            M_ListView.SelectedIndexChanged += M_ListView_SelectedIndexChanged;
            M_ListView.ItemCheck += M_ListView_ItemCheck;
            M_ListView.ItemActivate += M_ListView_ItemActivate;
            M_ListView.BeforeLabelEdit += M_ListView_BeforeLabelEdit;
            SortedColumn = null;
            AllowSorting = true;
            Sorting = (int)System.Windows.Forms.SortOrder.None;
            AfterLabelEdit = "";
            BeforeLabelEdit = "";
            SelectedIndexChanged = "";
            ColumnClick = "";
            ItemCheck = "";
            ItemActivate = "";
        }

        public int Activation
        {
            get { return (int)M_ListView.Activation; }
            set { M_ListView.Activation = (System.Windows.Forms.ItemActivation)value; }
        }

        public int Alignment
        {
            get { return (int)M_ListView.Alignment; }
            set { M_ListView.Alignment = (System.Windows.Forms.ListViewAlignment)value; }
        }

        public bool AllowColumnReorder
        {
            get { return M_ListView.AllowColumnReorder; }
            set { M_ListView.AllowColumnReorder = value; }
        }

        public bool AutoArrange
        {
            get { return M_ListView.AutoArrange; }
            set { M_ListView.AutoArrange = value; }
        }

        public int BorderStyle
        {
            get { return (int)M_ListView.BorderStyle; }
            set { M_ListView.BorderStyle = (System.Windows.Forms.BorderStyle)value; }
        }

        public bool CheckBoxes
        {
            get { return M_ListView.CheckBoxes; }
            set { M_ListView.CheckBoxes = value; }
        }

        public osf.ListViewCheckedItemCollection CheckedItems
        {
            get { return new ListViewCheckedItemCollection(M_ListView.CheckedItems); }
        }

        public osf.ListViewColumnHeaderCollection Columns
        {
            get { return new ListViewColumnHeaderCollection(M_ListView.Columns); }
        }

        public osf.ListViewItem FocusedItem
        {
            get
            {
                if (M_ListView.FocusedItem != null)
                {
                    return ((ListViewItemEx)M_ListView.FocusedItem).M_Object;
                }
                return null;
            }
        }

        public bool FullRowSelect
        {
            get { return M_ListView.FullRowSelect; }
            set { M_ListView.FullRowSelect = value; }
        }

        public bool GridLines
        {
            get { return M_ListView.GridLines; }
            set { M_ListView.GridLines = value; }
        }

        public int HeaderStyle
        {
            get { return (int)M_ListView.HeaderStyle; }
            set { M_ListView.HeaderStyle = (System.Windows.Forms.ColumnHeaderStyle)value; }
        }

        public bool HideSelection
        {
            get { return M_ListView.HideSelection; }
            set { M_ListView.HideSelection = value; }
        }

        public bool HoverSelection
        {
            get { return M_ListView.HoverSelection; }
            set { M_ListView.HoverSelection = value; }
        }

        public osf.ListViewItemCollection Items
        {
            get { return new ListViewItemCollection(M_ListView.Items); }
        }

        public bool LabelEdit
        {
            get { return M_ListView.LabelEdit; }
            set { M_ListView.LabelEdit = value; }
        }

        public bool LabelWrap
        {
            get { return M_ListView.LabelWrap; }
            set { M_ListView.LabelWrap = value; }
        }

        public osf.ImageList LargeImageList
        {
            get { return new ImageList(M_ListView.LargeImageList); }
            set { M_ListView.LargeImageList = value.M_ImageList; }
        }

        public bool MultiSelect
        {
            get { return M_ListView.MultiSelect; }
            set { M_ListView.MultiSelect = value; }
        }

        public bool Scrollable
        {
            get { return M_ListView.Scrollable; }
            set { M_ListView.Scrollable = value; }
        }

        public object SelectedIndices
        {
            get { return (object)""; }
        }

        public osf.ListViewSelectedItemCollection SelectedItems
        {
            get { return new ListViewSelectedItemCollection(M_ListView.SelectedItems); }
        }

        public osf.ImageList SmallImageList
        {
            get
            {
                ImageList ImageList1 = new ImageList(M_ListView.SmallImageList);
                //System.Windows.Forms.Application.DoEvents();
                return ImageList1;
            }
            set
            {
                M_ListView.SmallImageList = value.M_ImageList;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int Sorting
        {
            get { return (int)M_ListView.Sorting; }
            set { M_ListView.Sorting = (System.Windows.Forms.SortOrder)value; }
        }

        public int View
        {
            get { return (int)M_ListView.View; }
            set { M_ListView.View = (System.Windows.Forms.View)value; }
        }

        public void EnsureVisible(int index)
        {
            M_ListView.EnsureVisible(index);
        }

        public osf.ListViewItem GetItemAt(int x, int y)
        {
            System.Windows.Forms.ListViewItem item = M_ListView.GetItemAt(x, y);
            if (item != null)
            {
                return ((ListViewItemEx)item).M_Object;
            }
            return null;
        }

        public void M_ListView_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            if (AfterLabelEdit.Length > 0)
            {
                LabelEditEventArgs LabelEditEventArgs1 = new LabelEditEventArgs();
                LabelEditEventArgs1.EventString = AfterLabelEdit;
                LabelEditEventArgs1.Sender = this;
                LabelEditEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.AfterLabelEdit);
                LabelEditEventArgs1.CancelEdit = e.CancelEdit;
                LabelEditEventArgs1.Label = e.Label;
                LabelEditEventArgs1.Item = e.Item;
                ClLabelEditEventArgs ClLabelEditEventArgs1 = new ClLabelEditEventArgs(LabelEditEventArgs1);
                OneScriptForms.Event = ClLabelEditEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.AfterLabelEdit);
                e.CancelEdit = LabelEditEventArgs1.CancelEdit;
            }
        }

        public void M_ListView_BeforeLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            if (BeforeLabelEdit.Length > 0)
            {
                LabelEditEventArgs LabelEditEventArgs1 = new LabelEditEventArgs();
                LabelEditEventArgs1.EventString = BeforeLabelEdit;
                LabelEditEventArgs1.Sender = this;
                LabelEditEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.BeforeLabelEdit);
                LabelEditEventArgs1.CancelEdit = e.CancelEdit;
                LabelEditEventArgs1.Item = e.Item;
                LabelEditEventArgs1.Label = e.Label;
                ClLabelEditEventArgs ClLabelEditEventArgs1 = new ClLabelEditEventArgs(LabelEditEventArgs1);
                OneScriptForms.Event = ClLabelEditEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.BeforeLabelEdit);
                e.CancelEdit = LabelEditEventArgs1.CancelEdit;
            }
        }

        private void M_ListView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (ColumnClick.Length > 0)
            {
                ColumnClickEventArgs ColumnClickEventArgs1 = new ColumnClickEventArgs();
                ColumnClickEventArgs1.EventString = ColumnClick;
                ColumnClickEventArgs1.Sender = this;
                ColumnClickEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.ColumnClick);
                ColumnClickEventArgs1.Column = e.Column;
                ClColumnClickEventArgs ClColumnClickEventArgs1 = new ClColumnClickEventArgs(ColumnClickEventArgs1);
                OneScriptForms.Event = ClColumnClickEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.ColumnClick);
            }
            if (!AllowSorting)
            {
                return;
            }
            if (SortedColumn == null)
            {
                SortedColumn = Columns[e.Column];
            }
            else if (SortedColumn.Index != e.Column)
            {
                SortedColumn = Columns[e.Column];
            }
            if (Sorting == (int)System.Windows.Forms.SortOrder.None)
            {
                Sorting = (int)System.Windows.Forms.SortOrder.Ascending;
            }
            else if (Sorting == (int)System.Windows.Forms.SortOrder.Ascending)
            {
                Sorting = (int)System.Windows.Forms.SortOrder.Descending;
            }
            else
            {
                Sorting = (int)System.Windows.Forms.SortOrder.Ascending;
            }
            M_ListView.ListViewItemSorter = new ListViewItemSorter(Sorting, this);
            M_ListView.ListViewItemSorter = null;
        }

        private void M_ListView_ItemActivate(object sender, System.EventArgs e)
        {
            if (ItemActivate.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = ItemActivate;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.ItemActivate);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.ItemActivate);
            }
        }

        public void M_ListView_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            if (ItemCheck.Length > 0)
            {
                ItemCheckEventArgs ItemCheckEventArgs1 = new ItemCheckEventArgs();
                ItemCheckEventArgs1.EventString = ItemCheck;
                ItemCheckEventArgs1.Sender = this;
                ItemCheckEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.ItemCheck);
                ItemCheckEventArgs1.CurrentValue = (int)e.CurrentValue;
                ItemCheckEventArgs1.Index = e.Index;
                ItemCheckEventArgs1.NewValue = (int)e.NewValue;
                ClItemCheckEventArgs ClItemCheckEventArgs1 = new ClItemCheckEventArgs(ItemCheckEventArgs1);
                OneScriptForms.Event = ClItemCheckEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.ItemCheck);
            }
        }

        private void M_ListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (SelectedIndexChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = SelectedIndexChanged;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.SelectedIndexChanged);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.SelectedIndexChanged);
            }
        }

        public void Sort(ColumnHeader column, int order)
        {
            SortedColumn = column;
            SortOrder = order;
            M_ListView.ListViewItemSorter = new ListViewItemSorter(SortOrder, this);
            M_ListView.ListViewItemSorter = (IComparer)null;
            //System.Windows.Forms.Application.DoEvents();
        }

        public override void BeginUpdate()
        {
            M_ListView.BeginUpdate();
            //System.Windows.Forms.Application.DoEvents();
        }

        public override void EndUpdate()
        {
            M_ListView.EndUpdate();
            //System.Windows.Forms.Application.DoEvents();
        }
    }

    public class ListViewItemSorter : IComparer
    {
        private int col;
        public osf.ListView owner;
        private int sortOrder;

        public ListViewItemSorter(int Sorting, osf.ListView p1)
        {
            sortOrder = Sorting;
            owner = p1;
            col = owner.SortedColumn.Index;
        }

        public int Compare(object x, object y)
        {
            ListViewItemEx Item1 = (ListViewItemEx)x;
            ListViewItemEx Item2 = (ListViewItemEx)y;
            int sortType = owner.Columns[col].SortType;
            int num = 0;
            if (sortType == 3)//Boolean
            {
                object Boolean1 = null;
                object Boolean2 = null;
                try
                {
                    Boolean1 = (System.Boolean)Boolean.Parse(Convert.ToString(Item1.SubItems[col].Text));
                }
                catch { }
                try
                {
                    Boolean2 = (System.Boolean)Boolean.Parse(Convert.ToString(Item2.SubItems[col].Text));
                }
                catch { }
                if (Boolean1 == null && Boolean2 == null)
                {
                    num = 0;
                }
                else if (Boolean1 != null && Boolean2 == null)
                {
                    num = 1;
                }
                else if (Boolean1 == null && Boolean2 != null)
                {
                    num = -1;
                }
                else
                {
                    num = ((System.Boolean)Boolean1).CompareTo((System.Boolean)Boolean2);
                }
            }
            if (sortType == 2)//DateTime
            {
                object DateTime1 = null;
                object DateTime2 = null;
                try
                {
                    DateTime1 = (System.DateTime)DateTime.Parse(Convert.ToString(Item1.SubItems[col].Text));
                }
                catch { }
                try
                {
                    DateTime2 = (System.DateTime)DateTime.Parse(Convert.ToString(Item2.SubItems[col].Text));
                }
                catch { }
                if (DateTime1 == null && DateTime2 == null)
                {
                    num = 0;
                }
                else if (DateTime1 != null && DateTime2 == null)
                {
                    num = 1;
                }
                else if (DateTime1 == null && DateTime2 != null)
                {
                    num = -1;
                }
                else
                {
                    num = System.DateTime.Compare((System.DateTime)DateTime1, (System.DateTime)DateTime2);
                }
            }
            else if (sortType == 1)//Number
            {
                object Number1 = null;
                object Number2 = null;
                try
                {
                    Number1 = (System.Decimal)decimal.Parse(Convert.ToString(Item1.SubItems[col].Text));
                }
                catch { }
                try
                {
                    Number2 = (System.Decimal)decimal.Parse(Convert.ToString(Item2.SubItems[col].Text));
                }
                catch { }
                if (Number1 == null && Number2 == null)
                {
                    num = 0;
                }
                else if (Number1 != null && Number2 == null)
                {
                    num = 1;
                }
                else if (Number1 == null && Number2 != null)
                {
                    num = -1;
                }
                else
                {
                    num = System.Decimal.Compare((System.Decimal)Number1, (System.Decimal)Number2);
                }
            }
            else //(sortType == 0)// text
            {
                string str1 = null;
                string str2 = null;
                try
                {
                    str1 = Convert.ToString(Item1.SubItems[col].Text);
                }
                catch { return num; }
                try
                {
                    str2 = Convert.ToString(Item2.SubItems[col].Text);
                }
                catch { return num; }
                if (str1 == null && str2 == null)
                {
                    num = 0;
                }
                else if (str1 != null && str2 == null)
                {
                    num = 1;
                }
                else if (str1 == null && str2 != null)
                {
                    num = -1;
                }
                else
                {
                    num = String.Compare(str1, str2, true);
                }
            }
            if (sortOrder == (int)System.Windows.Forms.SortOrder.Ascending)
            {
                return num;
            }
            if (sortOrder == (int)System.Windows.Forms.SortOrder.Descending)
            {
                return checked(-num);
            }
            return num;
        }
    }

    [ContextClass ("КлСписокЭлементов", "ClListView")]
    public class ClListView : AutoContext<ClListView>
    {
        private IValue _AfterLabelEdit;
        private IValue _BeforeLabelEdit;
        private IValue _Click;
        private IValue _ColumnClick;
        private IValue _ControlAdded;
        private IValue _ControlRemoved;
        private IValue _DoubleClick;
        private IValue _Enter;
        private IValue _ItemActivate;
        private IValue _ItemCheck;
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
        private ClListViewCheckedItemCollection checkedItems;
        private ClRectangle clientRectangle;
        private ClListViewColumnHeaderCollection columns;
        private ClControlCollection controls;
        private ClCursor cursor;
        private ClFont font;
        private ClColor foreColor;
        private ClListViewItemCollection items;
        private ClImageList largeImageList;
        private ClListViewSelectedItemCollection selectedItems;
        private ClImageList smallImageList;
        private ClCollection tag = new ClCollection();

        public ClListView()
        {
            ListView ListView1 = new ListView();
            ListView1.dll_obj = this;
            Base_obj = ListView1;
            selectedItems = new ClListViewSelectedItemCollection(Base_obj.SelectedItems);
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            columns = new ClListViewColumnHeaderCollection(Base_obj.Columns);
            foreColor = new ClColor(Base_obj.ForeColor);
            checkedItems = new ClListViewCheckedItemCollection(Base_obj.CheckedItems);
            backColor = new ClColor(Base_obj.BackColor);
            items = new ClListViewItemCollection(Base_obj.Items);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClListView(ListView p1)
        {
            ListView ListView1 = p1;
            ListView1.dll_obj = this;
            Base_obj = ListView1;
            selectedItems = new ClListViewSelectedItemCollection(Base_obj.SelectedItems);
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            columns = new ClListViewColumnHeaderCollection(Base_obj.Columns);
            foreColor = new ClColor(Base_obj.ForeColor);
            checkedItems = new ClListViewCheckedItemCollection(Base_obj.CheckedItems);
            backColor = new ClColor(Base_obj.BackColor);
            items = new ClListViewItemCollection(Base_obj.Items);
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public ListView Base_obj;
        
        [ContextProperty("АвтоУпорядочивание", "AutoArrange")]
        public bool AutoArrange
        {
            get { return Base_obj.AutoArrange; }
            set { Base_obj.AutoArrange = value; }
        }

        [ContextProperty("Активация", "Activation")]
        public int Activation
        {
            get { return (int)Base_obj.Activation; }
            set { Base_obj.Activation = value; }
        }

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

        [ContextProperty("ВыборПриНаведении", "HoverSelection")]
        public bool HoverSelection
        {
            get { return Base_obj.HoverSelection; }
            set { Base_obj.HoverSelection = value; }
        }

        [ContextProperty("ВыбранныеЭлементы", "SelectedItems")]
        public ClListViewSelectedItemCollection SelectedItems
        {
            get { return selectedItems; }
        }

        [ContextProperty("Выравнивание", "Alignment")]
        public int Alignment
        {
            get { return (int)Base_obj.Alignment; }
            set { Base_obj.Alignment = value; }
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
        public IValue DoubleClick
        {
            get { return _DoubleClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _DoubleClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DoubleClick = "DelegateActionDoubleClick";
                }
                else
                {
                    _DoubleClick = value;
                    Base_obj.DoubleClick = "osfActionDoubleClick";
                }
            }
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

        [ContextProperty("ИндексВыбранногоИзменен", "SelectedIndexChanged")]
        public IValue SelectedIndexChanged
        {
            get { return _SelectedIndexChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _SelectedIndexChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.SelectedIndexChanged = "DelegateActionSelectedIndexChanged";
                }
                else
                {
                    _SelectedIndexChanged = value;
                    Base_obj.SelectedIndexChanged = "osfActionSelectedIndexChanged";
                }
            }
        }
        
        [ContextProperty("ИспользоватьКурсорОжидания", "UseWaitCursor")]
        public bool UseWaitCursor
        {
            get { return Base_obj.UseWaitCursor; }
            set { Base_obj.UseWaitCursor = value; }
        }

        [ContextProperty("КлавишаВверх", "KeyUp")]
        public IValue KeyUp
        {
            get { return _KeyUp; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _KeyUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyUp = "DelegateActionKeyUp";
                }
                else
                {
                    _KeyUp = value;
                    Base_obj.KeyUp = "osfActionKeyUp";
                }
            }
        }
        
        [ContextProperty("КлавишаВниз", "KeyDown")]
        public IValue KeyDown
        {
            get { return _KeyDown; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _KeyDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyDown = "DelegateActionKeyDown";
                }
                else
                {
                    _KeyDown = value;
                    Base_obj.KeyDown = "osfActionKeyDown";
                }
            }
        }
        
        [ContextProperty("КлавишаНажата", "KeyPress")]
        public IValue KeyPress
        {
            get { return _KeyPress; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _KeyPress = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyPress = "DelegateActionKeyPress";
                }
                else
                {
                    _KeyPress = value;
                    Base_obj.KeyPress = "osfActionKeyPress";
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

        [ContextProperty("КолонкаНажатие", "ColumnClick")]
        public IValue ColumnClick
        {
            get { return _ColumnClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ColumnClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ColumnClick = "DelegateActionColumnClick";
                }
                else
                {
                    _ColumnClick = value;
                    Base_obj.ColumnClick = "osfActionColumnClick";
                }
            }
        }
        
        [ContextProperty("КолонкаСортировки", "SortedColumn")]
        public ClColumnHeader SortedColumn
        {
            get
            {
                if (Base_obj.SortedColumn != null)
                {
                    return Base_obj.SortedColumn.dll_obj;
                }
                return null;
            }
        }
        
        [ContextProperty("Колонки", "Columns")]
        public ClListViewColumnHeaderCollection Columns
        {
            get { return columns; }
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
            get
            {
                if (cursor != null)
                {
                    return cursor;
                }
                return new ClCursor(Base_obj.Cursor);
            }
            set
            {
                cursor = value;
                Base_obj.Cursor = value.Base_obj;
            }
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
        
        [ContextProperty("МножественныйВыбор", "MultiSelect")]
        public bool MultiSelect
        {
            get { return Base_obj.MultiSelect; }
            set { Base_obj.MultiSelect = value; }
        }

        [ContextProperty("МышьНадЭлементом", "MouseEnter")]
        public IValue MouseEnter
        {
            get { return _MouseEnter; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseEnter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseEnter = "DelegateActionMouseEnter";
                }
                else
                {
                    _MouseEnter = value;
                    Base_obj.MouseEnter = "osfActionMouseEnter";
                }
            }
        }
        
        [ContextProperty("МышьПокинулаЭлемент", "MouseLeave")]
        public IValue MouseLeave
        {
            get { return _MouseLeave; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseLeave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseLeave = "DelegateActionMouseLeave";
                }
                else
                {
                    _MouseLeave = value;
                    Base_obj.MouseLeave = "osfActionMouseLeave";
                }
            }
        }
        
        [ContextProperty("Нажатие", "Click")]
        public IValue Click
        {
            get { return _Click; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Click = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Click = "DelegateActionClick";
                }
                else
                {
                    _Click = value;
                    Base_obj.Click = "osfActionClick";
                }
            }
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

        [ContextProperty("ПередРедактированиемНадписи", "BeforeLabelEdit")]
        public IValue BeforeLabelEdit
        {
            get { return _BeforeLabelEdit; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _BeforeLabelEdit = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.BeforeLabelEdit = "DelegateActionBeforeLabelEdit";
                }
                else
                {
                    _BeforeLabelEdit = value;
                    Base_obj.BeforeLabelEdit = "osfActionBeforeLabelEdit";
                }
            }
        }
        
        [ContextProperty("ПереносНадписи", "LabelWrap")]
        public bool LabelWrap
        {
            get { return Base_obj.LabelWrap; }
            set { Base_obj.LabelWrap = value; }
        }

        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
        }
        
        [ContextProperty("ВыбиратьПодэлементы", "FullRowSelect")]
        public bool FullRowSelect
        {
            // Устаревшее свойство, оставить для совместимости.
            get { return Base_obj.FullRowSelect; }
            set { Base_obj.FullRowSelect = value; }
        }

        [ContextProperty("ПолныйВыборСтроки", "FullRowSelect4")]
        public bool FullRowSelect4
        {
            get { return FullRowSelect; }
            set { FullRowSelect = value; }
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
            get { return _LocationChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _LocationChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LocationChanged = "DelegateActionLocationChanged";
                }
                else
                {
                    _LocationChanged = value;
                    Base_obj.LocationChanged = "osfActionLocationChanged";
                }
            }
        }
        
        [ContextProperty("ПомеченныеЭлементы", "CheckedItems")]
        public ClListViewCheckedItemCollection CheckedItems
        {
            get { return checkedItems; }
        }

        [ContextProperty("ПорядокОбхода", "TabIndex")]
        public int TabIndex
        {
            get { return Base_obj.TabIndex; }
            set { Base_obj.TabIndex = value; }
        }

        [ContextProperty("ПослеРедактированияНадписи", "AfterLabelEdit")]
        public IValue AfterLabelEdit
        {
            get { return _AfterLabelEdit; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _AfterLabelEdit = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.AfterLabelEdit = "DelegateActionAfterLabelEdit";
                }
                else
                {
                    _AfterLabelEdit = value;
                    Base_obj.AfterLabelEdit = "osfActionAfterLabelEdit";
                }
            }
        }
        
        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return Base_obj.Right; }
        }

        [ContextProperty("ПриАктивизацииЭлемента", "ItemActivate")]
        public IValue ItemActivate
        {
            get { return _ItemActivate; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ItemActivate = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ItemActivate = "DelegateActionItemActivate";
                }
                else
                {
                    _ItemActivate = value;
                    Base_obj.ItemActivate = "osfActionItemActivate";
                }
            }
        }
        
        [ContextProperty("ПриВходе", "Enter")]
        public IValue Enter
        {
            get { return _Enter; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Enter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Enter = "DelegateActionEnter";
                }
                else
                {
                    _Enter = value;
                    Base_obj.Enter = "osfActionEnter";
                }
            }
        }
        
        [ContextProperty("ПриЗадержкеМыши", "MouseHover")]
        public IValue MouseHover
        {
            get { return _MouseHover; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseHover = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseHover = "DelegateActionMouseHover";
                }
                else
                {
                    _MouseHover = value;
                    Base_obj.MouseHover = "osfActionMouseHover";
                }
            }
        }
        
        [ContextProperty("ПриНажатииКнопкиМыши", "MouseDown")]
        public IValue MouseDown
        {
            get { return _MouseDown; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseDown = "DelegateActionMouseDown";
                }
                else
                {
                    _MouseDown = value;
                    Base_obj.MouseDown = "osfActionMouseDown";
                }
            }
        }
        
        [ContextProperty("ПриОтпусканииМыши", "MouseUp")]
        public IValue MouseUp
        {
            get { return _MouseUp; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseUp = "DelegateActionMouseUp";
                }
                else
                {
                    _MouseUp = value;
                    Base_obj.MouseUp = "osfActionMouseUp";
                }
            }
        }
        
        [ContextProperty("ПриПеремещении", "Move")]
        public IValue Move
        {
            get { return _Move; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Move = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Move = "DelegateActionMove";
                }
                else
                {
                    _Move = value;
                    Base_obj.Move = "osfActionMove";
                }
            }
        }
        
        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public IValue MouseMove
        {
            get { return _MouseMove; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _MouseMove = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseMove = "DelegateActionMouseMove";
                }
                else
                {
                    _MouseMove = value;
                    Base_obj.MouseMove = "osfActionMouseMove";
                }
            }
        }
        
        [ContextProperty("ПриПерерисовке", "Paint")]
        public IValue Paint
        {
            get { return _Paint; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Paint = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Paint = "DelegateActionPaint";
                }
                else
                {
                    _Paint = value;
                    Base_obj.Paint = "osfActionPaint";
                }
            }
        }
        
        [ContextProperty("ПриПотереФокуса", "LostFocus")]
        public IValue LostFocus
        {
            get { return _LostFocus; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _LostFocus = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LostFocus = "DelegateActionLostFocus";
                }
                else
                {
                    _LostFocus = value;
                    Base_obj.LostFocus = "osfActionLostFocus";
                }
            }
        }
        
        [ContextProperty("ПриУходе", "Leave")]
        public IValue Leave
        {
            get { return _Leave; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _Leave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Leave = "DelegateActionLeave";
                }
                else
                {
                    _Leave = value;
                    Base_obj.Leave = "osfActionLeave";
                }
            }
        }
        
        [ContextProperty("Прокручиваемый", "Scrollable")]
        public bool Scrollable
        {
            get { return Base_obj.Scrollable; }
            set { Base_obj.Scrollable = value; }
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
            get { return _SizeChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _SizeChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.SizeChanged = "DelegateActionSizeChanged";
                }
                else
                {
                    _SizeChanged = value;
                    Base_obj.SizeChanged = "osfActionSizeChanged";
                }
            }
        }
        
        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return Convert.ToInt32(Base_obj.FontSize); }
            set { Base_obj.FontSize = value; }
        }
        
        [ContextProperty("РазрешитьПеретаскиваниеКолонок", "AllowColumnReorder")]
        public bool AllowColumnReorder
        {
            get { return Base_obj.AllowColumnReorder; }
            set { Base_obj.AllowColumnReorder = value; }
        }

        [ContextProperty("РазрешитьСортировку", "AllowSorting")]
        public bool AllowSorting
        {
            get { return Base_obj.AllowSorting; }
            set { Base_obj.AllowSorting = value; }
        }

        [ContextProperty("РедактированиеНадписи", "LabelEdit")]
        public bool LabelEdit
        {
            get { return Base_obj.LabelEdit; }
            set { Base_obj.LabelEdit = value; }
        }

        [ContextProperty("РежимОтображения", "View")]
        public int View
        {
            get { return (int)Base_obj.View; }
            set { Base_obj.View = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("Сетка", "GridLines")]
        public bool GridLines
        {
            get { return Base_obj.GridLines; }
            set { Base_obj.GridLines = value; }
        }

        [ContextProperty("СкрытьВыделение", "HideSelection")]
        public bool HideSelection
        {
            get { return Base_obj.HideSelection; }
            set { Base_obj.HideSelection = value; }
        }

        [ContextProperty("Сортировка", "Sorting")]
        public int Sorting
        {
            get { return (int)Base_obj.Sorting; }
            set { Base_obj.Sorting = value; }
        }

        [ContextProperty("СписокБольшихИзображений", "LargeImageList")]
        public ClImageList LargeImageList
        {
            get
            {
                if (largeImageList != null)
                {
                    return largeImageList;
                }
                return new ClImageList(Base_obj.LargeImageList);
            }
            set
            {
                largeImageList = value;
                Base_obj.LargeImageList = value.Base_obj;
            }
        }
        
        [ContextProperty("СписокМаленькихИзображений", "SmallImageList")]
        public ClImageList SmallImageList
        {
            get
            {
                if (smallImageList != null)
                {
                    return smallImageList;
                }
                return new ClImageList(Base_obj.SmallImageList);
            }
            set
            {
                smallImageList = value;
                Base_obj.SmallImageList = value.Base_obj;
            }
        }
        
        [ContextProperty("СтильГраницы", "BorderStyle")]
        public int BorderStyle
        {
            get { return (int)Base_obj.BorderStyle; }
            set { Base_obj.BorderStyle = value; }
        }

        [ContextProperty("СтильЗаголовка", "HeaderStyle")]
        public int HeaderStyle
        {
            get { return (int)Base_obj.HeaderStyle; }
            set { Base_obj.HeaderStyle = value; }
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

        [ContextProperty("СфокусированныйЭлемент", "FocusedItem")]
        public ClListViewItem FocusedItem
        {
            get { return (ClListViewItem)OneScriptForms.RevertObj(Base_obj.FocusedItem); }
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
            get { return _TextChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _TextChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.TextChanged = "DelegateActionTextChanged";
                }
                else
                {
                    _TextChanged = value;
                    Base_obj.TextChanged = "osfActionTextChanged";
                }
            }
        }
        
        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("Флажки", "CheckBoxes")]
        public bool CheckBoxes
        {
            get { return Base_obj.CheckBoxes; }
            set { Base_obj.CheckBoxes = value; }
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

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get
            {
                if (font != null)
                {
                    return font;
                }
                return new ClFont(Base_obj.Font);
            }
            set
            {
                font = value;
                Base_obj.Font = value.Base_obj;
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
            get { return _ControlAdded; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ControlAdded = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ControlAdded = "DelegateActionControlAdded";
                }
                else
                {
                    _ControlAdded = value;
                    Base_obj.ControlAdded = "osfActionControlAdded";
                }
            }
        }
        
        [ContextProperty("ЭлементПомечен", "ItemCheck")]
        public IValue ItemCheck
        {
            get { return _ItemCheck; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ItemCheck = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ItemCheck = "DelegateActionItemCheck";
                }
                else
                {
                    _ItemCheck = value;
                    Base_obj.ItemCheck = "osfActionItemCheck";
                }
            }
        }
        
        [ContextProperty("ЭлементУдален", "ControlRemoved")]
        public IValue ControlRemoved
        {
            get { return _ControlRemoved; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ControlRemoved = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ControlRemoved = "DelegateActionControlRemoved";
                }
                else
                {
                    _ControlRemoved = value;
                    Base_obj.ControlRemoved = "osfActionControlRemoved";
                }
            }
        }
        
        [ContextProperty("Элементы", "Items")]
        public ClListViewItemCollection Items
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
					
        [ContextMethod("ВыбранныеЭлементы", "SelectedItems")]
        public ClListViewItem SelectedItems2(int p1)
        {
            return new ClListViewItem(Base_obj.SelectedItems[p1]);
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
					
        [ContextMethod("Колонки", "Columns")]
        public ClColumnHeader Columns2(int p1)
        {
            return new ClColumnHeader(Base_obj.Columns[p1]);
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
        
        [ContextMethod("ОбеспечитьОтображение", "EnsureVisible")]
        public void EnsureVisible(int p1)
        {
            Base_obj.EnsureVisible(p1);
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

        [ContextMethod("ПолучитьЭлемент", "GetItemAt")]
        public ClListViewItem GetItemAt(int p1, int p2)
        {
            return new ClListViewItem(Base_obj.GetItemAt(p1, p2));
        }

        [ContextMethod("ПомеченныеЭлементы", "CheckedItems")]
        public ClListViewItem CheckedItems2(int p1)
        {
            return new ClListViewItem(Base_obj.CheckedItems[p1]);
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
					
        [ContextMethod("Сортировать", "Sort")]
        public void Sort(ClColumnHeader p1, int p2)
        {
            Base_obj.Sort(p1.Base_obj, p2);
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
        public ClListViewItem Items2(int p1)
        {
            return new ClListViewItem(Base_obj.Items[p1]);
        }

        [ContextMethod("ЭлементыУправления", "Controls")]
        public IValue Controls2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
        }
    }
}
