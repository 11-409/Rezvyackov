namespace HomeWork
{
    public class Stack<T>
    {
        private readonly T[] _items;
        private int _top = -1;

        public Stack(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive");

            _items = new T[capacity];
            Capacity = capacity;
        }

        public int Capacity { get; }
        public int Count => _top + 1;
        public bool IsEmpty => _top == -1;
        public bool IsFull => _top == Capacity - 1;

        public bool Push(T item)
        {
            if (IsFull)
                return false;

            _items[++_top] = item;
            return true;
        }

        public T? Pop()
        {
            if (IsEmpty)
                return default;

            return _items[_top--];
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            return _items[_top];
        }
    }
}