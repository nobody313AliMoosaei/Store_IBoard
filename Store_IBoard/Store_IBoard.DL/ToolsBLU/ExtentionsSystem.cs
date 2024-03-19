using Store_IBoard.BL.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.ToolsBLU
{
    public static class ExtentionsSystem
    {
        public static bool IsNullOrEmpty(this string? Value)
        {
            try
            {
                if (Value is null || string.IsNullOrEmpty(Value) || string.IsNullOrWhiteSpace(Value)
                    || string.IsNullOrWhiteSpace(Value.Trim()))
                    return true;
                return false;
            }
            catch
            {
                return true;
            }
        }

        public static void AddError(this ErrorsVM res, string message)
        {
            if (res.LstErrors is null)
                res.LstErrors = new List<string>();
            res.LstErrors.Add(message);
        }
    }
}
