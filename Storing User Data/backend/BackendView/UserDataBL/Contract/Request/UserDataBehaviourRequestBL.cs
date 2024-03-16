using System.Collections.Generic;

namespace UserDataBL.Contract.Request
{
    public class UserDataBehaviourRequestBL
    {
        public Users[] Users { get; set; }
        
    }

    public class Users
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
