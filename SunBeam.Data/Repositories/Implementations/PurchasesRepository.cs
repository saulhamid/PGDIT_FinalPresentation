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


public class PurchasesRepository : DBGeneric<Purchases>, IRepository<Purchases>
{

protected ILogger Logger { get; set; }

public PurchasesRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Purchases
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(Purchases entity)
{
try
{
var cmd = new SqlCommand("sp_Purchases");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@InvoiecNo", entity.InvoiecNo);
cmd.Parameters.AddWithValue("@SupplierId", entity.SupplierId);
cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
cmd.Parameters.AddWithValue("@Date", entity.Date);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@CouponName", entity.CouponName);
cmd.Parameters.AddWithValue("@CouponAmunt", entity.CouponAmunt);
cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
cmd.Parameters.AddWithValue("@CreatedFrom", entity.CreatedFrom);


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
/// Update Purchases
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(Purchases entity)
{
try
{
var cmd = new SqlCommand("sp_Purchases");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@InvoiecNo", entity.InvoiecNo);
cmd.Parameters.AddWithValue("@SupplierId", entity.SupplierId);
cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
cmd.Parameters.AddWithValue("@Date", entity.Date);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@CouponName", entity.CouponName);
cmd.Parameters.AddWithValue("@CouponAmunt", entity.CouponAmunt);
cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
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
/// Delete Purchases
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_Purchases");
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
/// Delete Purchases
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,Purchases entity)
{
try
{
var cmd = new SqlCommand("sp_Purchases");
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
/// Get All Purchases
/// </summary>
/// <returns>List ofPurchases</returns>
public async Task<IEnumerable<Purchases>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_Purchases");
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
/// Get Purchases by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Purchases Object</returns>
public async Task<Purchases> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_Purchases");
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
/// Data Mapping for Purchases
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>Purchases Object</returns>
public Purchases Mapping(SqlDataReader reader)
{
try
{
Purchases oPurchases = new Purchases();
oPurchases.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oPurchases.InvoiecNo = Helper.ColumnExists(reader, "InvoiecNo") ? reader["InvoiecNo"].ToString() : "";
oPurchases.SupplierId = Helper.ColumnExists(reader, "SupplierId") ? ((reader["SupplierId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplierId"])) : 0 ;
oPurchases.EmployeeId = Helper.ColumnExists(reader, "EmployeeId") ? ((reader["EmployeeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["EmployeeId"])) : 0 ;
oPurchases.Date = Helper.ColumnExists(reader, "Date") ? reader["Date"].ToString() : "";
oPurchases.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
oPurchases.CouponName = Helper.ColumnExists(reader, "CouponName") ? reader["CouponName"].ToString() : "";
oPurchases.CouponAmunt = Helper.ColumnExists(reader, "CouponAmunt") ? ((reader["CouponAmunt"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["CouponAmunt"])) : 0;
oPurchases.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oPurchases.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oPurchases.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oPurchases.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oPurchases.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oPurchases.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oPurchases.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oPurchases.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oPurchases.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
oPurchases.SupplierName = Helper.ColumnExists(reader, "SupplierName") ? reader["SupplierName"].ToString() : "";
oPurchases.EmployeeName = Helper.ColumnExists(reader, "EmployeeName") ? reader["EmployeeName"].ToString() : "";
                return oPurchases;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name Purchases
/// </summary>
/// <returns>List ofPurchases</returns>
public async Task<IEnumerable<Purchases>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_Purchases");
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
