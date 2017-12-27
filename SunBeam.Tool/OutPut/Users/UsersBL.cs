using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class UsersBL : IUsersBL
{

protected ILogger logger { get; set; }

public UsersBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert Users
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertUsers(Users entity)
{
try
{
var result = await new UsersRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Users
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateUsers(Users entity)
{
try
{
var result = await new UsersRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Users
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteUsers(string[] IdList, Users entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new UsersRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete Users
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteUsers(int Id)
{
string result = string.Empty;
try
{
result = await new UsersRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All Users
/// </summary>
/// <returns>List ofUsers</returns>
public async Task<IEnumerable<Users>> GetAllUsers()
{
try
{
var result = await new UsersRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Users by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Users Object</returns>
public async Task<Users> GetUsersById(int Id)
{
try
{
var result = await new UsersRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name Users
/// </summary>
/// <returns>List ofUsers</returns>
public async Task<IEnumerable<Users>> DropDownUsers()
{
try
{
var result = await new UsersRepository(logger).Dropdown();
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
