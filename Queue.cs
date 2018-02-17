namespace GraphTraversal
{
    public class Queue : IQueue
    {
        private readonly int DEFAULT_SIZE = 5;
        private char[] _queue;
        private int _currentElement;
        private int _lastElement;
        private int _size;

        public Queue()
        {
            _queue = new char[DEFAULT_SIZE];
            _currentElement = 0;
            _lastElement = -1;
            _size = 0;
        }

        public void Add(char item)
        {
            if (_lastElement + 1 == _queue.Length)
            {
                expandQueue();
            }

            _lastElement++;
            _size++;

            _queue[_lastElement] = item;
        }

        public char Remove()
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
            char[] newQueue = new char[newSize];

            for (int i = 0; i < _queue.Length; i++)
            {
                newQueue[i] = _queue[i];
            }

            _queue = newQueue;
        }
    }
}