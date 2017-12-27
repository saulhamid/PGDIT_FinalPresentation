using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class PurcheaseReturnsBL : IPurcheaseReturnsBL
{

protected ILogger logger { get; set; }

public PurcheaseReturnsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert PurcheaseReturns
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertPurcheaseReturns(PurcheaseReturns entity)
{
try
{
var result = await new PurcheaseReturnsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update PurcheaseReturns
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdatePurcheaseReturns(PurcheaseReturns entity)
{
try
{
var result = await new PurcheaseReturnsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete PurcheaseReturns
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeletePurcheaseReturns(string[] IdList, PurcheaseReturns entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new PurcheaseReturnsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete PurcheaseReturns
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeletePurcheaseReturns(int Id)
{
string result = string.Empty;
try
{
result = await new PurcheaseReturnsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All PurcheaseReturns
/// </summary>
/// <returns>List ofPurcheaseReturns</returns>
public async Task<IEnumerable<PurcheaseReturns>> GetAllPurcheaseReturns()
{
try
{
var result = await new PurcheaseReturnsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get PurcheaseReturns by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>PurcheaseReturns Object</returns>
public async Task<PurcheaseReturns> GetPurcheaseReturnsById(int Id)
{
try
{
var result = await new PurcheaseReturnsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name PurcheaseReturns
/// </summary>
/// <returns>List ofPurcheaseReturns</returns>
public async Task<IEnumerable<PurcheaseReturns>> DropDownPurcheaseReturns()
{
try
{
var result = await new PurcheaseReturnsRepository(logger).Dropdown();
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
