using System;
using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace osf
{
    [ContextClass ("КлРежимСортировки", "ClDataGridViewColumnSortMode")]
    public class ClDataGridViewColumnSortMode : AutoContext<ClDataGridViewColumnSortMode>
    {
        private int m_notSortable = (int)DataGridViewColumnSortMode.NotSortable; // 0 Колонка может быть отсортирована только программным способом, однако он не предназначен для сортировки, поэтому заголовок колонки не будет содержать места для глифа сортировки.
        private int m_automatic = (int)DataGridViewColumnSortMode.Automatic; // 1 Пользователь может сортировать колонку, щелкнув заголовок колонки (или нажав клавишу F3 в ячейке), если только заголовки колонок не используются для выборки. Глиф сортировки отображается автоматически.
        private int m_programmatic = (int)DataGridViewColumnSortMode.Programmatic; // 2 Колонка может быть отсортирована только программным способом, и заголовок колонки будет содержать место для глифа сортировки.

        [ContextProperty("Автоматически", "Automatic")]
        public int Automatic
        {
        	get { return m_automatic; }
        }

        [ContextProperty("НеСортируемый", "NotSortable")]
        public int NotSortable
        {
        	get { return m_notSortable; }
        }

        [ContextProperty("Программный", "Programmatic")]
        public int Programmatic
        {
        	get { return m_programmatic; }
        }
    }
}
