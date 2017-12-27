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


public class MarketsRepository : DBGeneric<Markets>, IRepository<Markets>
{

protected ILogger Logger { get; set; }

public MarketsRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Markets
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(Markets entity)
{
try
{
var cmd = new SqlCommand("sp_Markets");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@ZoneOrAreaId", entity.ZoneOrAreaId);
cmd.Parameters.AddWithValue("@Code", entity.Code);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@Description", entity.Description);
cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
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
/// Update Markets
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(Markets entity)
{
try
{
var cmd = new SqlCommand("sp_Markets");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@ZoneOrAreaId", entity.ZoneOrAreaId);
cmd.Parameters.AddWithValue("@Code", entity.Code);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@Description", entity.Description);
cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
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
/// Delete Markets
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_Markets");
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
/// Delete Markets
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,Markets entity)
{
try
{
var cmd = new SqlCommand("sp_Markets");
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
/// Get All Markets
/// </summary>
/// <returns>List ofMarkets</returns>
public async Task<IEnumerable<Markets>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_Markets");
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
/// Get Markets by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Markets Object</returns>
public async Task<Markets> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_Markets");
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
/// Data Mapping for Markets
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>Markets Object</returns>
public Markets Mapping(SqlDataReader reader)
{
try
{
Markets oMarkets = new Markets();
oMarkets.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oMarkets.ZoneOrAreaId = Helper.ColumnExists(reader, "ZoneOrAreaId") ? ((reader["ZoneOrAreaId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ZoneOrAreaId"])) : 0 ;
oMarkets.Code = Helper.ColumnExists(reader, "Code") ? reader["Code"].ToString() : "";
oMarkets.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
oMarkets.Description = Helper.ColumnExists(reader, "Description") ? reader["Description"].ToString() : "";
oMarkets.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oMarkets.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oMarkets.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oMarkets.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oMarkets.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oMarkets.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oMarkets.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oMarkets.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oMarkets.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oMarkets;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name Markets
/// </summary>
/// <returns>List ofMarkets</returns>
public async Task<IEnumerable<Markets>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_Markets");
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
