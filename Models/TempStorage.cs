using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeRasmussen_Assignment3.Models
{
    public static class TempStorage
    {
        private static List<Movies> movies = new List<Movies>();
        public static IEnumerable<Movies> MovieList => movies;
        public static void AddMovie(Movies movie)
        {
            movies.Add(movie);
        }
    }
}
