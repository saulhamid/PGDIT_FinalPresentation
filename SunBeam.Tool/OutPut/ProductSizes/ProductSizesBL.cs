using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductSizesBL : IProductSizesBL
{

protected ILogger logger { get; set; }

public ProductSizesBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ProductSizes
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProductSizes(ProductSizes entity)
{
try
{
var result = await new ProductSizesRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ProductSizes
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProductSizes(ProductSizes entity)
{
try
{
var result = await new ProductSizesRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ProductSizes
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProductSizes(string[] IdList, ProductSizes entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductSizesRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete ProductSizes
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProductSizes(int Id)
{
string result = string.Empty;
try
{
result = await new ProductSizesRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ProductSizes
/// </summary>
/// <returns>List ofProductSizes</returns>
public async Task<IEnumerable<ProductSizes>> GetAllProductSizes()
{
try
{
var result = await new ProductSizesRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ProductSizes by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductSizes Object</returns>
public async Task<ProductSizes> GetProductSizesById(int Id)
{
try
{
var result = await new ProductSizesRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ProductSizes
/// </summary>
/// <returns>List ofProductSizes</returns>
public async Task<IEnumerable<ProductSizes>> DropDownProductSizes()
{
try
{
var result = await new ProductSizesRepository(logger).Dropdown();
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
