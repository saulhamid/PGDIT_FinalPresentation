using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class PurcheaseReturnDetailsBL : IPurcheaseReturnDetailsBL
{

protected ILogger logger { get; set; }

public PurcheaseReturnDetailsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert PurcheaseReturnDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertPurcheaseReturnDetails(PurcheaseReturnDetails entity)
{
try
{
var result = await new PurcheaseReturnDetailsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update PurcheaseReturnDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdatePurcheaseReturnDetails(PurcheaseReturnDetails entity)
{
try
{
var result = await new PurcheaseReturnDetailsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete PurcheaseReturnDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeletePurcheaseReturnDetails(string[] IdList, PurcheaseReturnDetails entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new PurcheaseReturnDetailsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete PurcheaseReturnDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeletePurcheaseReturnDetails(int Id)
{
string result = string.Empty;
try
{
result = await new PurcheaseReturnDetailsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All PurcheaseReturnDetails
/// </summary>
/// <returns>List ofPurcheaseReturnDetails</returns>
public async Task<IEnumerable<PurcheaseReturnDetails>> GetAllPurcheaseReturnDetails()
{
try
{
var result = await new PurcheaseReturnDetailsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get PurcheaseReturnDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>PurcheaseReturnDetails Object</returns>
public async Task<PurcheaseReturnDetails> GetPurcheaseReturnDetailsById(int Id)
{
try
{
var result = await new PurcheaseReturnDetailsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name PurcheaseReturnDetails
/// </summary>
/// <returns>List ofPurcheaseReturnDetails</returns>
public async Task<IEnumerable<PurcheaseReturnDetails>> DropDownPurcheaseReturnDetails()
{
try
{
var result = await new PurcheaseReturnDetailsRepository(logger).Dropdown();
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
