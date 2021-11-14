using MasterDetails.DAL;
using MasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace MasterDetails.BLL
{
    public class EmployeeBLL
    {
        public readonly EmployeeDal employeeDal = new EmployeeDal();

        private string connectionString = WebConfigurationManager.ConnectionStrings["EmployeeDbContext"].ConnectionString;

        public async Task <string> InsertEmployee(Employee employee)
        {
            string returnMessage = "";
            try
            {
                foreach (var tableData in employee.Employees)
                {
                    int result = await employeeDal.InsertEmployee(tableData);

                    if (result == 1)
                    {
                        returnMessage = "Successfully";
                    }
                    else
                    {
                        returnMessage = "Failed";
                    }
                }

                return returnMessage;
            }
            catch (Exception ex)
            {
                return "something went wrong";
            }
        }
    }
}