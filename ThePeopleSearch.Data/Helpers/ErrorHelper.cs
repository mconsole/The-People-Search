﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThePeopleSearch.Data.Models;

namespace ThePeopleSearch.Data.Helpers
{
    public class ErrorHelper
    {
        public void Log(string message, string stackTrace, DateTime datetime)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Error er = new Error();
                    er.message = message;
                    er.stackTrace = stackTrace;
                    er.createdDtTime = datetime;

                    string postURL = ConfigurationManager.AppSettings["WebAPIUrl"] + "/api/errors/lognewerror";

                    var postJson = JsonConvert.SerializeObject(er);

                    var locationString = new StringContent(postJson, UnicodeEncoding.UTF8, "application/json");

                    var locationResult = client.PostAsync(postURL, locationString).Result;
                }
            } catch (Exception ex)
            {
                //log to file system
            }
        }
    }
}
