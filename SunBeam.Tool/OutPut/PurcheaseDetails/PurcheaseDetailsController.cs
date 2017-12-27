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
public class PurcheaseDetailController:Controller
{
private readonly IPurcheaseDetailsBL repo;
public PurcheaseDetailController(IPurcheaseDetailsBL _repo)
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
  public async Task<ActionResult> Create(PurcheaseDetails data)
{ 
 string result = string.Empty; 
try 
 {
result = await repo.InsertPurcheaseDetails(data); 
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
 data =  repo.GetPurcheaseDetailsById(Id).Result;
 }
catch (Exception ex) 
{ 
 throw;
 }
 return PartialView(data);
}
 [HttpPost] 
  public async Task<ActionResult> Edit(PurcheaseDetails data)
{ 
 string result = string.Empty; 
try 
 {
result = await repo.UpdatePurcheaseDetails(data); 
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
PurcheaseDetails vm = new PurcheaseDetails(); 
try 
{ 
 result = await repo.IsDeletePurcheaseDetails(IdList,vm); 
 }
catch (Exception ex) 
{ 
 throw;
 }
  return Json(result, JsonRequestBehavior.AllowGet);
} 
 public async Task<JsonResult> DropDownPurcheaseDetails() 
 {
   dynamic result;
 try
 {
  result = await repo.DropDownPurcheaseDetails();
 }
catch (Exception ex) 
 {
  throw ex;
} 
return Json(new SelectList((result), "Id","Name"), JsonRequestBehavior.AllowGet); 
 }
 
}
}
