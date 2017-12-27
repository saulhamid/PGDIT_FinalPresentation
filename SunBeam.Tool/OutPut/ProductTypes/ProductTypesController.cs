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
public class ProductTypeController:Controller
{
private readonly IProductTypesBL repo;
public ProductTypeController(IProductTypesBL _repo)
{
this.repo = _repo;
}
 
 public ActionResult Index()
 {
 return View();
 }
 
[HttpGet] 
public ActionResult Create()
{
return PartialView();
}
[HttpPost] 
  public async Task<ActionResult> Create(ProductTypes data)
{ 
 string result = string.Empty; 
try 
 {
result = await repo.InsertProductTypes(data); 
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
 data =  repo.GetProductTypesById(Id).Result;
 }
catch (Exception ex) 
{ 
 throw;
 }
 return PartialView(data);
}
 [HttpPost] 
  public async Task<ActionResult> Edit(ProductTypes data)
{ 
 string result = string.Empty; 
try 
 {
result = await repo.UpdateProductTypes(data); 
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
ProductTypes vm = new ProductTypes(); 
try 
{ 
 result = await repo.IsDeleteProductTypes(IdList,vm); 
 }
catch (Exception ex) 
{ 
 throw;
 }
  return Json(result, JsonRequestBehavior.AllowGet);
} 
 public async Task<JsonResult> DropDownProductTypes() 
 {
   dynamic result;
 try
 {
  result = await repo.DropDownProductTypes();
 }
catch (Exception ex) 
 {
  throw ex;
} 
return Json(new SelectList((result), "Id","Name"), JsonRequestBehavior.AllowGet); 
 }
 
}
}
