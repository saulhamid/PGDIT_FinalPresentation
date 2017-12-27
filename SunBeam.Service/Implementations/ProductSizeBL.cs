using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductSizeBL : IProductSizeBL
{

protected ILogger logger { get; set; }

public ProductSizeBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ProductSize
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProductSize(ProductSize entity)
{
try
{
var result = await new ProductSizeRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ProductSize
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProductSize(ProductSize entity)
{
try
{
var result = await new ProductSizeRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ProductSize
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProductSize(string[] IdList, ProductSize entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductSizeRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete ProductSize
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProductSize(int Id)
{
string result = string.Empty;
try
{
result = await new ProductSizeRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ProductSize
/// </summary>
/// <returns>List ofProductSize</returns>
public async Task<IEnumerable<ProductSize>> GetAllProductSize()
{
try
{
var result = await new ProductSizeRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ProductSize by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductSize Object</returns>
public async Task<ProductSize> GetProductSizeById(int Id)
{
try
{
var result = await new ProductSizeRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ProductSize
/// </summary>
/// <returns>List ofProductSize</returns>
public async Task<IEnumerable<ProductSize>> DropDownProductSize()
{
try
{
var result = await new ProductSizeRepository(logger).Dropdown();
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
