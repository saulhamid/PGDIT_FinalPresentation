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
public class StockDetailController:Controller
{
private readonly IStockDetailsBL repo;
public StockDetailController(IStockDetailsBL _repo)
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
  public async Task<ActionResult> Create(StockDetails data)
{ 
 string result = string.Empty; 
try 
 {
result = await repo.InsertStockDetails(data); 
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
 data =  repo.GetStockDetailsById(Id).Result;
 }
catch (Exception ex) 
{ 
 throw;
 }
 return PartialView(data);
}
 [HttpPost] 
  public async Task<ActionResult> Edit(StockDetails data)
{ 
 string result = string.Empty; 
try 
 {
result = await repo.UpdateStockDetails(data); 
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
StockDetails vm = new StockDetails(); 
try 
{ 
 result = await repo.IsDeleteStockDetails(IdList,vm); 
 }
catch (Exception ex) 
{ 
 throw;
 }
  return Json(result, JsonRequestBehavior.AllowGet);
} 
 public async Task<JsonResult> DropDownStockDetails() 
 {
   dynamic result;
 try
 {
  result = await repo.DropDownStockDetails();
 }
catch (Exception ex) 
 {
  throw ex;
} 
return Json(new SelectList((result), "Id","Name"), JsonRequestBehavior.AllowGet); 
 }
 
}
}
