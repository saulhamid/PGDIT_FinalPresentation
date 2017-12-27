using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class SuppliersBL : ISuppliersBL
{

protected ILogger logger { get; set; }

public SuppliersBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Suppliers
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertSuppliers(Suppliers entity)
{
try
{
var result = await new SuppliersRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Suppliers
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateSuppliers(Suppliers entity)
{
try
{
var result = await new SuppliersRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Suppliers
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteSuppliers(string[] IdList, Suppliers entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new SuppliersRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Suppliers
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteSuppliers(int Id)
{
string result = string.Empty;
try
{
result = await new SuppliersRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Suppliers
/// </summary>
/// <returns>List ofSuppliers</returns>
public async Task<IEnumerable<Suppliers>> GetAllSuppliers()
{
try
{
var result = await new SuppliersRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Suppliers by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Suppliers Object</returns>
public async Task<Suppliers> GetSuppliersById(int Id)
{
try
{
var result = await new SuppliersRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Suppliers
/// </summary>
/// <returns>List ofSuppliers</returns>
public async Task<IEnumerable<Suppliers>> DropDownSuppliers()
{
try
{
var result = await new SuppliersRepository(logger).Dropdown();
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
