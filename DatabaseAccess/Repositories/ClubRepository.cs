using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using DatabaseAccess.InternalModel;

namespace DatabaseAccess.Repositories
{
    public class ClubRepository
    {
        public ReadOnlyCollection<ExternalModel.AllClubsResult> GetAllClubs()
        {
            List<ExternalModel.AllClubsResult> clubs = new List<ExternalModel.AllClubsResult>();

            using (var context = new DatabaseContext())
            {
                var databaseClubs = context.Database.SqlQuery<InternalModel.GetClubsResult>("dbo.api_GetAllClubs");

                List<InternalModel.Club> clubsList = new List<InternalModel.Club>();

                foreach (InternalModel.GetClubsResult databaseClub in databaseClubs)
                {
                    ExternalModel.AllClubsResult newClub = new ExternalModel.AllClubsResult(databaseClub.ClubId.ToString(), databaseClub.ShortName, databaseClub.LongName);
                    clubs.Add(newClub);
                }

            }

            return new ReadOnlyCollection<ExternalModel.AllClubsResult>(clubs);
        }

        public ExternalModel.Club GetClub(string clubReference)
        {
            ExternalModel.Club newClub = null;

            bool converts = int.TryParse(clubReference, out int clubId);

            if (converts == false)
                return null;

            using (var context = new DatabaseContext())
            {
                InternalModel.Club club = context.Clubs.SingleOrDefault(cl => cl.ClubId == clubId);

                if (club != null)
                {
                    newClub = new ExternalModel.Club(
                        club.ClubId.ToString(),
                        club.ShortName,
                        club.LongName,
                        club.Description,
                        club.VenueId.ToString(),
                        club.Url,
                        club.ImageFile,
                        club.ContactName,
                        club.AddressLine1,
                        club.AddressLine2,
                        club.AddressLine3,
                        club.Postcode,
                        club.Telephone,
                        club.Fax,
                        club.CustomerId.ToString(),
                        club.AssociationId.ToString());
                }
            }

            return newClub;
        }
    }
}