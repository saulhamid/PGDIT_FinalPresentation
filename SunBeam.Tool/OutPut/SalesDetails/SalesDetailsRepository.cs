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


public class SalesDetailsRepository : DBGeneric<SalesDetails>, IRepository<SalesDetails>
{

protected ILogger Logger { get; set; }

public SalesDetailsRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert SalesDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(SalesDetails entity)
{
try
{
var cmd = new SqlCommand("sp_SalesDetails");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@SalesId", entity.SalesId);
cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
cmd.Parameters.AddWithValue("@ProductName", entity.ProductName);
cmd.Parameters.AddWithValue("@ProductCode", entity.ProductCode);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@UnitePrice", entity.UnitePrice);
cmd.Parameters.AddWithValue("@Date", entity.Date);
cmd.Parameters.AddWithValue("@Slup", entity.Slup);
cmd.Parameters.AddWithValue("@Bonus", entity.Bonus);
cmd.Parameters.AddWithValue("@AssaignQuantity", entity.AssaignQuantity);
cmd.Parameters.AddWithValue("@SalesQuantity", entity.SalesQuantity);
cmd.Parameters.AddWithValue("@Return", entity.Return);
cmd.Parameters.AddWithValue("@Replace", entity.Replace);
cmd.Parameters.AddWithValue("@TotalSlupPrice", entity.TotalSlupPrice);
cmd.Parameters.AddWithValue("@WithOurDiscountPrice", entity.WithOurDiscountPrice);
cmd.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
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
/// Update SalesDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(SalesDetails entity)
{
try
{
var cmd = new SqlCommand("sp_SalesDetails");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@SalesId", entity.SalesId);
cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
cmd.Parameters.AddWithValue("@ProductName", entity.ProductName);
cmd.Parameters.AddWithValue("@ProductCode", entity.ProductCode);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@UnitePrice", entity.UnitePrice);
cmd.Parameters.AddWithValue("@Date", entity.Date);
cmd.Parameters.AddWithValue("@Slup", entity.Slup);
cmd.Parameters.AddWithValue("@Bonus", entity.Bonus);
cmd.Parameters.AddWithValue("@AssaignQuantity", entity.AssaignQuantity);
cmd.Parameters.AddWithValue("@SalesQuantity", entity.SalesQuantity);
cmd.Parameters.AddWithValue("@Return", entity.Return);
cmd.Parameters.AddWithValue("@Replace", entity.Replace);
cmd.Parameters.AddWithValue("@TotalSlupPrice", entity.TotalSlupPrice);
cmd.Parameters.AddWithValue("@WithOurDiscountPrice", entity.WithOurDiscountPrice);
cmd.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
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
/// Delete SalesDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_SalesDetails");
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
/// Delete SalesDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,SalesDetails entity)
{
try
{
var cmd = new SqlCommand("sp_SalesDetails");
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
/// Get All SalesDetails
/// </summary>
/// <returns>List ofSalesDetails</returns>
public async Task<IEnumerable<SalesDetails>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_SalesDetails");
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
/// Get SalesDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>SalesDetails Object</returns>
public async Task<SalesDetails> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_SalesDetails");
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
/// Data Mapping for SalesDetails
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>SalesDetails Object</returns>
public SalesDetails Mapping(SqlDataReader reader)
{
try
{
SalesDetails oSalesDetails = new SalesDetails();
oSalesDetails.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oSalesDetails.SalesId = Helper.ColumnExists(reader, "SalesId") ? ((reader["SalesId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SalesId"])) : 0 ;
oSalesDetails.ProductId = Helper.ColumnExists(reader, "ProductId") ? ((reader["ProductId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductId"])) : 0 ;
oSalesDetails.ProductName = Helper.ColumnExists(reader, "ProductName") ? reader["ProductName"].ToString() : "";
oSalesDetails.ProductCode = Helper.ColumnExists(reader, "ProductCode") ? reader["ProductCode"].ToString() : "";
oSalesDetails.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
oSalesDetails.UnitePrice = Helper.ColumnExists(reader, "UnitePrice") ? ((reader["UnitePrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["UnitePrice"])) : 0;
oSalesDetails.Date = Helper.ColumnExists(reader, "Date") ? reader["Date"].ToString() : "";
oSalesDetails.Slup = Helper.ColumnExists(reader, "Slup") ? ((reader["Slup"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Slup"])) : 0;
oSalesDetails.Bonus = Helper.ColumnExists(reader, "Bonus") ? ((reader["Bonus"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Bonus"])) : 0;
oSalesDetails.AssaignQuantity = Helper.ColumnExists(reader, "AssaignQuantity") ? ((reader["AssaignQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["AssaignQuantity"])) : 0;
oSalesDetails.SalesQuantity = Helper.ColumnExists(reader, "SalesQuantity") ? ((reader["SalesQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["SalesQuantity"])) : 0;
oSalesDetails.Return = Helper.ColumnExists(reader, "Return") ? ((reader["Return"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Return"])) : 0;
oSalesDetails.Replace = Helper.ColumnExists(reader, "Replace") ? ((reader["Replace"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Replace"])) : 0;
oSalesDetails.TotalSlupPrice = Helper.ColumnExists(reader, "TotalSlupPrice") ? ((reader["TotalSlupPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalSlupPrice"])) : 0;
oSalesDetails.WithOurDiscountPrice = Helper.ColumnExists(reader, "WithOurDiscountPrice") ? ((reader["WithOurDiscountPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["WithOurDiscountPrice"])) : 0;
oSalesDetails.TotalAmount = Helper.ColumnExists(reader, "TotalAmount") ? ((reader["TotalAmount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalAmount"])) : 0;
oSalesDetails.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oSalesDetails.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oSalesDetails.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oSalesDetails.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oSalesDetails.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oSalesDetails.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oSalesDetails.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oSalesDetails.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oSalesDetails.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oSalesDetails;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name SalesDetails
/// </summary>
/// <returns>List ofSalesDetails</returns>
public async Task<IEnumerable<SalesDetails>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_SalesDetails");
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
