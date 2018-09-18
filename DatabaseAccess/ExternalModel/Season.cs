using System;

namespace DatabaseAccess.ExternalModel
{
    public class Season
    {
        private readonly string _seasonId;
        private readonly string _shortName;
        private readonly string _longName;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly bool _winterSeason;

        public Season(
            string seasonId,
            string shortName,
            string longName,
            DateTime startDate,
            DateTime endDate,
            bool winterSeason)
        {
            _seasonId = seasonId;
            _shortName = shortName;
            _longName = longName;
            _startDate = startDate;
            _endDate = endDate;
            _winterSeason = winterSeason;
        }

        public string SeasonId
        {
            get { return _seasonId; }
        }

        public string ShortName
        {
            get { return _shortName; }
        }

        public string LongName
        {
            get { return _longName; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
        }

        public bool WinterSeason
        {
            get { return _winterSeason; }
        }
    }
}
