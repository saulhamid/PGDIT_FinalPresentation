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


public class PurcheaseReturnsRepository : DBGeneric<PurcheaseReturns>, IRepository<PurcheaseReturns>
{

protected ILogger Logger { get; set; }

public PurcheaseReturnsRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert PurcheaseReturns
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(PurcheaseReturns entity)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturns");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@SupplierId", entity.SupplierId);
cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
cmd.Parameters.AddWithValue("@PurchaseId", entity.PurchaseId);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@TotalPaid", entity.TotalPaid);
cmd.Parameters.AddWithValue("@InvoiceNo", entity.InvoiceNo);
cmd.Parameters.AddWithValue("@Date", entity.Date);
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
/// Update PurcheaseReturns
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(PurcheaseReturns entity)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturns");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@SupplierId", entity.SupplierId);
cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
cmd.Parameters.AddWithValue("@PurchaseId", entity.PurchaseId);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@TotalPaid", entity.TotalPaid);
cmd.Parameters.AddWithValue("@InvoiceNo", entity.InvoiceNo);
cmd.Parameters.AddWithValue("@Date", entity.Date);
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
/// Delete PurcheaseReturns
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturns");
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
/// Delete PurcheaseReturns
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,PurcheaseReturns entity)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturns");
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
/// Get All PurcheaseReturns
/// </summary>
/// <returns>List ofPurcheaseReturns</returns>
public async Task<IEnumerable<PurcheaseReturns>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturns");
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
/// Get PurcheaseReturns by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>PurcheaseReturns Object</returns>
public async Task<PurcheaseReturns> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturns");
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
/// Data Mapping for PurcheaseReturns
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>PurcheaseReturns Object</returns>
public PurcheaseReturns Mapping(SqlDataReader reader)
{
try
{
PurcheaseReturns oPurcheaseReturns = new PurcheaseReturns();
oPurcheaseReturns.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oPurcheaseReturns.SupplierId = Helper.ColumnExists(reader, "SupplierId") ? ((reader["SupplierId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplierId"])) : 0 ;
oPurcheaseReturns.EmployeeId = Helper.ColumnExists(reader, "EmployeeId") ? ((reader["EmployeeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["EmployeeId"])) : 0 ;
oPurcheaseReturns.PurchaseId = Helper.ColumnExists(reader, "PurchaseId") ? ((reader["PurchaseId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PurchaseId"])) : 0 ;
oPurcheaseReturns.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
oPurcheaseReturns.TotalPaid = Helper.ColumnExists(reader, "TotalPaid") ? ((reader["TotalPaid"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPaid"])) : 0;
oPurcheaseReturns.InvoiceNo = Helper.ColumnExists(reader, "InvoiceNo") ? reader["InvoiceNo"].ToString() : "";
oPurcheaseReturns.Date = Helper.ColumnExists(reader, "Date") ? reader["Date"].ToString() : "";
oPurcheaseReturns.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oPurcheaseReturns.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oPurcheaseReturns.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oPurcheaseReturns.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oPurcheaseReturns.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oPurcheaseReturns.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oPurcheaseReturns.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oPurcheaseReturns.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oPurcheaseReturns.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
                oPurcheaseReturns.SupplierName = Helper.ColumnExists(reader, "SupplierName") ? reader["SupplierName"].ToString() : "";
                oPurcheaseReturns.EmployeeName = Helper.ColumnExists(reader, "EmployeeName") ? reader["EmployeeName"].ToString() : "";
                return oPurcheaseReturns;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name PurcheaseReturns
/// </summary>
/// <returns>List ofPurcheaseReturns</returns>
public async Task<IEnumerable<PurcheaseReturns>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturns");
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
