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
    [ContextClass ("КлСтильПоляВыбораЯчейки", "ClDataGridViewComboBoxDisplayStyle")]
    public class ClDataGridViewComboBoxDisplayStyle : AutoContext<ClDataGridViewComboBoxDisplayStyle>
    {
        private int m_comboBox = (int)System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox; // 0 Ячейка <A href="OneScriptForms.DataGridViewComboBoxCell.html">ПолеВыбораЯчейки&nbsp;(DataGridViewComboBoxCell)</A> не находится в режиме редактирования, ее внешний вид аналогичен элементу управления <A href="OneScriptForms.ComboBox.html">ПолеВыбора&nbsp;(ComboBox)</A>.
        private int m_dropDownButton = (int)System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton; // 1 Если ячейка <A href="OneScriptForms.DataGridViewComboBoxCell.html">ПолеВыбораЯчейки&nbsp;(DataGridViewComboBoxCell)</A> не находится в режиме редактирования, в ней отображается кнопка раскрывающегося списка, но в остальном ее внешний вид отличается от элемента управления <A href="OneScriptForms.ComboBox.html">ПолеВыбора&nbsp;(ComboBox)</A>.
        private int m_nothing = (int)System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing; // 2 Ячейка <A href="OneScriptForms.DataGridViewComboBoxCell.html">ПолеВыбораЯчейки&nbsp;(DataGridViewComboBoxCell)</A> не находится в режиме редактирования, она отображается без кнопки раскрывающегося списка.

        [ContextProperty("КнопкаСписка", "DropDownButton")]
        public int DropDownButton
        {
        	get { return m_dropDownButton; }
        }

        [ContextProperty("Отсутствие", "Nothing")]
        public int Nothing
        {
        	get { return m_nothing; }
        }

        [ContextProperty("ПолеВыбора", "ComboBox")]
        public int ComboBox
        {
        	get { return m_comboBox; }
        }
    }
}
