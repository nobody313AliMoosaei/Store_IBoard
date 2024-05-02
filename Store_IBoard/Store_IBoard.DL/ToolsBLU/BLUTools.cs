using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.ToolsBLU
{
    public enum UserStatus
    {
        Block = -1,
        Accept = 1,
        UnAccept,
        Reject
    }
    public enum UserRoles
    {
        Administrator = 1,
        DefulatUser = 2,
        MiddLevelUser = 3,
        TopLevelUser = 4
    }
    public enum AccessLevel
    {
        None = 0,
        Level1,
        Level2,
        Level3,
        Admin
    }

    public enum BasLookupTypes
    {
        OrderStatus =0,
    }
}
