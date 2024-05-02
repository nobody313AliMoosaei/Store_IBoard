using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{

    public class City
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public long Key { get; set; }
        public string? Title { get; set; }
        public bool IsDomestic { get; set; }
        public bool IsForeign { get; set; }
        public string? Terminals { get; set; }
        public string? PersianTitle { get; set; }
        public string? EnglishTitle { get; set; }
        public string? Code { get; set; }
        public long ProvinceRef { get; set; }

        public Province? ProvinceRefNavigation { get; set; }
        public ICollection<Address>? Addresses { get; set; } = new HashSet<Address>();
    }

    public class Province
    {
        public long Id { get; set; }
        public string? ProvinceName { get; set; }
        public int ProvinceID { get; set; }

        public ICollection<City>? Cities { get; set; } = new HashSet<City>();
    }

}
