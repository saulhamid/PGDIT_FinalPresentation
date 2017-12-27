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
public class ProductCategoryController:Controller
{
private readonly IProductCategorysBL repo;
public ProductCategoryController(IProductCategorysBL _repo)
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
            var NameFilter = Convert.ToString(Request["sSearch_1"]);
            var IsActiveFilter = Convert.ToString(Request["sSearch_2"]);
            var remarksFilter = Convert.ToString(Request["sSearch_3"]);

            var IsActiveFilter1 = IsActiveFilter.ToLower() == "active" ? true.ToString() : false.ToString();

            #endregion Column Search
            var getAllData = repo.GetAllProductCategorys().Result;
            IEnumerable<ProductCategory> filteredData;

            if (!string.IsNullOrEmpty(param.sSearch))
            {

                var isSearchable1 = Convert.ToBoolean(Request["bSearchable_1"]);
                var isSearchable2 = Convert.ToBoolean(Request["bSearchable_2"]);

                filteredData = getAllData
                   .Where(c => isSearchable1 && c.Name.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isSearchable2 && c.Remarks.ToLower().Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredData = getAllData;
            }
            #region Column Filtering
            if (NameFilter != "" || IsActiveFilter != "" || remarksFilter != "")

            {
                filteredData = filteredData
                                .Where(c =>
                                           (NameFilter == "" || c.Name.ToLower().Contains(NameFilter.ToLower()))
                                           &&
                                           (IsActiveFilter == "" || c.IsActive.ToString().ToLower().Contains(IsActiveFilter1.ToLower()))
                                            &&
                                           (remarksFilter == "" || c.Remarks.ToString().ToLower().Contains(remarksFilter.ToLower()))
                                           );
            }

            #endregion Column Filtering
            var isSortable_1 = Convert.ToBoolean(Request["bSortable_1"]);
            var isSortable_2 = Convert.ToBoolean(Request["bSortable_2"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<ProductCategory, string> orderingFunction = (c => sortColumnIndex == 1 && isSortable_1 ? c.Name :
                                                           sortColumnIndex == 2 && isSortable_2 ? c.Remarks :
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
                             , c.Name
                             , Convert.ToString(c.IsActive == true ? "Active" : "Inactive")
                             , c.Remarks
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
  public async Task<ActionResult> Create(ProductCategory data)
{ 
 string result = string.Empty; 
try 
 {
result = await repo.InsertProductCategorys(data); 
 }
catch (Exception ex) 
{ 
 throw;
 }
return Json(result,JsonRequestBehavior.AllowGet); 
} 
[HttpGet] 
public ActionResult Edit(int Id) 
{ 
 dynamic data; 
 try
 {
 data =  repo.GetProductCategorysById(Id).Result;
 }
catch (Exception ex) 
{ 
 throw;
 }
 return PartialView(data);
}
 [HttpPost] 
  public async Task<ActionResult> Edit(ProductCategory data)
{ 
 string result = string.Empty; 
try 
 {
result = await repo.UpdateProductCategorys(data); 
 }
catch (Exception ex) 
{ 
 throw;
 }
return Json(result,JsonRequestBehavior.AllowGet); 
} 
 
 public async Task<JsonResult> Delete(string ids) 
 {
string result = string.Empty; 
string[] IdList = ids.Split('~'); 
ProductCategory vm = new ProductCategory(); 
try 
{ 
 result = await repo.IsDeleteProductCategorys(IdList,vm); 
 }
catch (Exception ex) 
{ 
 throw;
 }
  return Json(result, JsonRequestBehavior.AllowGet);
} 
 public async Task<JsonResult> DropDownProductCategorys() 
 {
   dynamic result;
 try
 {
  result = await repo.DropDownProductCategorys();
 }
catch (Exception ex) 
 {
  throw ex;
} 
return Json(new SelectList((result), "Id","Name"), JsonRequestBehavior.AllowGet); 
 }
 
}
}
