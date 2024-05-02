using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store_IBoard.BL.DTO.INPUT.SignUp;
using Store_IBoard.BL.Services.BackUpDatabase;
using Store_IBoard.BL.Services.Session;
using Store_IBoard.BL.Services.SMS;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.ToolsBLU;
using Store_IBoard.DL.UnitOfWork;
using Store_IBoard.Utlities.Attributes;
using ZstdSharp.Unsafe;

namespace Store_IBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private IBackUpDatabase _backUpDatabase;
        private ISMS _sms;
        private RepositoryGeneric<Users> _userRepo;
        public TestController(IBackUpDatabase backdatabase, ISMS sms
            , RepositoryGeneric<Users> userRepo)
        {
            _backUpDatabase = backdatabase;
            _sms = sms;
            _userRepo = userRepo;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> GetGenericRepo(long Id)
        {
            var tt = await _userRepo.GetQuery().Select(e => e.AccessLevel).ToListAsync();
            return Ok(tt);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetTestQuery()
        {
            var Parameters = new DynamicParameters();
            Parameters.Add("@NationalCode", 5990104758, System.Data.DbType.Int64);

            //var rr = await SqlHelper.ExecuteStoreProcedure<LoginDTO>("exec dbo.USP_InfoUsers");
            var TT = await SqlHelper.ExecuteQuery<object>(@$"SELECT  * FROM USERS (NOLOCK)");
            return Ok(TT);
        }
    }

}
