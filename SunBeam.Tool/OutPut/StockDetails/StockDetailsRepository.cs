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


public class StockDetailsRepository : DBGeneric<StockDetails>, IRepository<StockDetails>
{

protected ILogger Logger { get; set; }

public StockDetailsRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert StockDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(StockDetails entity)
{
try
{
var cmd = new SqlCommand("sp_StockDetails");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@SalesId", entity.SalesId);
cmd.Parameters.AddWithValue("@SalesReturnId", entity.SalesReturnId);
cmd.Parameters.AddWithValue("@PurcheaseId", entity.PurcheaseId);
cmd.Parameters.AddWithValue("@PurcheaseReturnId", entity.PurcheaseReturnId);
cmd.Parameters.AddWithValue("@StockId", entity.StockId);
cmd.Parameters.AddWithValue("@StockReplace", entity.StockReplace);
cmd.Parameters.AddWithValue("@TransReplace", entity.TransReplace);
cmd.Parameters.AddWithValue("@TotalReplace", entity.TotalReplace);
cmd.Parameters.AddWithValue("@StockReturn", entity.StockReturn);
cmd.Parameters.AddWithValue("@TransReturn", entity.TransReturn);
cmd.Parameters.AddWithValue("@TotalReturn", entity.TotalReturn);
cmd.Parameters.AddWithValue("@StockDiscount", entity.StockDiscount);
cmd.Parameters.AddWithValue("@TransDiscount", entity.TransDiscount);
cmd.Parameters.AddWithValue("@TotalDiscount", entity.TotalDiscount);
cmd.Parameters.AddWithValue("@TransSlup", entity.TransSlup);
cmd.Parameters.AddWithValue("@StockSlup", entity.StockSlup);
cmd.Parameters.AddWithValue("@TotalSlup", entity.TotalSlup);
cmd.Parameters.AddWithValue("@StockQuantity", entity.StockQuantity);
cmd.Parameters.AddWithValue("@TransQuantity", entity.TransQuantity);
cmd.Parameters.AddWithValue("@TotalQuantity", entity.TotalQuantity);
cmd.Parameters.AddWithValue("@TotalPaid", entity.TotalPaid);
cmd.Parameters.AddWithValue("@StockPrice", entity.StockPrice);
cmd.Parameters.AddWithValue("@TransPrice", entity.TransPrice);
cmd.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
cmd.Parameters.AddWithValue("@StockStutes", entity.StockStutes);
cmd.Parameters.AddWithValue("@Date", entity.Date);
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
/// Update StockDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(StockDetails entity)
{
try
{
var cmd = new SqlCommand("sp_StockDetails");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@SalesId", entity.SalesId);
cmd.Parameters.AddWithValue("@SalesReturnId", entity.SalesReturnId);
cmd.Parameters.AddWithValue("@PurcheaseId", entity.PurcheaseId);
cmd.Parameters.AddWithValue("@PurcheaseReturnId", entity.PurcheaseReturnId);
cmd.Parameters.AddWithValue("@StockId", entity.StockId);
cmd.Parameters.AddWithValue("@StockReplace", entity.StockReplace);
cmd.Parameters.AddWithValue("@TransReplace", entity.TransReplace);
cmd.Parameters.AddWithValue("@TotalReplace", entity.TotalReplace);
cmd.Parameters.AddWithValue("@StockReturn", entity.StockReturn);
cmd.Parameters.AddWithValue("@TransReturn", entity.TransReturn);
cmd.Parameters.AddWithValue("@TotalReturn", entity.TotalReturn);
cmd.Parameters.AddWithValue("@StockDiscount", entity.StockDiscount);
cmd.Parameters.AddWithValue("@TransDiscount", entity.TransDiscount);
cmd.Parameters.AddWithValue("@TotalDiscount", entity.TotalDiscount);
cmd.Parameters.AddWithValue("@TransSlup", entity.TransSlup);
cmd.Parameters.AddWithValue("@StockSlup", entity.StockSlup);
cmd.Parameters.AddWithValue("@TotalSlup", entity.TotalSlup);
cmd.Parameters.AddWithValue("@StockQuantity", entity.StockQuantity);
cmd.Parameters.AddWithValue("@TransQuantity", entity.TransQuantity);
cmd.Parameters.AddWithValue("@TotalQuantity", entity.TotalQuantity);
cmd.Parameters.AddWithValue("@TotalPaid", entity.TotalPaid);
cmd.Parameters.AddWithValue("@StockPrice", entity.StockPrice);
cmd.Parameters.AddWithValue("@TransPrice", entity.TransPrice);
cmd.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
cmd.Parameters.AddWithValue("@StockStutes", entity.StockStutes);
cmd.Parameters.AddWithValue("@Date", entity.Date);
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
/// Delete StockDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_StockDetails");
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
/// Delete StockDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,StockDetails entity)
{
try
{
var cmd = new SqlCommand("sp_StockDetails");
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
/// Get All StockDetails
/// </summary>
/// <returns>List ofStockDetails</returns>
public async Task<IEnumerable<StockDetails>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_StockDetails");
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
/// Get StockDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>StockDetails Object</returns>
public async Task<StockDetails> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_StockDetails");
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
/// Data Mapping for StockDetails
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>StockDetails Object</returns>
public StockDetails Mapping(SqlDataReader reader)
{
try
{
StockDetails oStockDetails = new StockDetails();
oStockDetails.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oStockDetails.SalesId = Helper.ColumnExists(reader, "SalesId") ? ((reader["SalesId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SalesId"])) : 0 ;
oStockDetails.SalesReturnId = Helper.ColumnExists(reader, "SalesReturnId") ? ((reader["SalesReturnId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SalesReturnId"])) : 0 ;
oStockDetails.PurcheaseId = Helper.ColumnExists(reader, "PurcheaseId") ? ((reader["PurcheaseId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PurcheaseId"])) : 0 ;
oStockDetails.PurcheaseReturnId = Helper.ColumnExists(reader, "PurcheaseReturnId") ? ((reader["PurcheaseReturnId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PurcheaseReturnId"])) : 0 ;
oStockDetails.StockId = Helper.ColumnExists(reader, "StockId") ? ((reader["StockId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StockId"])) : 0 ;
oStockDetails.StockReplace = Helper.ColumnExists(reader, "StockReplace") ? ((reader["StockReplace"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["StockReplace"])) : 0;
oStockDetails.TransReplace = Helper.ColumnExists(reader, "TransReplace") ? ((reader["TransReplace"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TransReplace"])) : 0;
oStockDetails.TotalReplace = Helper.ColumnExists(reader, "TotalReplace") ? ((reader["TotalReplace"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalReplace"])) : 0;
oStockDetails.StockReturn = Helper.ColumnExists(reader, "StockReturn") ? ((reader["StockReturn"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["StockReturn"])) : 0;
oStockDetails.TransReturn = Helper.ColumnExists(reader, "TransReturn") ? ((reader["TransReturn"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TransReturn"])) : 0;
oStockDetails.TotalReturn = Helper.ColumnExists(reader, "TotalReturn") ? ((reader["TotalReturn"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalReturn"])) : 0;
oStockDetails.StockDiscount = Helper.ColumnExists(reader, "StockDiscount") ? ((reader["StockDiscount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["StockDiscount"])) : 0;
oStockDetails.TransDiscount = Helper.ColumnExists(reader, "TransDiscount") ? ((reader["TransDiscount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TransDiscount"])) : 0;
oStockDetails.TotalDiscount = Helper.ColumnExists(reader, "TotalDiscount") ? ((reader["TotalDiscount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalDiscount"])) : 0;
oStockDetails.TransSlup = Helper.ColumnExists(reader, "TransSlup") ? ((reader["TransSlup"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TransSlup"])) : 0;
oStockDetails.StockSlup = Helper.ColumnExists(reader, "StockSlup") ? ((reader["StockSlup"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["StockSlup"])) : 0;
oStockDetails.TotalSlup = Helper.ColumnExists(reader, "TotalSlup") ? ((reader["TotalSlup"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalSlup"])) : 0;
oStockDetails.StockQuantity = Helper.ColumnExists(reader, "StockQuantity") ? ((reader["StockQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["StockQuantity"])) : 0;
oStockDetails.TransQuantity = Helper.ColumnExists(reader, "TransQuantity") ? ((reader["TransQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TransQuantity"])) : 0;
oStockDetails.TotalQuantity = Helper.ColumnExists(reader, "TotalQuantity") ? ((reader["TotalQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalQuantity"])) : 0;
oStockDetails.TotalPaid = Helper.ColumnExists(reader, "TotalPaid") ? ((reader["TotalPaid"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPaid"])) : 0;
oStockDetails.StockPrice = Helper.ColumnExists(reader, "StockPrice") ? ((reader["StockPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["StockPrice"])) : 0;
oStockDetails.TransPrice = Helper.ColumnExists(reader, "TransPrice") ? ((reader["TransPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TransPrice"])) : 0;
oStockDetails.TotalPrice = Helper.ColumnExists(reader, "TotalPrice") ? ((reader["TotalPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPrice"])) : 0;
oStockDetails.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oStockDetails.StockStutes = Helper.ColumnExists(reader, "StockStutes") ? ((reader["StockStutes"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StockStutes"])) : false;
oStockDetails.Date = Helper.ColumnExists(reader, "Date") ? reader["Date"].ToString() : "";
oStockDetails.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oStockDetails.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oStockDetails.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oStockDetails.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oStockDetails.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oStockDetails.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oStockDetails.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oStockDetails.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oStockDetails;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name StockDetails
/// </summary>
/// <returns>List ofStockDetails</returns>
public async Task<IEnumerable<StockDetails>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_StockDetails");
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
