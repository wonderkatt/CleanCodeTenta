using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.DTO;
using MovieLibrary.Entities;
using MovieLibrary.Helpers;
using RestSharp;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
     
        private const string BASE_URL = "https://ithstenta2020.s3.eu-north-1.amazonaws.com";
        [HttpGet]
        [Route("/movies")]
        public ActionResult GetDetailedList(bool orderByAscending = true)
        {
            var top100List = GetTop100MovieList();
            var parsedMovieList = GetDetailedMovies();
            var listToOrder = ListSorter.CombineMovieListsWithioutDoubles(parsedMovieList, top100List);
            var orderedList = ListSorter.orderList(orderByAscending, listToOrder);
            var listOfTitles = new List<string>();
            foreach (var movie in orderedList)
            {
                listOfTitles.Add(movie.title);
            }
            return Ok(listOfTitles);
        }

        private static List<Movie> GetDetailedMovies()
        {
            var url = BASE_URL + "/detailedMovies.json";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Get<List<MovieDTO>>(request);
            var data = response.Data;
            var parsedMovieList = StringParser.ParseMovieList(data);
            return parsedMovieList;
        }

        [HttpGet]
        [Route("/movie")]
        public ActionResult GetMovieById(string id)
        {
            var top100List = GetTop100MovieList();
            var detailedMovieList = GetDetailedMovies();
            var combinedList = ListSorter.CombineMovieListsWithioutDoubles(detailedMovieList, top100List);
            return Ok(combinedList.FirstOrDefault(movie => movie.id == id));
        }

        private List<Movie> GetTop100MovieList()
        {
            var url = BASE_URL + "/topp100.json";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Get<List<MovieDTO>>(request);
            var data = response.Data;
            return StringParser.ParseMovieList(data);
        }
    }
}