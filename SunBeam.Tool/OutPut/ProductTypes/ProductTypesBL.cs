using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductTypesBL : IProductTypesBL
{

protected ILogger logger { get; set; }

public ProductTypesBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ProductTypes
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProductTypes(ProductTypes entity)
{
try
{
var result = await new ProductTypesRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ProductTypes
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProductTypes(ProductTypes entity)
{
try
{
var result = await new ProductTypesRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ProductTypes
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProductTypes(string[] IdList, ProductTypes entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductTypesRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete ProductTypes
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProductTypes(int Id)
{
string result = string.Empty;
try
{
result = await new ProductTypesRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ProductTypes
/// </summary>
/// <returns>List ofProductTypes</returns>
public async Task<IEnumerable<ProductTypes>> GetAllProductTypes()
{
try
{
var result = await new ProductTypesRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ProductTypes by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductTypes Object</returns>
public async Task<ProductTypes> GetProductTypesById(int Id)
{
try
{
var result = await new ProductTypesRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ProductTypes
/// </summary>
/// <returns>List ofProductTypes</returns>
public async Task<IEnumerable<ProductTypes>> DropDownProductTypes()
{
try
{
var result = await new ProductTypesRepository(logger).Dropdown();
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
