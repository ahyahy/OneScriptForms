using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Linq;
using System.Windows.Forms;

namespace osf
{
    public class DataGridViewComboBoxCellEx : System.Windows.Forms.DataGridViewComboBoxCell, ISpannedCell
    {
        public osf.DataGridViewComboBoxCell M_Object;

        public DataGridViewComboBoxCellEx() : base()
        {
        }

        private int m_ColumnSpan = 1;
        private int m_RowSpan = 1;
        private DataGridViewComboBoxCellEx m_OwnerCell;

        public int ColumnSpan
        {
            get { return m_ColumnSpan; }
            set
            {
                if (DataGridView == null || m_OwnerCell != null)
                {
                    return;
                }
                if (value < 1 || ColumnIndex + value - 1 >= DataGridView.ColumnCount)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }
                if (m_ColumnSpan != value)
                {
                    SetSpan(value, m_RowSpan);
                }
            }
        }

        public int RowSpan
        {
            get { return m_RowSpan; }
            set
            {
                if (DataGridView == null || m_OwnerCell != null)
                {
                    return;
                }
                if (value < 1 || RowIndex + value - 1 >= DataGridView.RowCount)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }
                if (m_RowSpan != value)
                {
                    SetSpan(m_ColumnSpan, value);
                }
            }
        }

        public System.Windows.Forms.DataGridViewCell OwnerCell
        {
            get { return m_OwnerCell; }
            private set { m_OwnerCell = value as DataGridViewComboBoxCellEx; }
        }

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;

                if (m_OwnerCell == null && (m_ColumnSpan > 1 || m_RowSpan > 1) && DataGridView != null)
                {
                    foreach (var col in Enumerable.Range(ColumnIndex, m_ColumnSpan))
                    {
                        foreach (var row in Enumerable.Range(RowIndex, m_RowSpan))
                        {
                            if (col != ColumnIndex || row != RowIndex)
                            {
                                DataGridView[col, row].ReadOnly = value;
                            }
                        }
                    }
                }
            }
        }

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, System.Windows.Forms.DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (m_OwnerCell != null && m_OwnerCell.DataGridView == null)
            {
                m_OwnerCell = null; // Ячейка-владелец была удалена.
            }

            if (DataGridView == null || (m_OwnerCell == null && m_ColumnSpan == 1 && m_RowSpan == 1))
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                return;
            }

            var ownerCell = this;
            var columnIndex = ColumnIndex;
            var columnSpan = m_ColumnSpan;
            var rowSpan = m_RowSpan;
            if (m_OwnerCell != null)
            {
                ownerCell = m_OwnerCell;
                columnIndex = m_OwnerCell.ColumnIndex;
                rowIndex = m_OwnerCell.RowIndex;
                columnSpan = m_OwnerCell.ColumnSpan;
                rowSpan = m_OwnerCell.RowSpan;
                value = m_OwnerCell.GetValue(rowIndex);
                errorText = m_OwnerCell.GetErrorText(rowIndex);
                cellState = m_OwnerCell.State;
                cellStyle = m_OwnerCell.GetInheritedStyle(null, rowIndex, true);
                formattedValue = m_OwnerCell.GetFormattedValue(value, rowIndex, ref cellStyle, null, null, DataGridViewDataErrorContexts.Display);
            }

            if (CellsRegionContainsSelectedCell(columnIndex, rowIndex, columnSpan, rowSpan))
            {
                cellState |= DataGridViewElementStates.Selected;
            }

            // Сохраним старые границы клипа.
            System.Drawing.RectangleF oldBounds = graphics.ClipBounds;
            var cellBounds2 = DataGridViewCellExHelper.GetSpannedCellBoundsFromChildCellBounds(this, cellBounds, DataGridView.SingleVerticalBorderAdded(), DataGridView.SingleHorizontalBorderAdded());
            clipBounds = DataGridViewCellExHelper.GetSpannedCellClipBounds(ownerCell, cellBounds2, DataGridView.SingleVerticalBorderAdded(), DataGridView.SingleHorizontalBorderAdded());
            advancedBorderStyle = DataGridViewCellExHelper.AdjustCellBorderStyle(ownerCell);
            using (var g = this.DataGridView.CreateGraphics())
            {
                // Задайте для новых границ клипа границы, рассчитанные для объединенных строк.
                g.SetClip(clipBounds);

                // Нарисуйте содержимое.
                ownerCell.NativePaint(g, clipBounds, cellBounds2, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.Border);

                // Нарисуйте границы.
                if ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None)
                {
                    var leftTopCell = ownerCell;
                    var advancedBorderStyle2 = new DataGridViewAdvancedBorderStyle
                    {
                        Left = advancedBorderStyle.Left,
                        Top = advancedBorderStyle.Top,
                        Right = DataGridViewAdvancedCellBorderStyle.None,
                        Bottom = DataGridViewAdvancedCellBorderStyle.None
                    };
                    leftTopCell.PaintBorder(g, clipBounds, cellBounds2, cellStyle, advancedBorderStyle2);

                    var rightBottomCell = DataGridView[columnIndex + columnSpan - 1, rowIndex + rowSpan - 1] as DataGridViewComboBoxCellEx ?? this;
                    var advancedBorderStyle3 = new DataGridViewAdvancedBorderStyle
                    {
                        Left = DataGridViewAdvancedCellBorderStyle.None,
                        Top = DataGridViewAdvancedCellBorderStyle.None,
                        Right = advancedBorderStyle.Right,
                        Bottom = advancedBorderStyle.Bottom
                    };
                    rightBottomCell.PaintBorder(g, clipBounds, cellBounds2, cellStyle, advancedBorderStyle3);
                }
            }

            // Задайте для новых границ клипа границы, рассчитанные для объединенных строк.
            graphics.SetClip(clipBounds);

            // Нарисуйте содержимое.
            ownerCell.NativePaint(graphics, clipBounds, cellBounds2, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.Border);

            // Нарисуйте границы.
            if ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None)
            {
                var leftTopCell = ownerCell;
                var advancedBorderStyle2 = new DataGridViewAdvancedBorderStyle
                {
                    Left = advancedBorderStyle.Left,
                    Top = advancedBorderStyle.Top,
                    Right = DataGridViewAdvancedCellBorderStyle.None,
                    Bottom = DataGridViewAdvancedCellBorderStyle.None
                };
                leftTopCell.PaintBorder(graphics, clipBounds, cellBounds2, cellStyle, advancedBorderStyle2);

                var rightBottomCell = DataGridView[columnIndex + columnSpan - 1, rowIndex + rowSpan - 1] as DataGridViewComboBoxCellEx ?? this;
                var advancedBorderStyle3 = new DataGridViewAdvancedBorderStyle
                {
                    Left = DataGridViewAdvancedCellBorderStyle.None,
                    Top = DataGridViewAdvancedCellBorderStyle.None,
                    Right = advancedBorderStyle.Right,
                    Bottom = advancedBorderStyle.Bottom
                };
                rightBottomCell.PaintBorder(graphics, clipBounds, cellBounds2, cellStyle, advancedBorderStyle3);
            }

            // Восстановите старые границы! В противном случае будет нарисована только объединенная строка, а всё что следует далее нарисовано не будет.
            graphics.SetClip(oldBounds);
        }

        private void NativePaint(
            System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            System.Windows.Forms.DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            System.Windows.Forms.DataGridViewCellStyle cellStyle,
            System.Windows.Forms.DataGridViewAdvancedBorderStyle advancedBorderStyle,
            System.Windows.Forms.DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        private void SetSpan(int columnSpan, int rowSpan)
        {
            int prevColumnSpan = m_ColumnSpan;
            int prevRowSpan = m_RowSpan;
            m_ColumnSpan = columnSpan;
            m_RowSpan = rowSpan;

            if (DataGridView != null)
            {
                // Очистка.
                foreach (int rowIndex in Enumerable.Range(RowIndex, prevRowSpan))
                {
                    foreach (int columnIndex in Enumerable.Range(ColumnIndex, prevColumnSpan))
                    {
                        var cell = DataGridView[columnIndex, rowIndex] as DataGridViewComboBoxCellEx;
                        if (cell != null)
                        {
                            cell.OwnerCell = null;
                        }
                    }
                }

                // Установка.
                foreach (int rowIndex in Enumerable.Range(RowIndex, m_RowSpan))
                {
                    foreach (int columnIndex in Enumerable.Range(ColumnIndex, m_ColumnSpan))
                    {
                        var cell = DataGridView[columnIndex, rowIndex] as DataGridViewComboBoxCellEx;
                        if (cell != null && cell != this)
                        {
                            if (cell.ColumnSpan > 1)
                            {
                                cell.ColumnSpan = 1;
                            }
                            if (cell.RowSpan > 1)
                            {
                                cell.RowSpan = 1;
                            }

                            // Удалим данные из объединяемых ячеек, кроме левой верхней ячейки.
                            cell.Value = null;

                            cell.OwnerCell = this;
                        }
                    }
                }
                OwnerCell = null;
                DataGridView.Invalidate();
            }
        }

        public override System.Drawing.Rectangle PositionEditingPanel(
            System.Drawing.Rectangle cellBounds,
            System.Drawing.Rectangle cellClip,
            System.Windows.Forms.DataGridViewCellStyle cellStyle,
            bool singleVerticalBorderAdded,
            bool singleHorizontalBorderAdded,
            bool isFirstDisplayedColumn,
            bool isFirstDisplayedRow)
        {
            if (m_OwnerCell == null && m_ColumnSpan == 1 && m_RowSpan == 1)
            {
                return base.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
            }

            var ownerCell = this;
            if (m_OwnerCell != null)
            {
                var rowIndex = m_OwnerCell.RowIndex;
                cellStyle = m_OwnerCell.GetInheritedStyle(null, rowIndex, true);
                m_OwnerCell.GetFormattedValue(m_OwnerCell.Value, rowIndex, ref cellStyle, null, null, DataGridViewDataErrorContexts.Formatting);
                var editingControl = DataGridView.EditingControl as IDataGridViewEditingControl;
                if (editingControl != null)
                {
                    editingControl.ApplyCellStyleToEditingControl(cellStyle);
                    var editingPanel = DataGridView.EditingControl.Parent;
                    if (editingPanel != null)
                    {
                        editingPanel.BackColor = cellStyle.BackColor;
                    }
                }
                ownerCell = m_OwnerCell;
            }
            cellBounds = DataGridViewCellExHelper.GetSpannedCellBoundsFromChildCellBounds(
                this,
                cellBounds,
                singleVerticalBorderAdded,
                singleHorizontalBorderAdded);
            cellClip = DataGridViewCellExHelper.GetSpannedCellClipBounds(
                ownerCell,
                cellBounds,
                singleVerticalBorderAdded,
                singleHorizontalBorderAdded);
            return base.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, ownerCell.InFirstDisplayedColumn(), ownerCell.InFirstDisplayedRow());
        }

        protected override object GetValue(int rowIndex)
        {
            if (m_OwnerCell != null)
            {
                return m_OwnerCell.GetValue(m_OwnerCell.RowIndex);
            }
            return base.GetValue(rowIndex);
        }

        protected override bool SetValue(int rowIndex, object value)
        {
            if (m_OwnerCell != null)
            {
                return m_OwnerCell.SetValue(m_OwnerCell.RowIndex, value);
            }
            return base.SetValue(rowIndex, value);
        }

        protected override void OnDataGridViewChanged()
        {
            base.OnDataGridViewChanged();

            if (DataGridView == null)
            {
                m_ColumnSpan = 1;
                m_RowSpan = 1;
            }
        }

        protected override System.Drawing.Rectangle BorderWidths(System.Windows.Forms.DataGridViewAdvancedBorderStyle advancedBorderStyle)
        {
            if (m_OwnerCell == null && m_ColumnSpan == 1 && m_RowSpan == 1)
            {
                return base.BorderWidths(advancedBorderStyle);
            }

            if (m_OwnerCell != null)
            {
                return m_OwnerCell.BorderWidths(advancedBorderStyle);
            }

            var leftTop = base.BorderWidths(advancedBorderStyle);
            var rightBottomCell = DataGridView[ColumnIndex + ColumnSpan - 1, RowIndex + RowSpan - 1] as DataGridViewComboBoxCellEx;
            var rightBottom = rightBottomCell != null ? NativeBorderWidths(advancedBorderStyle) : leftTop;
            return new System.Drawing.Rectangle(leftTop.X, leftTop.Y, rightBottom.Width, rightBottom.Height);
        }

        private System.Drawing.Rectangle NativeBorderWidths(System.Windows.Forms.DataGridViewAdvancedBorderStyle advancedBorderStyle)
        {
            return base.BorderWidths(advancedBorderStyle);
        }

        protected override System.Drawing.Size GetPreferredSize(
            System.Drawing.Graphics graphics,
            System.Windows.Forms.DataGridViewCellStyle cellStyle,
            int rowIndex,
            System.Drawing.Size constraintSize)
        {
            if (OwnerCell != null)
            {
                return new System.Drawing.Size(0, 0);
            }
            var size = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            var grid = DataGridView;
            var width = size.Width - Enumerable.Range(ColumnIndex + 1, ColumnSpan - 1)
                                           .Select(index => grid.Columns[index].Width)
                                           .Sum();
            var height = size.Height - Enumerable.Range(RowIndex + 1, RowSpan - 1)
                                           .Select(index => grid.Rows[index].Height)
                                           .Sum();
            return new System.Drawing.Size(width, height);
        }

        private bool CellsRegionContainsSelectedCell(int columnIndex, int rowIndex, int columnSpan, int rowSpan)
        {
            if (DataGridView == null)
            {
                return false;
            }

            return (from col in Enumerable.Range(columnIndex, columnSpan)
                    from row in Enumerable.Range(rowIndex, rowSpan)
                    where DataGridView[col, row].Selected
                    select col).Any();
        }
    }

    public class DataGridViewComboBoxCell : DataGridViewCell
    {
        public new ClDataGridViewComboBoxCell dll_obj;
        private dynamic M_DataGridViewComboBoxCell;

        public DataGridViewComboBoxCell()
        {
            M_DataGridViewComboBoxCell = new DataGridViewComboBoxCellEx();
            M_DataGridViewComboBoxCell.M_Object = this;
            base.M_DataGridViewCell = M_DataGridViewComboBoxCell;
            M_DataGridViewComboBoxCell.DisplayMember = "Text";
            M_DataGridViewComboBoxCell.ValueMember = "Value";
        }

        public DataGridViewComboBoxCell(DataGridViewComboBoxCellEx p1)
        {
            M_DataGridViewComboBoxCell = p1;
            M_DataGridViewComboBoxCell.M_Object = this;
            base.M_DataGridViewCell = M_DataGridViewComboBoxCell;
        }

        public DataGridViewComboBoxCell(osf.DataGridViewComboBoxCell p1)
        {
            M_DataGridViewComboBoxCell = p1.M_DataGridViewComboBoxCell;
            M_DataGridViewComboBoxCell.M_Object = this;
            base.M_DataGridViewCell = M_DataGridViewComboBoxCell;
        }

        public DataGridViewComboBoxCell(System.Windows.Forms.DataGridViewComboBoxCell p1)
        {
            M_DataGridViewComboBoxCell = p1;
            base.M_DataGridViewCell = M_DataGridViewComboBoxCell;
        }

        public object DataSource
        {
            get
            {
                object obj;
                try
                {
                    obj = ((dynamic)M_DataGridViewComboBoxCell.DataSource).M_Object;
                }
                catch
                {
                    obj = M_DataGridViewComboBoxCell.DataSource;
                }
                return obj;
            }
            set
            {
                M_DataGridViewComboBoxCell.DataSource = null;
                try
                {
                    System.Type Type1 = value.GetType();
                    string strType1 = Type1.ToString();
                    string str1 = strType1.Substring(strType1.LastIndexOf(".") + 1);
                    M_DataGridViewComboBoxCell.DataSource = Type1.GetField("M_" + str1).GetValue(value);
                }
                catch
                {
                    M_DataGridViewComboBoxCell.DataSource = value;
                }
            }
        }

        public string DisplayMember
        {
            get { return M_DataGridViewComboBoxCell.DisplayMember; }
            set { M_DataGridViewComboBoxCell.DisplayMember = value; }
        }

        public int DisplayStyle
        {
            get { return (int)M_DataGridViewComboBoxCell.DisplayStyle; }
            set { M_DataGridViewComboBoxCell.DisplayStyle = (System.Windows.Forms.DataGridViewComboBoxDisplayStyle)value; }
        }

        public int FlatStyle
        {
            get { return (int)M_DataGridViewComboBoxCell.FlatStyle; }
            set { M_DataGridViewComboBoxCell.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
        }

        public osf.DataGridViewComboBoxCellObjectCollection Items
        {
            get { return new DataGridViewComboBoxCellObjectCollection(M_DataGridViewComboBoxCell.Items); }
        }

        public int MaxDropDownItems
        {
            get { return M_DataGridViewComboBoxCell.MaxDropDownItems; }
            set { M_DataGridViewComboBoxCell.MaxDropDownItems = value; }
        }

        public bool Sorted
        {
            get { return M_DataGridViewComboBoxCell.Sorted; }
            set { M_DataGridViewComboBoxCell.Sorted = value; }
        }

        public string ValueMember
        {
            get { return M_DataGridViewComboBoxCell.ValueMember; }
            set { M_DataGridViewComboBoxCell.ValueMember = value; }
        }
    }

    [ContextClass ("КлПолеВыбораЯчейки", "ClDataGridViewComboBoxCell")]
    public class ClDataGridViewComboBoxCell : AutoContext<ClDataGridViewComboBoxCell>
    {
        private ClRectangle contentBounds;
        private ClCollection tag = new ClCollection();

        public ClDataGridViewComboBoxCell()
        {
            DataGridViewComboBoxCell DataGridViewComboBoxCell1 = new DataGridViewComboBoxCell();
            DataGridViewComboBoxCell1.dll_obj = this;
            Base_obj = DataGridViewComboBoxCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
		
        public ClDataGridViewComboBoxCell(DataGridViewComboBoxCell p1)
        {
            DataGridViewComboBoxCell DataGridViewComboBoxCell1 = p1;
            DataGridViewComboBoxCell1.dll_obj = this;
            Base_obj = DataGridViewComboBoxCell1;
            contentBounds = new ClRectangle(Base_obj.ContentBounds);
        }
        
        public DataGridViewComboBoxCell Base_obj;
        
        [ContextProperty("Выбран", "Selected")]
        public bool Selected
        {
            get { return Base_obj.Selected; }
            set { Base_obj.Selected = value; }
        }

        [ContextProperty("ГраницыСодержимого", "ContentBounds")]
        public ClRectangle ContentBounds
        {
            get { return contentBounds; }
        }

        [ContextProperty("Закреплено", "Frozen")]
        public bool Frozen
        {
            get { return Base_obj.Frozen; }
        }

        [ContextProperty("Значение", "Value")]
        public IValue Value
        {
            get { return OneScriptForms.RevertObj(Base_obj.Value); }
            set { Base_obj.Value = value; }
        }
        
        [ContextProperty("ЗначениеЭлемента", "ValueMember")]
        public string ValueMember
        {
            get { return Base_obj.ValueMember; }
            set { Base_obj.ValueMember = value; }
        }

        [ContextProperty("ИзменяемыйРазмер", "Resizable")]
        public bool Resizable
        {
            get { return Base_obj.Resizable; }
        }

        [ContextProperty("ИндексКолонки", "ColumnIndex")]
        public int ColumnIndex
        {
            get { return Base_obj.ColumnIndex; }
        }

        [ContextProperty("ИндексСтроки", "RowIndex")]
        public int RowIndex
        {
            get { return Base_obj.RowIndex; }
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

        [ContextProperty("КолонкаВладелец", "OwningColumn")]
        public ClDataGridViewColumn OwningColumn
        {
            get { return (ClDataGridViewColumn)OneScriptForms.RevertObj(Base_obj.OwningColumn); }
        }

        [ContextProperty("МаксимумЭлементов", "MaxDropDownItems")]
        public int MaxDropDownItems
        {
            get { return Base_obj.MaxDropDownItems; }
            set
            {
                if (OneScriptForms.systemVersionIsMicrosoft)
                {
                    Base_obj.MaxDropDownItems = value;
                }
            }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("Отображается", "Displayed")]
        public bool Displayed
        {
            get { return Base_obj.Displayed; }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
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
            set
            {
                if (OneScriptForms.systemVersionIsMicrosoft)
                {
                    Base_obj.Sorted = value;
                }
            }
        }

        [ContextProperty("ПлоскийСтиль", "FlatStyle")]
        public int FlatStyle
        {
            get { return (int)Base_obj.FlatStyle; }
            set { Base_obj.FlatStyle = value; }
        }

        [ContextProperty("ПредпочтительныйРазмер", "PreferredSize")]
        public ClSize PreferredSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.PreferredSize); }
        }

        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
        }

        [ContextProperty("Стиль", "Style")]
        public ClDataGridViewCellStyle Style
        {
            get { return (ClDataGridViewCellStyle)OneScriptForms.RevertObj(Base_obj.Style); }
            set { Base_obj.Style = value.Base_obj; }
        }

        [ContextProperty("СтильОтображения", "DisplayStyle")]
        public int DisplayStyle
        {
            get { return (int)Base_obj.DisplayStyle; }
            set { Base_obj.DisplayStyle = value; }
        }

        [ContextProperty("СтильУстановлен", "HasStyle")]
        public bool HasStyle
        {
            get { return Base_obj.HasStyle; }
        }

        [ContextProperty("СтрокаВладелец", "OwningRow")]
        public ClDataGridViewRow OwningRow
        {
            get { return (ClDataGridViewRow)OneScriptForms.RevertObj(Base_obj.OwningRow); }
        }

        [ContextProperty("Таблица", "DataGridView")]
        public ClDataGridView DataGridView
        {
            get { return (ClDataGridView)OneScriptForms.RevertObj(Base_obj.DataGridView); }
        }

        [ContextProperty("ТекстПодсказки", "ToolTipText")]
        public string ToolTipText
        {
            get { return Base_obj.ToolTipText; }
            set { Base_obj.ToolTipText = value; }
        }

        [ContextProperty("ТолькоЧтение", "ReadOnly")]
        public bool ReadOnly
        {
            get { return Base_obj.ReadOnly; }
            set { Base_obj.ReadOnly = value; }
        }

        [ContextProperty("ФорматированноеЗначение", "FormattedValue")]
        public IValue FormattedValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.FormattedValue); }
        }
        
        [ContextProperty("ФорматированноеЗначениеРедактируемого", "EditedFormattedValue")]
        public IValue EditedFormattedValue
        {
            get { return OneScriptForms.RevertObj(Base_obj.EditedFormattedValue); }
        }
        
        [ContextProperty("Элементы", "Items")]
        public ClDataGridViewComboBoxCellObjectCollection Items
        {
            get { return (ClDataGridViewComboBoxCellObjectCollection)OneScriptForms.RevertObj(Base_obj.Items); }
        }
        
        [ContextMethod("Элементы", "Items")]
        public IValue Items2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Items[p1]);
        }
    }
}
