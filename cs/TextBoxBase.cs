namespace osf
{

    public class TextBoxBase : Control
    {
        private System.Windows.Forms.TextBoxBase m_TextBoxBase;

        public TextBoxBase()
        {
        }

        //Свойства============================================================

        public bool AcceptsTab
        {
            get { return M_TextBoxBase.AcceptsTab; }
            set
            {
                M_TextBoxBase.AcceptsTab = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool AutoSize
        {
            get { return M_TextBoxBase.AutoSize; }
            set
            {
                M_TextBoxBase.AutoSize = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int BorderStyle
        {
            get { return (int)M_TextBoxBase.BorderStyle; }
            set
            {
                M_TextBoxBase.BorderStyle = (System.Windows.Forms.BorderStyle)value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool CanUndo
        {
            get { return M_TextBoxBase.CanUndo; }
        }

        public bool HideSelection
        {
            get { return M_TextBoxBase.HideSelection; }
            set
            {
                M_TextBoxBase.HideSelection = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public virtual int PreferredHeight
        {
            get { return M_TextBoxBase.PreferredHeight; }
        }

        public System.Windows.Forms.TextBoxBase M_TextBoxBase
        {
            get { return m_TextBoxBase; }
            set
            {
                m_TextBoxBase = value;
                base.M_Control = m_TextBoxBase;
            }
        }

        public int MaxLength
        {
            get { return M_TextBoxBase.MaxLength; }
            set
            {
                M_TextBoxBase.MaxLength = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool Modified
        {
            get { return M_TextBoxBase.Modified; }
            set
            {
                M_TextBoxBase.Modified = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool MultiLine
        {
            get { return M_TextBoxBase.Multiline; }
            set
            {
                M_TextBoxBase.Multiline = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool ReadOnly
        {
            get { return M_TextBoxBase.ReadOnly; }
            set
            {
                M_TextBoxBase.ReadOnly = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public string SelectedText
        {
            get { return M_TextBoxBase.SelectedText; }
            set
            {
                M_TextBoxBase.SelectedText = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int SelectionLength
        {
            get { return M_TextBoxBase.SelectionLength; }
            set
            {
                M_TextBoxBase.SelectionLength = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int SelectionStart
        {
            get { return M_TextBoxBase.SelectionStart; }
            set
            {
                M_TextBoxBase.SelectionStart = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public int TextLength
        {
            get { return M_TextBoxBase.TextLength; }
        }

        public bool WordWrap
        {
            get { return M_TextBoxBase.WordWrap; }
            set
            {
                M_TextBoxBase.WordWrap = value;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        //Методы============================================================

        public void AppendText(string text)
        {
            M_TextBoxBase.AppendText(text);
            System.Windows.Forms.Application.DoEvents();
        }

        public void Copy()
        {
            M_TextBoxBase.Copy();
            System.Windows.Forms.Application.DoEvents();
        }

        public void Cut()
        {
            M_TextBoxBase.Cut();
            System.Windows.Forms.Application.DoEvents();
        }

        public void Paste()
        {
            M_TextBoxBase.Paste();
            System.Windows.Forms.Application.DoEvents();
        }

        public void ScrollToCaret()
        {
            M_TextBoxBase.ScrollToCaret();
            System.Windows.Forms.Application.DoEvents();
        }

        public void SelectAll()
        {
            M_TextBoxBase.SelectAll();
            System.Windows.Forms.Application.DoEvents();
        }

        public void Undo()
        {
            M_TextBoxBase.Undo();
            System.Windows.Forms.Application.DoEvents();
        }

    }

}
