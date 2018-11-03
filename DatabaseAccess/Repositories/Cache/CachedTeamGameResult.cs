using System;
using System.Collections.ObjectModel;
using DatabaseAccess.ExternalModel.QueryResults;

namespace DatabaseAccess.Repositories.Cache
{
    internal class CachedTeamGameResult
    {
        private readonly int _teamId;
        private readonly int _seasonId;
        private readonly DateTime _date;
        private readonly ReadOnlyCollection<TeamGameResult> _teamGameResults;

        internal CachedTeamGameResult(int teamId, int seasonId, DateTime date, ReadOnlyCollection<TeamGameResult> teamsGameResults)
        {
            _teamId = teamId;
            _seasonId = seasonId;
            _date = date;
            _teamGameResults = teamsGameResults;
        }

        public int TeamId => _teamId;

        public int SeasonId => _seasonId;

        public DateTime Date => _date;

        public ReadOnlyCollection<TeamGameResult> TeamGameResults => _teamGameResults;
    }
}
