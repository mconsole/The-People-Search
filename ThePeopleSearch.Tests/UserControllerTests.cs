using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePeopleSearch.WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using ThePeopleSearch.Data.Models;

namespace ThePeopleSearch.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void testgetAllByTermVwWithEmptyQuery()
        {
            //arrange
            var uc = new UserController();

            //act
            var results = uc.getAllByTermVw(String.Empty);
            var data = results as OkNegotiatedContentResult<List<UsersVw>>;
            var count = data.Content.Count;

            //assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void testgetAllByTermWithEmptyQuery()
        {
            //arrange
            var uc = new UserController();

            //act
            var results = uc.getAllByTerm(String.Empty);
            var data = results as OkNegotiatedContentResult<List<Users>>;
            var count = data.Content.Count;

            //assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void testAddNewUserWithNullUser()
        {
            try
            {
                //arrange
                var uc = new UserController();

                //act
                uc.addNewUser(null);

                //assert
                Assert.Fail();
            }
            catch
            {

            }
        }
    }
}
