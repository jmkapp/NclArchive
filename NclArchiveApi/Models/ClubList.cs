using Newtonsoft.Json;
using System.Collections.Generic;

namespace NclArchiveApi.Models
{
    public class ClubList
    {
        [JsonProperty(PropertyName = "clubs")]
        public IEnumerable<Club> Clubs { get; set; }
    }
}