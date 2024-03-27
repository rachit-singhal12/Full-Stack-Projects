using Microsoft.AspNetCore.Mvc;
using Backend.Model;
using Newtonsoft.Json;
using System.Data;
namespace Backend.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        [HttpGet]
        [Route("/getdemo")]
        public string getDemo()
        {
            return "Service Connected";
        }
        [HttpPost]
        [Route("/getsrtudentdata")]
        public string getStudentDatas(StudentModelRequest request)
        {
            StudentModelResponse response = new StudentModelResponse();
            StudentModel obj = new StudentModel();
            response = obj.getData(request);
            string json = JsonConvert.SerializeObject(response.data, Formatting.Indented);
            return json;
        }
        
    }
}
