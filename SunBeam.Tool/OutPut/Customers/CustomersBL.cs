using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class CustomersBL : ICustomersBL
{

protected ILogger logger { get; set; }

public CustomersBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Customers
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertCustomers(Customers entity)
{
try
{
var result = await new CustomersRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Customers
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateCustomers(Customers entity)
{
try
{
var result = await new CustomersRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Customers
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteCustomers(string[] IdList, Customers entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new CustomersRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Customers
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteCustomers(int Id)
{
string result = string.Empty;
try
{
result = await new CustomersRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Customers
/// </summary>
/// <returns>List ofCustomers</returns>
public async Task<IEnumerable<Customers>> GetAllCustomers()
{
try
{
var result = await new CustomersRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Customers by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Customers Object</returns>
public async Task<Customers> GetCustomersById(int Id)
{
try
{
var result = await new CustomersRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Customers
/// </summary>
/// <returns>List ofCustomers</returns>
public async Task<IEnumerable<Customers>> DropDownCustomers()
{
try
{
var result = await new CustomersRepository(logger).Dropdown();
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
