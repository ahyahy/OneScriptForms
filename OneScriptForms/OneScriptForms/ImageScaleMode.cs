using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРежимМасштабированияКартинки", "ClImageScaleMode")]
    public class ClImageScaleMode : AutoContext<ClImageScaleMode>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_clip = 0; // 0 Не масштабировать
        private int m_fit = 1; // 1 Масштабирует изображение так, чтобы оно соответствовало прямоугольнику дисплея, соотношение сторон не фиксировано.
        private int m_alwaysScale = 2; // 2 Масштабирование изображения в соответствии с отображаемым прямоугольником с учетом соотношения сторон.

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

        internal ClImageScaleMode()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AlwaysScale));
            _list.Add(ValueFactory.Create(Clip));
            _list.Add(ValueFactory.Create(Fit));
        }

        [ContextProperty("Вписать", "Fit")]
        public int Fit
        {
        	get { return m_fit; }
        }

        [ContextProperty("Клип", "Clip")]
        public int Clip
        {
        	get { return m_clip; }
        }

        [ContextProperty("Масштабировать", "AlwaysScale")]
        public int AlwaysScale
        {
        	get { return m_alwaysScale; }
        }
    }
}
