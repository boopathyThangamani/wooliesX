using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WooliesxAssignment.Models;
using WooliesxAssignment.Services;

namespace WooliesxAssignment.Controllers
{
    [RoutePrefix("api/answers")]
    public class UserController : BaseController
    {
        private readonly IUserDetails _userDetails;

        public UserController(IUserDetails userDetails)
        {
            _userDetails = userDetails;
        }
        [HttpGet]
        [Route("user")]
        public User GetUserDetails()
        {
           return  _userDetails.GetUserDetails();
        }
    }
}
