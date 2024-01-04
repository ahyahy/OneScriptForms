using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections;
using System.Collections.Generic;

namespace osf
{
    [ContextClass ("КлРезультатМаски", "ClMaskedTextResultHint")]
    public class ClMaskedTextResultHint : AutoContext<ClMaskedTextResultHint>, ICollectionContext, IEnumerable<IValue>
    {
        private int m_positionOutOfRange = (int)System.ComponentModel.MaskedTextResultHint.PositionOutOfRange; // -55 Не удалось выполнить операцию. Заданная позиция находится вне диапазона конечной строки. Обычно это происходит, если это значение меньше нуля или больше длины конечной строки.
        private int m_nonEditPosition = (int)System.ComponentModel.MaskedTextResultHint.NonEditPosition; // -54 Не удалось выполнить операцию. Текущая позиция в форматируемой строке является литералом.
        private int m_unavailableEditPosition = (int)System.ComponentModel.MaskedTextResultHint.UnavailableEditPosition; // -53 Не удалось выполнить операцию. Недостаточно редактируемых позиций для выполнения запроса.
        private int m_promptCharNotAllowed = (int)System.ComponentModel.MaskedTextResultHint.PromptCharNotAllowed; // -52 Не удалось выполнить операцию. Знак приглашения нельзя использовать для ввода, возможно, потому что свойство <B>МаскаПоляВвода.ИспользоватьСимволПриглашения&nbsp;(MaskedTextBox.AllowPromptAsInput)</B> равно <B>Ложь</B>.
        private int m_invalidInput = (int)System.ComponentModel.MaskedTextResultHint.InvalidInput; // -51 Не удалось выполнить операцию. Программа обнаружила недопустимый входной символ.
        private int m_signedDigitExpected = (int)System.ComponentModel.MaskedTextResultHint.SignedDigitExpected; // -5 Не удалось выполнить операцию. Обнаружен введенный знак, не являющийся цифрой со знаком.
        private int m_letterExpected = (int)System.ComponentModel.MaskedTextResultHint.LetterExpected; // -4 Не удалось выполнить операцию. Обнаружен введенный знак, не являющийся буквой.
        private int m_digitExpected = (int)System.ComponentModel.MaskedTextResultHint.DigitExpected; // -3 Не удалось выполнить операцию. Обнаружен введенный знак, не являющийся цифрой.
        private int m_asciiCharacterExpected = (int)System.ComponentModel.MaskedTextResultHint.AsciiCharacterExpected; // -1 Не удалось выполнить операцию. Обнаружен введенный знак, не являющийся элементом набора знаков ASCII.
        private int m_unknown = (int)System.ComponentModel.MaskedTextResultHint.Unknown; // 0 Нет данных. Результат операции не удалось определить.
        private int m_characterEscaped = (int)System.ComponentModel.MaskedTextResultHint.CharacterEscaped; // 1 Выполнено. Операция завершилась успешно, так как экранированным знаком является знак литерала, приглашения или пробела.
        private int m_noEffect = (int)System.ComponentModel.MaskedTextResultHint.NoEffect; // 2 Выполнено. Основная операция не была выполнена, так как она не понадобилась, поэтому побочные эффекты отсутствуют.
        private int m_sideEffect = (int)System.ComponentModel.MaskedTextResultHint.SideEffect; // 3 Выполнено. Основная операция не была выполнена, так как она не понадобилась, но метод вызвал побочные эффекты.
        private int m_success = (int)System.ComponentModel.MaskedTextResultHint.Success; // 4 Успех. Основная операция успешно завершена.

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

        internal ClMaskedTextResultHint()
        {
            _list = new List<IValue>();
            _list.Add(ValueFactory.Create(AsciiCharacterExpected));
            _list.Add(ValueFactory.Create(CharacterEscaped));
            _list.Add(ValueFactory.Create(DigitExpected));
            _list.Add(ValueFactory.Create(InvalidInput));
            _list.Add(ValueFactory.Create(LetterExpected));
            _list.Add(ValueFactory.Create(NoEffect));
            _list.Add(ValueFactory.Create(NonEditPosition));
            _list.Add(ValueFactory.Create(PositionOutOfRange));
            _list.Add(ValueFactory.Create(PromptCharNotAllowed));
            _list.Add(ValueFactory.Create(SideEffect));
            _list.Add(ValueFactory.Create(SignedDigitExpected));
            _list.Add(ValueFactory.Create(Success));
            _list.Add(ValueFactory.Create(UnavailableEditPosition));
            _list.Add(ValueFactory.Create(Unknown));
        }

        [ContextProperty("БезЭффекта", "NoEffect")]
        public int NoEffect
        {
        	get { return m_noEffect; }
        }

        [ContextProperty("НеASCII", "AsciiCharacterExpected")]
        public int AsciiCharacterExpected
        {
        	get { return m_asciiCharacterExpected; }
        }

        [ContextProperty("НеБуква", "LetterExpected")]
        public int LetterExpected
        {
        	get { return m_letterExpected; }
        }

        [ContextProperty("НедопустимыйСимвол", "InvalidInput")]
        public int InvalidInput
        {
        	get { return m_invalidInput; }
        }

        [ContextProperty("НедоступнаяПозицияРедактирования", "UnavailableEditPosition")]
        public int UnavailableEditPosition
        {
        	get { return m_unavailableEditPosition; }
        }

        [ContextProperty("Неизвестно", "Unknown")]
        public int Unknown
        {
        	get { return m_unknown; }
        }

        [ContextProperty("НеРедактируемаяПозиция", "NonEditPosition")]
        public int NonEditPosition
        {
        	get { return m_nonEditPosition; }
        }

        [ContextProperty("НеЦифра", "DigitExpected")]
        public int DigitExpected
        {
        	get { return m_digitExpected; }
        }

        [ContextProperty("НеЦифраСоЗнаком", "SignedDigitExpected")]
        public int SignedDigitExpected
        {
        	get { return m_signedDigitExpected; }
        }

        [ContextProperty("ПобочныйЭффект", "SideEffect")]
        public int SideEffect
        {
        	get { return m_sideEffect; }
        }

        [ContextProperty("ПозицияВнеДиапазона", "PositionOutOfRange")]
        public int PositionOutOfRange
        {
        	get { return m_positionOutOfRange; }
        }

        [ContextProperty("ПриглашениеНеПрименимо", "PromptCharNotAllowed")]
        public int PromptCharNotAllowed
        {
        	get { return m_promptCharNotAllowed; }
        }

        [ContextProperty("Успех", "Success")]
        public int Success
        {
        	get { return m_success; }
        }

        [ContextProperty("Экранирование", "CharacterEscaped")]
        public int CharacterEscaped
        {
        	get { return m_characterEscaped; }
        }
    }
}
