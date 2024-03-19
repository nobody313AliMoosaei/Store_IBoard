using Store_IBoard.BL.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.Eamil
{
    public interface IEmailService
    {
        Task<ErrorsVM> SendYahooMailAsync(string To, string body, string Title = "I Board");
        Task<ErrorsVM> SendG_EmailAsync(string To, string Body, string Title = "I Board");
    }
}
