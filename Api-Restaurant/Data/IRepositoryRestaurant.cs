using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Restaurant.Domain.Entities;

namespace Api_Restaurant.Data
{
    public interface IRepositoryRestaurant
    {
        Restaurant Insert(Restaurant restaurant);
        IEnumerable<Restaurant> GetAll();
        Restaurant GetRestaurantById(string id);
        bool UpdateRestaurant(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetRestaurantFilter(string text);
    }
}