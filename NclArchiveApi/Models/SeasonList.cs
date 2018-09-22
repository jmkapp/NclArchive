using System.Collections.Generic;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class SeasonList
    {
        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<Season> Seasons { get; set; }
    }
}