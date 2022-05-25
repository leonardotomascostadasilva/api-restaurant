using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Restaurant.Domain.Entities;

namespace Api_Restaurant.Service
{
    public interface IRestaurantService
    {
        Restaurant InsertRestaurant(Restaurant restaurant);
        IEnumerable<Restaurant> GetAllRestaurant();
        Restaurant GetRestaurantById(string id);
        bool UpdateRestaurant(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetRestaurantFilter(string text);
    }
}