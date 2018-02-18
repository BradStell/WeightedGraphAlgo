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

            // Question 5: The distance of the route A-E-D
            Console.WriteLine($" The distance of A-E-D => {graph.CalculatePathWeight("A-E-D")}");

            // Question 6: # of trips starting at C and ending at C with <= 3 stops
            Console.WriteLine($"# of trips from C to C => {graph.NumberOfTripsBetweenVerticiesLessThanStops('C', 'C', 3)}");

            // Question 7: # of trips starting at A and ending at C with <= 4 stops
            Console.WriteLine($"# of trips from A to C => {graph.NumberOfTripsBetweenVerticiesWithExactStops('A', 'C', 4)}");

            // Question 8: Shortest path from A-C
            Console.WriteLine($"Shortest path from A to C => {graph.ShortestPath('A', 'C')}");

            // Question 8: Shortest path from B-B
            Console.WriteLine($"Shortest path from B to B => {graph.ShortestPath('B', 'B')}");

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

                if (!graph.DoesVerticeExist(vertecie1))
                {
                    graph.AddVertex(vertecie1);
                }

                if (!graph.DoesVerticeExist(vertecie2))
                {
                    graph.AddVertex(vertecie2);
                }

                graph.AddEdge(vertecie1, vertecie2, weight);
            }
        }
    }
}
