using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class DataGridEx : System.Windows.Forms.DataGrid
    {
        public osf.DataGrid M_Object;
    }

    public class DataGrid : Control
    {
        public string CurrentCellChanged;
        public ClDataGrid dll_obj;
        public DataGridEx M_DataGrid;

        public DataGrid()
        {
            M_DataGrid = new DataGridEx();
            M_DataGrid.M_Object = this;
            base.M_Control = M_DataGrid;
            M_DataGrid.CurrentCellChanged += M_DataGrid_CurrentCellChanged;
            CurrentCellChanged = "";
        }

        public DataGrid(System.Windows.Forms.DataGrid p1)
        {
            M_DataGrid = (DataGridEx)p1;
            M_DataGrid.M_Object = this;
            base.M_Control = M_DataGrid;
            M_DataGrid.CurrentCellChanged += M_DataGrid_CurrentCellChanged;
            CurrentCellChanged = "";
        }

        public DataGrid(osf.DataGrid p1)
        {
            M_DataGrid = p1.M_DataGrid;
            M_DataGrid.M_Object = this;
            base.M_Control = M_DataGrid;
            M_DataGrid.CurrentCellChanged += M_DataGrid_CurrentCellChanged;
            CurrentCellChanged = "";
        }

        //Свойства============================================================

        public bool AllowSorting
        {
            get { return M_DataGrid.AllowSorting; }
            set
            {
                M_DataGrid.AllowSorting = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Color BackgroundColor
        {
            get { return new Color(M_DataGrid.BackgroundColor); }
            set
            {
                M_DataGrid.BackgroundColor = value.M_Color;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.Color CaptionBackColor
        {
            get { return new Color(M_DataGrid.CaptionBackColor); }
            set
            {
                M_DataGrid.CaptionBackColor = value.M_Color;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string CaptionText
        {
            get { return M_DataGrid.CaptionText; }
            set
            {
                M_DataGrid.CaptionText = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool CaptionVisible
        {
            get { return M_DataGrid.CaptionVisible; }
            set
            {
                M_DataGrid.CaptionVisible = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.DataGridCell CurrentCell
        {
            get { return new DataGridCell(M_DataGrid.CurrentCell); }
            set
            {
                M_DataGrid.CurrentCell = value.M_DataGridCell;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int CurrentRowIndex
        {
            get { return M_DataGrid.CurrentRowIndex; }
            set
            {
                M_DataGrid.CurrentRowIndex = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string DataMember
        {
            get { return M_DataGrid.DataMember; }
            set { M_DataGrid.DataMember = value; }
        }

        public object DataSource
        {
            get
            {
                if (M_DataGrid.DataSource != null)
                {
                    return ((dynamic)M_DataGrid.DataSource).M_Object;
                }
                return null;
            }
            set
            {
                System.Type Type1 = ((dynamic)value).GetType();
                string strType1 = Type1.ToString();
                string str1 = strType1.Substring(strType1.LastIndexOf(".") + 1);
                M_DataGrid.DataSource = Type1.GetField("M_" + str1).GetValue(value);
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int PreferredRowHeight
        {
            get { return M_DataGrid.PreferredRowHeight; }
            set { M_DataGrid.PreferredRowHeight = value; }
        }

        public bool ReadOnly
        {
            get { return M_DataGrid.ReadOnly; }
            set
            {
                M_DataGrid.ReadOnly = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public osf.GridTableStylesCollection TableStyles
        {
            get { return new GridTableStylesCollection(M_DataGrid.TableStyles); }
        }

        //Методы============================================================

        public bool BeginEdit(osf.DataGridColumnStyle p1, int p2)
        {
            return M_DataGrid.BeginEdit(p1.M_DataGridColumnStyle, p2);
        }

        public bool EndEdit(osf.DataGridColumnStyle p1, int p2, bool p3)
        {
            return M_DataGrid.EndEdit(p1.M_DataGridColumnStyle, p2, p3);
        }

        public osf.Rectangle GetCurrentCellBounds()
        {
            return new Rectangle(M_DataGrid.GetCurrentCellBounds());
        }

        public bool IsSelected(int row)
        {
            return M_DataGrid.IsSelected(row);
        }

        public void M_DataGrid_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (CurrentCellChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = CurrentCellChanged;
                EventArgs1.Sender = (object)this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        public void SetDataBinding(object source, string member = null)
        {
            if (source is osf.DataView)
            {
                M_DataGrid.SetDataBinding((System.Data.DataView)((osf.DataView)source).M_DataView, member);
            }
            if (source is osf.DataTable)
            {
                M_DataGrid.SetDataBinding((System.Data.DataTable)((osf.DataTable)source).M_DataTable, member);
            }
            if (source is osf.DataSet)
            {
                M_DataGrid.SetDataBinding((System.Data.DataSet)((osf.DataSet)source).M_DataSet, member);
            }
            if (source is osf.ArrayList)
            {
                M_DataGrid.SetDataBinding((System.Collections.ArrayList)((osf.ArrayList)source).M_ArrayList, member);
            }
            System.Windows.Forms.Application.DoEvents();
        }

    }

    [ContextClass ("КлСеткаДанных", "ClDataGrid")]
    public class ClDataGrid : AutoContext<ClDataGrid>
    {
        private ClColor backColor;
        private ClColor backgroundColor;
        private ClRectangle bounds;
        private ClColor captionBackColor;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClColor foreColor;
        private ClGridTableStylesCollection tableStyles;
        private ClCollection tag = new ClCollection();

        public ClDataGrid()
        {
            DataGrid DataGrid1 = new DataGrid();
            DataGrid1.dll_obj = this;
            Base_obj = DataGrid1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            tableStyles = new ClGridTableStylesCollection(Base_obj.TableStyles);
            backColor = new ClColor(Base_obj.BackColor);
            captionBackColor = new ClColor(Base_obj.CaptionBackColor);
            backgroundColor = new ClColor(Base_obj.BackgroundColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClDataGrid(DataGrid p1)
        {
            DataGrid DataGrid1 = p1;
            DataGrid1.dll_obj = this;
            Base_obj = DataGrid1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            tableStyles = new ClGridTableStylesCollection(Base_obj.TableStyles);
            backColor = new ClColor(Base_obj.BackColor);
            captionBackColor = new ClColor(Base_obj.CaptionBackColor);
            backgroundColor = new ClColor(Base_obj.BackgroundColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public DataGrid Base_obj;

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

        [ContextProperty("ИндексТекущейСтроки", "CurrentRowIndex")]
        public int CurrentRowIndex
        {
            get { return Base_obj.CurrentRowIndex; }
            set { Base_obj.CurrentRowIndex = value; }
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

        [ContextProperty("ОтображатьЗаголовок", "CaptionVisible")]
        public bool CaptionVisible
        {
            get { return Base_obj.CaptionVisible; }
            set { Base_obj.CaptionVisible = value; }
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

        [ContextProperty("ПредпочтительнаяВысотаСтрок", "PreferredRowHeight")]
        public int PreferredRowHeight
        {
            get { return Base_obj.PreferredRowHeight; }
            set { Base_obj.PreferredRowHeight = value; }
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
        
        [ContextProperty("РазрешитьСортировку", "AllowSorting")]
        public bool AllowSorting
        {
            get { return Base_obj.AllowSorting; }
            set { Base_obj.AllowSorting = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("СтилиТаблицы", "TableStyles")]
        public ClGridTableStylesCollection TableStyles
        {
            get { return tableStyles; }
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

        [ContextProperty("ТекстЗаголовка", "CaptionText")]
        public string CaptionText
        {
            get { return Base_obj.CaptionText; }
            set { Base_obj.CaptionText = value; }
        }

        [ContextProperty("ТекстИзменен", "TextChanged")]
        public string TextChanged
        {
            get { return Base_obj.TextChanged; }
            set { Base_obj.TextChanged = value; }
        }

        [ContextProperty("ТекущаяЯчейка", "CurrentCell")]
        public ClDataGridCell CurrentCell
        {
            get { return new ClDataGridCell(Base_obj.CurrentCell); }
            set { Base_obj.CurrentCell = value.Base_obj; }
        }

        [ContextProperty("ТекущаяЯчейкаИзменена", "CurrentCellChanged")]
        public string CurrentCellChanged
        {
            get { return Base_obj.CurrentCellChanged; }
            set { Base_obj.CurrentCellChanged = value; }
        }

        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("ТолькоЧтение", "ReadOnly")]
        public bool ReadOnly
        {
            get { return Base_obj.ReadOnly; }
            set { Base_obj.ReadOnly = value; }
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

        [ContextProperty("ЦветФонаЗаголовка", "CaptionBackColor")]
        public ClColor CaptionBackColor
        {
            get { return captionBackColor; }
            set 
            {
                captionBackColor = value;
                Base_obj.CaptionBackColor = value.Base_obj;
            }
        }

        [ContextProperty("ЦветФонаСеткиДанных", "BackgroundColor")]
        public ClColor BackgroundColor
        {
            get { return backgroundColor; }
            set 
            {
                backgroundColor = value;
                Base_obj.BackgroundColor = value.Base_obj;
            }
        }

        [ContextProperty("ЧленДанных", "DataMember")]
        public string DataMember
        {
            get { return Base_obj.DataMember; }
            set { Base_obj.DataMember = value; }
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
					
        [ContextMethod("Выбрана", "IsSelected")]
        public bool IsSelected(int p1)
        {
            return Base_obj.IsSelected(p1);
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
        
        [ContextMethod("ГраницыТекущейЯчейки", "GetCurrentCellBounds")]
        public ClRectangle GetCurrentCellBounds()
        {
            return new ClRectangle(Base_obj.GetCurrentCellBounds());
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
					
        [ContextMethod("ЗавершитьРедактирование", "EndEdit")]
        public bool EndEdit(IValue p1, int p2, bool p3)
        {
            return Base_obj.EndEdit(((dynamic)p1).Base_obj, p2, p3);
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
					
        [ContextMethod("НачатьРедактирование", "BeginEdit")]
        public bool BeginEdit(IValue p1, int p2)
        {
            return Base_obj.BeginEdit(((dynamic)p1).Base_obj, p2);
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
					
        [ContextMethod("СтилиТаблицы", "TableStyles")]
        public ClDataGridTableStyle TableStyles2(int p1)
        {
            return (ClDataGridTableStyle)OneScriptForms.RevertObj(Base_obj.TableStyles[p1]);
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

        [ContextMethod("УстановитьСвязьДанных", "SetDataBinding")]
        public void SetDataBinding(IValue p1, string p2 = null)
        {
            dynamic p3 = p1.AsObject();
            Base_obj.SetDataBinding(p3.Base_obj, p2);
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
        
        [ContextMethod("ЭлементыУправления", "Controls")]
        public IValue Controls2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
        }
    }
}
