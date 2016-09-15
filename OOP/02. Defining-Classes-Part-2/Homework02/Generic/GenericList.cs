using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02.Generic
{
    class GenericList<T>
        where T : IComparable
    {
        private T[] list;
        private int capacity;
        private int count;
        private const int startCount = 0;
        //constructor
        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.List = new T[Capacity];
            this.Count = startCount;
        }
        //count property
        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }
        //capacity property
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentException("Invalid capacity");
                }
                this.capacity = value;
            }
        }
        public T[] List
        {
            get
            {
                return this.list;
            }
            private set
            {
                this.list = value;
            }

        }
        //doubles the size of the list and copies the elements
        private void Expand()
        {
            var tempArray = this.list;
            this.Capacity *= 2;
            this.list = new T[this.Capacity];
            Array.Copy(tempArray,this.list, this.count);

        }
        public void Add(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Expand();
            }
            this.List[this.Count] = element;
            this.Count++;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }
                else
                {
                    return this.list[index];
                }
            }
            set
            {
                if (index < 0 || index > this.Count + 1)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }
                else
                {
                    if (this.Count == this.Capacity)
                    {
                        this.Expand();
                    }
                    this.list[index] = value;
                    this.Count++;
                }
            }


        }
        public void Remove(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new ArgumentException("Invalid index");
            }
            var tempArray = this.List;
            this.list = new T[this.Capacity];
            for (int i = 0; i < this.Capacity - 1; i++)
            {
                if (i < index)
                {
                    this.list[i] = tempArray[i];
                }
                else
                {
                    this.list[i] = tempArray[i + 1];
                }
            }
            this.count--;

        }
        public void Clear()
        {
            this.List = new T[this.Capacity];
            this.Count = startCount;
        }
        //finds the index of an element, if there is no element it returns -1
        public int FindElement(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.List[i].Equals(element))
                {
                    return i;
                }


            }
            return -1;
        }
        public override string ToString()
        {
            if (this.Count==0)
            {
                return "Empty list";
            }
            var stringer = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {

                stringer.Append(this.List[i] + " ");
            }


            return stringer.ToString();
        }
        public void Insert(T item, int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
            var tempArr = this.List;
            this.List = new T[this.Capacity];
            this.Count++;
            if (this.Count == this.Capacity)
            {
                this.Expand();
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (i < index)
                {
                    this.List[i] = tempArr[i];
                }
                else if (i == index)
                {
                    this.List[i] = item;
                }
                else
                {
                    this.List[i] = tempArr[i - 1];
                }
            }

        }
        public T Min()
        {
            return this.List.Min();
        }
        public T Max()
        {
            return this.List.Max();
        }

    }
}
