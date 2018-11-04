using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;
using DatabaseAccess.Repositories.Interfaces;

namespace DatabaseAccess.Repositories.Cache
{
    public class CachedSeasonRepository : ISeasonRepository
    {
        private readonly SeasonRepository _seasonRepository;
        private readonly Dictionary<DateTime, Season> _seasons;

        public CachedSeasonRepository()
        {
            _seasonRepository = new SeasonRepository();
            _seasons = new Dictionary<DateTime, Season>();
        }

        public async Task<Season> GetSeasonAsync(int seasonId)
        {
            Season season = _seasons.Values.FirstOrDefault(s => s.SeasonId == seasonId);

            if (season == null)
            {
                season = await _seasonRepository.GetSeasonAsync(seasonId);

                if(season != null)
                    _seasons.Add(DateTime.Now, season);
            }

            return season;
        }
    }
}
