using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductCategorysBL : IProductCategorysBL
{

protected ILogger logger { get; set; }

public ProductCategorysBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ProductCategorys
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProductCategorys(ProductCategorys entity)
{
try
{
var result = await new ProductCategorysRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ProductCategorys
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProductCategorys(ProductCategorys entity)
{
try
{
var result = await new ProductCategorysRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ProductCategorys
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProductCategorys(string[] IdList, ProductCategorys entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductCategorysRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete ProductCategorys
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProductCategorys(int Id)
{
string result = string.Empty;
try
{
result = await new ProductCategorysRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ProductCategorys
/// </summary>
/// <returns>List ofProductCategorys</returns>
public async Task<IEnumerable<ProductCategorys>> GetAllProductCategorys()
{
try
{
var result = await new ProductCategorysRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ProductCategorys by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductCategorys Object</returns>
public async Task<ProductCategorys> GetProductCategorysById(int Id)
{
try
{
var result = await new ProductCategorysRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ProductCategorys
/// </summary>
/// <returns>List ofProductCategorys</returns>
public async Task<IEnumerable<ProductCategorys>> DropDownProductCategorys()
{
try
{
var result = await new ProductCategorysRepository(logger).Dropdown();
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
