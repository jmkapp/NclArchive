﻿namespace DatabaseAccess.ExternalModel
{
    public class AllClubsResult
    {
        private readonly string _clubId;
        private readonly string _shortName;
        private readonly string _longName;
        public AllClubsResult(string clubId, string shortName, string longName)
        {
            _clubId = clubId;
            _shortName = shortName;
            _longName = longName;
        }
        public string ClubId
        {
            get { return _clubId; }
        }
        public string LongName
        {
            get
            {
                return _longName;
            }
        }
        public string ShortName
        {
            get
            {
                return _shortName;
            }
        }
    }
}