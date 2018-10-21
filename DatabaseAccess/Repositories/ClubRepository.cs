using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel.QueryResults;
using DatabaseAccess.InternalModel.StoredProcedureResults;
using DatabaseAccess.Repositories.Interfaces;

namespace DatabaseAccess.Repositories
{
    public class ClubRepository : IClubRepository
    { 
        public async Task<ReadOnlyCollection<AllClubsResult>> GetAllClubsAsync()
        {
            List<AllClubsResult> clubs = new List<AllClubsResult>();

            using (var context = new DatabaseContext())
            {
                var databaseClubs = await context.Database.SqlQuery<GetClubsResult>("dbo.api_GetAllClubs").ToListAsync();

                foreach (GetClubsResult databaseClub in databaseClubs)
                {
                    AllClubsResult newClub = new AllClubsResult(databaseClub.ClubId, databaseClub.ShortName, databaseClub.LongName);
                    clubs.Add(newClub);
                }
            }

            return new ReadOnlyCollection<AllClubsResult>(clubs);
        }

        public async Task<ExternalModel.Club> GetClubAsync(int clubId)
        {
            ExternalModel.Club newClub = null;

            using (var context = new DatabaseContext())
            {
                InternalModel.Club club = await context.Clubs.SingleOrDefaultAsync(cl => cl.ClubId == clubId);

                if (club != null)
                {
                    newClub = ExternalModel.Club.Convert(club);
                }
            }

            return newClub;
        }
    }
}

   

