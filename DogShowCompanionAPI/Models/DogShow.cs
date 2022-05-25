namespace DogShowCompanionAPI.Models
{
    public class DogShow
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CivicAddress? Address { get; set; }
        public double EntryFee { get; set; }
        public double Distance { get; set; }
        public List<DogShowClass>? Classes { get; set; }

    }
}
