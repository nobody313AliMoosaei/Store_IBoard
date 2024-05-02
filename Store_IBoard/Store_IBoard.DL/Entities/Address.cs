using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class Address
    {
        public long Id { get; set; }

        /// <summary>
        /// آدرس پستی
        /// </summary>
        public string? PostalAddress { get; set; }
        /// <summary>
        /// محله
        /// </summary>
        public string? District { get; set; }
        /// <summary>
        /// پلاک
        /// </summary>
        public short? Plaque { get; set; }
        /// <summary>
        /// واحد
        /// </summary>
        public byte? Unit { get; set; }
        /// <summary>
        /// کد پستی
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// نام گیرنده
        /// </summary>
        public string? FirstName_Receiver { get; set; }
        /// <summary>
        /// نام خانوادگی گیرنده
        /// </summary>
        public string? LastName_Receiver { get; set; }
        /// <summary>
        /// شماره موبایل گیرنده
        /// </summary>
        public string? PhoneNumber_Receiver { get; set; }
        /// <summary>
        /// شهر
        /// </summary>
        public long? CityRef { get; set; }
        public City? CityRefNavigation { get; set; }

        /// <summary>
        /// کاربر
        /// </summary>
        public long? UserRef { get; set; }
        public Users? UserRefNavigation { get; set; }

    }
}
