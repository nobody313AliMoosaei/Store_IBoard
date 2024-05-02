using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class GoodImage
    {
        public long? Id { get; set; }
        public string? ImageAddress { get; set; }
        public string? ImageName { get; set; }
        public DateTime? CreateDateTime { get; set; } = DateTime.Now;
        public long? GoodRef { get; set; }
        public Good? GoodRefNavigation { get; set; }
    }
}
