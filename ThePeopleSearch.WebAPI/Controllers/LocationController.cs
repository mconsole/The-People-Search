using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using ThePeopleSearch.Data.Helpers;
using ThePeopleSearch.Data.Models;

namespace ThePeopleSearch.WebAPI.Controllers
{
    [RoutePrefix("api/locations")]
    public class LocationController : ApiController
    {
        private string connectionString = ConfigurationManager.AppSettings["DBconnection"];

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult getAll()
        {
            var repo = new DapperHelper<Locations>(connectionString);

            var results = repo.GetAll();

            return Ok(results);
        }

        [HttpPost]
        [Route("addNewLocation")]
        public IHttpActionResult addNewLocation(Locations location)
        {
            var repo = new DapperHelper<UsersVw>(connectionString);

            var results = repo.InsertNewLocation(location);

            return Ok(results);
        }
    }
}