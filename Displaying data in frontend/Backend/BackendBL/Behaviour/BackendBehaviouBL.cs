using BackendBL.Contract.Request;
using BackendBL.Contract.Response;
using BackendBL.Shared;
using BackendDL.Behaviour;
using BackendDL.Contract.Request;
using BackendDL.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBL.Behaviour
{
    public class BackendBehaviouBL:BaseBehaviour
    {
        public override BaseResponse Execute(BaseRequest baseRequest)
        {
            BaseResponse response = new BaseResponse();
            BackendRequestBL reqBL = new BackendRequestBL();
            reqBL  = (BackendRequestBL)baseRequest;
            
            response = getStudentData(reqBL);
            response.BaseResponseMessage = "executed";
            return response;
        }

        private BackendResponseBL getStudentData(BackendRequestBL request)
        {
            BackendResponseBL response = new BackendResponseBL();
            BackendBehaviouDL objDl = new BackendBehaviouDL();
            BackendRequestDL reqDL = new BackendRequestDL();
            BackendResponseDL resDL = new BackendResponseDL();
            reqDL.id = request.id;
            resDL = objDl.getStudentData(reqDL);
            response.data = resDL.data;
            return response;
        }
    }
}
