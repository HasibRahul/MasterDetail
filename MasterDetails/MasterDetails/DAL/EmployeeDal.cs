using MasterDetails.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace MasterDetails.DAL
{
    public class EmployeeDal
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["EmployeeDbContext"].ConnectionString;

        public async Task<int> InsertEmployee(Employee employee)
        {
            string query = "INSERT INTO employees_details( Employee_Title, Employee_Address, Employee_Type, Create_Date, Create_Time, Remarks) " +
                "VALUES(@Title, @Address, @Type, @Date, @Time, @Remarks)";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("Title", SqlDbType.VarChar);
            command.Parameters["Title"].Value = employee.Title;

            command.Parameters.Add("Address", SqlDbType.VarChar);
            command.Parameters["Address"].Value = employee.Address;

            command.Parameters.Add("Type", SqlDbType.VarChar);
            command.Parameters["Type"].Value = employee.Type;

            command.Parameters.Add("Date", SqlDbType.VarChar);
            command.Parameters["Date"].Value = employee.Date.ToShortDateString();

            command.Parameters.Add("Time", SqlDbType.VarChar);
            command.Parameters["Time"].Value = employee.Time.ToShortTimeString();

            command.Parameters.Add("Remarks", SqlDbType.VarChar);
            command.Parameters["Remarks"].Value = employee.Remarks;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}
