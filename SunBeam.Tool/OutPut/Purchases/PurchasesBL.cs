using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class PurchasesBL : IPurchasesBL
{

protected ILogger logger { get; set; }

public PurchasesBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Purchases
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertPurchases(Purchases entity)
{
try
{
var result = await new PurchasesRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Purchases
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdatePurchases(Purchases entity)
{
try
{
var result = await new PurchasesRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Purchases
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeletePurchases(string[] IdList, Purchases entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new PurchasesRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
}
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Delete Purchases
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeletePurchases(int Id)
{
string result = string.Empty;
try
{
result = await new PurchasesRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Purchases
/// </summary>
/// <returns>List ofPurchases</returns>
public async Task<IEnumerable<Purchases>> GetAllPurchases()
{
try
{
var result = await new PurchasesRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Purchases by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Purchases Object</returns>
public async Task<Purchases> GetPurchasesById(int Id)
{
try
{
var result = await new PurchasesRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Purchases
/// </summary>
/// <returns>List ofPurchases</returns>
public async Task<IEnumerable<Purchases>> DropDownPurchases()
{
try
{
var result = await new PurchasesRepository(logger).Dropdown();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}
}


}
