using MovieLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Helpers
{
    public class ListSorter
    {
        public static List<Movie> CombineMovieListsWithioutDoubles(List<Movie> listToTakeFrom, List<Movie> listToAddTo)
        {
            var listOfTitles = new List<string>();
            foreach (var movie in listToAddTo)
            {
                listOfTitles.Add(movie.title);
            }

            foreach (var movie in listToTakeFrom)
            {
                if (listOfTitles.Contains(movie.title))
                {
                    continue;
                }
                else
                {
                    listToAddTo.Add(movie);
                }
            }
            return listToAddTo;
        }

        public static List<Movie> orderList(bool orderByAscending, List<Movie> listToOrder)
        {
            List<Movie> orderedList;
            if (orderByAscending)
            {
                orderedList = listToOrder.OrderBy(e => e.rated).ToList();
            }
            else
            {
                orderedList = listToOrder.OrderByDescending(e => e.rated).ToList();
            }

            return orderedList;
        }
    }
}
