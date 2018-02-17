namespace GraphTraversal
{
    public interface IQueue
    {
        void Add(char item);

        char Remove();

        bool IsEmpty();
    }
}