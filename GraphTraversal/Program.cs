﻿using System;

namespace GraphTraversal
{
    public class Program
    {
        public static readonly string RAW_GRAPH_DATA = @"AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";

        static void Main(string[] args)
        {
            try
            {
                string rawGraphData = args.Length == 1 ? args[0] : RAW_GRAPH_DATA;

                IDirectedGraph<char> graph = new DirectedGraph<char>();

                buildGraphFromInitialState(graph, rawGraphData);

                // Question 1: The distance of the route A-B-C
                Console.WriteLine($" The distance of A-B-C \t\t | {graph.CalculatePathWeight(new char[] {'A', 'B', 'C'})}");

                // Question 2: The distance of the route A-D
                Console.WriteLine($" The distance of A-D \t\t | {graph.CalculatePathWeight(new char[] {'A', 'D'})}");

                // Question 3: The distance of the route A-D-C
                Console.WriteLine($" The distance of A-D-C \t\t | {graph.CalculatePathWeight(new char[] {'A', 'D', 'C'})}");

                // Question 4: The distance of the route A-E-B-C-D
                Console.WriteLine($" The distance of A-E-B-C-D \t | {graph.CalculatePathWeight(new char[] {'A', 'E', 'B', 'C', 'D'})}");

                // Question 5: The distance of the route A-E-D
                Console.WriteLine($" The distance of A-E-D \t\t | {graph.CalculatePathWeight(new char[] {'A', 'E', 'D'})}");

                // Question 6: # of trips starting at C and ending at C with <= 3 stops
                Console.WriteLine($" # of trips from C to C \t | {graph.NumberOfTripsBetweenVerticiesLessThanStops('C', 'C', 3)}");

                // Question 7: # of trips starting at A and ending at C with <= 4 stops
                Console.WriteLine($" # of trips from A to C \t | {graph.NumberOfTripsBetweenVerticiesWithExactStops('A', 'C', 4)}");

                // Question 8: Shortest path from A-C
                Console.WriteLine($" Shortest path from A to C \t | {graph.ShortestPath('A', 'C')}");

                // Question 9: Shortest path from B-B
                Console.WriteLine($" Shortest path from B to B \t | {graph.ShortestPath('B', 'B')}");

                // TODO figure this $h!t out
                // Question 10: # of different routes from C to C with distance less than 30
                Console.WriteLine($" # of trips from C to C with distance less than 30 => {graph.NumberOfTripsBetweenVerticiesLessThanDistance('C', 'C', 30)}");

                Console.WriteLine("\nGraph Adjacency Matrix::\n");
                Console.Write(graph.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error with the way the application was called. Please try again");
                Console.WriteLine($"\n***********************\nError message:\n\t{ex.Message}\n\n");
            }
        }
        
        public static void buildGraphFromInitialState(IDirectedGraph<char> graph, string rawGraphData)
        {
            try
            {
                string[] verticeEdgeData = rawGraphData.Split(",");

                foreach (string verticeEdge in verticeEdgeData)
                {
                    string verticeEdgeTrimmed = verticeEdge.Trim();

                    char vertecie1 = Char.Parse(verticeEdgeTrimmed.Substring(0, 1));
                    char vertecie2 = Char.Parse(verticeEdgeTrimmed.Substring(1, 1));
                    float weight = float.Parse(verticeEdgeTrimmed.Substring(2, verticeEdgeTrimmed.Length - 2));

                    graph.AddVertex(vertecie1);
                    graph.AddVertex(vertecie2);

                    graph.AddEdge(vertecie1, vertecie2, weight);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("The graph data was passed in an incorrect form.\n\tFor a node A that connects to a node B with a weight of 5 pass data in like 'AB5'.\n\tSeparate data by columns: 'AB5, AC2'");
                throw;                
            }
        }
    }
}
