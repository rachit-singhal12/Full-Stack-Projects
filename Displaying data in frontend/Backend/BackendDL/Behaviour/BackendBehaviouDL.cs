using BackendDL.Contract.Request;
using BackendDL.Contract.Response;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDL.Behaviour
{
    public class BackendBehaviouDL
    {
        private readonly string _dbString = new Entity.Student.TraingContext().Database.GetConnectionString();


        public BackendResponseDL getStudentData(BackendRequestDL request)
        {
            BackendResponseDL response = new BackendResponseDL();


            DataSet ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(_dbString))
            {
                SqlCommand command = new SqlCommand("delete_student", connection);
                command.CommandType = CommandType.StoredProcedure;

                if (request.id != 0)
                  command.Parameters.Add("id", SqlDbType.Int).Value = request.id;

                //command.Parameters.Add("id", SqlDbType.Int).Value = request.id;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                connection.Open();
                sqlDataAdapter.Fill(ds);

                response.data = ds; 

            }
            return response;
        }
    }
}
