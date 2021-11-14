using MasterDetails.BLL;
using MasterDetails.DAL;
using MasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MasterDetails.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly DropdownDAL dropdownDal = new DropdownDAL();
        private readonly EmployeeBLL employeeBLL = new EmployeeBLL();

        public  async Task<ActionResult> CreateOrEdit()
        {
            ViewBag.EmployeeTypeList = await dropdownDal.GetEmployeeTypes();
            return View();
        }

        public ActionResult SaveEmployee(Employee objEmployee)
        {
            var data = employeeBLL.InsertEmployee(objEmployee);
            var returnData = new
            {
                m = data,
                isRedirect = true,
                redirectUrl = Url.Action("CreateOrEdit")
            };
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

    }
}