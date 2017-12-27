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


public class EnumDivisionRepository : DBGeneric<EnumDivision>, IRepository<EnumDivision>
{

protected ILogger Logger { get; set; }

public EnumDivisionRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert EnumDivision
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(EnumDivision entity)
{
try
{
var cmd = new SqlCommand("sp_EnumDivision");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@CountryId", entity.CountryId);
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
/// Update EnumDivision
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(EnumDivision entity)
{
try
{
var cmd = new SqlCommand("sp_EnumDivision");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@CountryId", entity.CountryId);
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
/// Delete EnumDivision
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_EnumDivision");
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
/// Delete EnumDivision
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,EnumDivision entity)
{
try
{
var cmd = new SqlCommand("sp_EnumDivision");
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
/// Get All EnumDivision
/// </summary>
/// <returns>List ofEnumDivision</returns>
public async Task<IEnumerable<EnumDivision>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_EnumDivision");
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
/// Get EnumDivision by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>EnumDivision Object</returns>
public async Task<EnumDivision> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_EnumDivision");
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
/// Data Mapping for EnumDivision
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>EnumDivision Object</returns>
public EnumDivision Mapping(SqlDataReader reader)
{
try
{
EnumDivision oEnumDivision = new EnumDivision();
oEnumDivision.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oEnumDivision.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
oEnumDivision.CountryId = Helper.ColumnExists(reader, "CountryId") ? ((reader["CountryId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CountryId"])) : 0 ;
oEnumDivision.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oEnumDivision.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oEnumDivision.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oEnumDivision.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oEnumDivision.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oEnumDivision.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oEnumDivision.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oEnumDivision.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oEnumDivision.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oEnumDivision;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name EnumDivision
/// </summary>
/// <returns>List ofEnumDivision</returns>
public async Task<IEnumerable<EnumDivision>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_EnumDivision");
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
