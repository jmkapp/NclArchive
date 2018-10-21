using System.Collections.Generic;
using Newtonsoft.Json;

namespace NclArchiveApi.Models.Lists
{
    public class ResourceList
    {
        [JsonProperty(PropertyName = "resources")]
        public IEnumerable<Resource> Resources { get; set; }
    }
}