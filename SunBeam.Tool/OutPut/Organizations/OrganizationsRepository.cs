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


public class OrganizationsRepository : DBGeneric<Organizations>, IRepository<Organizations>
{

protected ILogger Logger { get; set; }

public OrganizationsRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Organizations
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(Organizations entity)
{
try
{
var cmd = new SqlCommand("sp_Organizations");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@Code", entity.Code);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@CountryId", entity.CountryId);
cmd.Parameters.AddWithValue("@DivisionId", entity.DivisionId);
cmd.Parameters.AddWithValue("@DistrictId", entity.DistrictId);
cmd.Parameters.AddWithValue("@Mobile", entity.Mobile);
cmd.Parameters.AddWithValue("@PermanentAddress", entity.PermanentAddress);
cmd.Parameters.AddWithValue("@PresentAddress", entity.PresentAddress);
cmd.Parameters.AddWithValue("@PABX", entity.PABX);
cmd.Parameters.AddWithValue("@Email", entity.Email);
cmd.Parameters.AddWithValue("@FAX", entity.FAX);
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
/// Update Organizations
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(Organizations entity)
{
try
{
var cmd = new SqlCommand("sp_Organizations");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@Code", entity.Code);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@CountryId", entity.CountryId);
cmd.Parameters.AddWithValue("@DivisionId", entity.DivisionId);
cmd.Parameters.AddWithValue("@DistrictId", entity.DistrictId);
cmd.Parameters.AddWithValue("@Mobile", entity.Mobile);
cmd.Parameters.AddWithValue("@PermanentAddress", entity.PermanentAddress);
cmd.Parameters.AddWithValue("@PresentAddress", entity.PresentAddress);
cmd.Parameters.AddWithValue("@PABX", entity.PABX);
cmd.Parameters.AddWithValue("@Email", entity.Email);
cmd.Parameters.AddWithValue("@FAX", entity.FAX);
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
/// Delete Organizations
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_Organizations");
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
/// Delete Organizations
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,Organizations entity)
{
try
{
var cmd = new SqlCommand("sp_Organizations");
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
/// Get All Organizations
/// </summary>
/// <returns>List ofOrganizations</returns>
public async Task<IEnumerable<Organizations>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_Organizations");
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
/// Get Organizations by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Organizations Object</returns>
public async Task<Organizations> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_Organizations");
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
/// Data Mapping for Organizations
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>Organizations Object</returns>
public Organizations Mapping(SqlDataReader reader)
{
try
{
Organizations oOrganizations = new Organizations();
oOrganizations.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oOrganizations.Code = Helper.ColumnExists(reader, "Code") ? reader["Code"].ToString() : "";
oOrganizations.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
oOrganizations.CountryId = Helper.ColumnExists(reader, "CountryId") ? ((reader["CountryId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CountryId"])) : 0 ;
oOrganizations.DivisionId = Helper.ColumnExists(reader, "DivisionId") ? ((reader["DivisionId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DivisionId"])) : 0 ;
oOrganizations.DistrictId = Helper.ColumnExists(reader, "DistrictId") ? ((reader["DistrictId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DistrictId"])) : 0 ;
oOrganizations.Mobile = Helper.ColumnExists(reader, "Mobile") ? reader["Mobile"].ToString() : "";
oOrganizations.PermanentAddress = Helper.ColumnExists(reader, "PermanentAddress") ? reader["PermanentAddress"].ToString() : "";
oOrganizations.PresentAddress = Helper.ColumnExists(reader, "PresentAddress") ? reader["PresentAddress"].ToString() : "";
oOrganizations.PABX = Helper.ColumnExists(reader, "PABX") ? reader["PABX"].ToString() : "";
oOrganizations.Email = Helper.ColumnExists(reader, "Email") ? reader["Email"].ToString() : "";
oOrganizations.FAX = Helper.ColumnExists(reader, "FAX") ? reader["FAX"].ToString() : "";
oOrganizations.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oOrganizations.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oOrganizations.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oOrganizations.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oOrganizations.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oOrganizations.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oOrganizations.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oOrganizations.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oOrganizations.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oOrganizations;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name Organizations
/// </summary>
/// <returns>List ofOrganizations</returns>
public async Task<IEnumerable<Organizations>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_Organizations");
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
