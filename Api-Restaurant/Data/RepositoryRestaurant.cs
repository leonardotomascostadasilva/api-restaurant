using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Restaurant.Domain.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Api_Restaurant.Data
{
    public class RepositoryRestaurant : IRepositoryRestaurant
    {
        private readonly IMongoCollection<Restaurant> _restaurants;

        public RepositoryRestaurant(Mongo mongo)
        {
            _restaurants = mongo.Db.GetCollection<Restaurant>("restaurantes");
        }

        public Restaurant Insert(Restaurant restaurant)
        {
            _restaurants.InsertOne(restaurant);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var restaurants = _restaurants.AsQueryable();

            return restaurants;
        }

        public Restaurant GetRestaurantById(string id)
        {
            return _restaurants.AsQueryable().FirstOrDefault(r => r.Id == id);
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            var result = _restaurants.ReplaceOne(_ => _.Id == restaurant.Id, restaurant);

            return result.ModifiedCount > 0;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantFilter(string text)
        {
            var filter = Builders<Restaurant>.Filter.Text(text);
            var restaurants = new List<Restaurant>();
            
            await _restaurants
                .AsQueryable()
                .Where(_ => filter.Inject())
                .ForEachAsync(restaurant => restaurants.Add(restaurant));

            return restaurants;
        }
    }
}