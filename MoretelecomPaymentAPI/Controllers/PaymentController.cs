using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoretelecomPaymentAPI.Main;
using MoretelecomPaymentAPI.Model;



namespace MoretelecomPaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {

        //POLICY ROLE
        //If ADMIN payment list will display. 
        //If USER payment list will not display. 
        //Comment out Authorize Roles to display Payment list in browser.

      
        [Authorize(Policy = "ADMIN")]
        [HttpGet("list")]
        public IEnumerable<paymentResponse> Get()
        {

            return Enumerable.Range(0, 6).Select(index => new paymentResponse
            {

                Payments = PaymentTransactions[index]

            })
            .ToArray();
        }

        
      //[Authorize(Policy = "ADMIN")]
        [HttpPost("list")]
        public IEnumerable<paymentResponse> Post([FromBody] UserCred userCred)
        {

            return Enumerable.Range(0, 6).Select(index => new paymentResponse
            {

                Payments = PaymentTransactions[index]

            })
            .ToArray();
        }

        private static readonly string[] PaymentTransactions = new[]
    {
        "", "", "","","",""
    };




    }
}
