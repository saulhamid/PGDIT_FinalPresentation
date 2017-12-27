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


public class PurcheaseReturnDetailsRepository : DBGeneric<PurcheaseReturnDetails>, IRepository<PurcheaseReturnDetails>
{

protected ILogger Logger { get; set; }

public PurcheaseReturnDetailsRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert PurcheaseReturnDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(PurcheaseReturnDetails entity)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturnDetails");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@PurchaseReturnId", entity.PurchaseReturnId);
cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
cmd.Parameters.AddWithValue("@ProductName", entity.ProductName);
cmd.Parameters.AddWithValue("@ProductCode", entity.ProductCode);
cmd.Parameters.AddWithValue("@UnitePrice", entity.UnitePrice);
cmd.Parameters.AddWithValue("@Data", entity.Data);
cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
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
/// Update PurcheaseReturnDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(PurcheaseReturnDetails entity)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturnDetails");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@PurchaseReturnId", entity.PurchaseReturnId);
cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
cmd.Parameters.AddWithValue("@ProductName", entity.ProductName);
cmd.Parameters.AddWithValue("@ProductCode", entity.ProductCode);
cmd.Parameters.AddWithValue("@UnitePrice", entity.UnitePrice);
cmd.Parameters.AddWithValue("@Data", entity.Data);
cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
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
/// Delete PurcheaseReturnDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturnDetails");
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
/// Delete PurcheaseReturnDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,PurcheaseReturnDetails entity)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturnDetails");
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
/// Get All PurcheaseReturnDetails
/// </summary>
/// <returns>List ofPurcheaseReturnDetails</returns>
public async Task<IEnumerable<PurcheaseReturnDetails>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturnDetails");
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
/// Get PurcheaseReturnDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>PurcheaseReturnDetails Object</returns>
public async Task<PurcheaseReturnDetails> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturnDetails");
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
/// Data Mapping for PurcheaseReturnDetails
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>PurcheaseReturnDetails Object</returns>
public PurcheaseReturnDetails Mapping(SqlDataReader reader)
{
try
{
PurcheaseReturnDetails oPurcheaseReturnDetails = new PurcheaseReturnDetails();
oPurcheaseReturnDetails.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oPurcheaseReturnDetails.PurchaseReturnId = Helper.ColumnExists(reader, "PurchaseReturnId") ? ((reader["PurchaseReturnId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PurchaseReturnId"])) : 0 ;
oPurcheaseReturnDetails.ProductId = Helper.ColumnExists(reader, "ProductId") ? ((reader["ProductId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductId"])) : 0 ;
oPurcheaseReturnDetails.ProductName = Helper.ColumnExists(reader, "ProductName") ? reader["ProductName"].ToString() : "";
oPurcheaseReturnDetails.ProductCode = Helper.ColumnExists(reader, "ProductCode") ? reader["ProductCode"].ToString() : "";
oPurcheaseReturnDetails.UnitePrice = Helper.ColumnExists(reader, "UnitePrice") ? ((reader["UnitePrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["UnitePrice"])) : 0;
oPurcheaseReturnDetails.Data = Helper.ColumnExists(reader, "Data") ? reader["Data"].ToString() : "";
oPurcheaseReturnDetails.Quantity = Helper.ColumnExists(reader, "Quantity") ? ((reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Quantity"])) : 0;
oPurcheaseReturnDetails.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
oPurcheaseReturnDetails.TotalPrice = Helper.ColumnExists(reader, "TotalPrice") ? ((reader["TotalPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPrice"])) : 0;
oPurcheaseReturnDetails.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oPurcheaseReturnDetails.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oPurcheaseReturnDetails.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oPurcheaseReturnDetails.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oPurcheaseReturnDetails.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oPurcheaseReturnDetails.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oPurcheaseReturnDetails.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oPurcheaseReturnDetails.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oPurcheaseReturnDetails.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oPurcheaseReturnDetails;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name PurcheaseReturnDetails
/// </summary>
/// <returns>List ofPurcheaseReturnDetails</returns>
public async Task<IEnumerable<PurcheaseReturnDetails>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_PurcheaseReturnDetails");
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
