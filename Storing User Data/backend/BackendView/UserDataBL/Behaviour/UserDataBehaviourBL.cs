using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataBL.Contract.Request;
using UserDataBL.Contract.Response;
using UserDataDL.Behaviour;
using UserDataDL.Contract;
using UserDataDL.Contract.Request;
using UserDataDL.Contract.Response;

namespace UserDataBL.Behaviour
{
    public class UserDataBehaviourBL
    {
        public UserDataBehaviourResponseBL getUserInfo(UserDataBehaviourRequestBL reqBL)
        {
            
            UserDataBehaviourResponseBL resBL = new UserDataBehaviourResponseBL();

            UserDataBehaviourResponseDL resDL = new UserDataBehaviourResponseDL();
            UserDataBehaviourRequestDL reqDL = new UserDataBehaviourRequestDL();
            UserDataBehaviourDL objDL = new UserDataBehaviourDL();

            if (reqBL.Users != null)
            {
                int length = reqBL.Users.Length;

                reqDL.Users = new UserDataDL.Contract.Request.Users[reqBL.Users.Length];

                for (int i = 0; i < length; i++)
                {
                    reqDL.Users[i] = new UserDataDL.Contract.Request.Users();
                    reqDL.Users[i].Name= reqBL.Users[i].Name;
                    reqDL.Users[i].Id= reqBL.Users[i].Id;
                    reqDL.Users[i].Password= reqBL.Users[i].Password;
                    reqDL.Users[i].Email = reqBL.Users[i].Email;

                }
                resDL = objDL.getUserData(reqDL);
                resBL.errormessage = resDL.errormessage;
                resBL.successmessage = resDL.successmessage;
            }
            else
            {
                resBL.errormessage = "data is not null here";
            }
            return resBL;
        }
       
    }
}
