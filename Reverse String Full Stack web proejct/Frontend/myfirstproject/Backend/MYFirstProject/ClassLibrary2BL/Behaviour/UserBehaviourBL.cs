using ClassLibrary2BL.Contract.Request;
using ClassLibrary2BL.Contract.Response;
using MyProjectDL.Contract.Response;
using MyProjectDL.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2BL.Behaviour
{
    public class UserBehaviourBL
    {

        public ResponseBL setUserData(UserRequestBL reqObj)
        {
            MyProjectDL.Behaviour.UserBehaviourDL obj = new MyProjectDL.Behaviour.UserBehaviourDL();
            MyProjectDL.Contract.Request.UserRequestDL reqobjDL = new MyProjectDL.Contract.Request.UserRequestDL();
            reqobjDL.Name = reqObj.Name;
            reqobjDL.Email = reqObj.Email;
            reqobjDL.Age = reqObj.Age;

            MyProjectDL.Contract.Response.UserResponseDL resdlobj = new MyProjectDL.Contract.Response.UserResponseDL();
            
            resdlobj = obj.setUserData(reqobjDL);

            ClassLibrary2BL.Contract.Response.ResponseBL resBL = new ClassLibrary2BL.Contract.Response.ResponseBL();

            resBL.errorMessage = resdlobj.errormessage;
            resBL.successMessage = resdlobj.successmessage;
            resBL.reverseName = resdlobj.reversedName;

            return resBL;
        }
    }
}
