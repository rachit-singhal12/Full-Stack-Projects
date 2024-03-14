using Microsoft.AspNetCore.Mvc;
using MYFirstProject.Model;

namespace MYFirstProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //setting http get request for practice
        [HttpGet]
        [Route("/getData")]
        public string getUserData()
        {
            return "hello Rachit";
        }

        //setting up http post request
        [HttpPost]
        [Route("/postData")]
        public ActionResult setUserData(UserClass user)
        {
            //create UserClass and UserModelResponse is a classes of model of this Route
            UserClass obj = new UserClass();
            UserModelResponse res =  obj.setUserData(user);
            JsonResult jsonResult = new JsonResult(res);
            return jsonResult;
        }
    }
}
