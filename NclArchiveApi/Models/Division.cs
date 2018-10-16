using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Division
    {
        [JsonProperty(PropertyName = "divisionId")]
        public string DivisionId { get; set; }
        [JsonProperty(PropertyName = "miniName")]
        public string MiniName { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "longName")]
        public string LongName { get; set; }
        [JsonProperty(PropertyName = "compId")]
        public int? CompId { get; set; }
        [JsonProperty(PropertyName = "seqNo")]
        public int? SeqNo { get; set; }
        [JsonProperty(PropertyName = "promotions")]
        public short? Promotions { get; set; }
        [JsonProperty(PropertyName = "demotions")]
        public short? Demotions { get; set; }
        [JsonProperty(PropertyName = "playOffs")]
        public short? PlayOffs { get; set; }
        [JsonProperty(PropertyName = "playOffTypeId")]
        public int? PlayOffTypeId { get; set; }
        [JsonProperty(PropertyName = "pointsWin")]
        public int? PointsWin { get; set; }
        [JsonProperty(PropertyName = "pointsDraw")]
        public int? PointsDraw { get; set; }
        [JsonProperty(PropertyName = "customerId")]
        public int? CustomerId { get; set; }
        [JsonProperty(PropertyName = "isGroup")]
        public bool IsGroup { get; set; }
        [JsonProperty(PropertyName = "divisionMemo")]
        public string DivisionMemo { get; set; }
        [JsonProperty(PropertyName = "useBonusPoints")]
        public bool? UseBonusPoints { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        internal static Division Convert(DatabaseAccess.ExternalModel.Division division)
        {
            Division newDivision = new Division();
            newDivision.DivisionId = division.DivisionId;
            newDivision.MiniName = division.MiniName;
            newDivision.ShortName = division.ShortName;
            newDivision.LongName = division.LongName;
            newDivision.CompId = division.CompId;
            newDivision.SeqNo = division.SeqNo;
            newDivision.Promotions = division.Promotions;
            newDivision.Demotions = division.Demotions;
            newDivision.PlayOffs = division.PlayOffs;
            newDivision.PlayOffTypeId = division.PlayOffTypeId;
            newDivision.PointsWin = division.PointsWin;
            newDivision.PointsDraw = division.PointsDraw;
            newDivision.CustomerId = division.CustomerId;
            newDivision.IsGroup = division.IsGroup;
            newDivision.DivisionMemo = division.DivisionMemo;
            newDivision.UseBonusPoints = division.UseBonusPoints;

            return newDivision;
        }
    }
}