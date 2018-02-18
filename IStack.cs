namespace GraphTraversal
{
    public interface IStack
    {
        void Push(char element);
        char Pop();
        bool IsEmpty();
    }
}