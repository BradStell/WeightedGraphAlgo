using System.Collections.Generic;

namespace GraphTraversal
{
    public interface IDirectedGraph : IGraph
    {
        void AddEdge(char vertex1, char vertex2, float weight);

        float ShortestPathWeight(char vertex1, char vertex2);

        float CalculatePathWeight(string path);
    }
}
