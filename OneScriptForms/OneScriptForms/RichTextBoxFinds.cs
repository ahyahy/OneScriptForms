using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлФорматированноеПолеВводаПоиск", "ClRichTextBoxFinds")]
    public class ClRichTextBoxFinds : AutoContext<ClRichTextBoxFinds>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.RichTextBoxFinds.None; // 0 Найти все экземпляры искомого текста, независимо от того целые это слова или нет.
        private int m_wholeWord = (int)System.Windows.Forms.RichTextBoxFinds.WholeWord; // 2 Найти только экземпляры текста с целыми словами.
        private int m_matchCase = (int)System.Windows.Forms.RichTextBoxFinds.MatchCase; // 4 Найти только экземпляры текста с точным соответствием регистра.
        private int m_noHighlight = (int)System.Windows.Forms.RichTextBoxFinds.NoHighlight; // 8 Найденный текст не будет выделен.
        private int m_reverse = (int)System.Windows.Forms.RichTextBoxFinds.Reverse; // 16 Поиск начинается с конца и продолжается до начала документа.

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

        public ClRichTextBoxFinds()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(MatchCase));
            _list.Add(ValueFactory.Create(NoHighlight));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Reverse));
            _list.Add(ValueFactory.Create(WholeWord));
        }

        [ContextProperty("НеВыделять", "NoHighlight")]
        public int NoHighlight
        {
        	get { return m_noHighlight; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("ПоискВОбратномНаправлении", "Reverse")]
        public int Reverse
        {
        	get { return m_reverse; }
        }

        [ContextProperty("ТолькоЦелыеСлова", "WholeWord")]
        public int WholeWord
        {
        	get { return m_wholeWord; }
        }

        [ContextProperty("УчитыватьРегистр", "MatchCase")]
        public int MatchCase
        {
        	get { return m_matchCase; }
        }
    }
}
