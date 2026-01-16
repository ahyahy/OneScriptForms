using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass("КлАвтоРазмерПанелиСтрокиСостояния", "ClStatusBarPanelAutoSize")]
    public class ClStatusBarPanelAutoSize : AutoContext<ClStatusBarPanelAutoSize>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.StatusBarPanelAutoSize.None; // 1 Размер не изменяется.
        private int m_spring = (int)System.Windows.Forms.StatusBarPanelAutoSize.Spring; // 2 <B>ПанельСтрокиСостояния&nbsp;(StatusBarPanel)</B> разделяет доступное пространство в строке состояния (пространство, не занятое другими панелями, у которых <B>АвтоРазмер&nbsp;(AutoSize)</B> равен свойству <B>Отсутствие&nbsp;(None)</B> или <B>ПоСодержимому&nbsp;(Contents)</B>) с другими панелями, у которых <B>АвтоРазмер&nbsp;(AutoSize)</B> равен свойству <B>Растяжимое&nbsp;(Spring)</B>.
        private int m_contents = (int)System.Windows.Forms.StatusBarPanelAutoSize.Contents; // 3 Ширина определяется его содержимым.

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

        [ContextProperty("Количество", "Count")]
        public int CountProp
        {
            get { return _list.Count; }
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(int index)
        {
            return _list[index];
        }

        [ContextMethod("Имя")]
        public string NameRu(decimal p1)
        {
            return namesRu.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        [ContextMethod("Name")]
        public string NameEn(decimal p1)
        {
            return namesEn.TryGetValue(p1, out string name) ? name : p1.ToString();
        }

        private static readonly Dictionary<decimal, string> namesRu = new Dictionary<decimal, string>
        {
            {1, "Отсутствие"},
            {3, "ПоСодержимому"},
            {2, "Растяжимое"},
        };

        private static readonly Dictionary<decimal, string> namesEn = new Dictionary<decimal, string>
        {
            {1, "None"},
            {3, "Contents"},
            {2, "Spring"},
        };

        public ClStatusBarPanelAutoSize()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Contents));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Spring));
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return m_none; }
        }

        [ContextProperty("ПоСодержимому", "Contents")]
        public int Contents
        {
            get { return m_contents; }
        }

        [ContextProperty("Растяжимое", "Spring")]
        public int Spring
        {
            get { return m_spring; }
        }
    }
}
