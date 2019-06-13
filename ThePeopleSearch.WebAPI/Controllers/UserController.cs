using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using Dapper;
using ThePeopleSearch.Data.Helpers;
using ThePeopleSearch.Data.Models;

namespace ThePeopleSearch.WebAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private string connectionString = ConfigurationManager.AppSettings["DBconnection"];

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult getAll()
        {
            var repo = new DapperHelper<Users>(connectionString);

            var results = repo.GetAll();

            return Ok(results);
        }

        [HttpGet]
        [Route("getAllByTerm")]
        public IHttpActionResult getAllByTerm([FromUri] string query)
        {
            var repo = new DapperHelper<Users>(connectionString);

            var results = repo.GetAllUsersByTerm(query);

            return Ok(results);
        }

        [HttpGet]
        [Route("getAllByTermVw")]
        public IHttpActionResult getAllByTermVw([FromUri] string query)
        {
            var repo = new DapperHelper<UsersVw>(connectionString);

            var results = repo.GetAllUsersByTerm(query);

            return Ok(results);
        }
    }
}