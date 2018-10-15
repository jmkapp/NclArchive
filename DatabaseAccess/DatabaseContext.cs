using System.Data.Entity;
using System.Security.Policy;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace DatabaseAccess
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=NclArchive")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DatabaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<InternalModel.Club> Clubs { get; set; }
        public DbSet<InternalModel.Team> Teams { get; set; }
        public DbSet<InternalModel.Game> Games { get; set; }
        public DbSet<InternalModel.Season> Seasons { get; set; }
        public DbSet<InternalModel.Division> Divisions { get; set; }
        public DbSet<InternalModel.Venue> Venues { get; set; }
    }
}
