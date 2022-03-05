using System;

using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Models
{
    public class UserDevices
    {
        public int Id { get; set; }
        public int? UserId {get; set;}
        
        public Users User { get; set; }
        //[ForeignKey("Users")]
        //public int UserId { get; set; }

        public string MacAddress { get; set; }
        public int? DeviceTypeId { get; set; }
        //public DeviceType DeviceType { get; set; }
        #nullable enable
        public string?  Status { get; set; }
       #nullable enable
        public string? Temparature { get; set; }
        #nullable enable
        public Boolean? Deleted { get; set; }
        #nullable enable
        public DateTime? DeletedAt { get; set; }
        #nullable enable
        public string? DeletedBy { get; set; }


    }
    public class DeviceType
    {}
}