using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлЗначокОкнаСообщений", "ClMessageBoxIcon")]
    public class ClMessageBoxIcon : AutoContext<ClMessageBoxIcon>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.MessageBoxIcon.None; // 0 Окно сообщения не содержит символов.
        private int m_stop = (int)System.Windows.Forms.MessageBoxIcon.Stop; // 16 Окно сообщения содержит символ, состоящий из белого <B>X</B> в кружке с красным фоном.
        private int m_error = (int)System.Windows.Forms.MessageBoxIcon.Error; // 16 Окно сообщения содержит символ, состоящий из белого <B>X</B> в кружке с красным фоном.
        private int m_hand = (int)System.Windows.Forms.MessageBoxIcon.Hand; // 16 Окно сообщения содержит символ, состоящий из белого <B>X</B> в кружке с красным фоном.
        private int m_question = (int)System.Windows.Forms.MessageBoxIcon.Question; // 32 Окно сообщения содержит символ, состоящий из вопросительного знака в кружке.
        private int m_exclamation = (int)System.Windows.Forms.MessageBoxIcon.Exclamation; // 48 Окно сообщения содержит символ, состоящий из восклицательного знака в треугольнике с желтым фоном.
        private int m_warning = (int)System.Windows.Forms.MessageBoxIcon.Warning; // 48 Окно сообщения содержит символ, состоящий из восклицательного знака в треугольнике с желтым фоном.
        private int m_asterisk = (int)System.Windows.Forms.MessageBoxIcon.Asterisk; // 64 Окно сообщения содержит символ, состоящий из строчной буквы в кружке.
        private int m_information = (int)System.Windows.Forms.MessageBoxIcon.Information; // 64 Окно сообщения содержит символ, состоящий из строчной буквы в кружке.

        private List<IValue> _list;

        public int Count()
        {
            return _list.Count;
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IValue>)_list).GetEnumerator();
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as IValue);
            }
        }

        internal ClMessageBoxIcon()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Asterisk));
            _list.Add(ValueFactory.Create(Error));
            _list.Add(ValueFactory.Create(Exclamation));
            _list.Add(ValueFactory.Create(Hand));
            _list.Add(ValueFactory.Create(Information));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Question));
            _list.Add(ValueFactory.Create(Stop));
            _list.Add(ValueFactory.Create(Warning));
        }

        [ContextProperty("Вопрос", "Question")]
        public int Question
        {
        	get { return m_question; }
        }

        [ContextProperty("Восклицание", "Exclamation")]
        public int Exclamation
        {
        	get { return m_exclamation; }
        }

        [ContextProperty("Звездочка", "Asterisk")]
        public int Asterisk
        {
        	get { return m_asterisk; }
        }

        [ContextProperty("Информация", "Information")]
        public int Information
        {
        	get { return m_information; }
        }

        [ContextProperty("Остановка", "Stop")]
        public int Stop
        {
        	get { return m_stop; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Ошибка", "Error")]
        public int Error
        {
        	get { return m_error; }
        }

        [ContextProperty("Предупреждение", "Warning")]
        public int Warning
        {
        	get { return m_warning; }
        }

        [ContextProperty("Рука", "Hand")]
        public int Hand
        {
        	get { return m_hand; }
        }
    }
}
