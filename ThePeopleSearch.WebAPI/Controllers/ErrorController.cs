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
    [RoutePrefix("api/errors")]
    public class ErrorController : ApiController
    {
        private string connectionString = ConfigurationManager.AppSettings["DBconnection"];

        [HttpPost]
        [Route("logNewError")]
        public IHttpActionResult logNewError(Error error)
        {
            var repo = new DapperHelper<Error>(connectionString);

            var results = repo.LogNewError(error);

            return Ok(results);
        }
    }
}