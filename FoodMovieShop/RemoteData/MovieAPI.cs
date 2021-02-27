using FoodMovieShop.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodMovieShop.RemoteData
{
    public class MovieAPI
    {
        private const string URL = "http://www.omdbapi.com/";
        private const string KEY = "123f5c4f";
        private RestClient client;

        public MovieAPI()
        {
            this.client = new RestClient(URL);
        }

        public Movie GetRandomMovie() 
        {
            // get data
            Random random = new Random();
            var request = new RestRequest(Method.GET);
            request.AddParameter("apikey", KEY);
            request.AddParameter("t", (char) random.Next(97, 122));
            IRestResponse response = client.Execute(request);

            // parse and return data
            return ParseResponse(response.Content);
        }

        public Movie ParseResponse(string response)
        {
            Random random = new Random();
            var data = JObject.Parse(response);
            return new Movie(
                (string) data["Title"], random.Next(100, 2000), random.Next(0, 2000), 
                (string) data["Poster"], 0, (string) data["Director"]);
        }
    }
}
