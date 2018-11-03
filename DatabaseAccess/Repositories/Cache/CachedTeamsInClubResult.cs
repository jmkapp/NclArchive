using System;
using System.Collections.ObjectModel;
using DatabaseAccess.ExternalModel.QueryResults;

namespace DatabaseAccess.Repositories.Cache
{
    internal class CachedTeamsInClubResult
    {
        private readonly int _clubId;
        private readonly DateTime _date;
        private readonly ReadOnlyCollection<TeamsInClubResult> _teamsInClubResults;

        public int ClubId => _clubId;

        public DateTime Date => _date;

        public ReadOnlyCollection<TeamsInClubResult> TeamsInClubResults => _teamsInClubResults;

        internal CachedTeamsInClubResult(int clubId, DateTime date, ReadOnlyCollection<TeamsInClubResult> teamsInClubResult)
        {
            _clubId = clubId;
            _date = date;
            _teamsInClubResults = teamsInClubResult;
        }
    }
}
