namespace DogShowCompanionAPI.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public int KennelId { get; set; }
        public string CommonName { get; set; } = string.Empty;
        public string OfficialName { get; set; } = string.Empty;
        public string AkcId { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Age { get; set; }= string.Empty;
        public DogBreed? Breed { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Microchip { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public DogColor? Color { get; set; }
        public DogGroup? Group { get; set; }

    }
}
