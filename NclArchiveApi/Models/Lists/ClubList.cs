using System.Collections.Generic;
using Newtonsoft.Json;

namespace NclArchiveApi.Models.Lists
{
    public class ClubList
    {
        [JsonProperty(PropertyName = "clubs")]
        public IEnumerable<Club> Clubs { get; set; }
    }
}