using System;
using System.Collections.Generic;

namespace GraphTraversal
{
    public class DirectedGraph<T> : IDirectedGraph<T>
    {
        //private readonly string _graphData;
        private readonly int DEFAULT_SIZE = 2;
        private int _numberOfVerticies;
        private float[,] _adjMatrix;
        private T[] _vertices;

        #region Constructors
        public DirectedGraph()
        {
            _numberOfVerticies = 0;
            _adjMatrix = new float[DEFAULT_SIZE,DEFAULT_SIZE];
            _vertices = new T[DEFAULT_SIZE];
        }

        #endregion

        #region Public Interface Methods
        public void AddEdge(T vertex1, T vertex2, float weight)
        {
            addEdge(getIndex(vertex1), getIndex(vertex2), weight);
        }

        public void AddVertex(T vertex)
        {
            if ((_numberOfVerticies + 1) == _adjMatrix.GetLength(0))
            {
                expandCapacity();
            }

            _vertices[_numberOfVerticies] = vertex;

            for (int i = 0; i < _numberOfVerticies; i++)
            {
                _adjMatrix[_numberOfVerticies, i] = 0;
                _adjMatrix[i, _numberOfVerticies] = 0;
            }

            _numberOfVerticies++;
        }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return _numberOfVerticies == 0;
        }

        public IEnumerator<T> IterateBreadthFirstSearch(T startVertex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> IterateDepthFirstSearch(T startVertex)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(T vertex1, T vertex2)
        {
            throw new NotImplementedException();
        }

        public void RemoveVertex(T vertex)
        {
            throw new NotImplementedException();
        }

        // Dijkstra's algo
        public float ShortestPath(T startVertex, T endVertex)
        {
            float[] vertexDistances = new float[_numberOfVerticies];
            bool[] includedSet = new bool[_numberOfVerticies];

            for (int i = 0; i < _numberOfVerticies; i++)
            {
                vertexDistances[i] = float.MaxValue;
                includedSet[i] = false;
            }

            vertexDistances[getIndex(startVertex)] = 0;

            for (int i = 0; i < _numberOfVerticies - 1; i++)
            {
                int closestVertex = calculateMin(vertexDistances, includedSet);
                includedSet[closestVertex] = true;

                // Short circuits for non cyclic variant 
                if (closestVertex == getIndex(endVertex) && vertexDistances[getIndex(endVertex)] != 0)
                {
                    return vertexDistances[getIndex(endVertex)];
                }

                for (int j = 0; j < _numberOfVerticies; j++)
                {
                    if
                    (
                        (!includedSet[j] || vertexDistances[j] == 0) && _adjMatrix[closestVertex,j] != 0 && vertexDistances[closestVertex] != float.MaxValue &&
                        (vertexDistances[closestVertex] + _adjMatrix[closestVertex, j] < vertexDistances[j] || vertexDistances[j] == 0)
                    )
                    {
                        vertexDistances[j] = vertexDistances[closestVertex] + _adjMatrix[closestVertex, j];
                    }
                }
            }

            return vertexDistances[getIndex(endVertex)];
        }        

        public int Size()
        {
            return _numberOfVerticies;
        }

        public override string ToString()
        {
            string graphString = "    ";

            foreach (T vert in _vertices)
            {
                graphString += $"{vert} ";
            }

            graphString += "\n    ---------\n";

            for (int i = 0; i < _numberOfVerticies; i++)
            {
                graphString += $"{_vertices[i]} | ";

                for (int j = 0; j < _numberOfVerticies; j++)
                {
                    graphString += $"{_adjMatrix[i, j]} ";
                }
                graphString += "\n";
            }

            return graphString;
        }

        public bool VertexExists(T vertex)
        {
            foreach (T vertecie in _vertices)
            {
                if (vertecie.Equals(vertex))
                {
                    return true;
                }
            }

            return false;
        }

        public bool DoesPathExist(T vertex1, T vertex2)
        {
            return _adjMatrix[getIndex(vertex1),getIndex(vertex2)] != 0;
        }

        public int NumberOfTripsBetweenVerticiesLessThanStops(T startingVertex, T endingVertex, int maxNumberOfStops)
        {
            int numberOfTripsBetweenV1andV2 = 0;

            IQueue<IQNode<T>> traversalQueue = new Queue<IQNode<T>>();
            traversalQueue.Add(new QNode<T>(startingVertex, 0));

            while (!traversalQueue.IsEmpty())
            {
                IQNode<T> current = traversalQueue.Remove();
                int currIndex = getIndex(current.Vertex);

                if (current.Depth >= maxNumberOfStops)
                {
                    break;
                }

                for (int i = 0; i < _numberOfVerticies; i++)
                {
                    if (_adjMatrix[currIndex, i] != 0)
                    {
                        traversalQueue.Add(new QNode<T>(_vertices[i], current.Depth + 1));

                        if (_vertices[i].Equals(endingVertex))
                        {
                            numberOfTripsBetweenV1andV2++;
                        }
                    }
                }
            }

            return numberOfTripsBetweenV1andV2;
        }

        public int NumberOfTripsBetweenVerticiesLessThanDistance(T startingVertex, T endingVertex, int maxDistance)
        {
            return 0;
        }

        public int NumberOfTripsBetweenVerticiesWithExactStops(T startingVertex, T endingVertex, int maxNumberOfStops)
        {
            int numberOfTripsBetweenV1andV2 = 0;

            IQueue<IQNode<T>> traversalQueue = new Queue<IQNode<T>>();
            traversalQueue.Add(new QNode<T>(startingVertex, 0));

            while (!traversalQueue.IsEmpty())
            {
                IQNode<T> current = traversalQueue.Remove();
                int currIndex = getIndex(current.Vertex);

                if (current.Depth >= maxNumberOfStops)
                {
                    break;
                }

                for (int i = 0; i < _numberOfVerticies; i++)
                {
                    if (_adjMatrix[currIndex, i] != 0)
                    {
                        traversalQueue.Add(new QNode<T>(_vertices[i], current.Depth + 1));

                        if (_vertices[i].Equals(endingVertex) && (current.Depth + 1) == maxNumberOfStops)
                        {
                            numberOfTripsBetweenV1andV2++;
                        }
                    }
                }
            }

            return numberOfTripsBetweenV1andV2;
        }

        public float GetPathWeight(T vertex1, T vertex2)
        {
            return _adjMatrix[getIndex(vertex1),getIndex(vertex2)];
        }

        public int GetIndex(T vertex)
        {
            int index = 0;
            foreach (T vertice in _vertices)
            {
                if (vertice.Equals(vertex))
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        #endregion

        #region Private Methods
        private void addEdge(int index1, int index2, float weight)
        {
            if (isIndexValid(index1) && isIndexValid(index2) && isWeightValid(weight))
            {
                _adjMatrix[index1, index2] = weight;
            }
        }

        public int getIndex(T vertex)
        {
            int index = 0;
            foreach (T vertice in _vertices)
            {
                if (vertice.Equals(vertex))
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        private bool isIndexValid(int index)
        {
            return index >= 0 && index < _numberOfVerticies ? true : false;
        }

        private bool isWeightValid(float weight)
        {
            return weight > 0;
        }

        private void expandCapacity()
        {
            int newSize = _vertices.Length * 2;
            T[] newVerticies = new T[newSize];
            float [,] newAdjMatrix = new float[newSize, newSize];

            for (int i = 0; i < _numberOfVerticies; i++)
            {
                for (int j = 0; j < _numberOfVerticies; j++)
                {
                    newAdjMatrix[i,j] = _adjMatrix[i,j];
                }
                newVerticies[i] = _vertices[i];
            }

            _adjMatrix = newAdjMatrix;
            _vertices = newVerticies;
        }

        private int calculateMin(float[] dist, bool[] includedSet)
        {
            float min = float.MaxValue;
            int index = 0;

            for (int i = 0; i < _numberOfVerticies; i++)
            {
                if (includedSet[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    index = i;
                }
            }

            return index;
        }

        #endregion
    }
}
