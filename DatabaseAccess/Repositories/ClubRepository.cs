using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public class ClubRepository : IClubRepository
    { 
        public async Task<ReadOnlyCollection<ExternalModel.AllClubsResult>> GetAllClubsAsync()
        {
            List<ExternalModel.AllClubsResult> clubs = new List<ExternalModel.AllClubsResult>();

            using (var context = new DatabaseContext())
            {
                var databaseClubs = await context.Database.SqlQuery<InternalModel.GetClubsResult>("dbo.api_GetAllClubs").ToListAsync();

                foreach (InternalModel.GetClubsResult databaseClub in databaseClubs)
                {
                    ExternalModel.AllClubsResult newClub = new ExternalModel.AllClubsResult(databaseClub.ClubId.ToString(), databaseClub.ShortName, databaseClub.LongName);
                    clubs.Add(newClub);
                }

            }

            return new ReadOnlyCollection<ExternalModel.AllClubsResult>(clubs);
        }

        public async Task<ExternalModel.Club> GetClubAsync(string clubReference)
        {
            ExternalModel.Club newClub = null;

            bool converts = int.TryParse(clubReference, out int clubId);

            if (converts == false)
                return null;

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

   

