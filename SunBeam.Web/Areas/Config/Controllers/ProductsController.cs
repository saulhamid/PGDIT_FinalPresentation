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
    public class ProductController : Controller
    {
        private readonly IProductsBL repo;
        public ProductController(IProductsBL _repo)
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
            var getAllData = repo.GetAllProductsDetail().Result;
            IEnumerable<Products> filteredData = getAllData;

            //#region Column Filtering
            //if (NameFilter != "" || MobileFilter != "" || EmailFilter != "" || CodeFilter != "" || IsActiveFilter != "")

            //{
            //    filteredData = filteredData
            //                    .Where(c =>
            //                               (CodeFilter == "" || c.Code.ToLower().Contains(CodeFilter.ToLower()))
            //                               && (NameFilter == "" || c.Name.ToLower().Contains(NameFilter.ToLower()))
            //                               && (IsActiveFilter == "" || c.IsActive.ToString().ToLower().Contains(IsActiveFilter1.ToLower()))
            //                               && (MobileFilter == "" || c.Mobile.ToLower().Contains(MobileFilter.ToLower()))
            //                               && (EmailFilter == "" || c.Email.ToLower().Contains(EmailFilter.ToLower()))
            //                               );
            //}

            // #endregion Column Filtering
            var isSortable_1 = Convert.ToBoolean(Request["bSortable_1"]);
            var isSortable_2 = Convert.ToBoolean(Request["bSortable_2"]);
            var isSortable_3 = Convert.ToBoolean(Request["bSortable_3"]);
            var isSortable_4 = Convert.ToBoolean(Request["bSortable_4"]);
            var isSortable_5 = Convert.ToBoolean(Request["bSortable_5"]);
            var isSortable_6 = Convert.ToBoolean(Request["bSortable_6"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Products, string> orderingFunction = (c => sortColumnIndex == 1 && isSortable_1 ? c.Code :
                                                           sortColumnIndex == 2 && isSortable_2 ? c.Name :
                                                           sortColumnIndex == 3 && isSortable_3 ? c.ProductCatagoriesName :
                                                           sortColumnIndex == 4 && isSortable_4 ? c.UOMName :
                                                           sortColumnIndex == 5 && isSortable_4 ? c.ProductSizeName :
                                                           sortColumnIndex == 6 && isSortable_4 ? c.ProductColorName :
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
                             , c.ProductCatagoriesName
                             , c.UOMName
                             , c.ProductSizeName
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
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Products data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.InsertProducts(data);
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
            Products data =new Products();
            try
            {
                data = repo.GetProductsById(Id: Id).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Products data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.UpdateProducts(data);
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
            Products vm = new Products();
            try
            {
                result = await repo.IsDeleteProducts(IdList, vm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> DropDownProducts()
        {
            dynamic result;
            try
            {
                result = await repo.DropDownProducts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new SelectList((result), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }

    }
}
