namespace GraphTraversal
{
    public interface IQueue<T>
    {
        void Add(T item);

        T Remove();

        bool IsEmpty();
    }
}