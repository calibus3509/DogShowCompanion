using Microsoft.EntityFrameworkCore;
using DogShowCompanionAPI.Models;
namespace DogShowCompanionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DogShow> DogShows { get; set; }
        public DbSet<Kennel> Kennels { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<CivicAddress> Addresses { get; set; }
        public DbSet<DogBreed> DogBreeds { get; set; }
        public DbSet<DogColor> DogColors { get; set; }
        public DbSet<DogShowClass> DogShowClasses { get; set; }
        public DbSet<DogShowClassCategory> DogShowClassCategories { get; set; }
        public DbSet<DogTrait> DogTraits { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<DogShowCompanionAPI.Models.DogGroup>? DogGroup { get; set; }



    }
}
