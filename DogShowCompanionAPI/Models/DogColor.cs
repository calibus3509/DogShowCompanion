namespace DogShowCompanionAPI.Models
{
    public class DogColor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsStandard { get; set; }
        public string RegistrationCode { get; set; } =string.Empty;

    }
}
