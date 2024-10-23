using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлСтильОкнаПроцесса", "ClProcessWindowStyle")]
    public class ClProcessWindowStyle : AutoContext<ClProcessWindowStyle>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_normal = (int)System.Diagnostics.ProcessWindowStyle.Normal; // 0 Стиль окна нормальный, видимый. Система отображает окно на экране в расположении по умолчанию. Если окно отображается, пользователь может вводить входные данные в окно и видеть выходные данные окна. Часто приложение может инициализировать новое окно со стилем Скрытое, пока не определит внешний вид окна, а затем меняет стиль окна на <B>Стандартное&nbsp;(Normal)</B>.
        private int m_hidden = (int)System.Diagnostics.ProcessWindowStyle.Hidden; // 1 Скрытый стиль окна. Окно может быть видимым или скрытым. Система отображает скрытое окно, но не рисует его. Если окно скрыто, оно эффективно отключено. Скрытое окно может обрабатывать сообщения от системы или от других окон, но не может обрабатывать ввод от пользователя или отображать выходные данные. Часто приложение может сохранять новое окно скрытым, пока определяет внешний вид окна и только затем делает стиль окна равным <B>Стандартное&nbsp;(Normal)</B>.
        private int m_minimized = (int)System.Diagnostics.ProcessWindowStyle.Minimized; // 2 Стиль свернутого окна. Система уменьшает свернутое окно до размера кнопки панели задач и помещает его на панели задач.
        private int m_maximized = (int)System.Diagnostics.ProcessWindowStyle.Maximized; // 3 Полноэкранный стиль окна. По умолчанию система расширяет полноэкранное окно так, чтобы оно заполняло экран или в случае дочернего окна клиентскую область родительского окна. Если окно имеет строку заголовка, система автоматически перемещает её в верхнюю часть экрана или верх клиентской области родительского окна. Кроме того система отключает возможность изменения размера окна и положения с помощью границ и строки заголовка.

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

        public ClProcessWindowStyle()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(Hidden));
            _list.Add(ValueFactory.Create(Maximized));
            _list.Add(ValueFactory.Create(Minimized));
            _list.Add(ValueFactory.Create(Normal));
        }

        [ContextProperty("Развернутое", "Maximized")]
        public int Maximized
        {
        	get { return m_maximized; }
        }

        [ContextProperty("Свернутое", "Minimized")]
        public int Minimized
        {
        	get { return m_minimized; }
        }

        [ContextProperty("Скрытое", "Hidden")]
        public int Hidden
        {
        	get { return m_hidden; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public int Normal
        {
        	get { return m_normal; }
        }
    }
}
