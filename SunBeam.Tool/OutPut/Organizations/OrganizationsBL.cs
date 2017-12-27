using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class OrganizationsBL : IOrganizationsBL
{

protected ILogger logger { get; set; }

public OrganizationsBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Organizations
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertOrganizations(Organizations entity)
{
try
{
var result = await new OrganizationsRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Organizations
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateOrganizations(Organizations entity)
{
try
{
var result = await new OrganizationsRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Organizations
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteOrganizations(string[] IdList, Organizations entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new OrganizationsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Organizations
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteOrganizations(int Id)
{
string result = string.Empty;
try
{
result = await new OrganizationsRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Organizations
/// </summary>
/// <returns>List ofOrganizations</returns>
public async Task<IEnumerable<Organizations>> GetAllOrganizations()
{
try
{
var result = await new OrganizationsRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Organizations by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Organizations Object</returns>
public async Task<Organizations> GetOrganizationsById(int Id)
{
try
{
var result = await new OrganizationsRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Organizations
/// </summary>
/// <returns>List ofOrganizations</returns>
public async Task<IEnumerable<Organizations>> DropDownOrganizations()
{
try
{
var result = await new OrganizationsRepository(logger).Dropdown();
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
