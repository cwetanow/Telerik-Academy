using System;

namespace _12.DynamicStackImplementation
{
    public class DynamicStack<T>
    {
        private const int InitialCapacity = 8;

        private T[] data;

        private int capacity;

        public DynamicStack(int capacity = InitialCapacity)
        {
            this.data = new T[capacity];
            this.Size = 0;
            this.capacity = capacity;
        }

        public int Size { get; private set; }

        public void Push(T obj)
        {
            if (this.Size == this.capacity)
            {
                this.Resize();
            }

            this.data[this.Size++] = obj;
        }

        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentNullException("Stack is empty");
            }

            this.Size--;
            return this.data[this.Size];
        }

        public T Peek()
        {
            return this.data[this.Size - 1];
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        private void Resize()
        {
            this.capacity *= 2;
            var newData = new T[this.capacity];

            for (var i = 0; i < this.Size; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }
    }
}
