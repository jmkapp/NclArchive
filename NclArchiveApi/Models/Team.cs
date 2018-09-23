using System.Collections.Generic;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class Team
    {
        [JsonProperty(PropertyName = "teamId")]
        public string TeamId { get; set; }
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "longName")]
        public string LongName { get; set; }
        [JsonProperty(PropertyName = "nclTeam")]
        public bool? NclTeam { get; set; }
        [JsonProperty(PropertyName = "teamRef")]
        public string TeamRef { get; set; }
        [JsonProperty(PropertyName = "isDirty")]
        public string IsDirty { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "sponsorName")]
        public string SponsorName { get; set; }
        [JsonProperty(PropertyName = "sponsorUrl")]
        public string SponsorUrl { get; set; }
        [JsonProperty(PropertyName = "miniName")]
        public string MiniName { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        [JsonProperty(PropertyName = "seasonsLink")]
        public string SeasonsLink { get; set; }
        [JsonProperty(PropertyName = "club")]
        public Club Club { get; set; }
        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<Season> Seasons { get; set; }

        internal static Team Convert(DatabaseAccess.ExternalModel.Team team)
        {
            Team newTeam = new Team();
            newTeam.TeamId = team.TeamId;
            newTeam.ShortName = team.ShortName;
            newTeam.LongName = team.LongName;
            newTeam.TeamRef = team.TeamRef;
            newTeam.IsDirty = team.IsDirty;
            newTeam.Url = team.Url;
            newTeam.SponsorName = team.SponsorsName;
            newTeam.SponsorUrl = team.SponsorsUrl;
            newTeam.MiniName = team.MiniName;
            newTeam.Club = team.Club == null ? null : Club.Convert(team.Club);

            return newTeam;
        }
    }
}