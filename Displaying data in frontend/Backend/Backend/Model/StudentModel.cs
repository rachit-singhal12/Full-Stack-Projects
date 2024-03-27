using BackendBL.Contract.Request;
using BackendBL.Contract.Response;
using BackendBL.Shared;
using System.Data;

namespace Backend.Model
{
    public class StudentModel
    {
        public StudentModelResponse getData(StudentModelRequest request)
        {
            StudentModelResponse response = new StudentModelResponse();
            ServiceLocator serviceobj = new ServiceLocator();
            BackendRequestBL reqBL = new BackendRequestBL();
            BaseResponse br = new BaseResponse();
            setParam(ref reqBL, "fetch_student-details","BackendBL.Behaviour.BackendBehaviouBL");
            reqBL.id = request.id;
         
             br =    serviceobj.Execute(reqBL);
            if(br.BaseResponseMessage != null)
            {
                BackendResponseBL r = (BackendResponseBL)br;
                response.data = r.data;
            }
            return response;
        }

        public void setParam(ref BackendRequestBL request,string action, string type)
        {
            request.BaseAction = action;
            request.BaseType = type;
        }
    }
    public class StudentModelRequest
    {
        public int id {  get; set; }
    }
    public class StudentModelResponse
    {
        public DataSet? data {  get; set; }
    }
}
