using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Store_IBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost("[action]")]
        public async Task<IActionResult> Get()
        {
            var re = typeof(PersianCalendar);
            return Ok(re);
        }
    }
}
