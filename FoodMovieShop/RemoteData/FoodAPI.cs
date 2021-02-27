using FoodMovieShop.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace FoodMovieShop.RemoteData
{
    public class FoodAPI
    {
        private const string URL = "https://api.spoonacular.com/recipes/random";
        private const string KEY = "e062797e705d486b999cefa90b7dc748";
        private RestClient client;

        public FoodAPI()
        {
            this.client = new RestClient(URL);
        }

        public List<Food> GetRandomFood(int count)
        {
            // get data
            var request = new RestRequest(Method.GET);
            request.AddParameter("apiKey", KEY);
            request.AddParameter("number", count);
            IRestResponse response = client.Execute(request);

            // parse and return data
            return ParseResponse(response.Content);
        }

        private List<Food> ParseResponse(string response)
        {
            var data = JObject.Parse(response)["recipes"];
            List<Food> result = new List<Food>();
            Random random = new Random();

            foreach (var item in data) 
            {
                result.Add(new Food(
                    (string) item["title"],
                    (int) item["pricePerServing"],
                    random.Next(0, 1000),
                    (string) item["image"],
                    random.Next(0, 100),
                    (int) item["readyInMinutes"]
                    ));
            }

            return result;
        }
    }
}
