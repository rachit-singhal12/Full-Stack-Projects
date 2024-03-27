using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBL.Shared
{
    public abstract class BaseBehaviour
    {
        public abstract BaseResponse Execute(BaseRequest baseRequest);
    }
}
