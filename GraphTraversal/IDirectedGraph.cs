using System.Collections.Generic;

namespace GraphTraversal
{
    public interface IDirectedGraph<T> : IGraph<T>
    {
        void AddEdge(T vertex1, T vertex2, float weight);

        float GetPathWeight(T vertex1, T vertex2);

        bool DoesPathExist(T vertex1, T vertex2);

        int NumberOfTripsBetweenVerticiesLessThanStops(T startingVertex, T endingVertex, int maxNumberOfStops);

        int NumberOfTripsBetweenVerticiesWithExactStops(T startingVertex, T endingVertex, int maxNumberOfStops);

        int NumberOfTripsBetweenVerticiesLessThanDistance(T startingVertex, T endingVertex, int maxDistance);
    }
}
