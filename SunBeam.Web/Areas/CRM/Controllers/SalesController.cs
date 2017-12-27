#region Library
using SunBeam.Domain.Models;
using SunBeam.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
#endregion library

namespace SunBeam.Web.Areas.CRM.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISalesBL repo;
        private readonly IProductsBL prorepo;
        public SaleController(ISalesBL _repo, IProductsBL _prorepo)
        {
            this.repo = _repo;
            this.prorepo = _prorepo;
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
            var DateFilter = Convert.ToString(Request["sSearch_3"]);
            var MobileFilter = Convert.ToString(Request["sSearch_4"]);
            var IsActiveFilter = Convert.ToString(Request["sSearch_5"]);

            //var IsActiveFilter1 = IsActiveFilter.ToLower() == "active" ? true.ToString() : false.ToString();

            #endregion Column Search
            var getAllData = repo.GetAllSales().Result;
            IEnumerable<Sales> filteredData;

            if (!string.IsNullOrEmpty(param.sSearch))
            {

                var isSearchable1 = Convert.ToBoolean(Request["bSearchable_1"]);
                var isSearchable2 = Convert.ToBoolean(Request["bSearchable_2"]);
                var isSearchable3 = Convert.ToBoolean(Request["bSearchable_3"]);
                var isSearchable4 = Convert.ToBoolean(Request["bSearchable_4"]);
                var isSearchable5 = Convert.ToBoolean(Request["bSearchable_5"]);

                filteredData = getAllData
                   .Where(c => isSearchable1 && c.InvoiecNo.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.Date.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.CustomerName.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.EmployeeName.ToLower().Contains(param.sSearch.ToLower())
                               );
            }
            else
            {
                filteredData = getAllData;
            }
            #region Column Filtering
            if (NameFilter != "" || MobileFilter != "" || DateFilter != "" || CodeFilter != "" || IsActiveFilter != "")

            {
                filteredData = filteredData
                                .Where(c =>
                                           (CodeFilter == "" || c.InvoiecNo.ToLower().Contains(CodeFilter.ToLower()))
                                           //  && (DateFilter == "" || c.Date.ToString().ToLower().Contains(IsActiveFilter1.ToLower()))
                                           && (MobileFilter == "" || c.CustomerName.ToLower().Contains(MobileFilter.ToLower()))
                                           // && (DateFilter == "" || c.EmployeeName.ToLower().Contains(EmailFilter.ToLower()))
                                           );
            }

            #endregion Column Filtering
            var isSortable_1 = Convert.ToBoolean(Request["bSortable_1"]);
            var isSortable_2 = Convert.ToBoolean(Request["bSortable_2"]);
            var isSortable_3 = Convert.ToBoolean(Request["bSortable_3"]);
            var isSortable_4 = Convert.ToBoolean(Request["bSortable_4"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Sales, string> orderingFunction = (c => sortColumnIndex == 1 && isSortable_1 ? c.InvoiecNo :
                                                           sortColumnIndex == 2 && isSortable_2 ? c.Date :
                                                           sortColumnIndex == 3 && isSortable_3 ? c.CustomerName :
                                                           sortColumnIndex == 4 && isSortable_4 ? c.EmployeeName :
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
                             , c.InvoiecNo
                             , c.Date.ToString()
                             , c.CustomerName
                             , c.EmployeeName
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
            Sales vm = new Sales();
           List<SalesDetails> SalesDetails = new List<SalesDetails>();
            vm.SalesDetails = SalesDetails;
            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Sales data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.InsertSales(data);
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
                data = repo.GetSalesById(Id).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Sales data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.UpdateSales(data);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SalesDetail(int proid, string unitprice, string quantity, string slup)
        {
            Products data;
            SalesDetails SalesDetails = new SalesDetails();
            try
            {
                data = prorepo.DropDownProducts().Result.FirstOrDefault(c => c.Id.Equals(proid));
                SalesDetails.SalesQuantity = Convert.ToDecimal(quantity);
                SalesDetails.UnitePrice = Convert.ToDecimal(unitprice);
                SalesDetails.Slup = Convert.ToDecimal(slup);
                SalesDetails.ProductId = proid;
                SalesDetails.ProductName = data.Name;
                SalesDetails.ProductCode = data.Code;
                SalesDetails.TotalAmount = SalesDetails.SalesQuantity * SalesDetails.UnitePrice- SalesDetails.Slup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PartialView(SalesDetails);
        }
        public async Task<JsonResult> Delete(string ids)
        {
            string result = string.Empty;
            string[] IdList = ids.Split('~');
            Sales vm = new Sales();
            try
            {
                result = await repo.IsDeleteSales(IdList, vm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> DropDownSales()
        {
            dynamic result;
            try
            {
                result = await repo.DropDownSales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new SelectList((result), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }

    }
}
