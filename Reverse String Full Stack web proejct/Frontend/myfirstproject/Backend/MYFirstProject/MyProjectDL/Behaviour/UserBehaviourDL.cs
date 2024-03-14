using MyProjectDL.Contract.Request;
using MyProjectDL.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDL.Behaviour
{
    public class UserBehaviourDL
    {
        public UserResponseDL setUserData(UserRequestDL reqObj)
        {
            MyProjectDL.Contract.Request.UserRequestDL reqDL = new MyProjectDL.Contract.Request.UserRequestDL();
            reqDL.Name = reqObj.Name;
            reqDL.Email = reqObj.Email;
            reqDL.Age = reqObj.Age;

            MyProjectDL.Contract.Response.UserResponseDL resDL = new MyProjectDL.Contract.Response.UserResponseDL();

            if (reqDL.Name!=string.Empty)
            {
                resDL.successmessage = "success";
            }
            else
            {
                resDL.errormessage = "String is Empty";
            }


            char[] charArray = reqDL.Name.ToCharArray();
            string reversedString = String.Empty;
            for (int i = charArray.Length - 1; i > -1; i--)
            {
                reversedString += charArray[i];
            }

            resDL.reversedName = reversedString;
            return resDL ;
        }
    }
}
