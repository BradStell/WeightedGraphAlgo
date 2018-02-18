using System.Collections.Generic;

namespace GraphTraversal
{
    public interface IDirectedGraph : IGraph
    {
        void AddEdge(char vertex1, char vertex2, float weight);

        float ShortestPathWeight(char vertex1, char vertex2);

        string CalculatePathWeight(string path);

        bool DoesPathExist(char vertex1, char vertex2);

        int NumberOfTripsBetweenVerticiesLessThanStops(char startingVertex, char endingVertex, int maxNumberOfStops);

        int NumberOfTripsBetweenVerticiesWithExactStops(char startingVertex, char endingVertex, int maxNumberOfStops);

        int NumberOfTripsBetweenVerticiesLessThanDistance(char startingVertex, char endingVertex, int maxDistance);
    }
}
