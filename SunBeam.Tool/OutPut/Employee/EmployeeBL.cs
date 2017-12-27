using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class EmployeeBL : IEmployeeBL
{

protected ILogger logger { get; set; }

public EmployeeBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Employee
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertEmployee(Employee entity)
{
try
{
var result = await new EmployeeRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Employee
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateEmployee(Employee entity)
{
try
{
var result = await new EmployeeRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Employee
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteEmployee(string[] IdList, Employee entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new EmployeeRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Employee
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteEmployee(int Id)
{
string result = string.Empty;
try
{
result = await new EmployeeRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Employee
/// </summary>
/// <returns>List ofEmployee</returns>
public async Task<IEnumerable<Employee>> GetAllEmployee()
{
try
{
var result = await new EmployeeRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Employee by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Employee Object</returns>
public async Task<Employee> GetEmployeeById(int Id)
{
try
{
var result = await new EmployeeRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Employee
/// </summary>
/// <returns>List ofEmployee</returns>
public async Task<IEnumerable<Employee>> DropDownEmployee()
{
try
{
var result = await new EmployeeRepository(logger).Dropdown();
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
