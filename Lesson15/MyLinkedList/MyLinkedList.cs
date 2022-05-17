using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15.MyLinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private MyLinkedNode<T> head;
        private MyLinkedNode<T> tail;
        private int count;
        public int Count { get { return count; } }

        public void Add(T data)
        {
            MyLinkedNode<T> node = new MyLinkedNode<T>(data);

            if (head == null) head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public void AddFirst(T data)
        {
            MyLinkedNode<T> node = new MyLinkedNode<T>(data);

            if (head == null) InitialElement(node);
            else
            {
                MyLinkedNode<T> tmp = head;
                node.Next = tmp;
                head = node;
                tmp.Previous = node;
            }
            count++;
        }

        public void AddLast(T data)
        {
            MyLinkedNode<T> node = new MyLinkedNode<T>(data);

            if (tail == null) InitialElement(node);
            else
            {
                MyLinkedNode<T> tmp = tail;
                node.Previous = tmp;
                tail = node;
                tmp.Next = node;
            }
            count++;
        }

        public bool Remove(T data)
        {
            MyLinkedNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data)) break;
                current = current.Next;
            }


            if (current != null)
            {
                if (current.Next == null)
                {
                    tail = current.Previous;
                    current.Previous.Next = null;
                }
                else if (current.Previous == null)
                {
                    head = current.Next;
                    current.Next.Previous = null;
                }
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }
                count--;
                return true;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            MyLinkedNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data)) return true;

                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyLinkedNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void InitialElement(MyLinkedNode<T> node)
        {
            head = node;
            tail = node;
        }
    }
}
