using System;
using Api_Restaurant.Domain.Enums;

namespace Api_Restaurant.Domain.Entities
{
    public class Restaurant
    {
        public string Id { get; set; } = $"{Guid.NewGuid()}";
        public string Name { get; set; }
        public ENationality Nationality { get; set; }
        public Address Address { get; set; }
    }
    
}