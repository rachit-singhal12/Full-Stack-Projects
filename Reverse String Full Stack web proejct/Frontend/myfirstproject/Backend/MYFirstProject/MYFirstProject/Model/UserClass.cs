using ClassLibrary2BL.Behaviour;
using ClassLibrary2BL.Contract.Response;
namespace MYFirstProject.Model
{
    public class UserClass
    {
        //Request Parameter is set for Model
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }



        public UserModelResponse setUserData(UserClass user)
        {
            ClassLibrary2BL.Behaviour.UserBehaviourBL objectBL = new ClassLibrary2BL.Behaviour.UserBehaviourBL();
            ClassLibrary2BL.Contract.Request.UserRequestBL reqObjBL = new ClassLibrary2BL.Contract.Request.UserRequestBL();
            reqObjBL.Name = user.Name;
            reqObjBL.Email = user.Email;
            reqObjBL.Age = user.Age;

            ResponseBL res = objectBL.setUserData(reqObjBL);
            UserModelResponse modelresponse = new UserModelResponse();
            modelresponse.successmeaggae = res.successMessage;
            modelresponse.errormeaggae = res.errorMessage;
            modelresponse.reversedName = res.reverseName;
            return modelresponse;
       }
    }

    //Response parameter is set for Model
     public class UserModelResponse
    {
        public string? successmeaggae { get; set; }
        public string? errormeaggae { get;set; }
        public string? reversedName { get; set; }
    }

}
