using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.Public
{
    public class ErrorsVM
    {
        public bool IsValid { get; set; } = false;
        public string? GUIDKey { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public List<string> LstErrors { get; set; } = new List<string>();
    }
}
