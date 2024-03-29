using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Store_IBoard.DL.ToolsBLU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.Session
{
    public class SessionManager : ISessionService
    {
        private IDistributedCache _cacheManager;
        public SessionManager(IDistributedCache cache)
        {
            _cacheManager = cache;
        }

        public bool SetValue(string Key, string Value)
        {
            try
            {
                _cacheManager.SetString(Key, Value);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> GetValue(string Key)
        {
            try
            {
                var Value = await _cacheManager.GetStringAsync(Key);
                return Value ?? string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


    }
}
