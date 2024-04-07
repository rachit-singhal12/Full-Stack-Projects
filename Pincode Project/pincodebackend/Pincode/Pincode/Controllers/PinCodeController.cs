using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pincode.Model;
using System;
namespace Pincode.Controllers
{
    [ApiController]
    public class PinCodeController : Controller
    {
        [HttpGet]
        [Route("/getRequest")]
        public string getRequest()
        {
            return "Service Works fine";
        }

        [HttpPost]
        [Route("/GetPinCodeData")]
        public string getData(PinCodeModelClassRequest request)
        {
            
            PinCodeModelClassResponse response = new PinCodeModelClassResponse();
            PiincodeModelClass obj = new PiincodeModelClass();
            response = obj.getData(request);
            string json = JsonConvert.SerializeObject(response.data);
            return json;
        }

        [HttpPost]
        [Route("/GetUserData")]
        public string getData(PinCodeFormrequest request)
        {
            PinCodeFormresponse response = new PinCodeFormresponse();
            PiincodeModelClass obj = new PiincodeModelClass();
            response = obj.getUserData(request);
            if (response.data != null)
            {
                string json = JsonConvert.SerializeObject(response.data);
                return json;
            }else
            return response.Message;
        }

    }
}
