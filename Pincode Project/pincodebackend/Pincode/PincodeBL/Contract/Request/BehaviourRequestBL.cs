using Microsoft.VisualBasic;
using PincodeBL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeBL.Contract.Request
{
    public class BehaviourRequestBL : BaseRequest
    {
        public string? status { get; set; }
        public int id { get; set; }
        public int id2 { get; set; }

        public string? name { get; set; }
        public string? email { get; set; }
        public DateTime? dateofBirth { get; set; }
        public int? age { get; set; }
        public string? gender { get; set; }
        public string? hobbies { get; set; }
        public int state { get; set; }
        public int district { get; set; }
        public int city { get; set; }
        public int pincode { get; set; }
    }
}
