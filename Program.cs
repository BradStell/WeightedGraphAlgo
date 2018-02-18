using System;

namespace GraphTraversal
{
    public class Program
    {
        static void Main(string[] args)
        {
            string rawGraphData = @"AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";

            IDirectedGraph<char> graph = new DirectedGraph<char>();

            buildGraphFromInitialState(graph, rawGraphData);

            // Question 1: The distance of the route A-B-C
            Console.WriteLine($" The distance of A-B-C \t\t | {CalculatePathWeight(graph, "A-B-C")}");

            // Question 2: The distance of the route A-D
            Console.WriteLine($" The distance of A-D \t\t | {CalculatePathWeight(graph, "A-D")}");

            // Question 3: The distance of the route A-D-C
            Console.WriteLine($" The distance of A-D-C \t\t | {CalculatePathWeight(graph, "A-D-C")}");

            // Question 4: The distance of the route A-E-B-C-D
            Console.WriteLine($" The distance of A-E-B-C-D \t | {CalculatePathWeight(graph, "A-E-B-C-D")}");

            // Question 5: The distance of the route A-E-D
            Console.WriteLine($" The distance of A-E-D \t\t | {CalculatePathWeight(graph, "A-E-D")}");

            // Question 6: # of trips starting at C and ending at C with <= 3 stops
            Console.WriteLine($" # of trips from C to C \t | {graph.NumberOfTripsBetweenVerticiesLessThanStops('C', 'C', 3)}");

            // Question 7: # of trips starting at A and ending at C with <= 4 stops
            Console.WriteLine($" # of trips from A to C \t | {graph.NumberOfTripsBetweenVerticiesWithExactStops('A', 'C', 4)}");

            // Question 8: Shortest path from A-C
            Console.WriteLine($" Shortest path from A to C \t | {graph.ShortestPath('A', 'C')}");

            // Question 8: Shortest path from B-B
            Console.WriteLine($"Shortest path from B to B \t | {graph.ShortestPath('B', 'B')}");

            // Question 9: # of different routes from C to C with distance less than 30
            Console.WriteLine($"# of trips from C to C with distance less than 30 => {graph.NumberOfTripsBetweenVerticiesLessThanDistance('C', 'C', 30)}");

            Console.WriteLine("\nGraph Adj Matrix::\n");
            Console.Write(graph.ToString());
        }

        public static string CalculatePathWeight(IDirectedGraph<char> graph, string path)
        {
            float pathWeight = 0.0f;
            string[] verticies = path.Split('-');

            for (int i = 0, j = 1; j < verticies.Length; i++, j++)
            {
                if (graph.VertexExists(char.Parse(verticies[i])) && graph.VertexExists(char.Parse(verticies[j])) && graph.DoesPathExist(char.Parse(verticies[i]), char.Parse(verticies[j])))
                {
                    pathWeight += graph.GetPathWeight(char.Parse(verticies[i]), char.Parse(verticies[j]));
                }
                else
                {
                    return "NO SUCH ROUTE";
                }
            }

            return pathWeight.ToString();
        }
        
        public static void buildGraphFromInitialState(IDirectedGraph<char> graph, string rawGraphData)
        {
            string[] verticeEdgeData = rawGraphData.Split(",");

            foreach (string verticeEdge in verticeEdgeData)
            {
                string verticeEdgeTrimmed = verticeEdge.Trim();

                char vertecie1 = Char.Parse(verticeEdgeTrimmed.Substring(0, 1));
                char vertecie2 = Char.Parse(verticeEdgeTrimmed.Substring(1, 1));
                float weight = float.Parse(verticeEdgeTrimmed.Substring(2, verticeEdgeTrimmed.Length - 2));

                if (!graph.VertexExists(vertecie1))
                {
                    graph.AddVertex(vertecie1);
                }

                if (!graph.VertexExists(vertecie2))
                {
                    graph.AddVertex(vertecie2);
                }

                graph.AddEdge(vertecie1, vertecie2, weight);
            }
        }
    }
}
