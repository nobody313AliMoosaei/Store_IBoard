using Store_IBoard.BL.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Store_IBoard.DL.ToolsBLU;

namespace Store_IBoard.BL.Services.Eamil
{
    public class EmailService : IEmailService
    {
        public Task<ErrorsVM> SendG_EmailAsync(string To, string Body, string Title = "I Board")
        {
            throw new NotImplementedException();
        }

        public async Task<ErrorsVM> SendYahooMailAsync(string To, string body, Stream? st = null, string Title = "I Board")
        {
            var res = new ErrorsVM();
            try
            {
                string From = "tickettinggroup@yahoo.com";
                SmtpClient client = new SmtpClient("smtp.mail.yahoo.com", 25);
                client.Port = 587;
                client.Host = "smtp.mail.yahoo.com";
                client.EnableSsl = true;
                client.Timeout = 1000000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                client.Credentials = new NetworkCredential(From, "bhedkhjtszmogxsp");
                var message = new MailMessage(From, To, Title, body);
                if (st is not null)
                    message.Attachments.Add(new Attachment(st, "BackUpDatabase"));

                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                await client.SendMailAsync(message);
                res.Message = "ایمیل با موفقیت ارسال شد";
                res.IsValid = true;
            }
            catch (Exception ex)
            {
                res.Message = "خطا در ارسال ایمیل";
                res.AddError(ex.Message);
                if (ex.InnerException is not null)
                    res.AddError(ex.InnerException.Message);
            }
            return res;
        }
    }
}
