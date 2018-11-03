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
    public class CachedTeamRepository : ITeamRepository
    {
        private readonly TeamRepository _teamRepository;
        private readonly List<CachedTeamsInClubResult> _teamsInClubResults;
        private readonly List<CachedSeasonsForTeamResult> _seasonsForTeamResults;
        private readonly Dictionary<DateTime, Team> _teams;

        public CachedTeamRepository()
        {
            _teamRepository = new TeamRepository();
            _teamsInClubResults = new List<CachedTeamsInClubResult>();
            _seasonsForTeamResults = new List<CachedSeasonsForTeamResult>();
            _teams = new Dictionary<DateTime, Team>();
        }

        public async Task<Team> GetTeamAsync(int teamId)
        {
            Team team = _teams.Values.FirstOrDefault(t => t.TeamId == teamId);

            if (team == null)
            {
                team = await _teamRepository.GetTeamAsync(teamId);

                if (team != null)
                    _teams.Add(DateTime.Now, team);
            }

            return team;
        }

        public async Task<ReadOnlyCollection<TeamsInClubResult>> GetTeamsInClubAsync(int clubId)
        {
            CachedTeamsInClubResult cachedTeamsInClubResult =
                _teamsInClubResults.FirstOrDefault(tic => tic.ClubId == clubId);

            if (cachedTeamsInClubResult == null)
            {
               ReadOnlyCollection<TeamsInClubResult> teamsInClubResult = await _teamRepository.GetTeamsInClubAsync(clubId);

                if (teamsInClubResult != null)
                {
                    cachedTeamsInClubResult = new CachedTeamsInClubResult(clubId, DateTime.Now, teamsInClubResult);
                    _teamsInClubResults.Add(cachedTeamsInClubResult);
                }
            }

            return cachedTeamsInClubResult?.TeamsInClubResults;
        }

        public async Task<ReadOnlyCollection<SeasonsForTeamResult>> GetSeasonsForTeamsAsync(int teamId)
        {
            CachedSeasonsForTeamResult cachedSeasonsForTeamResult =
                _seasonsForTeamResults.FirstOrDefault(s => s.TeamId == teamId);

            if (cachedSeasonsForTeamResult == null)
            {
                ReadOnlyCollection<SeasonsForTeamResult> seasonsForTeamResults =
                    await _teamRepository.GetSeasonsForTeamsAsync(teamId);

                if (seasonsForTeamResults != null)
                {
                    cachedSeasonsForTeamResult = new CachedSeasonsForTeamResult(teamId, DateTime.Now, seasonsForTeamResults);
                    _seasonsForTeamResults.Add(cachedSeasonsForTeamResult);
                }
            }

            return cachedSeasonsForTeamResult?.SeasonsForTeamResults;
        }
    }
}
