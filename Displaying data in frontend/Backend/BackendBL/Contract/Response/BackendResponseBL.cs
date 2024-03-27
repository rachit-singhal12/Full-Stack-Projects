using BackendBL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBL.Contract.Response
{
    public class BackendResponseBL : BaseResponse
    {
        public DataSet? data { get; set; }

    }
}
