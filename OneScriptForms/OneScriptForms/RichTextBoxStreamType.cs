using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлФорматированноеПолеВводаТипыПотоков", "ClRichTextBoxStreamType")]
    public class ClRichTextBoxStreamType : AutoContext<ClRichTextBoxStreamType>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_richText = (int)System.Windows.Forms.RichTextBoxStreamType.RichText; // 0 Форматированный текст (RTF).
        private int m_plainText = (int)System.Windows.Forms.RichTextBoxStreamType.PlainText; // 1 Поток простого текста с пробелами в местах объектов OLE.
        private int m_richNoOleObjs = (int)System.Windows.Forms.RichTextBoxStreamType.RichNoOleObjs; // 2 Форматированный текст (RTF) с пробелами вместо объектов OLE.
        private int m_textTextOleObjs = (int)System.Windows.Forms.RichTextBoxStreamType.TextTextOleObjs; // 3 Поток простого текста с текстовым представлением объектов OLE.
        private int m_unicodePlainText = (int)System.Windows.Forms.RichTextBoxStreamType.UnicodePlainText; // 4 Текст в кодировке Юникод с пробелами вместо объектов OLE. 

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

        internal ClRichTextBoxStreamType()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(PlainText));
            _list.Add(ValueFactory.Create(RichNoOleObjs));
            _list.Add(ValueFactory.Create(RichText));
            _list.Add(ValueFactory.Create(TextTextOleObjs));
            _list.Add(ValueFactory.Create(UnicodePlainText));
        }

        [ContextProperty("ПростойТекст", "PlainText")]
        public int PlainText
        {
        	get { return m_plainText; }
        }

        [ContextProperty("ТекстОбъектыКакТекст", "TextTextOleObjs")]
        public int TextTextOleObjs
        {
        	get { return m_textTextOleObjs; }
        }

        [ContextProperty("Форматированный", "RichText")]
        public int RichText
        {
        	get { return m_richText; }
        }

        [ContextProperty("ФорматированныйБезОбъектов", "RichNoOleObjs")]
        public int RichNoOleObjs
        {
        	get { return m_richNoOleObjs; }
        }

        [ContextProperty("ЮникодПростойТекст", "UnicodePlainText")]
        public int UnicodePlainText
        {
        	get { return m_unicodePlainText; }
        }
    }
}
