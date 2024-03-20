using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Memory;
using Store_IBoard.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.Session
{
    public class SessionService : ISessionService
    {
        private IHttpContextAccessor _contextAccessor;
        public SessionService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;

        }
        public Task<string> Get(string Key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Set(string Key, string Value)
        {
            throw new NotImplementedException();
        }
    }
}
