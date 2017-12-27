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


public class SuppliersRepository : DBGeneric<Suppliers>, IRepository<Suppliers>
{

protected ILogger Logger { get; set; }

public SuppliersRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Suppliers
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(Suppliers entity)
{
try
{
var cmd = new SqlCommand("sp_Suppliers");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@BranchId", entity.BranchId);
cmd.Parameters.AddWithValue("@Code", entity.Code);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@Salutation_E", entity.Salutation_E);
cmd.Parameters.AddWithValue("@MiddleName", entity.MiddleName);
cmd.Parameters.AddWithValue("@LastName", entity.LastName);
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
/// Update Suppliers
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(Suppliers entity)
{
try
{
var cmd = new SqlCommand("sp_Suppliers");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@BranchId", entity.BranchId);
cmd.Parameters.AddWithValue("@Code", entity.Code);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@Salutation_E", entity.Salutation_E);
cmd.Parameters.AddWithValue("@MiddleName", entity.MiddleName);
cmd.Parameters.AddWithValue("@LastName", entity.LastName);
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
/// Delete Suppliers
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_Suppliers");
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
/// Delete Suppliers
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,Suppliers entity)
{
try
{
var cmd = new SqlCommand("sp_Suppliers");
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
/// Get All Suppliers
/// </summary>
/// <returns>List ofSuppliers</returns>
public async Task<IEnumerable<Suppliers>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_Suppliers");
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
/// Get Suppliers by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Suppliers Object</returns>
public async Task<Suppliers> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_Suppliers");
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
/// Data Mapping for Suppliers
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>Suppliers Object</returns>
public Suppliers Mapping(SqlDataReader reader)
{
try
{
Suppliers oSuppliers = new Suppliers();
oSuppliers.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oSuppliers.BranchId = Helper.ColumnExists(reader, "BranchId") ? ((reader["BranchId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["BranchId"])) : 0 ;
oSuppliers.Code = Helper.ColumnExists(reader, "Code") ? reader["Code"].ToString() : "";
oSuppliers.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
oSuppliers.Salutation_E = Helper.ColumnExists(reader, "Salutation_E") ? reader["Salutation_E"].ToString() : "";
oSuppliers.MiddleName = Helper.ColumnExists(reader, "MiddleName") ? reader["MiddleName"].ToString() : "";
oSuppliers.LastName = Helper.ColumnExists(reader, "LastName") ? reader["LastName"].ToString() : "";
oSuppliers.CountryId = Helper.ColumnExists(reader, "CountryId") ? ((reader["CountryId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CountryId"])) : 0 ;
oSuppliers.DivisionId = Helper.ColumnExists(reader, "DivisionId") ? ((reader["DivisionId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DivisionId"])) : 0 ;
oSuppliers.DistrictId = Helper.ColumnExists(reader, "DistrictId") ? ((reader["DistrictId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DistrictId"])) : 0 ;
oSuppliers.Mobile = Helper.ColumnExists(reader, "Mobile") ? reader["Mobile"].ToString() : "";
oSuppliers.PermanentAddress = Helper.ColumnExists(reader, "PermanentAddress") ? reader["PermanentAddress"].ToString() : "";
oSuppliers.PresentAddress = Helper.ColumnExists(reader, "PresentAddress") ? reader["PresentAddress"].ToString() : "";
oSuppliers.PABX = Helper.ColumnExists(reader, "PABX") ? reader["PABX"].ToString() : "";
oSuppliers.Email = Helper.ColumnExists(reader, "Email") ? reader["Email"].ToString() : "";
oSuppliers.FAX = Helper.ColumnExists(reader, "FAX") ? reader["FAX"].ToString() : "";
oSuppliers.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oSuppliers.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oSuppliers.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oSuppliers.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oSuppliers.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oSuppliers.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oSuppliers.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oSuppliers.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oSuppliers.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oSuppliers;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name Suppliers
/// </summary>
/// <returns>List ofSuppliers</returns>
public async Task<IEnumerable<Suppliers>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_Suppliers");
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
