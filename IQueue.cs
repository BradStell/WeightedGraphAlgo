namespace GraphTraversal
{
    public interface IQueue
    {
        void Add(QNode item);

        QNode Remove();

        bool IsEmpty();
    }
}