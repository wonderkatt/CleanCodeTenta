using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.DTO;
using MovieLibrary.Entities;
using MovieLibrary.Helpers;
using System.Collections.Generic;

namespace MovieLibraryTest
{
    [TestClass]
    public class MovieLibraryTests
    {
        [TestMethod]
        public void ParseListFromDTOtoMovieEntity()
        {
            var movieDTOList = new List<MovieDTO>
            {
                new MovieDTO{id = "id", title = "title", rated = "8,8"}
            };
            var movieList = new List<Movie>
            {
                new Movie
                {
                    id = "id", title = "title", rated = 8.8f
                }
            };

            var parsedList = StringParser.ParseMovieList(movieDTOList);

            Assert.AreEqual(parsedList[0].title, movieList[0].title);
            Assert.AreEqual(parsedList[0].rated, movieList[0].rated);
            Assert.AreEqual(parsedList[0].id, movieList[0].id);
        }

        [TestMethod]
        public void OrderListByDescending()
        {
            var fistMovie = new Movie
            {
                id = "1",
                title = "first",
                rated = 10f
            };
            var secondMovie = new Movie
            {
                id = "2",
                title = "second",
                rated = 0f
            };
            var listToSort = new List<Movie>
            {
                fistMovie,
                secondMovie
            };

            var actual = ListSorter.orderList(false, listToSort);

            Assert.AreEqual(fistMovie, actual[0]);
        }

        [TestMethod]
        public void RemoveDoubleMovies()
        {
            var fistMovie = new Movie
            {
                id = "1",
                title = "first",
                rated = 10f
            };
            var secondMovie = new Movie
            {
                id = "2",
                title = "second",
                rated = 0f
            };
            var thirdMovie = new Movie
            {
                id = "3",
                title = "third",
                rated = 0f
            };
            var firstList = new List<Movie>
            {
                fistMovie,
                secondMovie,
                thirdMovie
            };
            var secondList = new List<Movie>
            {
                fistMovie
            };

            var actual = ListSorter.CombineMovieListsWithioutDoubles(firstList, secondList);

            Assert.AreEqual(3, actual.Count);
        }
    }
}
