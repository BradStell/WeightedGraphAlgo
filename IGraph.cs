using System.Collections.Generic;

namespace GraphTraversal
{
    public interface IGraph<T>
    {
        void AddVertex(T vertex);

        void RemoveVertex(T vertex);

        void RemoveEdge(T vertex1, T vertex2);

        IEnumerator<T> IterateBreadthFirstSearch(T startVertex);

        IEnumerator<T> IterateDepthFirstSearch(T startVertex);

        float ShortestPath(T startVertex, T endVertex);

        bool IsEmpty();

        bool IsConnected();

        int Size();

        bool VertexExists(T vertex);
    }
}