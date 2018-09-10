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
    }
}
