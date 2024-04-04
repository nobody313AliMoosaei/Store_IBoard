using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Store_IBoard.BL.Services.Public;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.ToolsBLU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Store_IBoard.BL.Services.SMS
{
    public class SMS : ISMS
    {
        private IHttpContextAccessor _httpContext;
        private DL.ApplicationDbContext.ApplicationDBContext _context;
        public SMS(IHttpContextAccessor HttpContext, DL.ApplicationDbContext.ApplicationDBContext context)
        {
            _httpContext = HttpContext;
            _context = context;

        }


        public async Task<ErrorsVM> SendSMS(string Mobile, string Message,long? UserId = null)
        {
            var res = new ErrorsVM();
            try
            {
                RestClient client = new RestClient("https://api.sms.ir/v1/send");
                RestRequest request = new RestRequest();
                request.AddParameter("Username", "9373844180");
                request.AddParameter("Password", "85hnS5LPrlZKzWwelYhqCBbFFx7posL87BPocGY4G5agSOk1RA9VY9hmf2pBkusO");
                request.AddParameter("Line", "30007732908297");
                request.AddParameter("Mobile", $"{Mobile}");
                request.AddParameter("Text", $"{Message}");
                var Response = await client.ExecuteAsync(request);
                if(Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _context.HistorySMS.Add(new DL.Entities.HistorySendSMS
                    {
                        UserRef = UserId,
                        Mobile = Mobile,
                        Message = Message,
                        Ip = _httpContext.HttpContext.Connection.RemoteIpAddress.ToString(),
                        Client = _httpContext.HttpContext.Request.Headers["User-Agent"]
                    });
                    await _context.SaveChangesAsync();
                    res.Message = "پیامک ارسال شد";
                    res.IsValid = true;
                }
                else
                    res.Message = "پیامک ارسال نشد";
            }catch (Exception ex)
            {
                res.Message = "خطا در اجرای برنامه";
                res.AddError(ex.Message);
                if (ex.InnerException is not null)
                    res.AddError(ex.InnerException.Message);
            }
            return res;
        }

        public Task<ErrorsVM> SendVerify(string Mobile, string Message)
        {
            throw new NotImplementedException();
        }
    }
}
