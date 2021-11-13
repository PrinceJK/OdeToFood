using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantDate : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantDate()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Scott's Pizza",
                    Cuisine = CuisineType.Italian
                },
                 new Restaurant
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tersiguels",
                    Cuisine = CuisineType.French
                },
                  new Restaurant
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Mango Grove",
                    Cuisine = CuisineType.Italian
                }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
