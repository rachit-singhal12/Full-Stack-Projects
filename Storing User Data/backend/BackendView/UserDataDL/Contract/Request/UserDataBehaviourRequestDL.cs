using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataDL.Contract.Request
{
    public class UserDataBehaviourRequestDL
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
