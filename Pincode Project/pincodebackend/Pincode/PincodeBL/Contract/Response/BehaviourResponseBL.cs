using PincodeBL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeBL.Contract.Response
{
    public class BehaviourResponseBL : BaseResponse
    {
        public DataSet? data { get; set; }
        public string? message { get; set; }
    }
}
