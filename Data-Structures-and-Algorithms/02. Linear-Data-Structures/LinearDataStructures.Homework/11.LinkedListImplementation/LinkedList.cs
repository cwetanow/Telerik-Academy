using System;
using System.Text;

namespace _11.LinkedListImplementation
{
    public class LinkedList<T>
        where T : IComparable
    {
        private class Node
        {
            public Node(T obj)
            {
                this.Element = obj;
                this.Next = null;
            }

            public Node(T obj, Node previousNode)
            {
                this.Element = obj;
                this.Next = null;

                previousNode.Next = this;
            }

            public T Element { get; set; }

            public Node Next { get; set; }
        }

        private Node head;
        private Node tail;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;

            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void Add(T obj)
        {
            if (this.IsEmpty())
            {
                this.head = new Node(obj);
                this.tail = this.head;
            }
            else
            {
                this.tail = new Node(obj, this.tail);
            }

            this.Count++;
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                var current = this.head;

                for (var i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Element;
            }
            set
            {
                this.ValidateIndex(index);

                var current = this.head;
                for (var i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Element = value;
            }
        }

        public T ElementAt(int index)
        {
            this.ValidateIndex(index);

            return this[index];
        }

        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);
            T result;

            if (index == 0)
            {
                result = this.head.Element;
                this.head = this.head.Next;

                return result;
            }
            else
            {
                Node previousNode = null;
                var current = this.head;

                for (var i = 0; i < index; i++)
                {
                    previousNode = current;
                    current = current.Next;
                }

                result = current.Element;

                previousNode.Next = current.Next;
            }

            return result;
        }

        public T Remove(T obj)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this.ElementAt(i).Equals(obj))
                {
                    return this.RemoveAt(i);
                }
            }

            throw new ArgumentNullException("Invalid object");
        }

        public bool Contains(T obj)
        {
            return this.IndexOf(obj) != -1;
        }

        public int IndexOf(T obj)
        {
            var index = 0;
            var current = this.head;

            while (current != null)
            {
                if (current.Element.Equals(obj))
                {
                    return index;
                }

                index++;
                current = current.Next;
            }

            return -1;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < this.Count - 1; i++)
            {
                result.Append(string.Format($"{this[i]}->"));
            }

            result.Append(this[this.Count - 1]);

            return result.ToString();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }
        }
    }
}
