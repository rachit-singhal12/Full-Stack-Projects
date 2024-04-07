using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PincodeDL.Contract.Request;
using PincodeDL.Contract.Response;
using PincodeDL.Entity.PinCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PincodeDL.Behaviour
{
    public class BehaviourDL
    {
        private readonly string _dbString = new Entity.PinCode.PincodeContext().Database.GetConnectionString();

        public BehaviourResponseDL FetchAddress(BehaviourRequestDL reqDL)
        {
            BehaviourResponseDL resDl = new BehaviourResponseDL();
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(_dbString))
                {
                    SqlCommand command = new SqlCommand("SelectDataByIdAndStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    if(reqDL.id!=0)
                    command.Parameters.Add("id", SqlDbType.Int).Value = reqDL.id;
                command.Parameters.Add("id2", SqlDbType.Int).Value = reqDL.id2;

                command.Parameters.Add("Status", SqlDbType.VarChar).Value = reqDL.status;

                    connection.Open();
                    sqlDataAdapter.Fill(ds);
                    if (ds != null)
                    {
                        resDl.data = ds;
                    }
                }
            //if (reqDL.status == "city")
            //{
            //    if (reqDL.status == "city")
            //    {

            //        DataSet ds = new DataSet();

            //        using (SqlConnection connection = new SqlConnection(_dbString))
            //        {
            //            SqlCommand command = new SqlCommand("selectCity", connection);
            //            command.CommandType = CommandType.StoredProcedure;
            //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            //            if (reqDL.id != 0)
            //                command.Parameters.Add("id", SqlDbType.Int).Value = reqDL.id;
            //            connection.Open();
            //            sqlDataAdapter.Fill(ds);
            //            if (ds != null)
            //            {
            //                resDl.data = ds;
            //            }
            //        }
            //    }
            //    return resDl;
            //}

            //if (reqDL.status == "district")
            //{
            //    if (reqDL.status == "district")
            //    {

            //        DataSet ds = new DataSet();

            //        using (SqlConnection connection = new SqlConnection(_dbString))
            //        {
            //            SqlCommand command = new SqlCommand("selectDistrict", connection);
            //            command.CommandType = CommandType.StoredProcedure;
            //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            //            if (reqDL.id != 0)
            //                command.Parameters.Add("id", SqlDbType.Int).Value = reqDL.id;
            //            connection.Open();
            //            sqlDataAdapter.Fill(ds);
            //            if (ds != null)
            //            {
            //                resDl.data = ds;
            //            }
            //        }
            //    }
            //    return resDl;
            //}
            //if (reqDL.status == "pincode")
            //{
            //    if (reqDL.status == "pincode")
            //    {

            //        DataSet ds = new DataSet();

            //        using (SqlConnection connection = new SqlConnection(_dbString))
            //        {
            //            SqlCommand command = new SqlCommand("selectPincode", connection);
            //            command.CommandType = CommandType.StoredProcedure;
            //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            //            if (reqDL.id != 0)
            //                command.Parameters.Add("id", SqlDbType.Int).Value = reqDL.id;
            //            connection.Open();
            //            sqlDataAdapter.Fill(ds);
            //            if (ds != null)
            //            {
            //                resDl.data = ds;
            //            }
            //        }
            //    }
            //}
            return resDl;
        }

        public BehaviourResponseDL SaveUserData(BehaviourRequestDL reqDL)
        {
            BehaviourResponseDL resDL = new BehaviourResponseDL();

            using (Entity.PinCode.PincodeContext context = new Entity.PinCode.PincodeContext())
            {
                RegisterUser obj = new RegisterUser();

                obj.Name = reqDL.name;
                obj.Email = reqDL.email;
                obj.DateOfBirth = reqDL.dateofBirth;
                obj.Age = reqDL.age;
                obj.Gender = reqDL.gender;
                string? hobbies = "";
                string? temp = reqDL.hobbies;
                if (temp[3] == 'Y' || temp[3] == 'y') hobbies += "Reading ";
                if (temp[8] == 'Y' || temp[8] == 'y') hobbies += "Traveling ";
                if (temp[13] == 'Y' || temp[13] == 'y') hobbies += "Cooking";
                obj.Hobbies = hobbies;

                obj.State = reqDL.state;
                obj.District = reqDL.district;
                obj.City = reqDL.city;
                obj.Pincode = reqDL.pincode;
                obj.Active = "Y";

                context.RegisterUsers.Add(obj);

                context.SaveChanges();

                resDL.message = "Details Saves";
            }
            resDL = FetchUsersDetails(reqDL);

            return resDL;
        }

        public BehaviourResponseDL FetchUsersDetails(BehaviourRequestDL reqDL)
        {
            BehaviourResponseDL response = new BehaviourResponseDL();

            DataSet ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(_dbString))
            {
                SqlCommand command = new SqlCommand("SelectAllUsersData", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                command.Parameters.Add("id", SqlDbType.Int);
                connection.Open();
                sqlDataAdapter.Fill(ds);
                if (ds != null)
                {
                    response.data = ds;
                }
            }

            return response;
        }
        public BehaviourResponseDL DeleteUserData(BehaviourRequestDL reqDL)
        {
            BehaviourResponseDL response = new BehaviourResponseDL();
            using (Entity.PinCode.PincodeContext context = new Entity.PinCode.PincodeContext())
            {
                RegisterUser userobj = context.RegisterUsers.FirstOrDefault((x => x.UsersId == reqDL.id));
                if (userobj != null)
                {
                    userobj.Active = "N";
                }

                context.SaveChanges();
                response.message = "user active set to no";
            }
            response = FetchUsersDetails(reqDL);
            return response;
        }
        public BehaviourResponseDL FetchSingleUser(BehaviourRequestDL reqDL)
        {
            BehaviourResponseDL resDl = new BehaviourResponseDL();
            DataSet ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(_dbString))
            {
                SqlCommand command = new SqlCommand("selectUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                if (reqDL.id != 0)
                    command.Parameters.Add("id", SqlDbType.Int).Value = reqDL.id;
                connection.Open();
                sqlDataAdapter.Fill(ds);
                if (ds != null)
                {
                    resDl.data = ds;
                }
            }
            return resDl;
        }
        public BehaviourResponseDL UpdateUser(BehaviourRequestDL reqDL)
        {
            BehaviourResponseDL resDl = new BehaviourResponseDL();
            DataSet ds = new DataSet();
            using (Entity.PinCode.PincodeContext context = new Entity.PinCode.PincodeContext())
            {
                RegisterUser ruser = context.RegisterUsers.FirstOrDefault((x => x.UsersId == reqDL.id));
                if (ruser != null)
                {

                    ruser.Name = reqDL.name;
                    ruser.Email = reqDL.email;
                    ruser.DateOfBirth = reqDL.dateofBirth;
                    ruser.Age = reqDL.age;
                    ruser.Gender = reqDL.gender;
                    string? hobbies = "";
                    string? temp = reqDL.hobbies;
                    if (temp[3] == 'Y' || temp[3] == 'y') hobbies += "Reading ";
                    if (temp[8] == 'Y' || temp[8] == 'y') hobbies += "Traveling ";
                    if (temp[13] == 'Y' || temp[13] == 'y') hobbies += "Cooking";
                    ruser.Hobbies = hobbies;
                    ruser.State = reqDL.state;
                    ruser.District = reqDL.district;
                    ruser.City = reqDL.city;
                    ruser.Pincode = reqDL.pincode;
                    ruser.Active = "Y";
                }
                context.SaveChanges();
            }
            return resDl;
        }
        public BehaviourResponseDL ChangeActivestateofuser(BehaviourRequestDL reqDL)
        {
            BehaviourResponseDL resDl = new BehaviourResponseDL();
            DataSet ds = new DataSet();
            using (Entity.PinCode.PincodeContext context = new Entity.PinCode.PincodeContext())
            {
                RegisterUser ruser = context.RegisterUsers.FirstOrDefault((x => x.UsersId == reqDL.id));
                if (ruser != null)
                {
                    ruser.Active = "Y";
                }
                context.SaveChanges();
            }
            resDl = FetchUsersDetails(reqDL);

            return resDl;
        }
        //public BehaviourResponseDL fetchState(BehaviourRequestDL reqDL)
        //{
        //    BehaviourResponseDL resDl = new BehaviourResponseDL();
        //    if(reqDL.status == "state")
        //    {

        //        DataSet ds = new DataSet();

        //        using (SqlConnection connection = new SqlConnection(_dbString))
        //        {
        //            SqlCommand command = new SqlCommand("selectState", connection);
        //            command.CommandType = CommandType.StoredProcedure;
        //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
        //            command.Parameters.Add("id", SqlDbType.Int);
        //            connection.Open();
        //            sqlDataAdapter.Fill(ds);
        //            if(ds!=null)
        //            {
        //                resDl.data = ds;
        //            }
        //        }
        //    }
        //    return resDl;

        //}
        //public BehaviourResponseDL fetchCity(BehaviourRequestDL reqDL)
        //{
        //    BehaviourResponseDL resDl = new BehaviourResponseDL();
        //    if (reqDL.status == "city")
        //    {

        //        DataSet ds = new DataSet();

        //        using (SqlConnection connection = new SqlConnection(_dbString))
        //        {
        //            SqlCommand command = new SqlCommand("selectCity", connection);
        //            command.CommandType = CommandType.StoredProcedure;
        //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
        //            if (reqDL.id != 0)
        //                command.Parameters.Add("id", SqlDbType.Int).Value = reqDL.id;
        //            connection.Open();
        //            sqlDataAdapter.Fill(ds);
        //            if (ds != null)
        //            {
        //                resDl.data = ds;
        //            }
        //        }
        //    }
        //    return resDl;

        //}
        //public BehaviourResponseDL fetchDistrict(BehaviourRequestDL reqDL)
        //{
        //    BehaviourResponseDL resDl = new BehaviourResponseDL();
        //    if (reqDL.status == "district")
        //    {

        //        DataSet ds = new DataSet();

        //        using (SqlConnection connection = new SqlConnection(_dbString))
        //        {
        //            SqlCommand command = new SqlCommand("selectDistrict", connection);
        //            command.CommandType = CommandType.StoredProcedure;
        //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
        //            if (reqDL.id != 0)
        //                command.Parameters.Add("id", SqlDbType.Int).Value = reqDL.id;
        //            connection.Open();
        //            sqlDataAdapter.Fill(ds);
        //            if (ds != null)
        //            {
        //                resDl.data = ds;
        //            }
        //        }
        //    }
        //    return resDl;
        //}

        //    public BehaviourResponseDL fetchPincode(BehaviourRequestDL reqDL)
        //    {
        //        BehaviourResponseDL resDl = new BehaviourResponseDL();
        //        if (reqDL.status == "pincode")
        //        {

        //            DataSet ds = new DataSet();

        //            using (SqlConnection connection = new SqlConnection(_dbString))
        //            {
        //                SqlCommand command = new SqlCommand("selectPincode", connection);
        //                command.CommandType = CommandType.StoredProcedure;
        //                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
        //            if (reqDL.id != 0)
        //                command.Parameters.Add("id", SqlDbType.Int).Value = reqDL.id;
        //            connection.Open();
        //                sqlDataAdapter.Fill(ds);
        //                if (ds != null)
        //                {
        //                    resDl.data = ds;
        //                }
        //            }
        //        }
        //        return resDl;

        //    }

    }
}
