using System.Collections.Generic;

namespace GraphTraversal
{
    public interface IGraph
    {
        void AddVertex(char vertex);

        void RemoveVertex(char vertex);

        void AddEdge(char vertex1, char vertex2);

        void RemoveEdge(char vertex1, char vertex2);

        IEnumerator<char> IterateBreadthFirstSearch(char startVertex);

        IEnumerator<char> IterateDepthFirstSearch(char startVertex);

        IEnumerator<char> ShortestPath(char startVertex, char endVertex);

        bool IsEmpty();

        bool IsConnected();

        int Size();

        string ToString();

        bool DoesVerticeExist(char vertex);
    }
}