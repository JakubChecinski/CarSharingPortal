using System;

namespace ShortestPathCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = "Gdynia";
            var end = "Szczecin";

            Graph graph = new Graph();
            graph.FindShortestTest(start, end);
            foreach (string city in graph.FindShortest(start, end)) Console.WriteLine(city);
        }
    }
}
