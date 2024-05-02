using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace Store_IBoard.Utlities.Attributes
{
    public class AuthorizationCustom : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext _context)
        {
            try
            {
                var auth = _context.HttpContext.Request.Headers.Where(e => e.Key == "Authorization")?.FirstOrDefault();
                if (auth is not null)
                {
                    var token = auth.Value.Value.ToString();
                    var jwtTokenString = Encoding.UTF8.GetString(Convert.FromBase64String(token.Replace("Bearer ", "").ToString()));
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
