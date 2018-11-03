using System;
using System.Collections.ObjectModel;
using DatabaseAccess.ExternalModel.QueryResults;

namespace DatabaseAccess.Repositories.Cache
{
    internal class CachedSeasonsForTeamResult
    {
        private readonly int _teamId;
        private readonly DateTime _date;
        private readonly ReadOnlyCollection<SeasonsForTeamResult> _seasonsForTeamResults;

        internal CachedSeasonsForTeamResult(int teamId, DateTime date,
            ReadOnlyCollection<SeasonsForTeamResult> seasonsForTeamResults)
        {
            _teamId = teamId;
            _date = date;
            _seasonsForTeamResults = seasonsForTeamResults;
        }

        public int TeamId => _teamId;

        public DateTime Date => _date;

        public ReadOnlyCollection<SeasonsForTeamResult> SeasonsForTeamResults => _seasonsForTeamResults;
    }
}
