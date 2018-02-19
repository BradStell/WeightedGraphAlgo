using GraphTraversal;

namespace Tests
{
    public class GraphFixture
    {
        public IDirectedGraph<char> graph  { get; private set; }
        private readonly string _rawGraphData = @"AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";

        public GraphFixture()
        {
            graph = new DirectedGraph<char>();
            Program.buildGraphFromInitialState(graph, _rawGraphData);
        }
    }
}