using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIMvc.Controllers
{
    public class EmployeesDataController : ApiController
    {
        //array get
        public string[] myEmployees = { "Jibran ", "Ahmer", "Adeel" };
         //[HttpGet] if not so run not necessary because bydefault getRequest
         //[HttpGet] url in enter data larehai ho prefix Get convention any action method before convention Get
         [HttpGet]
        public string[] GetEmployees()
        {
            return myEmployees;
        }

        //string return
        //parameter pass parameter name must id  in url controller kai baad
        [HttpGet]
        public string GetEmployeeByIndex(int id)
        {
            return myEmployees[id];
        }
    }
}
