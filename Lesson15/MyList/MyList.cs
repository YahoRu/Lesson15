using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15.MyList
{
    public class MyList<T> : IList<T>
    {
        private T[] list;

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public int Capacity => list.Length;
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public MyList()
        {
            list = new T[4];
        }

        public void Add(T item)
        {
            if (Count == Capacity) IncreaseCapacity();

            list[Count] = item;
            Count++;
        }

        public void Clear()
        {
            var tmp = new T[Capacity];
            list = tmp;
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (list[i].Equals(item)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex) => Array.Copy(list, 0, array, arrayIndex, Count);

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (list[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (Count == Capacity) IncreaseCapacity();

            for (int i = Count; i > index; i--)
            {
                list[i] = list[i - 1];
            }
            list[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (list[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index > Count) return;

            for (int i = index; i < Count; i++)
            {
                if (i == Count - 1)
                {
                    list[i] = default;
                    Count--;
                    return;
                }

                list[i] = list[i + 1]; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void IncreaseCapacity()
        {
            var tmp = new T[Capacity * 2];
            list.CopyTo(tmp, 0);
            list = tmp;
        }
    }
}
