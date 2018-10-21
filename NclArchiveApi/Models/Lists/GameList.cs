using System.Collections.Generic;
using Newtonsoft.Json;

namespace NclArchiveApi.Models.Lists
{
    public class GameList
    {
        [JsonProperty(PropertyName = "games")]
        public IEnumerable<Game> Games { get; set; }
    }
}