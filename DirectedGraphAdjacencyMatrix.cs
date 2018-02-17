using System;
using System.Collections.Generic;

namespace GraphTraversal
{
    public class DirectedGraphAdjacencyMatrix : IDirectedGraph
    {
        //private readonly string _graphData;
        private readonly int DEFAULT_SIZE = 2;
        private int _numberOfVerticies;
        private float[,] _adjMatrix;
        private char[] _vertices;
        private int _count;

        #region Constructors
        public DirectedGraphAdjacencyMatrix()
        {
            _numberOfVerticies = 0;
            _adjMatrix = new float[DEFAULT_SIZE,DEFAULT_SIZE];
            _vertices = new char[DEFAULT_SIZE];
            _count = 0;
        }

        #endregion

        #region Public Interface Methods
        public void AddEdge(char vertex1, char vertex2, float weight)
        {
            addEdge(getIndex(vertex1), getIndex(vertex2), weight);
        }        

        public void AddEdge(char vertex1, char vertex2)
        {
            throw new NotImplementedException();
        }

        public void AddVertex(char vertex)
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
            _count++;
        }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<char> IterateBreadthFirstSearch(char startVertex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<char> IterateDepthFirstSearch(char startVertex)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(char vertex1, char vertex2)
        {
            throw new NotImplementedException();
        }

        public void RemoveVertex(char vertex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<char> ShortestPath(char startVertex, char endVertex)
        {
            throw new NotImplementedException();
        }

        public float ShortestPathWeight(char vertex1, char vertex2)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string graphString = "    ";

            foreach (char vert in _vertices)
            {
                graphString += $"{vert} ";
            }

            graphString += "\n    ---------\n";

            for (int i = 0; i < _vertices.Length; i++)
            {
                graphString += $"{_vertices[i]} | ";

                for (int j = 0; j < _vertices.Length; j++)
                {
                    graphString += $"{_adjMatrix[i, j]} ";
                }
                graphString += "\n";
            }

            return graphString;
        }

        public bool DoesVerticeExist(char vertex)
        {
            foreach (char vertecie in _vertices)
            {
                if (vertecie == vertex)
                {
                    return true;
                }
            }

            return false;
        }

        // I don't like casting weight as string to return
        // however, need this to be able to return 'no such route'
        // either that or throw exception and catch that in main and print 'no such route'
        // but this will lead to program termination...
        public string CalculatePathWeight(string path)
        {
            float pathWeight = 0.0f;
            string[] verticies = path.Split('-');

            for (int i = 0, j = 1; j < verticies.Length; i++, j++)
            {
                if (DoesVerticeExist(char.Parse(verticies[i])) && DoesVerticeExist(char.Parse(verticies[j])) && DoesPathExist(char.Parse(verticies[i]), char.Parse(verticies[j])))
                {
                    pathWeight += _adjMatrix[getIndex(char.Parse(verticies[i])),getIndex(char.Parse(verticies[j]))];
                }
                else
                {
                    return "NO SUCH ROUTE";
                }
            }

            return pathWeight.ToString();
        }

        public bool DoesPathExist(char vertex1, char vertex2)
        {
            return _adjMatrix[getIndex(vertex1),getIndex(vertex2)] != 0;
        }

        #endregion


        #region Private Methods
        private void addEdge(int index1, int index2, float weight)
        {
            if (isIndexValid(index1) && isIndexValid(index2) && isWeightValid(weight))
            {
                _adjMatrix[index1, index2] = weight;
                _count++;
            }
        }

        private int getIndex(char vertex)
        {
            int index = 0;
            foreach (char vertice in _vertices)
            {
                if (vertice == vertex)
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        private bool isIndexValid(int index)
        {
            return index >= 0 && index < _count ? true : false;
        }

        private bool isWeightValid(float weight)
        {
            return weight > 0;
        }

        private void expandCapacity()
        {
            int newSize = _vertices.Length * 2;
            char[] newVerticies = new char[newSize];
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

        #endregion
    }
}
