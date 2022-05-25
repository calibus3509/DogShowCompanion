namespace DogShowCompanionAPI.Models
{
    public class DogBreed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<DogTrait>? Traits { get; set; }
        public string About { get; set; } = string.Empty;
        public List<DogColor>? Colors { get; set; }


    }
}
