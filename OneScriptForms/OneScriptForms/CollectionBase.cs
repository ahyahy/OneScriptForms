using System;

namespace osf
{
    public class CollectionBase : System.Collections.IList, System.Collections.IEnumerator, System.Collections.IEnumerable
    {
        public object current;
        public System.Collections.IEnumerator Enumerator;
        public System.Collections.IList List;

        public virtual bool IsFixedSize
        {
            get { return List.IsFixedSize; }
        }

        public virtual bool IsReadOnly
        {
            get { return List.IsReadOnly; }
        }

        public virtual bool IsSynchronized
        {
            get { return List.IsSynchronized; }
        }

        public virtual int Count
        {
            get { return List.Count; }
        }

        public virtual object SyncRoot
        {
            get { return List.SyncRoot; }
        }

        public virtual object this[int index]
        {
            get { return List[index]; }
            set { List[index] = value; }
        }

        public virtual object Current
        {
            get { return current; }
        }

        public virtual void Reset()
        {
            Enumerator.Reset();
        }

        public virtual bool Contains(object value)
        {
            return List.Contains(value);
        }

        public virtual bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public virtual int Add(object value)
        {
            return List.Add(value);
        }

        public virtual int IndexOf(object value)
        {
            return List.IndexOf(value);
        }

        public void RemoveAt(int Index)
        {
            List.RemoveAt(Index);
            System.Windows.Forms.Application.DoEvents();
        }

        public virtual System.Collections.IEnumerator GetEnumerator()
        {
            Enumerator = List.GetEnumerator();
            return (System.Collections.IEnumerator)this;
        }

        public virtual void Clear()
        {
            List.Clear();
        }

        public virtual void CopyTo(Array array, int index)
        {
            List.CopyTo(array, index);
        }

        public virtual void Insert(int index, object value)
        {
            List.Insert(index, value);
        }

        public virtual void Remove(object value)
        {
            List.Remove(value);
        }
    }
}
