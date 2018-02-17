using System.Collections.Generic;

namespace GraphTraversal
{
    public interface IDirectedGraph : IGraph
    {
        void AddEdge(char vertex1, char vertex2, float weight);

        float ShortestPathWeight(char vertex1, char vertex2);

        string CalculatePathWeight(string path);

        bool DoesPathExist(char vertex1, char vertex2);

        int NumberOfTripsBetweenVerticies(char vertex1, char vertex2);

        int NumberOfTripsBetweenVerticies(char vertex1, char vertex2, int maxNumberOfStops);
    }
}
