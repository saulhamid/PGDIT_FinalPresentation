using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductTypeBL : IProductTypeBL
{

protected ILogger logger { get; set; }

public ProductTypeBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ProductType
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProductType(ProductType entity)
{
try
{
var result = await new ProductTypeRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ProductType
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProductType(ProductType entity)
{
try
{
var result = await new ProductTypeRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ProductType
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProductType(string[] IdList, ProductType entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductTypeRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete ProductType
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProductType(int Id)
{
string result = string.Empty;
try
{
result = await new ProductTypeRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ProductType
/// </summary>
/// <returns>List ofProductType</returns>
public async Task<IEnumerable<ProductType>> GetAllProductType()
{
try
{
var result = await new ProductTypeRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ProductType by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductType Object</returns>
public async Task<ProductType> GetProductTypeById(int Id)
{
try
{
var result = await new ProductTypeRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ProductType
/// </summary>
/// <returns>List ofProductType</returns>
public async Task<IEnumerable<ProductType>> DropDownProductType()
{
try
{
var result = await new ProductTypeRepository(logger).Dropdown();
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
