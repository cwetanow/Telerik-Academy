namespace _13.ImplementLinkedQueue
{
    public class LinkedQueue<T>
    {
        protected class Node
        {
            public Node(T obj, Node prev)
            {
                this.Element = obj;
                this.Next = null;

                prev.Next = this;
            }

            public Node(T obj)
            {
                this.Element = obj;
                this.Next = null;
            }

            public T Element { get; set; }

            public Node Next { get; set; }
        }

        private Node headNode;
        private Node tailNode;

        public LinkedQueue()
        {
            this.headNode = null;
            this.tailNode = this.headNode;

            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.IsEmpty())
            {
                this.headNode = new Node(element);
                this.tailNode = this.headNode;
            }
            else
            {
                this.tailNode = new Node(element, this.tailNode);
            }

            this.Count++;
        }

        public T Dequeue()
        {
            var element = this.headNode.Element;

            this.headNode = this.headNode.Next;

            return element;
        }

        public T Peek()
        {
            return this.headNode.Element;
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }
    }
}
