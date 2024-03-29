using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.Session
{
    public interface ISessionService
    {
        bool SetValue(string Key, string Value);
        Task<string> GetValue(string Key);
    }
}
