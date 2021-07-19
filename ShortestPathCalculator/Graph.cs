using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestPathCalculator
{
    public class Graph
    {
        private int[,] adjMatrix;
        public List<string> Cities { get; set; }
        public Graph()
        {
            Cities = CitiesDistancesData.GetCities();
            adjMatrix = CitiesDistancesData.GetAdjMatrix();
            if (adjMatrix.GetLength(0) != adjMatrix.GetLength(1) || adjMatrix.GetLength(0) != Cities.Count)
                throw new Exception("Failed to initalize graph");
        }

    }
}
