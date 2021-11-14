using MasterDetails.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace MasterDetails.DAL
{
    public class DropdownDAL
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["EmployeeDbContext"].ConnectionString;
        
        public async Task<List<EmpType>> GetEmployeeTypes()
        {
            var query = "SELECT " +
                      "Type_Id, " +
                      "Types  " +
                      "FROM Employee_Type ";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<EmpType> emplTypeList = new List<EmpType>();

            while (reader.Read())
            {
                EmpType emplType = new EmpType();
                emplType.Id = Convert.ToInt32(reader["Type_Id"]);
                emplType.Name = reader["Types"].ToString();
                emplTypeList.Add(emplType);
            }
            reader.Close();
            connection.Close();

            return emplTypeList;
        }
    }
}