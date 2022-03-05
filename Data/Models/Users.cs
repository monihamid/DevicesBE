using System;

namespace Data.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public String Role { get; set; }
        #nullable enable
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
         #nullable enable
        public DateTime? ModifiedAt { get; set; }
         #nullable enable
        public Boolean? Deleted { get; set; }
         #nullable enable
        public DateTime? DeletedAt { get; set; }
         #nullable enable
        public string? DeletedBy { get; set; }
        //public UserDevices? UserDevices {get; set;}
    }
}