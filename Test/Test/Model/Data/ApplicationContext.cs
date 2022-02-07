using Microsoft.EntityFrameworkCore;


namespace Test.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tamb> Tambs { get; set; }
        public DbSet<Lab> Labs { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;");
        }
    }
}
