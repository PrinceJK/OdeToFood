using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(Guid? id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(Guid? id);
    }
}
