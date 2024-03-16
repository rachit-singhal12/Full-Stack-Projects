using BackendView.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackendView.Controllers
{
    [ApiController]
    public class UserDataController : Controller
    {
        [HttpGet]
        [Route("/getMessage")]
        public string getUserMessage()
        {
            return "Hello Rachit";
        }

        [HttpPost]
        [Route("/getUserData")]
        public ModelResponse getUserFormData(UserDataClass obj) 
        {
            UserDataClass user  = new UserDataClass();
            ModelResponse modelresponse = user.GetUsers(obj);
            return modelresponse;
        }
    }
}
