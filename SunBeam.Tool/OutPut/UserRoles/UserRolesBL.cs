using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class UserRolesBL : IUserRolesBL
{

protected ILogger logger { get; set; }

public UserRolesBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert UserRoles
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertUserRoles(UserRoles entity)
{
try
{
var result = await new UserRolesRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update UserRoles
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateUserRoles(UserRoles entity)
{
try
{
var result = await new UserRolesRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete UserRoles
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteUserRoles(string[] IdList, UserRoles entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new UserRolesRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete UserRoles
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteUserRoles(int Id)
{
string result = string.Empty;
try
{
result = await new UserRolesRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All UserRoles
/// </summary>
/// <returns>List ofUserRoles</returns>
public async Task<IEnumerable<UserRoles>> GetAllUserRoles()
{
try
{
var result = await new UserRolesRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get UserRoles by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>UserRoles Object</returns>
public async Task<UserRoles> GetUserRolesById(int Id)
{
try
{
var result = await new UserRolesRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name UserRoles
/// </summary>
/// <returns>List ofUserRoles</returns>
public async Task<IEnumerable<UserRoles>> DropDownUserRoles()
{
try
{
var result = await new UserRolesRepository(logger).Dropdown();
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
