using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class StockDetailsBL : IStockDetailsBL
{

protected ILogger logger { get; set; }

public StockDetailsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert StockDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertStockDetails(StockDetails entity)
{
try
{
var result = await new StockDetailsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update StockDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateStockDetails(StockDetails entity)
{
try
{
var result = await new StockDetailsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete StockDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteStockDetails(string[] IdList, StockDetails entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new StockDetailsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete StockDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteStockDetails(int Id)
{
string result = string.Empty;
try
{
result = await new StockDetailsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All StockDetails
/// </summary>
/// <returns>List ofStockDetails</returns>
public async Task<IEnumerable<StockDetails>> GetAllStockDetails()
{
try
{
var result = await new StockDetailsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get StockDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>StockDetails Object</returns>
public async Task<StockDetails> GetStockDetailsById(int Id)
{
try
{
var result = await new StockDetailsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name StockDetails
/// </summary>
/// <returns>List ofStockDetails</returns>
public async Task<IEnumerable<StockDetails>> DropDownStockDetails()
{
try
{
var result = await new StockDetailsRepository(logger).Dropdown();
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
