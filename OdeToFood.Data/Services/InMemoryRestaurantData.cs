using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Id = Guid.NewGuid(),
                    Name = "Scott's Pizza",
                    Cuisine = CuisineType.Italian
                },
                 new Restaurant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tersiguels",
                    Cuisine = CuisineType.French
                },
                  new Restaurant
                {
                    Id = Guid.NewGuid(),
                    Name = "Mango Grove",
                    Cuisine = CuisineType.Italian
                }
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = Guid.NewGuid();
            restaurants.Add(restaurant);
        }

        public Restaurant Get(Guid? id)
        {
             return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
