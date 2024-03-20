using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.Session
{
    public class SessionService : ISessionService
    {
        private IHttpContextAccessor _httpContext;

        public SessionService(IHttpContextAccessor httpcontext)
        {
            _httpContext = httpcontext;
        }
        public Task<string> GetString(string Key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetString(string Key, string Value)
        {
            throw new NotImplementedException();
        }
    }
}
