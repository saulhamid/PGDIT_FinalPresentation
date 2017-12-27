using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ProductsBL : IProductsBL
{

protected ILogger logger { get; set; }

public ProductsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Products
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertProducts(Products entity)
{
try
{
var result = await new ProductsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Products
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateProducts(Products entity)
{
try
{
var result = await new ProductsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Products
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteProducts(string[] IdList, Products entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ProductsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Products
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteProducts(int Id)
{
string result = string.Empty;
try
{
result = await new ProductsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Products
/// </summary>
/// <returns>List ofProducts</returns>
public async Task<IEnumerable<Products>> GetAllProducts()
{
try
{
var result = await new ProductsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Products by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Products Object</returns>
public async Task<Products> GetProductsById(int Id)
{
try
{
var result = await new ProductsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Products
/// </summary>
/// <returns>List ofProducts</returns>
public async Task<IEnumerable<Products>> DropDownProducts()
{
try
{
var result = await new ProductsRepository(logger).Dropdown();
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
