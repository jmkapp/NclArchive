using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DatabaseAccess.Repositories
{
    public class ClubRepository
    {
        public ReadOnlyCollection<ExternalModel.Club> GetAllClubs()
        {
            List<ExternalModel.Club> clubs = new List<ExternalModel.Club>();

            using (var context = new DatabaseContext())
            {
                var databaseClubs = context.Database.SqlQuery<InternalModel.Club>("dbo.api_GetAllClubs");

                foreach (InternalModel.Club databaseClub in databaseClubs)
                {
                    ExternalModel.Club newClub = new ExternalModel.Club(databaseClub.ClubId.ToString(), databaseClub.ShortName, databaseClub.LongName);
                    clubs.Add(newClub);
                }

            }

            return new ReadOnlyCollection<ExternalModel.Club>(clubs);
        }
    }
}
