using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Windows.Forms;
using System.Reflection;

namespace osf
{
    public class DataGridViewEx : System.Windows.Forms.DataGridView
    {
        public osf.DataGridView M_Object;
    }

    public class DataGridView : Control
    {
        public bool ArrowRowHeaders;
        public bool AutoNumberingRows;
        public string CellBeginEdit;
        public string CellClick;
        public string CellContentClick;
        public string CellDoubleClick;
        public string CellEndEdit;
        public string CellEnter;
        public string CellLeave;
        public string CellMouseDown;
        public string CellMouseEnter;
        public string CellMouseLeave;
        public string CellMouseMove;
        public string CellMouseUp;
        public string CellValueChanged;
        public string ColumnHeaderMouseClick;
        public string CurrentCellChanged;
        public ClDataGridView dll_obj;
        public DataGridViewEx M_DataGridView;
        public string RowEnter;
        public string RowHeaderMouseClick;
        public string RowLeave;

        public DataGridView()
        {
            M_DataGridView = new DataGridViewEx();
            M_DataGridView.M_Object = this;
            base.M_Control = M_DataGridView;
            M_DataGridView.CellBeginEdit += M_DataGridView_CellBeginEdit;
            M_DataGridView.CellClick += M_DataGridView_CellClick;
            M_DataGridView.CellContentClick += M_DataGridView_CellContentClick;
            M_DataGridView.CellDoubleClick += M_DataGridView_CellDoubleClick;
            M_DataGridView.CellEndEdit += M_DataGridView_CellEndEdit;
            M_DataGridView.CellEnter += M_DataGridView_CellEnter;
            M_DataGridView.CellLeave += M_DataGridView_CellLeave;
            M_DataGridView.CellMouseDown += M_DataGridView_CellMouseDown;
            M_DataGridView.CellMouseEnter += M_DataGridView_CellMouseEnter;
            M_DataGridView.CellMouseLeave += M_DataGridView_CellMouseLeave;
            M_DataGridView.CellMouseMove += M_DataGridView_CellMouseMove;
            M_DataGridView.CellMouseUp += M_DataGridView_CellMouseUp;
            M_DataGridView.CellValueChanged += M_DataGridView_CellValueChanged;
            M_DataGridView.ColumnHeaderMouseClick += M_DataGridView_ColumnHeaderMouseClick;
            M_DataGridView.CurrentCellChanged += M_DataGridView_CurrentCellChanged;
            M_DataGridView.RowEnter += M_DataGridView_RowEnter;
            M_DataGridView.RowHeaderMouseClick += M_DataGridView_RowHeaderMouseClick;
            M_DataGridView.RowLeave += M_DataGridView_RowLeave;
            M_DataGridView.CellFormatting += M_DataGridView_CellFormatting;
            M_DataGridView.RowPrePaint += M_DataGridView_RowPrePaint;
            M_DataGridView.RowPostPaint += M_DataGridView_RowPostPaint;
            M_DataGridView.DataError += M_DataGridView_DataError;
            CellBeginEdit = "";
            CellClick = "";
            CellContentClick = "";
            CellDoubleClick = "";
            CellEndEdit = "";
            CellEnter = "";
            CellLeave = "";
            CellMouseDown = "";
            CellMouseEnter = "";
            CellMouseLeave = "";
            CellMouseMove = "";
            CellMouseUp = "";
            CellValueChanged = "";
            ColumnHeaderMouseClick = "";
            CurrentCellChanged = "";
            RowEnter = "";
            RowHeaderMouseClick = "";
            RowLeave = "";
            ArrowRowHeaders = true;
            AutoNumberingRows = false;
            typeof(System.Windows.Forms.DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, M_DataGridView, new object[] { true });
        }

        public DataGridView(osf.DataGridView p1)
        {
            M_DataGridView = p1.M_DataGridView;
            M_DataGridView.M_Object = this;
            base.M_Control = M_DataGridView;
            M_DataGridView.CellBeginEdit += M_DataGridView_CellBeginEdit;
            M_DataGridView.CellClick += M_DataGridView_CellClick;
            M_DataGridView.CellContentClick += M_DataGridView_CellContentClick;
            M_DataGridView.CellDoubleClick += M_DataGridView_CellDoubleClick;
            M_DataGridView.CellEndEdit += M_DataGridView_CellEndEdit;
            M_DataGridView.CellEnter += M_DataGridView_CellEnter;
            M_DataGridView.CellLeave += M_DataGridView_CellLeave;
            M_DataGridView.CellMouseDown += M_DataGridView_CellMouseDown;
            M_DataGridView.CellMouseEnter += M_DataGridView_CellMouseEnter;
            M_DataGridView.CellMouseLeave += M_DataGridView_CellMouseLeave;
            M_DataGridView.CellMouseMove += M_DataGridView_CellMouseMove;
            M_DataGridView.CellMouseUp += M_DataGridView_CellMouseUp;
            M_DataGridView.CellValueChanged += M_DataGridView_CellValueChanged;
            M_DataGridView.ColumnHeaderMouseClick += M_DataGridView_ColumnHeaderMouseClick;
            M_DataGridView.CurrentCellChanged += M_DataGridView_CurrentCellChanged;
            M_DataGridView.RowEnter += M_DataGridView_RowEnter;
            M_DataGridView.RowHeaderMouseClick += M_DataGridView_RowHeaderMouseClick;
            M_DataGridView.RowLeave += M_DataGridView_RowLeave;
            M_DataGridView.CellFormatting += M_DataGridView_CellFormatting;
            M_DataGridView.RowPrePaint += M_DataGridView_RowPrePaint;
            M_DataGridView.RowPostPaint += M_DataGridView_RowPostPaint;
            M_DataGridView.DataError += M_DataGridView_DataError;
            CellBeginEdit = "";
            CellClick = "";
            CellContentClick = "";
            CellDoubleClick = "";
            CellEndEdit = "";
            CellEnter = "";
            CellLeave = "";
            CellMouseDown = "";
            CellMouseEnter = "";
            CellMouseLeave = "";
            CellMouseMove = "";
            CellMouseUp = "";
            CellValueChanged = "";
            ColumnHeaderMouseClick = "";
            CurrentCellChanged = "";
            RowEnter = "";
            RowHeaderMouseClick = "";
            RowLeave = "";
            ArrowRowHeaders = true;
            AutoNumberingRows = false;
            typeof(System.Windows.Forms.DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, M_DataGridView, new object[] { true });
        }

        public DataGridView(System.Windows.Forms.DataGridView p1)
        {
            M_DataGridView = (DataGridViewEx)p1;
            M_DataGridView.M_Object = this;
            base.M_Control = M_DataGridView;
            M_DataGridView.CellBeginEdit += M_DataGridView_CellBeginEdit;
            M_DataGridView.CellClick += M_DataGridView_CellClick;
            M_DataGridView.CellContentClick += M_DataGridView_CellContentClick;
            M_DataGridView.CellDoubleClick += M_DataGridView_CellDoubleClick;
            M_DataGridView.CellEndEdit += M_DataGridView_CellEndEdit;
            M_DataGridView.CellEnter += M_DataGridView_CellEnter;
            M_DataGridView.CellLeave += M_DataGridView_CellLeave;
            M_DataGridView.CellMouseDown += M_DataGridView_CellMouseDown;
            M_DataGridView.CellMouseEnter += M_DataGridView_CellMouseEnter;
            M_DataGridView.CellMouseLeave += M_DataGridView_CellMouseLeave;
            M_DataGridView.CellMouseMove += M_DataGridView_CellMouseMove;
            M_DataGridView.CellMouseUp += M_DataGridView_CellMouseUp;
            M_DataGridView.CellValueChanged += M_DataGridView_CellValueChanged;
            M_DataGridView.ColumnHeaderMouseClick += M_DataGridView_ColumnHeaderMouseClick;
            M_DataGridView.CurrentCellChanged += M_DataGridView_CurrentCellChanged;
            M_DataGridView.RowEnter += M_DataGridView_RowEnter;
            M_DataGridView.RowHeaderMouseClick += M_DataGridView_RowHeaderMouseClick;
            M_DataGridView.RowLeave += M_DataGridView_RowLeave;
            M_DataGridView.CellFormatting += M_DataGridView_CellFormatting;
            M_DataGridView.RowPrePaint += M_DataGridView_RowPrePaint;
            M_DataGridView.RowPostPaint += M_DataGridView_RowPostPaint;
            M_DataGridView.DataError += M_DataGridView_DataError;
            CellBeginEdit = "";
            CellClick = "";
            CellContentClick = "";
            CellDoubleClick = "";
            CellEndEdit = "";
            CellEnter = "";
            CellLeave = "";
            CellMouseDown = "";
            CellMouseEnter = "";
            CellMouseLeave = "";
            CellMouseMove = "";
            CellMouseUp = "";
            CellValueChanged = "";
            ColumnHeaderMouseClick = "";
            CurrentCellChanged = "";
            RowEnter = "";
            RowHeaderMouseClick = "";
            RowLeave = "";
            ArrowRowHeaders = true;
            AutoNumberingRows = false;
            typeof(System.Windows.Forms.DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null, M_DataGridView, new object[] { true });
        }

        public bool AllowUserToAddRows
        {
            get { return M_DataGridView.AllowUserToAddRows; }
            set { M_DataGridView.AllowUserToAddRows = value; }
        }

        public bool AllowUserToResizeColumns
        {
            get { return M_DataGridView.AllowUserToResizeColumns; }
            set { M_DataGridView.AllowUserToResizeColumns = value; }
        }

        public bool AllowUserToResizeRows
        {
            get { return M_DataGridView.AllowUserToResizeRows; }
            set { M_DataGridView.AllowUserToResizeRows = value; }
        }

        public bool AutoGenerateColumns
        {
            get { return M_DataGridView.AutoGenerateColumns; }
            set { M_DataGridView.AutoGenerateColumns = value; }
        }

        public int AutoResizeRowHeadersWidth
        {
            get { return (int)M_DataGridView.RowHeadersWidthSizeMode; }
            set { M_DataGridView.RowHeadersWidthSizeMode = (System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode)value; }
        }

        public int AutoSizeColumnsMode
        {
            get { return (int)M_DataGridView.AutoSizeColumnsMode; }
            set { M_DataGridView.AutoSizeColumnsMode = (System.Windows.Forms.DataGridViewAutoSizeColumnsMode)value; }
        }

        public int AutoSizeRowsMode
        {
            get { return (int)M_DataGridView.AutoSizeRowsMode; }
            set { M_DataGridView.AutoSizeRowsMode = (System.Windows.Forms.DataGridViewAutoSizeRowsMode)value; }
        }

        public osf.Color BackgroundColor
        {
            get { return new Color(M_DataGridView.BackgroundColor); }
            set
            {
                M_DataGridView.BackgroundColor = value.M_Color;
                //System.Windows.Forms.Application.DoEvents();
            }
        }

        public int ColumnCount
        {
            get { return M_DataGridView.ColumnCount; }
            set { M_DataGridView.ColumnCount = value; }
        }

        public osf.DataGridViewCellStyle ColumnHeadersDefaultCellStyle
        {
            get { return new DataGridViewCellStyle(M_DataGridView.ColumnHeadersDefaultCellStyle); }
            set { M_DataGridView.ColumnHeadersDefaultCellStyle = value.M_DataGridViewCellStyle; }
        }

        public int ColumnHeadersHeight
        {
            get { return M_DataGridView.ColumnHeadersHeight; }
            set { M_DataGridView.ColumnHeadersHeight = value; }
        }

        public osf.DataGridViewColumnCollection Columns
        {
            get { return new osf.DataGridViewColumnCollection(M_DataGridView.Columns); }
        }

        public dynamic CurrentCell
        {
            get
            {
                dynamic Obj1 = null;
                string str1 = M_DataGridView.CurrentCell.GetType().ToString();
                string str2 = str1.Replace("System.Windows.Forms.", "osf.");
                System.Type Type1 = System.Type.GetType(str2, false, true);
                object[] args1 = { M_DataGridView.CurrentCell };
                Obj1 = Activator.CreateInstance(Type1, args1);

                return Obj1;
            }
            set { M_DataGridView.CurrentCell = value.M_DataGridViewCell; }
        }

        public osf.DataGridViewRow CurrentRow
        {
            get { return new DataGridViewRow(M_DataGridView.CurrentRow); }
        }

        public string DataMember
        {
            get { return M_DataGridView.DataMember; }
            set { M_DataGridView.DataMember = value; }
        }

        public object DataSource
        {
            get
            {
                if (M_DataGridView.DataSource != null)
                {
                    if (M_DataGridView.DataSource.GetType() == typeof(System.Data.DataView))
                    {
                        osf.DataView DataView1 = new osf.DataView((System.Data.DataView)M_DataGridView.DataSource);
                        return (dynamic)DataView1;
                    }
                    else
                    {
                        return ((dynamic)M_DataGridView.DataSource).M_Object;
                    }
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    System.Type Type1 = ((dynamic)value).GetType();
                    string strType1 = Type1.ToString();
                    string str1 = strType1.Substring(strType1.LastIndexOf(".") + 1);
                    M_DataGridView.DataSource = Type1.GetField("M_" + str1).GetValue(value);
                    //System.Windows.Forms.Application.DoEvents();
                }
                else
                {
                    M_DataGridView.DataSource = null;
                }
            }
        }

        public bool ReadOnly
        {
            get { return M_DataGridView.ReadOnly; }
            set { M_DataGridView.ReadOnly = value; }
        }

        public int RowCount
        {
            get { return M_DataGridView.RowCount; }
            set { M_DataGridView.RowCount = value; }
        }

        public osf.DataGridViewCellStyle RowHeadersDefaultCellStyle
        {
            get { return new DataGridViewCellStyle(M_DataGridView.RowHeadersDefaultCellStyle); }
            set { M_DataGridView.RowHeadersDefaultCellStyle = value.M_DataGridViewCellStyle; }
        }

        public int RowHeadersWidth
        {
            get { return M_DataGridView.RowHeadersWidth; }
            set { M_DataGridView.RowHeadersWidth = value; }
        }

        public osf.DataGridViewRowCollection Rows
        {
            get { return new DataGridViewRowCollection(M_DataGridView.Rows); }
        }

        public int ScrollBars
        {
            get { return (int)M_DataGridView.ScrollBars; }
            set { M_DataGridView.ScrollBars = (System.Windows.Forms.ScrollBars)value; }
        }

        public int SelectionMode
        {
            get { return (int)M_DataGridView.SelectionMode; }
            set { M_DataGridView.SelectionMode = (System.Windows.Forms.DataGridViewSelectionMode)value; }
        }

        public bool BeginEdit(bool p1)
        {
            return M_DataGridView.BeginEdit(p1);
        }

        public bool EndEdit()
        {
            return M_DataGridView.EndEdit();
        }

        private void M_DataGridView_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (CellBeginEdit.Length > 0)
            {
                DataGridViewCellCancelEventArgs DataGridViewCellCancelEventArgs1 = new DataGridViewCellCancelEventArgs();
                DataGridViewCellCancelEventArgs1.EventString = CellBeginEdit;
                DataGridViewCellCancelEventArgs1.Sender = this;
                DataGridViewCellCancelEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellCancelEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellCancelEventArgs1.Cancel = e.Cancel;
                DataGridViewCellCancelEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellBeginEdit);
                ClDataGridViewCellCancelEventArgs ClDataGridViewCellCancelEventArgs1 = new ClDataGridViewCellCancelEventArgs(DataGridViewCellCancelEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellCancelEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellBeginEdit);
                e.Cancel = DataGridViewCellCancelEventArgs1.Cancel;
            }
        }

        private void M_DataGridView_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellClick.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellClick;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellClick);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellClick);
            }
        }

        private void M_DataGridView_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellContentClick.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellContentClick;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellContentClick);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellContentClick);
            }
        }

        private void M_DataGridView_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellDoubleClick;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellDoubleClick);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellDoubleClick);
            }
        }

        private void M_DataGridView_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellEndEdit.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellEndEdit;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellEndEdit);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellEndEdit);
            }
        }

        private void M_DataGridView_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellEnter.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellEnter;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellEnter);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellEnter);
            }
        }

        private void M_DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (AutoNumberingRows)
            {
                ((System.Windows.Forms.DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
            }
        }

        private void M_DataGridView_CellLeave(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellLeave.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellLeave;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellLeave);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellLeave);
            }
        }

        private void M_DataGridView_CellMouseDown(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (CellMouseDown.Length > 0)
            {
                DataGridViewCellMouseEventArgs DataGridViewCellMouseEventArgs1 = new DataGridViewCellMouseEventArgs();
                DataGridViewCellMouseEventArgs1.EventString = CellMouseDown;
                DataGridViewCellMouseEventArgs1.Sender = this;
                DataGridViewCellMouseEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellMouseEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellMouseEventArgs1.Button = (int)e.Button;
                DataGridViewCellMouseEventArgs1.Clicks = e.Clicks;
                DataGridViewCellMouseEventArgs1.X = e.X;
                DataGridViewCellMouseEventArgs1.Y = e.Y;
                DataGridViewCellMouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellMouseDown);
                ClDataGridViewCellMouseEventArgs ClDataGridViewCellMouseEventArgs1 = new ClDataGridViewCellMouseEventArgs(DataGridViewCellMouseEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellMouseEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellMouseDown);
            }
        }

        private void M_DataGridView_CellMouseEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellMouseEnter.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellMouseEnter;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellMouseEnter);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellMouseEnter);
            }
        }

        private void M_DataGridView_CellMouseLeave(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellMouseLeave.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellMouseLeave;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellMouseLeave);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellMouseLeave);
            }
        }

        private void M_DataGridView_CellMouseMove(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (CellMouseMove.Length > 0)
            {
                DataGridViewCellMouseEventArgs DataGridViewCellMouseEventArgs1 = new DataGridViewCellMouseEventArgs();
                DataGridViewCellMouseEventArgs1.EventString = CellMouseMove;
                DataGridViewCellMouseEventArgs1.Sender = this;
                DataGridViewCellMouseEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellMouseEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellMouseEventArgs1.Button = (int)e.Button;
                DataGridViewCellMouseEventArgs1.Clicks = e.Clicks;
                DataGridViewCellMouseEventArgs1.X = e.X;
                DataGridViewCellMouseEventArgs1.Y = e.Y;
                DataGridViewCellMouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellMouseMove);
                ClDataGridViewCellMouseEventArgs ClDataGridViewCellMouseEventArgs1 = new ClDataGridViewCellMouseEventArgs(DataGridViewCellMouseEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellMouseEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellMouseMove);
            }
        }

        private void M_DataGridView_CellMouseUp(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (CellMouseUp.Length > 0)
            {
                DataGridViewCellMouseEventArgs DataGridViewCellMouseEventArgs1 = new DataGridViewCellMouseEventArgs();
                DataGridViewCellMouseEventArgs1.EventString = CellMouseUp;
                DataGridViewCellMouseEventArgs1.Sender = this;
                DataGridViewCellMouseEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellMouseEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellMouseEventArgs1.Button = (int)e.Button;
                DataGridViewCellMouseEventArgs1.Clicks = e.Clicks;
                DataGridViewCellMouseEventArgs1.X = e.X;
                DataGridViewCellMouseEventArgs1.Y = e.Y;
                DataGridViewCellMouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellMouseUp);
                ClDataGridViewCellMouseEventArgs ClDataGridViewCellMouseEventArgs1 = new ClDataGridViewCellMouseEventArgs(DataGridViewCellMouseEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellMouseEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellMouseUp);
            }
        }

        private void M_DataGridView_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CellValueChanged.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = CellValueChanged;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CellValueChanged);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CellValueChanged);
            }
        }

        private void M_DataGridView_ColumnHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (ColumnHeaderMouseClick.Length > 0)
            {
                DataGridViewCellMouseEventArgs DataGridViewCellMouseEventArgs1 = new DataGridViewCellMouseEventArgs();
                DataGridViewCellMouseEventArgs1.EventString = ColumnHeaderMouseClick;
                DataGridViewCellMouseEventArgs1.Sender = this;
                DataGridViewCellMouseEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellMouseEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellMouseEventArgs1.Button = (int)e.Button;
                DataGridViewCellMouseEventArgs1.Clicks = e.Clicks;
                DataGridViewCellMouseEventArgs1.X = e.X;
                DataGridViewCellMouseEventArgs1.Y = e.Y;
                DataGridViewCellMouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.ColumnHeaderMouseClick);
                ClDataGridViewCellMouseEventArgs ClDataGridViewCellMouseEventArgs1 = new ClDataGridViewCellMouseEventArgs(DataGridViewCellMouseEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellMouseEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.ColumnHeaderMouseClick);
            }
        }

        public void M_DataGridView_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (CurrentCellChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = CurrentCellChanged;
                EventArgs1.Sender = this;
                EventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.CurrentCellChanged);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
                OneScriptForms.Event = ClEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.CurrentCellChanged);
            }
        }

        private void M_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context.ToString() == "InitialValueRestoration")
            {
                e.ThrowException = false;
            }
        }

        private void M_DataGridView_RowEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (RowEnter.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = RowEnter;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.RowEnter);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.RowEnter);
            }
        }

        private void M_DataGridView_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (RowHeaderMouseClick.Length > 0)
            {
                DataGridViewCellMouseEventArgs DataGridViewCellMouseEventArgs1 = new DataGridViewCellMouseEventArgs();
                DataGridViewCellMouseEventArgs1.EventString = RowHeaderMouseClick;
                DataGridViewCellMouseEventArgs1.Sender = this;
                DataGridViewCellMouseEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellMouseEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellMouseEventArgs1.Button = (int)e.Button;
                DataGridViewCellMouseEventArgs1.Clicks = e.Clicks;
                DataGridViewCellMouseEventArgs1.X = e.X;
                DataGridViewCellMouseEventArgs1.Y = e.Y;
                DataGridViewCellMouseEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.RowHeaderMouseClick);
                ClDataGridViewCellMouseEventArgs ClDataGridViewCellMouseEventArgs1 = new ClDataGridViewCellMouseEventArgs(DataGridViewCellMouseEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellMouseEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.RowHeaderMouseClick);
            }
        }

        private void M_DataGridView_RowLeave(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (RowLeave.Length > 0)
            {
                DataGridViewCellEventArgs DataGridViewCellEventArgs1 = new DataGridViewCellEventArgs();
                DataGridViewCellEventArgs1.EventString = RowLeave;
                DataGridViewCellEventArgs1.Sender = this;
                DataGridViewCellEventArgs1.ColumnIndex = e.ColumnIndex;
                DataGridViewCellEventArgs1.RowIndex = e.RowIndex;
                DataGridViewCellEventArgs1.Parameter = OneScriptForms.GetEventParameter(((dynamic)sender).M_Object.dll_obj.RowLeave);
                ClDataGridViewCellEventArgs ClDataGridViewCellEventArgs1 = new ClDataGridViewCellEventArgs(DataGridViewCellEventArgs1);
                OneScriptForms.Event = ClDataGridViewCellEventArgs1;
                OneScriptForms.ExecuteEvent(((dynamic)sender).M_Object.dll_obj.RowLeave);
            }
        }

        private void M_DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (!ArrowRowHeaders)
            {
                object o = M_DataGridView.Rows[e.RowIndex].HeaderCell.Value;
                string str1 = "";
                if (o != null)
                {
                    str1 = o.ToString();
                }
                e.Graphics.DrawString(
                    str1,
                    M_DataGridView.Font,
                    new SolidBrush(M_DataGridView.RowHeadersDefaultCellStyle.ForeColor),
                    new System.Drawing.PointF((float)e.RowBounds.Left + 5, (float)e.RowBounds.Top + 2));
            }
        }

        private void M_DataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!ArrowRowHeaders)
            {
                int x = e.ClipBounds.X;
                int y = e.ClipBounds.Y;
                int w = e.ClipBounds.Width;
                int h = e.ClipBounds.Height;
                System.Drawing.Rectangle Rectangle1 = new System.Drawing.Rectangle(x, y, w, h);
                e.ClipBounds = Rectangle1;
                e.PaintCells(Rectangle1, DataGridViewPaintParts.All);
                e.PaintHeader(DataGridViewPaintParts.Background
                    | DataGridViewPaintParts.Border
                    | DataGridViewPaintParts.Focus
                    | DataGridViewPaintParts.SelectionBackground
                    | DataGridViewPaintParts.ContentForeground);
                e.Handled = true;
            }
        }
    }

    [ContextClass ("КлТаблица", "ClDataGridView")]
    public class ClDataGridView : AutoContext<ClDataGridView>
    {
        private IValue _CellBeginEdit;
        private IValue _CellClick;
        private IValue _CellContentClick;
        private IValue _CellDoubleClick;
        private IValue _CellEndEdit;
        private IValue _CellEnter;
        private IValue _CellLeave;
        private IValue _CellMouseDown;
        private IValue _CellMouseEnter;
        private IValue _CellMouseLeave;
        private IValue _CellMouseMove;
        private IValue _CellMouseUp;
        private IValue _CellValueChanged;
        private IValue _Click;
        private IValue _ColumnHeaderMouseClick;
        private IValue _ControlAdded;
        private IValue _ControlRemoved;
        private IValue _CurrentCellChanged;
        private IValue _DoubleClick;
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
        private IValue _RowEnter;
        private IValue _RowHeaderMouseClick;
        private IValue _RowLeave;
        private IValue _SizeChanged;
        private IValue _TextChanged;
        private ClColor backColor;
        private ClColor backgroundColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClCursor cursor;
        private ClFont font;
        private ClColor foreColor;
        private ClCollection tag = new ClCollection();

        public ClDataGridView()
        {
            DataGridView DataGridView1 = new DataGridView();
            DataGridView1.dll_obj = this;
            Base_obj = DataGridView1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            backgroundColor = new ClColor(Base_obj.BackgroundColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClDataGridView(DataGridView p1)
        {
            DataGridView DataGridView1 = p1;
            DataGridView1.dll_obj = this;
            Base_obj = DataGridView1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            backgroundColor = new ClColor(Base_obj.BackgroundColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public DataGridView Base_obj;
        
        [ContextProperty("АвтоНумерацияСтрок", "AutoNumberingRows")]
        public bool AutoNumberingRows
        {
            get { return Base_obj.AutoNumberingRows; }
            set { Base_obj.AutoNumberingRows = value; }
        }

        [ContextProperty("АвтоСозданиеКолонок", "AutoGenerateColumns")]
        public bool AutoGenerateColumns
        {
            get { return Base_obj.AutoGenerateColumns; }
            set { Base_obj.AutoGenerateColumns = value; }
        }

        [ContextProperty("АвтоШиринаЗаголовковСтрок", "AutoResizeRowHeadersWidth")]
        public int AutoResizeRowHeadersWidth
        {
            get { return (int)Base_obj.AutoResizeRowHeadersWidth; }
            set { Base_obj.AutoResizeRowHeadersWidth = value; }
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

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
            set { Base_obj.Height = value; }
        }

        [ContextProperty("ВысотаЗаголовковКолонок", "ColumnHeadersHeight")]
        public int ColumnHeadersHeight
        {
            get { return Base_obj.ColumnHeadersHeight; }
            set { Base_obj.ColumnHeadersHeight = value; }
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
        
        [ContextProperty("ДвойноеНажатиеЯчейки", "CellDoubleClick")]
        public IValue CellDoubleClick
        {
            get { return _CellDoubleClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellDoubleClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellDoubleClick = "DelegateActionCellDoubleClick";
                }
                else
                {
                    _CellDoubleClick = value;
                    Base_obj.CellDoubleClick = "osfActionCellDoubleClick";
                }
            }
        }
        
        [ContextProperty("ДобавлятьСтроки", "AllowUserToAddRows")]
        public bool AllowUserToAddRows
        {
            get { return Base_obj.AllowUserToAddRows; }
            set { Base_obj.AllowUserToAddRows = value; }
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

        [ContextProperty("ЗначениеЯчейкиИзменено", "CellValueChanged")]
        public IValue CellValueChanged
        {
            get { return _CellValueChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellValueChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellValueChanged = "DelegateActionCellValueChanged";
                }
                else
                {
                    _CellValueChanged = value;
                    Base_obj.CellValueChanged = "osfActionCellValueChanged";
                }
            }
        }
        
        [ContextProperty("ИзменятьРазмерКолонок", "AllowUserToResizeColumns")]
        public bool AllowUserToResizeColumns
        {
            get { return Base_obj.AllowUserToResizeColumns; }
            set { Base_obj.AllowUserToResizeColumns = value; }
        }

        [ContextProperty("ИзменятьРазмерСтрок", "AllowUserToResizeRows")]
        public bool AllowUserToResizeRows
        {
            get { return Base_obj.AllowUserToResizeRows; }
            set { Base_obj.AllowUserToResizeRows = value; }
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

        [ContextProperty("КоличествоКолонок", "ColumnCount")]
        public int ColumnCount
        {
            get { return Base_obj.ColumnCount; }
            set { Base_obj.ColumnCount = value; }
        }

        [ContextProperty("КоличествоСтрок", "RowCount")]
        public int RowCount
        {
            get { return Base_obj.RowCount; }
            set { Base_obj.RowCount = value; }
        }

        [ContextProperty("Колонки", "Columns")]
        public ClDataGridViewColumnCollection Columns
        {
            get { return (ClDataGridViewColumnCollection)OneScriptForms.RevertObj(Base_obj.Columns); }
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
        
        [ContextProperty("МышьНадЯчейкой", "CellMouseEnter")]
        public IValue CellMouseEnter
        {
            get { return _CellMouseEnter; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellMouseEnter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellMouseEnter = "DelegateActionCellMouseEnter";
                }
                else
                {
                    _CellMouseEnter = value;
                    Base_obj.CellMouseEnter = "osfActionCellMouseEnter";
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
        
        [ContextProperty("МышьПокинулаЯчейку", "CellMouseLeave")]
        public IValue CellMouseLeave
        {
            get { return _CellMouseLeave; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellMouseLeave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellMouseLeave = "DelegateActionCellMouseLeave";
                }
                else
                {
                    _CellMouseLeave = value;
                    Base_obj.CellMouseLeave = "osfActionCellMouseLeave";
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
        
        [ContextProperty("НажатиеСодержимогоЯчейки", "CellContentClick")]
        public IValue CellContentClick
        {
            get { return _CellContentClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellContentClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellContentClick = "DelegateActionCellContentClick";
                }
                else
                {
                    _CellContentClick = value;
                    Base_obj.CellContentClick = "osfActionCellContentClick";
                }
            }
        }
        
        [ContextProperty("НажатиеЯчейки", "CellClick")]
        public IValue CellClick
        {
            get { return _CellClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellClick = "DelegateActionCellClick";
                }
                else
                {
                    _CellClick = value;
                    Base_obj.CellClick = "osfActionCellClick";
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
        
        [ContextProperty("ПолосыПрокрутки", "ScrollBars")]
        public int ScrollBars
        {
            get { return (int)Base_obj.ScrollBars; }
            set { Base_obj.ScrollBars = value; }
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
        
        [ContextProperty("ПриВходеВСтроку", "RowEnter")]
        public IValue RowEnter
        {
            get { return _RowEnter; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _RowEnter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.RowEnter = "DelegateActionRowEnter";
                }
                else
                {
                    _RowEnter = value;
                    Base_obj.RowEnter = "osfActionRowEnter";
                }
            }
        }
        
        [ContextProperty("ПриВходеВЯчейку", "CellEnter")]
        public IValue CellEnter
        {
            get { return _CellEnter; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellEnter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellEnter = "DelegateActionCellEnter";
                }
                else
                {
                    _CellEnter = value;
                    Base_obj.CellEnter = "osfActionCellEnter";
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
        
        [ContextProperty("ПриНажатииЗаголовкаКолонки", "ColumnHeaderMouseClick")]
        public IValue ColumnHeaderMouseClick
        {
            get { return _ColumnHeaderMouseClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _ColumnHeaderMouseClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ColumnHeaderMouseClick = "DelegateActionColumnHeaderMouseClick";
                }
                else
                {
                    _ColumnHeaderMouseClick = value;
                    Base_obj.ColumnHeaderMouseClick = "osfActionColumnHeaderMouseClick";
                }
            }
        }
        
        [ContextProperty("ПриНажатииЗаголовкаСтроки", "RowHeaderMouseClick")]
        public IValue RowHeaderMouseClick
        {
            get { return _RowHeaderMouseClick; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _RowHeaderMouseClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.RowHeaderMouseClick = "DelegateActionRowHeaderMouseClick";
                }
                else
                {
                    _RowHeaderMouseClick = value;
                    Base_obj.RowHeaderMouseClick = "osfActionRowHeaderMouseClick";
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
        
        [ContextProperty("ПриНажатииКнопкиМышиВЯчейке", "CellMouseDown")]
        public IValue CellMouseDown
        {
            get { return _CellMouseDown; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellMouseDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellMouseDown = "DelegateActionCellMouseDown";
                }
                else
                {
                    _CellMouseDown = value;
                    Base_obj.CellMouseDown = "osfActionCellMouseDown";
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
        
        [ContextProperty("ПриОтпусканииМышиНадЯчейкой", "CellMouseUp")]
        public IValue CellMouseUp
        {
            get { return _CellMouseUp; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellMouseUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellMouseUp = "DelegateActionCellMouseUp";
                }
                else
                {
                    _CellMouseUp = value;
                    Base_obj.CellMouseUp = "osfActionCellMouseUp";
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
        
        [ContextProperty("ПриПеремещенииМышиНадЯчейкой", "CellMouseMove")]
        public IValue CellMouseMove
        {
            get { return _CellMouseMove; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellMouseMove = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellMouseMove = "DelegateActionCellMouseMove";
                }
                else
                {
                    _CellMouseMove = value;
                    Base_obj.CellMouseMove = "osfActionCellMouseMove";
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
        
        [ContextProperty("ПриУходеИзСтроки", "RowLeave")]
        public IValue RowLeave
        {
            get { return _RowLeave; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _RowLeave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.RowLeave = "DelegateActionRowLeave";
                }
                else
                {
                    _RowLeave = value;
                    Base_obj.RowLeave = "osfActionRowLeave";
                }
            }
        }
        
        [ContextProperty("ПриУходеИзЯчейки", "CellLeave")]
        public IValue CellLeave
        {
            get { return _CellLeave; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellLeave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellLeave = "DelegateActionCellLeave";
                }
                else
                {
                    _CellLeave = value;
                    Base_obj.CellLeave = "osfActionCellLeave";
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
        
        [ContextProperty("РедактированиеЯчейкиЗавершено", "CellEndEdit")]
        public IValue CellEndEdit
        {
            get { return _CellEndEdit; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellEndEdit = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellEndEdit = "DelegateActionCellEndEdit";
                }
                else
                {
                    _CellEndEdit = value;
                    Base_obj.CellEndEdit = "osfActionCellEndEdit";
                }
            }
        }
        
        [ContextProperty("РедактированиеЯчейкиНачато", "CellBeginEdit")]
        public IValue CellBeginEdit
        {
            get { return _CellBeginEdit; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CellBeginEdit = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CellBeginEdit = "DelegateActionCellBeginEdit";
                }
                else
                {
                    _CellBeginEdit = value;
                    Base_obj.CellBeginEdit = "osfActionCellBeginEdit";
                }
            }
        }
        
        [ContextProperty("РежимАвтоРазмераКолонок", "AutoSizeColumnsMode")]
        public int AutoSizeColumnsMode
        {
            get { return (int)Base_obj.AutoSizeColumnsMode; }
            set { Base_obj.AutoSizeColumnsMode = value; }
        }

        [ContextProperty("РежимАвтоРазмераСтрок", "AutoSizeRowsMode")]
        public int AutoSizeRowsMode
        {
            get { return (int)Base_obj.AutoSizeRowsMode; }
            set { Base_obj.AutoSizeRowsMode = value; }
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
        
        [ContextProperty("СтильЗаголовковКолонок", "ColumnHeadersDefaultCellStyle")]
        public ClDataGridViewCellStyle ColumnHeadersDefaultCellStyle
        {
            get { return (ClDataGridViewCellStyle)OneScriptForms.RevertObj(Base_obj.ColumnHeadersDefaultCellStyle); }
            set { Base_obj.ColumnHeadersDefaultCellStyle = value.Base_obj; }
        }

        [ContextProperty("СтильЗаголовковСтрок", "RowHeadersDefaultCellStyle")]
        public ClDataGridViewCellStyle RowHeadersDefaultCellStyle
        {
            get { return (ClDataGridViewCellStyle)OneScriptForms.RevertObj(Base_obj.RowHeadersDefaultCellStyle); }
            set { Base_obj.RowHeadersDefaultCellStyle = value.Base_obj; }
        }

        [ContextProperty("СтрелкаЗаголовковСтрок", "ArrowRowHeaders")]
        public bool ArrowRowHeaders
        {
            get { return Base_obj.ArrowRowHeaders; }
            set { Base_obj.ArrowRowHeaders = value; }
        }

        [ContextProperty("Строки", "Rows")]
        public ClDataGridViewRowCollection Rows
        {
            get { return (ClDataGridViewRowCollection)OneScriptForms.RevertObj(Base_obj.Rows); }
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
        
        [ContextProperty("ТекущаяСтрока", "CurrentRow")]
        public ClDataGridViewRow CurrentRow
        {
            get { return (ClDataGridViewRow)OneScriptForms.RevertObj(Base_obj.CurrentRow); }
        }

        [ContextProperty("ТекущаяЯчейка", "CurrentCell")]
        public IValue CurrentCell
        {
            get { return OneScriptForms.RevertObj(Base_obj.CurrentCell); }
            set { Base_obj.CurrentCell = ((dynamic)value).Base_obj; }
        }

        [ContextProperty("ТекущаяЯчейкаИзменена", "CurrentCellChanged")]
        public IValue CurrentCellChanged
        {
            get { return _CurrentCellChanged; }
            set
            {
                if (value.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    _CurrentCellChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CurrentCellChanged = "DelegateActionCurrentCellChanged";
                }
                else
                {
                    _CurrentCellChanged = value;
                    Base_obj.CurrentCellChanged = "osfActionCurrentCellChanged";
                }
            }
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

        [ContextProperty("ЦветФонаТаблицы", "BackgroundColor")]
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

        [ContextProperty("ШиринаЗаголовковСтрок", "RowHeadersWidth")]
        public int RowHeadersWidth
        {
            get { return Base_obj.RowHeadersWidth; }
            set { Base_obj.RowHeadersWidth = value; }
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
        
        [ContextMethod("ЗавершитьОбновление", "EndUpdate")]
        public void EndUpdate()
        {
            Base_obj.EndUpdate();
        }
					
        [ContextMethod("ЗавершитьРедактирование", "EndEdit")]
        public bool EndEdit()
        {
            return Base_obj.EndEdit();
        }

        [ContextMethod("Колонки", "Columns")]
        public IValue Columns2(int p1)
        {
            dynamic Obj1 = null;
            string str1 = Base_obj.Columns[p1].GetType().ToString();
            string str2 = str1.Replace("System.Windows.Forms.", "osf.");
            System.Type Type1 = System.Type.GetType(str2, false, true);
            object[] args1 = { Base_obj.Columns[p1] };
            Obj1 = Activator.CreateInstance(Type1, args1);
            return OneScriptForms.RevertObj(Obj1);
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
					
        [ContextMethod("НачатьРедактирование", "BeginEdit")]
        public bool BeginEdit(bool p1)
        {
            return Base_obj.BeginEdit(p1);
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
					
        [ContextMethod("Строки", "Rows")]
        public ClDataGridViewRow Rows2(int p1)
        {
            return (ClDataGridViewRow)OneScriptForms.RevertObj(Base_obj.Rows[p1]);
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
        
        [ContextMethod("ЭлементыУправления", "Controls")]
        public IValue Controls2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
        }

        [ContextMethod("Ячейка", "Cell")]
        public IValue Cell2(int p1, int p2)
        {
            dynamic Obj1 = null;
            string str1 = Base_obj.M_DataGridView.Rows[p2].Cells[p1].GetType().ToString();
            string str2 = str1.Replace("System.Windows.Forms.", "osf.");
            System.Type Type1 = System.Type.GetType(str2, false, true);
            object[] args1 = { Base_obj.M_DataGridView.Rows[p2].Cells[p1] };
            Obj1 = Activator.CreateInstance(Type1, args1);
            return OneScriptForms.RevertObj(Obj1);
        }
    }
}
