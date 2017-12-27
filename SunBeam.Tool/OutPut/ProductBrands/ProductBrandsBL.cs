using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductBrandsBL : IProductBrandsBL
{

protected ILogger logger { get; set; }

public ProductBrandsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ProductBrands
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProductBrands(ProductBrands entity)
{
try
{
var result = await new ProductBrandsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ProductBrands
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProductBrands(ProductBrands entity)
{
try
{
var result = await new ProductBrandsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ProductBrands
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProductBrands(string[] IdList, ProductBrands entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductBrandsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete ProductBrands
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProductBrands(int Id)
{
string result = string.Empty;
try
{
result = await new ProductBrandsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ProductBrands
/// </summary>
/// <returns>List ofProductBrands</returns>
public async Task<IEnumerable<ProductBrands>> GetAllProductBrands()
{
try
{
var result = await new ProductBrandsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ProductBrands by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductBrands Object</returns>
public async Task<ProductBrands> GetProductBrandsById(int Id)
{
try
{
var result = await new ProductBrandsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ProductBrands
/// </summary>
/// <returns>List ofProductBrands</returns>
public async Task<IEnumerable<ProductBrands>> DropDownProductBrands()
{
try
{
var result = await new ProductBrandsRepository(logger).Dropdown();
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
