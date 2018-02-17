using System;

namespace GraphTraversal
{
    public class Program
    {
        static void Main(string[] args)
        {
            string rawGraphData = @"AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";

            IDirectedGraph graph = new DirectedGraphAdjacencyMatrix();

            buildGraphFromInitialState(graph, rawGraphData);

            // Question 1: The distance of the route A-B-C
            Console.WriteLine($" The distance of A-B-C => {graph.CalculatePathWeight("A-B-C")}");

            // Question 2: The distance of the route A-D
            Console.WriteLine($" The distance of A-D => {graph.CalculatePathWeight("A-D")}");

            // Question 3: The distance of the route A-D-C
            Console.WriteLine($" The distance of A-D-C => {graph.CalculatePathWeight("A-D-C")}");

            // Question 4: The distance of the route A-E-B-C-D
            Console.WriteLine($" The distance of A-E-B-C-D => {graph.CalculatePathWeight("A-E-B-C-D")}");

            Console.Write(graph.ToString());
        }
        
        public static void buildGraphFromInitialState(IDirectedGraph graph, string rawGraphData)
        {
            string[] verticeEdgeData = rawGraphData.Split(",");

            foreach (string verticeEdge in verticeEdgeData)
            {
                string verticeEdgeTrimmed = verticeEdge.Trim();

                char vertecie1 = Char.Parse(verticeEdgeTrimmed.Substring(0, 1));
                char vertecie2 = Char.Parse(verticeEdgeTrimmed.Substring(1, 1));
                float weight = float.Parse(verticeEdgeTrimmed.Substring(2, verticeEdgeTrimmed.Length - 2));

                if (!graph.Exists(vertecie1))
                {
                    graph.AddVertex(vertecie1);
                }

                if (!graph.Exists(vertecie2))
                {
                    graph.AddVertex(vertecie2);
                }

                graph.AddEdge(vertecie1, vertecie2, weight);
            }
        }
    }
}
