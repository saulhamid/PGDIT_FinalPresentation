using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class StocksBL : IStocksBL
{

protected ILogger logger { get; set; }

public StocksBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Stocks
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertStocks(Stocks entity)
{
try
{
var result = await new StocksRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Stocks
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateStocks(Stocks entity)
{
try
{
var result = await new StocksRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Stocks
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteStocks(string[] IdList, Stocks entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new StocksRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Stocks
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteStocks(int Id)
{
string result = string.Empty;
try
{
result = await new StocksRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Stocks
/// </summary>
/// <returns>List ofStocks</returns>
public async Task<IEnumerable<Stocks>> GetAllStocks()
{
try
{
var result = await new StocksRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Stocks by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Stocks Object</returns>
public async Task<Stocks> GetStocksById(int Id)
{
try
{
var result = await new StocksRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Stocks
/// </summary>
/// <returns>List ofStocks</returns>
public async Task<IEnumerable<Stocks>> DropDownStocks()
{
try
{
var result = await new StocksRepository(logger).Dropdown();
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
