namespace DogShowCompanionAPI.Models
{
    public class DogShowClass
    {
        public int Id { get; set; }
        public DogShowClassCategory? Category { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DogBreed? Breed { get; set; }
        public int RingNumber { get; set; }
        public DateTime StartTime { get; set; }
        public Person? Judge { get; set; }
        public List<Dog>? Dogs { get; set; }
    }
}
