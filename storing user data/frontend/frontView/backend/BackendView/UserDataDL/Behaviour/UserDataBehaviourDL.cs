using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataDL.Contract.Request;
using UserDataDL.Contract.Response;

namespace UserDataDL.Behaviour
{
    public class UserDataBehaviourDL
    {
        public UserDataBehaviourResponseDL getUserData(UserDataBehaviourRequestDL reqDL)
        {
            UserDataBehaviourResponseDL resDL = new UserDataBehaviourResponseDL();

            foreach(var user in reqDL.Users)
            {
                if(user.Name=="null")
                {
                    resDL.errormessage = "failed";
                    break;
                }
            }
            if(resDL.errormessage!="failed")
            {
                resDL.successmessage = "success";
            }
            return resDL;
        }
    }
}
