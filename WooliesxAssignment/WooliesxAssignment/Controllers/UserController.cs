using System.Web;
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
        public IHttpActionResult GetUserDetails()
        {
            return Ok(_userDetails.GetUserDetails());
        }
    }
}