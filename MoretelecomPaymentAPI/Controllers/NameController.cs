
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoretelecomPaymentAPI.Main;

namespace MoretelecomPaymentAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private readonly ITokenRefresher tokenRefresher;

        public NameController(IJWTAuthenticationManager jWTAuthenticationManager, ITokenRefresher tokenRefresher)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            this.tokenRefresher = tokenRefresher;
        }



        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            


            var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);



            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] RefreshCred refreshCred)
        {
            var token = tokenRefresher.Refresh(refreshCred);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
