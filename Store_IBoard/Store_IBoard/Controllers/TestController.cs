using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_IBoard.BL.Services.BackUpDatabase;
using Store_IBoard.BL.Services.Session;
using Store_IBoard.BL.Services.SMS;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.ToolsBLU;
using ZstdSharp.Unsafe;

namespace Store_IBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private IBackUpDatabase _backUpDatabase;
        private ISMS _sms;
        public TestController(IBackUpDatabase backdatabase, ISMS sms)
        {
            _backUpDatabase = backdatabase;
            _sms = sms;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetBackUpDatabase()
        {
            await _backUpDatabase.BackUpDatabase();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendSMS(string mobile, string message)
        {
            return Ok(await _sms.SendSMS(mobile, message));
        }
        //    [HttpPost("[action]")]
        //    public async Task<IActionResult> ConvertJsonToTable(IFormFile _file)
        //    {
        //        var SR = new StreamReader(_file.OpenReadStream());
        //        var Text = await SR.ReadToEndAsync();
        //        if (!Text.IsNullOrEmpty())
        //        {
        //            var Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(Text);
        //            try
        //            {
        //                _context.Roots.AddRange(Data);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (Exception ex) { }
        //            return Ok(Data);
        //        }
        //        return BadRequest();
        //    }
    }

}
