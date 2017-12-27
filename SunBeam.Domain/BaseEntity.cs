using SunBeam.Common.Utility;
using System;

namespace SunBeam.Domain
{
    public class BaseEntity
    {
       static string date = DateTime.Now.ToString();
        static string ip = "11.11.11";
       static string user = "Admin";

        public string Remarks { get; set; }
        public Nullable<bool> IsActive { get; set; } = true;
        public Nullable<bool> IsArchive { get; set; } = false;
        public string CreatedBy { get; set; } = ip;
        public string CreatedAt { get; set; } = date;
        public string CreatedFrom { get; set; } = user;
        public string LastUpdateBy { get; set; } = ip;
        public string LastUpdateAt { get; set; } = date;
        public string LastUpdateFrom { get; set; } = user;
    }
}
