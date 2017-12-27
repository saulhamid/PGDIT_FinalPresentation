using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class SalesDetailsBL : ISalesDetailsBL
{

protected ILogger logger { get; set; }

public SalesDetailsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert SalesDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertSalesDetails(SalesDetails entity)
{
try
{
var result = await new SalesDetailsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update SalesDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateSalesDetails(SalesDetails entity)
{
try
{
var result = await new SalesDetailsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete SalesDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteSalesDetails(string[] IdList, SalesDetails entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new SalesDetailsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete SalesDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteSalesDetails(int Id)
{
string result = string.Empty;
try
{
result = await new SalesDetailsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All SalesDetails
/// </summary>
/// <returns>List ofSalesDetails</returns>
public async Task<IEnumerable<SalesDetails>> GetAllSalesDetails()
{
try
{
var result = await new SalesDetailsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get SalesDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>SalesDetails Object</returns>
public async Task<SalesDetails> GetSalesDetailsById(int Id)
{
try
{
var result = await new SalesDetailsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name SalesDetails
/// </summary>
/// <returns>List ofSalesDetails</returns>
public async Task<IEnumerable<SalesDetails>> DropDownSalesDetails()
{
try
{
var result = await new SalesDetailsRepository(logger).Dropdown();
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
