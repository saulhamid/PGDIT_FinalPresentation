using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductDetailsBL : IProductDetailsBL
{

protected ILogger logger { get; set; }

public ProductDetailsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ProductDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProductDetails(ProductDetails entity)
{
try
{
var result = await new ProductDetailsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ProductDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProductDetails(ProductDetails entity)
{
try
{
var result = await new ProductDetailsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ProductDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProductDetails(string[] IdList, ProductDetails entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductDetailsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete ProductDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProductDetails(int Id)
{
string result = string.Empty;
try
{
result = await new ProductDetailsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ProductDetails
/// </summary>
/// <returns>List ofProductDetails</returns>
public async Task<IEnumerable<ProductDetails>> GetAllProductDetails()
{
try
{
var result = await new ProductDetailsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ProductDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductDetails Object</returns>
public async Task<ProductDetails> GetProductDetailsById(int Id)
{
try
{
var result = await new ProductDetailsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ProductDetails
/// </summary>
/// <returns>List ofProductDetails</returns>
public async Task<IEnumerable<ProductDetails>> DropDownProductDetails()
{
try
{
var result = await new ProductDetailsRepository(logger).Dropdown();
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
