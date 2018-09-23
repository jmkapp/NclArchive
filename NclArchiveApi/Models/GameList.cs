using System.Collections.Generic;
using Newtonsoft.Json;

namespace NclArchiveApi.Models
{
    public class GameList
    {
        [JsonProperty(PropertyName = "games")]
        public IEnumerable<Game> Games { get; set; }
    }
}