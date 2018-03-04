using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Services
{
    public interface IUserDetails
    {
        User GetUserDetails();
    }
}