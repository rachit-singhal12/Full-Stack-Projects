using AutoMapper;
using PincodeBL.Contract.Request;
using PincodeBL.Contract.Response;
using PincodeBL.Shared;
using PincodeDL.Behaviour;
using PincodeDL.Contract.Request;
using PincodeDL.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeBL.Behaviour
{
    public class BehaviourBL:BaseBehaviour
    {
        private IMapper _mapper;

        public BehaviourBL()
        {
            MapperConfiguration configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BehaviourRequestBL, BehaviourRequestDL>();
            });
            _mapper = configMapper.CreateMapper();
        }
        public override BaseResponse Execute(BaseRequest request)
        {
            BehaviourResponseBL resBl = new BehaviourResponseBL();
            BehaviourRequestBL reqBl = new BehaviourRequestBL();
            //FetchAddress

            if (request.BaseAction == "fetch state"|| request.BaseAction == "fetch city"|| request.BaseAction == "fetch district" || request.BaseAction == "fetch pincode")
            {
                reqBl = (BehaviourRequestBL)request;
                resBl = FetchAddress(reqBl);
            }

            //if (request.BaseAction == "fetch state")
            //{
            //    reqBl = (BehaviourRequestBL)request;
            //    resBl = fetchState(reqBl);
            //}
            //if (request.BaseAction == "fetch city")
            //{
            //    reqBl = (BehaviourRequestBL)request;
            //    resBl = fetchCity(reqBl);
            //}
            //if (request.BaseAction == "fetch district")
            //{
            //    reqBl = (BehaviourRequestBL)request;
            //    resBl = fetchDistrict(reqBl);
            //}
            //if (request.BaseAction == "fetch pincode")
            //{
            //    reqBl = (BehaviourRequestBL)request;
            //    resBl = fetchPincode(reqBl);
            //}


            if (request.BaseAction == "save user")
            {
                reqBl = (BehaviourRequestBL)request;
                resBl = SaveUserData(reqBl);
            }
            if (request.BaseAction == "fetchusers")
            {
                reqBl = (BehaviourRequestBL)request;
                resBl = FetchUsersDetails(reqBl);
            }
            if (request.BaseAction == "deleteuser")
            {
                reqBl = (BehaviourRequestBL)request;
                resBl = DeleteUserData(reqBl);
            }
            if (request.BaseAction == "fetchsingleuser")
            {
                reqBl = (BehaviourRequestBL)request;
                resBl = FetchSingleUser(reqBl);
            }
            if (request.BaseAction == "update user")
            {
                reqBl = (BehaviourRequestBL)request;
                resBl = UpdateUser(reqBl);
            }
            //changeActivestateofuser
            if (request.BaseAction == "changeActivestateofuser")
            {
                reqBl = (BehaviourRequestBL)request;
                resBl = ChangeActivestateofuser(reqBl);
            }
            return resBl;
        }
        private BehaviourResponseBL FetchAddress(BehaviourRequestBL request)
        {
            BehaviourResponseBL resBl = new BehaviourResponseBL();
            BehaviourDL objDl = new BehaviourDL();
            BehaviourRequestDL reqDl = new BehaviourRequestDL();
            BehaviourResponseDL resDl = new BehaviourResponseDL();
            reqDl.id = request.id;
            reqDl.id2 = request.id2;
            reqDl.status = request.status;

            resDl = objDl.FetchAddress(reqDl);
            resBl.data = resDl.data;
            resBl.BaseResponseMessage = "BL";
            return resBl;
        }
       

        private BehaviourResponseBL SaveUserData(BehaviourRequestBL requestBL)
        {
            BehaviourDL objDl = new BehaviourDL();
            BehaviourResponseDL resDl = new BehaviourResponseDL();
            BehaviourResponseBL resBL = new BehaviourResponseBL();
            BehaviourRequestDL reqDL = _mapper.Map<BehaviourRequestBL, BehaviourRequestDL>(requestBL);
            resDl = objDl.SaveUserData(reqDL);
            resBL.data = resDl.data;
            resBL.message= resDl.message;
            return resBL;
        }

        private BehaviourResponseBL FetchUsersDetails(BehaviourRequestBL requestBL)
        {
            BehaviourDL objDl = new BehaviourDL();
            BehaviourResponseBL responseBL = new BehaviourResponseBL();
            BehaviourResponseDL respDl = new BehaviourResponseDL();
            BehaviourRequestDL reqDL = new BehaviourRequestDL();

            respDl = objDl.FetchUsersDetails(reqDL);
            responseBL.data = respDl.data;
            return responseBL;
        }

        private BehaviourResponseBL DeleteUserData(BehaviourRequestBL request)
        {
            BehaviourResponseBL response = new BehaviourResponseBL();

            BehaviourDL objDl = new BehaviourDL();
            BehaviourResponseBL responseBL = new BehaviourResponseBL();
            BehaviourResponseDL respDl = new BehaviourResponseDL();
            BehaviourRequestDL reqDL = _mapper.Map<BehaviourRequestBL, BehaviourRequestDL>(request);



            respDl = objDl.DeleteUserData(reqDL);
            responseBL.data = respDl.data;
            return responseBL;

        }

        private BehaviourResponseBL FetchSingleUser(BehaviourRequestBL request)
        {
            BehaviourResponseBL response = new BehaviourResponseBL();

            BehaviourDL objDl = new BehaviourDL();
            BehaviourResponseBL responseBL = new BehaviourResponseBL();
            BehaviourResponseDL respDl = new BehaviourResponseDL();
            BehaviourRequestDL reqDL = _mapper.Map<BehaviourRequestBL, BehaviourRequestDL>(request);
            respDl = objDl.FetchSingleUser(reqDL);
            responseBL.data = respDl.data;
            return responseBL;
        }
        private BehaviourResponseBL UpdateUser(BehaviourRequestBL request)
        {
            BehaviourResponseBL response = new BehaviourResponseBL();
            BehaviourDL objDl = new BehaviourDL();
            BehaviourResponseBL responseBL = new BehaviourResponseBL();
            BehaviourResponseDL respDl = new BehaviourResponseDL();
            BehaviourRequestDL reqDL = _mapper.Map<BehaviourRequestBL, BehaviourRequestDL>(request);
            respDl = objDl.UpdateUser(reqDL);
            responseBL.data = respDl.data;
            return responseBL;
        }

        private BehaviourResponseBL ChangeActivestateofuser(BehaviourRequestBL request)
        {
            BehaviourResponseBL response = new BehaviourResponseBL();
            BehaviourDL objDl = new BehaviourDL();
            BehaviourResponseBL responseBL = new BehaviourResponseBL();
            BehaviourResponseDL respDl = new BehaviourResponseDL();
            BehaviourRequestDL reqDL = _mapper.Map<BehaviourRequestBL, BehaviourRequestDL>(request);
            respDl = objDl.ChangeActivestateofuser(reqDL);
            responseBL.data = respDl.data;
            return responseBL;
        }
    }
}
