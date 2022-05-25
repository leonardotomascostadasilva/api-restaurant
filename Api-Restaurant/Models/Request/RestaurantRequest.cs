using Api_Restaurant.Domain.Entities;
using Api_Restaurant.Domain.Enums;

namespace Api_Restaurant.Models.Request
{
    public class RestaurantRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ENationality Nationality { get; set; }
        public Address Address { get; set; }

        public static implicit operator Restaurant(RestaurantRequest request)
        {
            if (request is null) return null;

            if (request.Id is null)
            {
                return new Restaurant
                {
                    Name = request.Name,
                    Nationality = request.Nationality,
                    Address = new Address
                    {
                        Cep = request.Address.Cep,
                        City = request.Address.City,
                        Number = request.Address.Number,
                        Street = request.Address.Street,
                        Uf = request.Address.Uf
                    }
                };
            }

            return new Restaurant
            {
                Id = request.Id,
                Name = request.Name,
                Nationality = request.Nationality,
                Address = new Address
                {
                    Cep = request.Address.Cep,
                    City = request.Address.City,
                    Number = request.Address.Number,
                    Street = request.Address.Street,
                    Uf = request.Address.Uf
                }
            };
        }
    }
}