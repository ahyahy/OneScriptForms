﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРазмещениеИзображения", "ClImageLayout")]
    public class ClImageLayout : AutoContext<ClImageLayout>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_none = (int)System.Windows.Forms.ImageLayout.None; // 0 Изображение выравнивается в клиентском прямоугольнике элемента управления вверху по левой стороне.
        private int m_tile = (int)System.Windows.Forms.ImageLayout.Tile; // 1 Выполняется мозаичное заполнение изображением клиентского прямоугольника элемента управления.
        private int m_center = (int)System.Windows.Forms.ImageLayout.Center; // 2 Изображение центрируется в клиентском прямоугольнике элемента управления.
        private int m_stretch = (int)System.Windows.Forms.ImageLayout.Stretch; // 3 Изображение растягивается на всю длину клиентского прямоугольника элемента управления.
        private int m_zoom = (int)System.Windows.Forms.ImageLayout.Zoom; // 4 Изображение увеличивается в пределах клиентского прямоугольника элемента управления.

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

        internal ClImageLayout()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Center));
            _list.Add(ValueFactory.Create(None));
            _list.Add(ValueFactory.Create(Stretch));
            _list.Add(ValueFactory.Create(Tile));
            _list.Add(ValueFactory.Create(Zoom));
        }

        [ContextProperty("Масштабировать", "Zoom")]
        public int Zoom
        {
        	get { return m_zoom; }
        }

        [ContextProperty("Мозаика", "Tile")]
        public int Tile
        {
        	get { return m_tile; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
        	get { return m_none; }
        }

        [ContextProperty("Растянуть", "Stretch")]
        public int Stretch
        {
        	get { return m_stretch; }
        }

        [ContextProperty("Центр", "Center")]
        public int Center
        {
        	get { return m_center; }
        }
    }
}
