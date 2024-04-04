using Store_IBoard.BL.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.SMS
{
    public interface ISMS
    {
        Task<ErrorsVM> SendVerify(string Mobile, string Message);
        Task<ErrorsVM> SendSMS(string Mobile, string Message, long? UserId = null);
    }
}
