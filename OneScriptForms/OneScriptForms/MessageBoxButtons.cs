﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлКнопкиОкнаСообщений", "ClMessageBoxButtons")]
    public class ClMessageBoxButtons : AutoContext<ClMessageBoxButtons>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_oK = (int)System.Windows.Forms.MessageBoxButtons.OK; // 0 Окно сообщения содержит кнопку <B>ОК</B>.
        private int m_oKCancel = (int)System.Windows.Forms.MessageBoxButtons.OKCancel; // 1 Окно сообщения содержит кнопки <B>ОК</B> и <B>Отмена</B>.
        private int m_abortRetryIgnore = (int)System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore; // 2 Окно сообщения содержит кнопки <B>Прервать</B>, <B>Повторить</B> и <B>Пропустить</B>.
        private int m_yesNoCancel = (int)System.Windows.Forms.MessageBoxButtons.YesNoCancel; // 3 Окно сообщения содержит <B>Да</B>, <B>Нет</B> и <B>Отмена</B>.
        private int m_yesNo = (int)System.Windows.Forms.MessageBoxButtons.YesNo; // 4 Окно сообщения содержит кнопки <B>Да</B> и <B>Нет</B>.
        private int m_retryCancel = (int)System.Windows.Forms.MessageBoxButtons.RetryCancel; // 5 Окно сообщения содержит кнопки <B>Повторить</B> и <B>Отмена</B>.

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

        public ClMessageBoxButtons()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AbortRetryIgnore));
            _list.Add(ValueFactory.Create(OK));
            _list.Add(ValueFactory.Create(OKCancel));
            _list.Add(ValueFactory.Create(RetryCancel));
            _list.Add(ValueFactory.Create(YesNo));
            _list.Add(ValueFactory.Create(YesNoCancel));
        }

        [ContextProperty("ДаНет", "YesNo")]
        public int YesNo
        {
        	get { return m_yesNo; }
        }

        [ContextProperty("ДаНетОтмена", "YesNoCancel")]
        public int YesNoCancel
        {
        	get { return m_yesNoCancel; }
        }

        [ContextProperty("ОК", "OK")]
        public int OK
        {
        	get { return m_oK; }
        }

        [ContextProperty("ОКОтмена", "OKCancel")]
        public int OKCancel
        {
        	get { return m_oKCancel; }
        }

        [ContextProperty("ПовторитьОтмена", "RetryCancel")]
        public int RetryCancel
        {
        	get { return m_retryCancel; }
        }

        [ContextProperty("ПрерватьПовторитьПропустить", "AbortRetryIgnore")]
        public int AbortRetryIgnore
        {
        	get { return m_abortRetryIgnore; }
        }
    }
}
