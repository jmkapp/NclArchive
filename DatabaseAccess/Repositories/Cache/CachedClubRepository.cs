using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;
using DatabaseAccess.ExternalModel.QueryResults;
using DatabaseAccess.Repositories.Interfaces;

namespace DatabaseAccess.Repositories.Cache
{
    public class CachedClubRepository : IClubRepository
    {
        private readonly ClubRepository _clubRepository;
        private ReadOnlyCollection<AllClubsResult> _allClubsResult;
        private DateTime _allClubsResultDate;
        private readonly Dictionary<DateTime, Club> _clubs;

        public CachedClubRepository()
        {
            _clubRepository = new ClubRepository();
            _clubs = new Dictionary<DateTime, Club>();
        }

        public async Task<ReadOnlyCollection<AllClubsResult>> GetAllClubsAsync()
        {
            if (_allClubsResult == null)
            {
                _allClubsResult = await _clubRepository.GetAllClubsAsync();

                if(_allClubsResult != null && _allClubsResult.Count > 0)
                    _allClubsResultDate = DateTime.Now;
            }

            return _allClubsResult;
        }

        public async Task<Club> GetClubAsync(int clubId)
        {
            Club club = _clubs.Values.FirstOrDefault(g => g.ClubId == clubId);

            if (club == null)
            {
                club = await _clubRepository.GetClubAsync(clubId);

                if (club != null)
                    _clubs.Add(DateTime.Now, club);
            }

            return club;
        }
    }
}
