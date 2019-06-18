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
            List<Users> results;

            if (String.IsNullOrWhiteSpace(query))
            {
                results = new List<Users>();
            } else
            {
                var repo = new DapperHelper<Users>(connectionString);

                results = repo.GetAllUsersByTerm(query);
            }

            return Ok(results);
        }

        [HttpGet]
        [Route("getAllByTermVw")]
        public IHttpActionResult getAllByTermVw([FromUri] string query)
        {
            List<UsersVw> results;

            if (String.IsNullOrWhiteSpace(query))
            {
                results = new List<UsersVw>();
            } else
            {
                var repo = new DapperHelper<UsersVw>(connectionString);

                results = repo.GetAllUsersByTerm(query);
            }

            return Ok(results);
        }

        [HttpPost]
        [Route("addNewUser")]
        public IHttpActionResult addNewUser(Users user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            } else
            {
                var repo = new DapperHelper<UsersVw>(connectionString);

                var results = repo.InsertNewUser(user);

                return Ok(results);
            }
        }
    }
}