using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductColorBL : IProductColorBL
{

protected ILogger logger { get; set; }

public ProductColorBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ProductColor
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProductColor(ProductColor entity)
{
try
{
var result = await new ProductColorRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ProductColor
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProductColor(ProductColor entity)
{
try
{
var result = await new ProductColorRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ProductColor
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProductColor(string[] IdList, ProductColor entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductColorRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete ProductColor
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProductColor(int Id)
{
string result = string.Empty;
try
{
result = await new ProductColorRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ProductColor
/// </summary>
/// <returns>List ofProductColor</returns>
public async Task<IEnumerable<ProductColor>> GetAllProductColor()
{
try
{
var result = await new ProductColorRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ProductColor by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductColor Object</returns>
public async Task<ProductColor> GetProductColorById(int Id)
{
try
{
var result = await new ProductColorRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ProductColor
/// </summary>
/// <returns>List ofProductColor</returns>
public async Task<IEnumerable<ProductColor>> DropDownProductColor()
{
try
{
var result = await new ProductColorRepository(logger).Dropdown();
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
