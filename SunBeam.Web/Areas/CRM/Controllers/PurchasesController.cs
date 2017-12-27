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
    public class PurchaseController : Controller
    {
        private readonly IPurchasesBL repo;
        private readonly IProductsBL prorepo;
        private readonly IPurcheaseDetailsBL prodrepo;
        public PurchaseController(IPurchasesBL _repo, IProductsBL _prorepo, IPurcheaseDetailsBL _prodrepo)
        {
            this.repo = _repo;
            this.prorepo = _prorepo;
            this.prodrepo = _prodrepo;
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
            var getAllData = repo.GetAllPurchases().Result;
            IEnumerable<Purchases> filteredData;

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
                               || isSearchable2 && c.SupplierName.ToLower().Contains(param.sSearch.ToLower())
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
                                           && (MobileFilter == "" || c.SupplierName.ToLower().Contains(MobileFilter.ToLower()))
                                          // && (DateFilter == "" || c.EmployeeName.ToLower().Contains(EmailFilter.ToLower()))
                                           );
            }

            #endregion Column Filtering
            var isSortable_1 = Convert.ToBoolean(Request["bSortable_1"]);
            var isSortable_2 = Convert.ToBoolean(Request["bSortable_2"]);
            var isSortable_3 = Convert.ToBoolean(Request["bSortable_3"]);
            var isSortable_4 = Convert.ToBoolean(Request["bSortable_4"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Purchases, string> orderingFunction = (c => sortColumnIndex == 1 && isSortable_1 ? c.InvoiecNo :
                                                           sortColumnIndex == 2 && isSortable_2 ? c.Date :
                                                           sortColumnIndex == 3 && isSortable_3 ? c.SupplierName :
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
                             , c.SupplierName
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
            Purchases vm = new Purchases();
           List<PurcheaseDetails> PurcheaseDetails = new List<PurcheaseDetails>();
            vm.PurcheaseDetails = PurcheaseDetails;
            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Purchases data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.InsertPurchases(data);
            }
            catch (Exception ex)
            {
                result = "Fail~" + ex.Message.ToString();
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult PurcheaseDetail(int proid,string unitprice,string quantity)
        {
            Products data;
            PurcheaseDetails PurcheaseDetail=new PurcheaseDetails();
            try
            {
                data =  prorepo.DropDownProducts().Result.FirstOrDefault(c => c.Id.Equals(proid));
                PurcheaseDetail.Quantity = Convert.ToDecimal(quantity);
                PurcheaseDetail.UnitePrice = Convert.ToDecimal(unitprice);
                PurcheaseDetail.ProductId = proid;
                PurcheaseDetail.ProductName = data.Name;
                PurcheaseDetail.ProductCode = data.Code;
                PurcheaseDetail.TotalPrice = PurcheaseDetail.Quantity* PurcheaseDetail.UnitePrice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PartialView(PurcheaseDetail);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            dynamic data;
            try
            {
                data = repo.GetPurchasesById(Id).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Purchases data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.UpdatePurchases(data);
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
            Purchases vm = new Purchases();
            try
            {
                result = await repo.IsDeletePurchases(IdList, vm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> DropDownPurchases()
        {
            dynamic result;
            try
            {
                result = await repo.DropDownPurchases();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new SelectList((result), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DropDownPurchasesBySupplier( int Id)
        {
            dynamic result;
            try
            {
                result = from pro in repo.GetAllPurchases().Result
                             where pro.SupplierId.Equals(Id)
                             select new {Id=pro.Id, Name=pro.InvoiecNo };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new SelectList((result), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DropDownPurchasesByPurcheaseId(int Id)
        {
            dynamic result;
            try
            {
                result = from pro in repo.GetAllPurchases().Result
                         join prod in prodrepo.GetAllPurcheaseDetails().Result on pro.Id equals prod.PurchaseId
                         join product in prorepo.DropDownProducts().Result on prod.ProductId equals product.Id
                         where pro.Id.Equals(Id)
                         select new { Id = prod.ProductId, Name = product.Name };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new SelectList((result), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }
    }
}
