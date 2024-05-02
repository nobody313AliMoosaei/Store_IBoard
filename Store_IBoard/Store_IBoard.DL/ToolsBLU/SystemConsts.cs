using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.ToolsBLU
{
    public static class SystemConsts
    {
        public static string? ConnectionString { get; set; }
        public static string? PrivateKey { get; set; }
        public static IConfiguration? SettingConfiguration { get; set; }
    }
}
