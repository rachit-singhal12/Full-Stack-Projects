using System.Collections.Generic;
using UserDataBL.Behaviour;
using UserDataBL.Contract.Request;
using UserDataBL.Contract.Response;

namespace BackendView.Model
{
    public class UserDataClass
    {
        public Users[] Users { get; set; }

        public ModelResponse GetUsers(UserDataClass objModel)
        {
            ModelResponse response = new ModelResponse();
            UserDataBehaviourRequestBL reqBL = new UserDataBehaviourRequestBL();
            UserDataBehaviourBL objBL = new UserDataBehaviourBL();
            UserDataBehaviourResponseBL respBL = new UserDataBehaviourResponseBL();

            if (objModel.Users != null)
            {
                Users = new Users[objModel.Users.Length];

                for (int i = 0; i < objModel.Users.Length; i++)
                {
                    Users[i] = new Users
                    {
                        Id = objModel.Users[i].Id,
                        Name = objModel.Users[i].Name,
                        Email = objModel.Users[i].Email,
                        Password = objModel.Users[i].Password
                    };
                }

                reqBL.Users = new UserDataBL.Contract.Request.Users[objModel.Users.Length];

                for (int i = 0; i < reqBL.Users.Length; i++)
                {
                    reqBL.Users[i] = new UserDataBL.Contract.Request.Users();
                     reqBL.Users[i].Name = Users[i].Name;
                     reqBL.Users[i].Email = Users[i].Email;
                     reqBL.Users[i].Password = Users[i].Password;
                    reqBL.Users[i].Id = Users[i].Id;
                }

                respBL = objBL.getUserInfo(reqBL);
                response.errormessage = respBL.errormessage;
                response.successmessage = respBL.successmessage;
            }
            else
            {
                response.errormessage = "User data is null";
            }
            return response;
        }

    }

    public class ModelResponse
    {
        public string successmessage { get; set; }
        public string errormessage { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
