namespace DogShowCompanionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DogShow> DogShows { get; set; }
    }
}
