using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.Session
{
    public interface ISessionService
    {
        Task<bool> Set(string Key, string Value);
        Task<string> Get(string Key);
    }
}
