namespace GraphTraversal
{
    public class Queue<T> : IQueue<T>
    {
        private readonly int DEFAULT_SIZE = 5;
        private T[] _queue;
        private int _currentElement;
        private int _lastElement;
        private int _size;

        public Queue()
        {
            _queue = new T[DEFAULT_SIZE];
            _currentElement = 0;
            _lastElement = -1;
            _size = 0;
        }

        public void Add(T item)
        {
            if (_lastElement + 1 == _queue.Length)
            {
                expandQueue();
            }

            _lastElement++;
            _size++;

            _queue[_lastElement] = item;
        }

        public T Remove()
        {
            _size--;
            return _queue[_currentElement++];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        private void expandQueue()
        {
            int newSize = _queue.Length * 2;
            T[] newQueue = new T[newSize];

            for (int i = 0; i < _queue.Length; i++)
            {
                newQueue[i] = _queue[i];
            }

            _queue = newQueue;
        }
    }
}