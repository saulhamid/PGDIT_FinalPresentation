using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class MarketsBL : IMarketsBL
{

protected ILogger logger { get; set; }

public MarketsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Markets
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertMarkets(Markets entity)
{
try
{
var result = await new MarketsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Markets
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateMarkets(Markets entity)
{
try
{
var result = await new MarketsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Markets
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteMarkets(string[] IdList, Markets entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new MarketsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Markets
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteMarkets(int Id)
{
string result = string.Empty;
try
{
result = await new MarketsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Markets
/// </summary>
/// <returns>List ofMarkets</returns>
public async Task<IEnumerable<Markets>> GetAllMarkets()
{
try
{
var result = await new MarketsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Markets by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Markets Object</returns>
public async Task<Markets> GetMarketsById(int Id)
{
try
{
var result = await new MarketsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Markets
/// </summary>
/// <returns>List ofMarkets</returns>
public async Task<IEnumerable<Markets>> DropDownMarkets()
{
try
{
var result = await new MarketsRepository(logger).Dropdown();
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
