namespace DogShowCompanionAPI.Models
{
    public class CivicAddress
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string Building { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CountryRegion { get; set; } = string.Empty;
        public string FloorLevel { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string StateProvince { get; set; } = string.Empty;

    }
}
