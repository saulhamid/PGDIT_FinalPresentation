using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class SalesBL : ISalesBL
{

protected ILogger logger { get; set; }

public SalesBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Sales
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertSales(Sales entity)
{
try
{
var result = await new SalesRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Sales
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateSales(Sales entity)
{
try
{
var result = await new SalesRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Sales
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteSales(string[] IdList, Sales entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new SalesRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Sales
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteSales(int Id)
{
string result = string.Empty;
try
{
result = await new SalesRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Sales
/// </summary>
/// <returns>List ofSales</returns>
public async Task<IEnumerable<Sales>> GetAllSales()
{
try
{
var result = await new SalesRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Sales by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Sales Object</returns>
public async Task<Sales> GetSalesById(int Id)
{
try
{
var result = await new SalesRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Sales
/// </summary>
/// <returns>List ofSales</returns>
public async Task<IEnumerable<Sales>> DropDownSales()
{
try
{
var result = await new SalesRepository(logger).Dropdown();
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
