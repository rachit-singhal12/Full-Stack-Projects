using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeBL.Shared
{
    public class ServiceLocator
    {
        public BaseResponse myExecute(BaseRequest request)
        {
            BaseResponse response = new BaseResponse();
            Type classType = Type.GetType(request.BaseType);
            if (classType != null)
            {
                BaseBehaviour behaviour = (BaseBehaviour)Activator.CreateInstance(classType);
                response = behaviour.Execute(request);
            }
            return response;
        }
    }
}
