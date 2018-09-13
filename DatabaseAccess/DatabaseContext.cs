using System.Data.Entity;
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
    }
}
