namespace GraphTraversal
{
    public class QNode<T> : IQNode<T>
    {
        public T Vertex { get; set; }
        public int Depth { get; set; }

        public QNode(T vertex, int depth)
        {
            Vertex = vertex;
            Depth = depth;
        }
    }
}