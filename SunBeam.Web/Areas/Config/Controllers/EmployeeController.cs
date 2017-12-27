#region Library
using SunBeam.Domain.Models;
using SunBeam.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
#endregion library

namespace SunBeam.Web.Areas.Config.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBL repo;
        public EmployeeController(IEmployeeBL _repo)
        {
            this.repo = _repo;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _index(JQueryDataTableParamVM param)
        {
            #region Column Search
            var idFilter = Convert.ToString(Request["sSearch_0"]);
            var CodeFilter = Convert.ToString(Request["sSearch_1"]);
            var NameFilter = Convert.ToString(Request["sSearch_2"]);
            var EmailFilter = Convert.ToString(Request["sSearch_3"]);
            var MobileFilter = Convert.ToString(Request["sSearch_4"]);
            var IsActiveFilter = Convert.ToString(Request["sSearch_5"]);

            var IsActiveFilter1 = IsActiveFilter.ToLower() == "active" ? true.ToString() : false.ToString();

            #endregion Column Search
            var getAllData = repo.GetAllEmployee().Result;
            IEnumerable<Employee> filteredData;

            if (!string.IsNullOrEmpty(param.sSearch))
            {

                var isSearchable1 = Convert.ToBoolean(Request["bSearchable_1"]);
                var isSearchable2 = Convert.ToBoolean(Request["bSearchable_2"]);
                var isSearchable3 = Convert.ToBoolean(Request["bSearchable_3"]);
                var isSearchable4 = Convert.ToBoolean(Request["bSearchable_4"]);
                var isSearchable5 = Convert.ToBoolean(Request["bSearchable_5"]);

                filteredData = getAllData
                   .Where(c => isSearchable1 && c.Code.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.Name.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.Email.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.Mobile.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.PresentAddress.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.Remarks.ToLower().Contains(param.sSearch.ToLower())
                               );
            }
            else
            {
                filteredData = getAllData;
            }
            #region Column Filtering
            if (NameFilter != "" || MobileFilter != "" || EmailFilter != "" || CodeFilter != "" || IsActiveFilter != "")

            {
                filteredData = filteredData
                                .Where(c =>
                                           (CodeFilter == "" || c.Code.ToLower().Contains(CodeFilter.ToLower()))
                                           && (NameFilter == "" || c.Name.ToLower().Contains(NameFilter.ToLower()))
                                           && (IsActiveFilter == "" || c.IsActive.ToString().ToLower().Contains(IsActiveFilter1.ToLower()))
                                           && (MobileFilter == "" || c.Mobile.ToLower().Contains(MobileFilter.ToLower()))
                                           && (EmailFilter == "" || c.Email.ToLower().Contains(EmailFilter.ToLower()))
                                           );
            }

            #endregion Column Filtering
            var isSortable_1 = Convert.ToBoolean(Request["bSortable_1"]);
            var isSortable_2 = Convert.ToBoolean(Request["bSortable_2"]);
            var isSortable_3 = Convert.ToBoolean(Request["bSortable_3"]);
            var isSortable_4 = Convert.ToBoolean(Request["bSortable_4"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Employee, string> orderingFunction = (c => sortColumnIndex == 1 && isSortable_1 ? c.Code :
                                                           sortColumnIndex == 2 && isSortable_2 ? c.Name :
                                                           sortColumnIndex == 3 && isSortable_3 ? c.Email :
                                                           sortColumnIndex == 4 && isSortable_4 ? c.Mobile :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredData = filteredData.OrderBy(orderingFunction);
            else
                filteredData = filteredData.OrderByDescending(orderingFunction);

            var displayedCompanies = filteredData.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCompanies
                         select new[] {
                             Convert.ToString(c.Id)
                             , c.Code
                             , c.Name
                             , c.Email
                             , c.Mobile
                              , Convert.ToString(c.IsActive == true ? "Active" : "Inactive")
                         };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = getAllData.Count(),
                iTotalDisplayRecords = filteredData.Count(),
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Employee vm = new Employee();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.InsertEmployee(data);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            dynamic data;
            try
            {
                data = repo.GetEmployeeById(Id).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Employee data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.UpdateEmployee(data);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Delete(string ids)
        {
            string result = string.Empty;
            string[] IdList = ids.Split('~');
            Employee vm = new Employee();
            try
            {
                result = await repo.IsDeleteEmployee(IdList, vm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> DropDownEmployee()
        {
            dynamic result;
            try
            {
                result = await repo.DropDownEmployee();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new SelectList((result), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }

    }
}
