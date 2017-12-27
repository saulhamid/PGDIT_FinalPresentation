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


public class UsersRepository : DBGeneric<Users>, IRepository<Users>
{

protected ILogger Logger { get; set; }

public UsersRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Users
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(Users entity)
{
try
{
var cmd = new SqlCommand("sp_Users");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@FullName", entity.FullName);
cmd.Parameters.AddWithValue("@UserName", entity.UserName);
cmd.Parameters.AddWithValue("@Email", entity.Email);
cmd.Parameters.AddWithValue("@LogId", entity.LogId);
cmd.Parameters.AddWithValue("@Password", entity.Password);
cmd.Parameters.AddWithValue("@VerificationCode", entity.VerificationCode);
cmd.Parameters.AddWithValue("@BranchId", entity.BranchId);
cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
cmd.Parameters.AddWithValue("@IsAdmin", entity.IsAdmin);
cmd.Parameters.AddWithValue("@Remember", entity.Remember);
cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
cmd.Parameters.AddWithValue("@IsVerified", entity.IsVerified);
cmd.Parameters.AddWithValue("@IsArchived", entity.IsArchived);
cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
cmd.Parameters.AddWithValue("@CreatedFrom", entity.CreatedFrom);
cmd.Parameters.AddWithValue("@LastUpdateBy", entity.LastUpdateBy);
cmd.Parameters.AddWithValue("@LastUpdateAt", entity.LastUpdateAt);
cmd.Parameters.AddWithValue("@LastUpdateFrom", entity.LastUpdateFrom);

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
/// Update Users
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(Users entity)
{
try
{
var cmd = new SqlCommand("sp_Users");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@FullName", entity.FullName);
cmd.Parameters.AddWithValue("@UserName", entity.UserName);
cmd.Parameters.AddWithValue("@Email", entity.Email);
cmd.Parameters.AddWithValue("@LogId", entity.LogId);
cmd.Parameters.AddWithValue("@Password", entity.Password);
cmd.Parameters.AddWithValue("@VerificationCode", entity.VerificationCode);
cmd.Parameters.AddWithValue("@BranchId", entity.BranchId);
cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
cmd.Parameters.AddWithValue("@IsAdmin", entity.IsAdmin);
cmd.Parameters.AddWithValue("@Remember", entity.Remember);
cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
cmd.Parameters.AddWithValue("@IsVerified", entity.IsVerified);
cmd.Parameters.AddWithValue("@IsArchived", entity.IsArchived);
cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
cmd.Parameters.AddWithValue("@CreatedFrom", entity.CreatedFrom);
cmd.Parameters.AddWithValue("@LastUpdateBy", entity.LastUpdateBy);
cmd.Parameters.AddWithValue("@LastUpdateAt", entity.LastUpdateAt);
cmd.Parameters.AddWithValue("@LastUpdateFrom", entity.LastUpdateFrom);

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
/// Delete Users
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_Users");
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
/// Delete Users
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,Users entity)
{
try
{
var cmd = new SqlCommand("sp_Users");
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
/// Get All Users
/// </summary>
/// <returns>List ofUsers</returns>
public async Task<IEnumerable<Users>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_Users");
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
/// Get Users by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Users Object</returns>
public async Task<Users> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_Users");
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
/// Data Mapping for Users
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>Users Object</returns>
public Users Mapping(SqlDataReader reader)
{
try
{
Users oUsers = new Users();
oUsers.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oUsers.FullName = 
oUsers.UserName = 
oUsers.Email = 
oUsers.LogId = 
oUsers.Password = 
oUsers.VerificationCode = 
oUsers.BranchId = Helper.ColumnExists(reader, "BranchId") ? ((reader["BranchId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["BranchId"])) : 0 ;
oUsers.EmployeeId = Helper.ColumnExists(reader, "EmployeeId") ? reader["EmployeeId"].ToString() : "";
oUsers.IsAdmin = Helper.ColumnExists(reader, "IsAdmin") ? ((reader["IsAdmin"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAdmin"])) : false;
oUsers.Remember = Helper.ColumnExists(reader, "Remember") ? ((reader["Remember"] == DBNull.Value) ? false : Convert.ToBoolean(reader["Remember"])) : false;
oUsers.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oUsers.IsVerified = Helper.ColumnExists(reader, "IsVerified") ? ((reader["IsVerified"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsVerified"])) : false;
oUsers.IsArchived = Helper.ColumnExists(reader, "IsArchived") ? ((reader["IsArchived"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchived"])) : false;
oUsers.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oUsers.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oUsers.CreatedFrom = 
oUsers.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oUsers.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oUsers.LastUpdateFrom = 
return oUsers;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name Users
/// </summary>
/// <returns>List ofUsers</returns>
public async Task<IEnumerable<Users>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_Users");
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
