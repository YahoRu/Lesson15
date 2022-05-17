using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15.MyLinkedList
{
    public class MyLinkedNode<T>
    {
        public T Data { get; set; }

        public MyLinkedNode<T> Next { get; set; }
        public MyLinkedNode<T> Previous { get; set; }

        public MyLinkedNode(T data)
        {
            Data = data;
        }
    }
}
