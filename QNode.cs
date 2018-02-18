namespace GraphTraversal
{
    public class QNode
    {
        public char Vertex { get; set; }
        public int Depth { get; set; }

        public QNode(char vertex, int depth)
        {
            Vertex = vertex;
            Depth = depth;
        }
    }
}