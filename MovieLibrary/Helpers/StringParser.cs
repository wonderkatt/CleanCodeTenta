using MovieLibrary.DTO;
using MovieLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Helpers
{
    public class StringParser
    {
        public static List<Movie> ParseMovieList(List<MovieDTO> data)
        {
            var parsedMovieList = new List<Movie>();
            try
            {
                foreach (var movie in data)
                {
                    parsedMovieList.Add(new Movie
                    {
                        id = movie.id,
                        title = movie.title,
                        rated = getRatingInFloatingNumber(movie.rated)
                    }); 
                }
            }
            catch (Exception)
            {

                throw;
            }
            return parsedMovieList;
        }

        private static float getRatingInFloatingNumber(string rated)
        {
            if(string.IsNullOrEmpty(rated))
            {
                return 0f;
            }
            var newString = rated.Replace(',', '.');
            return float.Parse(newString);
        }

       
    }
}
