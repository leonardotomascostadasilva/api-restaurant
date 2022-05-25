using Api_Restaurant.Domain.Entities;
using Api_Restaurant.Domain.Enums;
using Api_Restaurant.Models.Request;

namespace Api_Restaurant.Models.Response
{
    public class RestaurantResponse
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public ENationality Nationality { get; private set; }
        public Address Address { get; private set; }

        public static implicit operator RestaurantResponse(Restaurant restaurant)
        {
            return new RestaurantResponse
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Nationality = restaurant.Nationality,
                Address = new Address
                {
                    Cep = restaurant.Address.Cep,
                    City = restaurant.Address.City,
                    Number = restaurant.Address.Number,
                    Street = restaurant.Address.Street,
                    Uf = restaurant.Address.Uf
                }
            };
        }
    }
}