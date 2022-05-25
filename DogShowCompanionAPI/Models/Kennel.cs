namespace DogShowCompanionAPI.Models
{
    public class Kennel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public CivicAddress? Address { get; set; }
        public List<Dog>? Dogs { get; set; }
        public List<Person>? Owners { get; set; }
    }
}
