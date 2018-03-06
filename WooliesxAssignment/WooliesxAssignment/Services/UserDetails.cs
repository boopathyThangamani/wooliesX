using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooliesxAssignment.Models;
using WooliesxAssignment.Services;

namespace WooliesxAssignment.Services
{
    public class UserDetails : IUserDetails
    {
        private readonly ILogger _logger;
        public UserDetails(ILogger logger)
        {
            _logger = logger;
        }
        public User GetUserDetails()
        {
            _logger.Information("User details requested");
            return new Models.User()
            {
                Token = "7bb17606-bd7e-4c30-b8bd-08255140a1e1",
                Name = "Boopathy Thangamani"
            };
        }
    }
}