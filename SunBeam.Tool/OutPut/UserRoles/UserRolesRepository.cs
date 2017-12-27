using SunBeam.Common.Log;
using SunBeam.Common.Utility;
using SunBeam.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SunBeam.Data.Repositories.Interfaces;
using SunBeam.Domain.Models;

namespace SunBeam.Data.Repositories.Implementations
{


public class UserRolesRepository : DBGeneric<UserRoles>, IRepository<UserRoles>
{

protected ILogger Logger { get; set; }

public UserRolesRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert UserRoles
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(UserRoles entity)
{
try
{
var cmd = new SqlCommand("sp_UserRoles");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@BranchId", entity.BranchId);
cmd.Parameters.AddWithValue("@UserInfoId", entity.UserInfoId);
cmd.Parameters.AddWithValue("@RoleInfoId", entity.RoleInfoId);
cmd.Parameters.AddWithValue("@IsArchived", entity.IsArchived);

cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);
cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
cmd.Parameters.AddWithValue("@pOptions", 1);

var result = await ExecuteNonQueryProc(cmd);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update UserRoles
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(UserRoles entity)
{
try
{
var cmd = new SqlCommand("sp_UserRoles");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@BranchId", entity.BranchId);
cmd.Parameters.AddWithValue("@UserInfoId", entity.UserInfoId);
cmd.Parameters.AddWithValue("@RoleInfoId", entity.RoleInfoId);
cmd.Parameters.AddWithValue("@IsArchived", entity.IsArchived);

cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);
cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
cmd.Parameters.AddWithValue("@pOptions", 2);

var result = await ExecuteNonQueryProc(cmd);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete UserRoles
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_UserRoles");
cmd.Parameters.AddWithValue("@Id", Id);
cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);


cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
cmd.Parameters.AddWithValue("@pOptions", 4);


var result = await ExecuteNonQueryProc(cmd);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete UserRoles
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,UserRoles entity)
{
try
{
var cmd = new SqlCommand("sp_UserRoles");
cmd.Parameters.AddWithValue("@Id", Id);
cmd.Parameters.AddWithValue("@IsArchive ", "true");
cmd.Parameters.AddWithValue("@LastUpdateBy ", entity.LastUpdateBy);
cmd.Parameters.AddWithValue("@LastUpdateAt ", entity.LastUpdateAt);
cmd.Parameters.AddWithValue("@LastUpdateFrom ", entity.LastUpdateFrom);
cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);


cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
cmd.Parameters.AddWithValue("@pOptions", 3);


var result = await ExecuteNonQueryProc(cmd);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get All UserRoles
/// </summary>
/// <returns>List ofUserRoles</returns>
public async Task<IEnumerable<UserRoles>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_UserRoles");
cmd.Parameters.AddWithValue("@pOptions", 5);
var result = await GetDataReaderProc(cmd);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get UserRoles by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>UserRoles Object</returns>
public async Task<UserRoles> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_UserRoles");
cmd.Parameters.AddWithValue("@Id", Id);
cmd.Parameters.AddWithValue("@pOptions", 6);
var result = await GetByDataReaderProc(cmd);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Data Mapping for UserRoles
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>UserRoles Object</returns>
public UserRoles Mapping(SqlDataReader reader)
{
try
{
UserRoles oUserRoles = new UserRoles();
oUserRoles.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oUserRoles.BranchId = Helper.ColumnExists(reader, "BranchId") ? ((reader["BranchId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["BranchId"])) : 0 ;
oUserRoles.UserInfoId = Helper.ColumnExists(reader, "UserInfoId") ? reader["UserInfoId"].ToString() : "";
oUserRoles.RoleInfoId = Helper.ColumnExists(reader, "RoleInfoId") ? reader["RoleInfoId"].ToString() : "";
oUserRoles.IsArchived = Helper.ColumnExists(reader, "IsArchived") ? ((reader["IsArchived"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchived"])) : false;
return oUserRoles;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name UserRoles
/// </summary>
/// <returns>List ofUserRoles</returns>
public async Task<IEnumerable<UserRoles>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_UserRoles");
cmd.Parameters.AddWithValue("@pOptions", 7);
var result = await GetDataReaderProc(cmd);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}


}


}
