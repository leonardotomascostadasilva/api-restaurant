namespace Api_Restaurant.Domain.Entities
{
    public class Address
    {
        public Address(string street, string number, string city, string uf, string cep)
        {
            Street = street;
            Number = number;
            City = city;
            Uf = uf;
            Cep = cep;
        }

        public Address()
        {
            
        }
        public string Street { get;  set; }
        public string Number { get;  set; }
        public string City { get;  set; }
        public string Uf { get;  set; }
        public string Cep { get;  set; }
    }
}