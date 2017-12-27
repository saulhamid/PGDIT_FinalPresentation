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
    public class StockController : Controller
    {
        private readonly IStocksBL repo;
        public StockController(IStocksBL _repo)
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
            var DateFilter = Convert.ToString(Request["sSearch_3"]);
            var MobileFilter = Convert.ToString(Request["sSearch_4"]);
            var IsActiveFilter = Convert.ToString(Request["sSearch_5"]);

            //var IsActiveFilter1 = IsActiveFilter.ToLower() == "active" ? true.ToString() : false.ToString();

            #endregion Column Search
            var getAllData = repo.GetAllStocks().Result;
            IEnumerable<Stocks> filteredData;

            if (!string.IsNullOrEmpty(param.sSearch))
            {

                var isSearchable1 = Convert.ToBoolean(Request["bSearchable_1"]);
                var isSearchable2 = Convert.ToBoolean(Request["bSearchable_2"]);
                var isSearchable3 = Convert.ToBoolean(Request["bSearchable_3"]);
                var isSearchable4 = Convert.ToBoolean(Request["bSearchable_4"]);
                var isSearchable5 = Convert.ToBoolean(Request["bSearchable_5"]);

                filteredData = getAllData
                   .Where(c => isSearchable1 && c.ProductName.ToLower().Contains(param.sSearch.ToLower())
                               || isSearchable2 && c.Date.ToLower().Contains(param.sSearch.ToLower())
                              
                               );
            }
            else
            {
                filteredData = getAllData;
            }
            #region Column Filtering
            //if (NameFilter != "" || MobileFilter != "" || DateFilter != "" || CodeFilter != "" || IsActiveFilter != "")

            //{
            //    filteredData = filteredData
            //                    .Where(c =>
            //                               (CodeFilter == "" || c.ProductName.ToLower().Contains(CodeFilter.ToLower()))
            //                               //  && (DateFilter == "" || c.Date.ToString().ToLower().Contains(IsActiveFilter1.ToLower()))
            //                               && (MobileFilter == "" || c.TotalPrice.ToString().ToLower().Contains(MobileFilter.ToLower()))
            //                               // && (DateFilter == "" || c.EmployeeName.ToLower().Contains(EmailFilter.ToLower()))
            //                               );
            //}

            #endregion Column Filtering
            var isSortable_1 = Convert.ToBoolean(Request["bSortable_1"]);
            var isSortable_2 = Convert.ToBoolean(Request["bSortable_2"]);
            var isSortable_3 = Convert.ToBoolean(Request["bSortable_3"]);
            var isSortable_4 = Convert.ToBoolean(Request["bSortable_4"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Stocks, string> orderingFunction = (c => sortColumnIndex == 1 && isSortable_1 ? c.ProductName :
                                                           sortColumnIndex == 2 && isSortable_2 ? c.Date :
                                                           sortColumnIndex == 3 && isSortable_3 ? c.FinalUnitPrice.ToString() :
                                                           sortColumnIndex == 4 && isSortable_4 ? c.Quantity.ToString() :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredData = filteredData.OrderBy(orderingFunction);
            else
                filteredData = filteredData.OrderByDescending(orderingFunction);

            var displayedCompanies = filteredData.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCompanies
                         select new[] {
                           
                              c.ProductName
                             , c.Date.ToString()
                             , c.FinalUnitPrice.ToString()
                             , c.Quantity.ToString()
                             , (c.FinalUnitPrice*c.Quantity).ToString()
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
            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Stocks data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.InsertStocks(data);
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
                data = repo.GetStocksById(Id).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return PartialView(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Stocks data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.UpdateStocks(data);
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
            Stocks vm = new Stocks();
            try
            {
                result = await repo.IsDeleteStocks(IdList, vm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> DropDownStocks()
        {
            dynamic result;
            try
            {
                result = await repo.DropDownStocks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new SelectList((result), "ProductId", "ProductName"), JsonRequestBehavior.AllowGet);
        }

    }
}
