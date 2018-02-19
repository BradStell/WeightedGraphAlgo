namespace GraphTraversal
{
    public class Stack : IStack
    {
        private readonly int DEFAULT_SIZE = 5;
        private char[] _stack;
        private int _index;

        public Stack()
        {
            _stack = new char[DEFAULT_SIZE];
            _index = -1;
        }

        public char Pop()
        {
            return _stack[_index--];
        }

        public void Push(char element)
        {
            if (_index + 1 == _stack.Length)
            {
                expandQueue();
            }

            _index++;

            _stack[_index] = element;
        }

        public bool IsEmpty()
        {
            return _index == -1;
        }

        private void expandQueue()
        {
            int newSize = _stack.Length * 2;
            char[] newQueue = new char[newSize];

            for (int i = 0; i < _stack.Length; i++)
            {
                newQueue[i] = _stack[i];
            }

            _stack = newQueue;
        }
    }
}