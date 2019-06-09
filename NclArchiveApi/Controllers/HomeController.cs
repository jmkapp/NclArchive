using NclArchiveApi.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using NclArchiveApi.Models.Lists;

// Test comments

namespace NclArchiveApi.Controllers
{
    [AllowAnonymous]
    public class HomeController : ApiController
    {
        [Route("")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            string baseUrl = Url.Content("~/");

            Resource club = new Resource();
            club.name = "clubs";
            club.Url = baseUrl + "clubs";

            ResourceList resourceList = new ResourceList();
            List<Resource> resources = new List<Resource>();

            resources.Add(club);

            resourceList.Resources = resources;

            return Ok(resourceList);
        }
    }
}
