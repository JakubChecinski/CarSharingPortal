﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShortestPathCalculator
{
    public static class CitiesDistancesData
    {
        public static List<string> GetCities()
        {
            return new List<string>()
            {
                "Białystok",
                "Bielsko-Biała",
                "Bydgoszcz",
                "Częstochowa",
                "Elbląg",
                "Gdańsk",
                "Gdynia",
                "Gliwice",
                "Katowice",
                "Kielce",
                "Koszalin",
                "Kraków",
                "Lublin",
                "Łódź",
                "Olsztyn",
                "Opole",
                "Poznań",
                "Radom",
                "Rzeszów",
                "Szczecin",
                "Toruń",
                "Warszawa",
                "Wrocław",
                "Zakopane",
                "Zielona Góra",
            };
        }

        public static int[,] GetAdjMatrix()
        {
            // note: only numbers smaller than 210 are included
            return new int[,] {
                {0,0,0,0,0,0,0,0,0,0,0,0,207,188,198,0,0,183,0,0,0,123,0,0,0},
                {0,0,0,110,0,0,0,72,57,166,0,101,0,0,0,123,0,0,175,0,0,0,169,132,0},
                {0,0,0,0,156,135,148,0,0,0,168,0,0,144,192,0,130,0,0,210,46,0,0,0,171},
                {0,110,0,0,0,0,0,59,58,123,0,137,0,134,0,105,0,159,189,0,197,169,157,203,0},
                {0,0,156,0,0,48,74,0,0,0,205,0,0,0,78,0,0,0,0,0,163,0,0,0,0},
                {0,0,135,0,48,0,42,0,0,0,175,0,0,207,112,0,0,0,0,0,99,0,0,0,0},
                {0,0,148,0,74,42,0,0,0,0,173,0,0,0,143,0,0,0,0,0,113,0,0,0,0},
                {0,72,0,59,0,0,0,0,22,153,0,84,0,185,0,74,0,188,156,0,0,0,108,169,0},
                {0,57,0,58,0,0,0,22,0,133,0,68,0,188,0,94,0,168,139,0,0,0,125,155,0},
                {0,166,0,123,0,0,0,153,133,0,0,126,144,177,0,204,0,62,140,0,0,133,0,0,0},
                {0,0,168,0,205,175,173,0,0,0,0,0,0,0,0,0,0,0,0,97,197,0,0,0,188},
                {0,101,0,137,0,0,0,84,68,126,0,0,0,0,0,165,0,152,114,0,0,0,178,143,0},
                {207,0,0,0,0,0,0,0,0,144,0,0,0,0,0,0,0,91,167,0,0,111,0,0,0},
                {188,0,144,134,0,207,0,185,188,177,0,0,0,0,0,169,159,139,0,0,115,102,139,0,206},
                {198,0,192,0,78,112,143,0,0,0,0,0,0,0,0,0,0,0,0,0,154,186,0,0,0},
                {0,123,0,105,0,0,0,74,94,204,0,165,0,169,0,0,187,0,210,0,0,0,83,0,0},
                {0,0,130,0,0,0,0,0,0,0,0,0,0,159,0,187,0,0,0,155,134,197,114,0,94},
                {183,0,0,159,0,0,0,188,168,62,0,152,91,139,0,0,0,0,197,0,196,99,0,0,0},
                {0,175,0,189,0,0,0,156,139,140,0,114,167,0,0,210,0,197,0,0,0,0,0,197,0},
                {0,0,210,0,0,0,0,0,0,0,97,0,0,0,0,0,155,0,0,0,0,0,0,0,121},
                {0,0,46,197,163,99,113,0,0,0,197,0,0,115,154,0,134,196,0,0,0,162,0,0,198},
                {123,0,0,169,0,0,0,0,0,133,0,0,111,102,186,0,197,99,0,0,162,0,208,0,0},
                {0,169,0,157,0,0,0,108,125,0,0,178,0,139,0,83,114,0,0,0,0,208,0,0,126},
                {0,132,0,203,0,0,0,169,155,0,0,143,0,0,0,0,0,0,197,0,0,0,0,0,0},
                {0,0,171,0,0,0,0,0,0,0,188,0,0,206,0,0,94,0,0,121,198,0,126,0,0},
            };
        }


    }
}
