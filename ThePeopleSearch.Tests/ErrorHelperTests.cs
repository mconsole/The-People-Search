﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThePeopleSearch.Data.Helpers;
using ThePeopleSearch.ErrorLogging;

namespace ThePeopleSearch.Tests
{
    [TestClass]
    public class ErrorHelperTests

    {
        [TestMethod]
        public void testLogWithFutureDateTime()
        {

            try
            {
                //arrange
                var futureDate = DateTime.Now.AddDays(7);
                var eh = new ErrorHelper();

                string application = "Unit Tests";
                string message = "Unit Test Error";
                string stackTrace = "Test stack trace";

                //act
                eh.Log(application, message, stackTrace, futureDate);

                //assert
                Assert.Fail();
            } catch
            {

            }
        }
    }
}
