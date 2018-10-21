using System.Data.Entity;
using System.Threading.Tasks;
using DatabaseAccess.Repositories.Interfaces;

namespace DatabaseAccess.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        public async Task<ExternalModel.Season> GetSeasonAsync(int seasonId)
        {
            ExternalModel.Season newSeason = null;

            using (var context = new DatabaseContext())
            {
                InternalModel.Season season = await context.Seasons.FirstOrDefaultAsync(s => s.SeasonId == seasonId);

                if (season != null)
                {
                    newSeason = ExternalModel.Season.Convert(season);
                }
            }

            return newSeason;
        }
    }
}
