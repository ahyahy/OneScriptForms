using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлФорматПоляКалендаря", "ClFormatDateTimePicker")]
    public class ClFormatDateTimePicker : AutoContext<ClFormatDateTimePicker>
    {
        private int m_long = (int)System.Windows.Forms.DateTimePickerFormat.Long; // 1 Элемент управления <B>ПолеКалендаря&nbsp;(DateTimePicker)</B> отображает значение даты/времени в длинном формате даты, настроенном в операционной системе пользователя.
        private int m_short = (int)System.Windows.Forms.DateTimePickerFormat.Short; // 2 Элемент управления <B>ПолеКалендаря&nbsp;(DateTimePicker)</B> отображает значение даты/времени в коротком формате даты, настроенном в операционной системе пользователя.
        private int m_time = (int)System.Windows.Forms.DateTimePickerFormat.Time; // 4 Элемент управления <B>ПолеКалендаря&nbsp;(DateTimePicker)</B> отображает значение даты/времени в формате времени, настроенном в операционной системе пользователя.
        private int m_custom = (int)System.Windows.Forms.DateTimePickerFormat.Custom; // 8 Элемент управления <B>ПолеКалендаря&nbsp;(DateTimePicker)</B> отображает значение даты/времени в пользовательском формате.

        [ContextProperty("Время", "Time")]
        public int Time
        {
        	get { return m_time; }
        }

        [ContextProperty("Длинный", "Long")]
        public int Long
        {
        	get { return m_long; }
        }

        [ContextProperty("Короткий", "Short")]
        public int Short
        {
        	get { return m_short; }
        }

        [ContextProperty("Пользовательский", "Custom")]
        public int Custom
        {
        	get { return m_custom; }
        }
    }
}
