namespace GraphTraversal
{
    public interface IQNode<T>
    {
        T Vertex { get; set; }
        int Depth { get; set; }
    }
}