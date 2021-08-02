using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuikGraph;
using QuikGraph.Algorithms;

namespace ShortestPathCalculator
{
    public class Graph
    {
        private int[,] adjMatrix;
        private AdjacencyGraph<string, TaggedEdge<string, int>> libraryGraph;
        public List<string> Cities { get; set; }
        public Graph()
        {
            Cities = CitiesDistancesData.GetCities();
            adjMatrix = CitiesDistancesData.GetAdjMatrix();
            if (adjMatrix.GetLength(0) != adjMatrix.GetLength(1) || adjMatrix.GetLength(0) != Cities.Count)
                throw new Exception("Failed to initalize graph");
            CreateLibraryGraph();
        }

        private void CreateLibraryGraph()
        {
            libraryGraph = new AdjacencyGraph<string, TaggedEdge<string, int>>();
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjMatrix.GetLength(1); j++)
                {
                    if (adjMatrix[i, j] == 0) continue;
                    libraryGraph.AddVerticesAndEdge(
                        new TaggedEdge<string, int>(Cities[i], Cities[j], adjMatrix[i, j]));
                }
            }
            
        }
        public void FindShortestTest(string start, string end, int maxNumberOfPaths = 4)
        {
            var graph = libraryGraph.ToBidirectionalGraph();
            foreach (var path in graph
                .RankedShortestPathHoffmanPavley(edge => edge.Tag, start, end, maxNumberOfPaths))
            {
                int totalDistance = 0;
                foreach (var node in path)
                {
                    Console.WriteLine(node);
                    totalDistance += node.Tag;
                }
                Console.WriteLine("Total distance: " + totalDistance);
                Console.WriteLine();
            }
        }
        public List<string> FindShortest(string start, string end, int maxNumberOfPaths = 4, double tolerance = 0.25)
        {
            // prepare graph and execute algorithm
            List<string> acceptableConnections = new List<string>();
            var graph = libraryGraph.ToBidirectionalGraph();
            var shortestPaths = graph.RankedShortestPathHoffmanPavley(edge => edge.Tag, start, end, maxNumberOfPaths);
            // calculate the shortest distance
            if (shortestPaths == null || shortestPaths.Count() == 0) return null;
            var theShortestPath = shortestPaths.ElementAt(0);
            int theShortestDistance = 0;
            foreach (var node in theShortestPath)
            {
                theShortestDistance += node.Tag;
            }
            // choose alternative paths within tolerance limit
            for(int i = 1; i < shortestPaths.Count(); i++)
            {
                int totalDistance = 0;
                foreach (var node in shortestPaths.ElementAt(i))
                {
                    totalDistance += node.Tag;
                }
                if ((double)totalDistance < (double)theShortestDistance * (1.0 + tolerance))
                {
                    foreach (var node in shortestPaths.ElementAt(i)) acceptableConnections.Add(node.Target);
                }
            }
            // prepare and return output
            acceptableConnections = acceptableConnections.Distinct().ToList();
            if (acceptableConnections.Contains(end)) acceptableConnections.Remove(end);
            return acceptableConnections;
        }


    }

}
