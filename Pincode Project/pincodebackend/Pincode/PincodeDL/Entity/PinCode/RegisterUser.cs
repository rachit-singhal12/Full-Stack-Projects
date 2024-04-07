using System;
using System.Collections.Generic;

namespace PincodeDL.Entity.PinCode
{
    public partial class RegisterUser
    {
        public int UsersId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Hobbies { get; set; }
        public int? State { get; set; }
        public int? District { get; set; }
        public int? City { get; set; }
        public int? Pincode { get; set; }
        public string? Active { get; set; }
    }
}
