using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
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
                    Cuisine = CuisineType.Indian
                }
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = Guid.NewGuid();
            _restaurants.Add(restaurant);
        }

        public void Delete(Guid? id)
        {
            var restaurant = Get(id);
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }
        }

        public Restaurant Get(Guid? id)
        {
            return _restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {
                //existing.Id = restaurant.Id;
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
