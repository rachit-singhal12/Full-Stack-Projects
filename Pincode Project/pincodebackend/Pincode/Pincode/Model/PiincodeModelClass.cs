using AutoMapper;
using Microsoft.VisualBasic;
using PincodeBL.Contract.Request;
using PincodeBL.Contract.Response;
using PincodeBL.Shared;
using System.Data;

namespace Pincode.Model
{
    public class PiincodeModelClass
    {
        private IMapper _mapper;

        public PiincodeModelClass()
        {
            MapperConfiguration configMapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PinCodeFormrequest, BehaviourRequestBL>();
                });
            _mapper = configMapper.CreateMapper();
        }

        public PinCodeModelClassResponse getData(PinCodeModelClassRequest request)
        {
            PinCodeModelClassResponse resModel = new PinCodeModelClassResponse();
            ServiceLocator slobj = new ServiceLocator();
            BehaviourRequestBL reqBL = new BehaviourRequestBL();
            reqBL.id = request.id;
            reqBL.id2 = request.id2;
            reqBL.status = request.status;

            if (reqBL.status == "state") 
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "fetch state");
            }
            if(reqBL.status == "city")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "fetch city");
            }
            if(reqBL.status == "district")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "fetch district");
            }
            if (reqBL.status =="pincode")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "fetch pincode");
            }
            if(reqBL.status == "deleteuser")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "deleteuser");
            }
            if(reqBL.status == "fetchsingleuser")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "fetchsingleuser");
            }
            if (reqBL.status == "changeActivestateofuser")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "changeActivestateofuser");
            }

            BaseResponse baseBL = new BaseResponse();
            baseBL = slobj.myExecute(reqBL);
            BehaviourResponseBL resBL = new BehaviourResponseBL();
            resBL = (BehaviourResponseBL)baseBL;
            
            resModel.data = resBL.data;
            return resModel;
        }

        public void setActionType(ref BehaviourRequestBL request,string type,string action)
        {
            request.BaseAction = action;
            request.BaseType = type;
        }

        public PinCodeFormresponse getUserData(PinCodeFormrequest request)
        {
            PinCodeFormresponse response = new PinCodeFormresponse();
            BehaviourRequestBL reqBL = _mapper.Map<PinCodeFormrequest, BehaviourRequestBL>(request);

            ServiceLocator slobj = new ServiceLocator();
            
            if (reqBL.status == "save user")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "save user");
            }

            if (reqBL.status == "fetchusers")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "fetchusers");
            }

            if (reqBL.status == "update user")
            {
                setActionType(ref reqBL, "PincodeBL.Behaviour.BehaviourBL", "update user");
            }

            BaseResponse baseBL = new BaseResponse();
            baseBL = slobj.myExecute(reqBL);
            BehaviourResponseBL resBL = new BehaviourResponseBL();
            resBL = (BehaviourResponseBL)baseBL;

            response.Message = resBL.message;
            response.data = resBL.data;

            return response;
        }
    }
    public class PinCodeModelClassRequest
    {
        public string? status { get; set; }
        public int id {  get; set; }
        public int id2 { get; set; }
    }
    public class PinCodeModelClassResponse
    {
        public DataSet? data { get; set; }
    }

    public class PinCodeFormrequest
    {
        public int id {  get; set; }
        public string? name { get; set; }
        public string? email {  get; set; }
        public DateTime? dateofBirth { get; set; }
        public int? age { get; set; }
        public string? gender { get; set; }
        public string? hobbies { get; set; }
        public int state {  get; set; }
        public int district { get; set; }
        public int city { get; set; }
        public int pincode { get; set; }
        public string? status { get; set; }
    }
    public class PinCodeFormresponse
    {
        public string? Message { get; set; }
        public DataSet? data { get; set; }

    }


}
