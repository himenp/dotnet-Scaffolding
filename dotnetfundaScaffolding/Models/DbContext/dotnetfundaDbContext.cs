using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace dotnetfundaScaffolding.Models
{
    public class dotnetfundaDbContext : DbContext
    {
        public dotnetfundaDbContext()
            : base("name=dotnetfundaDbContext")
        {
            //This will turn off Database initializer.
            Database.SetInitializer<dotnetfundaDbContext>(null);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}