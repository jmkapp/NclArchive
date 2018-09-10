using Newtonsoft.Json;
using System.Collections.Generic;

namespace NclArchiveApi.Models
{
    public class ResourceList
    {
        [JsonProperty(PropertyName = "resources")]
        public IEnumerable<Resource> Resources { get; set; }
    }
}