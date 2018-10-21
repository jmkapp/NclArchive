namespace DatabaseAccess.ExternalModel
{
    public class Division
    {
        private readonly int _divisionId;
        private readonly string _miniName;
        private readonly string _shortName;
        private readonly string _longName;
        private readonly int? _compId;
        private readonly int? _seqNo;
        private readonly short? _promotions;
        private readonly short? _demotions;
        private readonly short? _playOffs;
        private readonly int? _playOffTypeId;
        private readonly int? _pointsWin;
        private readonly int? _pointsDraw;
        private readonly int? _customerId;
        private readonly bool _isGroup;
        private readonly string _divisionMemo;
        private readonly bool? _useBonusPoints;

        public Division(
            int divisionId,
            string miniName,
            string shortName,
            string longName,
            int? compId,
            int? seqNo,
            short? promotions,
            short? demotions,
            short? playoffs,
            int? playOffTypeId,
            int? pointsWin,
            int? pointsDraw,
            int? customerId,
            bool isGroup,
            string divisionMemo,
            bool? useBonusPoints)
        {
            _divisionId = divisionId;
            _miniName = miniName;
            _shortName = shortName;
            _longName = longName;
            _compId = compId;
            _seqNo = seqNo;
            _promotions = promotions;
            _demotions = demotions;
            _playOffs = playoffs;
            _playOffTypeId = playOffTypeId;
            _pointsWin = pointsWin;
            _pointsDraw = pointsDraw;
            _customerId = customerId;
            _isGroup = isGroup;
            _divisionMemo = divisionMemo;
            _useBonusPoints = useBonusPoints;
        }

        public int DivisionId => _divisionId;

        public string MiniName => _miniName;

        public string ShortName => _shortName;

        public string LongName => _longName;

        public int? CompId => _compId;

        public int? SeqNo => _seqNo;

        public short? Promotions => _promotions;

        public short? Demotions => _demotions;

        public short? PlayOffs => _playOffs;

        public int? PlayOffTypeId => _playOffTypeId;

        public int? PointsWin => _pointsWin;

        public int? PointsDraw => _pointsDraw;

        public int? CustomerId => _customerId;

        public bool IsGroup => _isGroup;

        public string DivisionMemo => _divisionMemo;

        public bool? UseBonusPoints => _useBonusPoints;

        internal static Division Convert(InternalModel.Division division)
        {
            return new Division(
                division.DivisionId,
                division.MiniName,
                division.ShortName,
                division.LongName,
                division.CompId,
                division.SeqNo,
                division.Promotions,
                division.Demotions,
                division.PlayOffs,
                division.PlayOffTypeId,
                division.PointsWin,
                division.PointsDraw,
                division.CustomerId,
                division.IsGroup,
                division.DivisionMemo,
                division.UseBonusPoints);
        }
    }
}
