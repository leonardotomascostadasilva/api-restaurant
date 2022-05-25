using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Restaurant.Data;
using Api_Restaurant.Domain.Entities;

namespace Api_Restaurant.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepositoryRestaurant _repositoryRestaurant;

        public RestaurantService(IRepositoryRestaurant repositoryRestaurant)
        {
            _repositoryRestaurant = repositoryRestaurant;
        }


        public Restaurant InsertRestaurant(Restaurant restaurant)
        {
            return _repositoryRestaurant.Insert(restaurant);
        }
        
        public IEnumerable<Restaurant> GetAllRestaurant()
        {
            return _repositoryRestaurant.GetAll();
        }

        public Restaurant GetRestaurantById(string id)
        {
            return _repositoryRestaurant.GetRestaurantById(id);
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            return _repositoryRestaurant.UpdateRestaurant(restaurant);
        }
        public async Task<IEnumerable<Restaurant>> GetRestaurantFilter(string text)
        {
            return await _repositoryRestaurant.GetRestaurantFilter(text);
        }
    }
}