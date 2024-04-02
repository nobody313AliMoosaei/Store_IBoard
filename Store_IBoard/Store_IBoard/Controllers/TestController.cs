using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_IBoard.BL.Services.Session;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.ToolsBLU;
using ZstdSharp.Unsafe;

namespace Store_IBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private DL.ApplicationDbContext.ApplicationDBContext _context;
        public TestController(DL.ApplicationDbContext.ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> ConvertJsonToTable(IFormFile _file)
        {
            var SR = new StreamReader(_file.OpenReadStream());
            var Text = await SR.ReadToEndAsync();
            if (!Text.IsNullOrEmpty())
            {
                var Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(Text);
                try
                {
                    _context.Roots.AddRange(Data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex) { }
                return Ok(Data);
            }
            return BadRequest();
        }
    }

}
