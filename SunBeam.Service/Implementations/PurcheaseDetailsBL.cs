using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class PurcheaseDetailsBL : IPurcheaseDetailsBL
{

protected ILogger logger { get; set; }

public PurcheaseDetailsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert PurcheaseDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertPurcheaseDetails(PurcheaseDetails entity)
{
try
{
var result = await new PurcheaseDetailsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update PurcheaseDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdatePurcheaseDetails(PurcheaseDetails entity)
{
try
{
var result = await new PurcheaseDetailsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete PurcheaseDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeletePurcheaseDetails(string[] IdList, PurcheaseDetails entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new PurcheaseDetailsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete PurcheaseDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeletePurcheaseDetails(int Id)
{
string result = string.Empty;
try
{
result = await new PurcheaseDetailsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All PurcheaseDetails
/// </summary>
/// <returns>List ofPurcheaseDetails</returns>
public async Task<IEnumerable<PurcheaseDetails>> GetAllPurcheaseDetails()
{
try
{
var result = await new PurcheaseDetailsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get PurcheaseDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>PurcheaseDetails Object</returns>
public async Task<PurcheaseDetails> GetPurcheaseDetailsById(int Id)
{
try
{
var result = await new PurcheaseDetailsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name PurcheaseDetails
/// </summary>
/// <returns>List ofPurcheaseDetails</returns>
public async Task<IEnumerable<PurcheaseDetails>> DropDownPurcheaseDetails()
{
try
{
var result = await new PurcheaseDetailsRepository(logger).Dropdown();
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
