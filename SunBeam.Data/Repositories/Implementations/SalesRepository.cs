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


public class SalesRepository : DBGeneric<Sales>, IRepository<Sales>
{

protected ILogger Logger { get; set; }

public SalesRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Sales
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(Sales entity)
{
try
{
var cmd = new SqlCommand("sp_Sales");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@InvoiecNo", entity.InvoiecNo);
cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
cmd.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
cmd.Parameters.AddWithValue("@ZoneOrAreaId", entity.ZoneOrAreaId);
cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@TotalDiscount", entity.TotalDiscount);
cmd.Parameters.AddWithValue("@TotalPaid", entity.TotalPaid);
cmd.Parameters.AddWithValue("@GrandTotal", entity.GrandTotal);
cmd.Parameters.AddWithValue("@Date", entity.Date);
cmd.Parameters.AddWithValue("@PackUnitPrice", entity.PackUnitPrice);
cmd.Parameters.AddWithValue("@PackQuantity", entity.PackQuantity);
cmd.Parameters.AddWithValue("@EventName", entity.EventName);
cmd.Parameters.AddWithValue("@EventAamount", entity.EventAamount);
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
/// Update Sales
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(Sales entity)
{
try
{
var cmd = new SqlCommand("sp_Sales");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@InvoiecNo", entity.InvoiecNo);
cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
cmd.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
cmd.Parameters.AddWithValue("@ZoneOrAreaId", entity.ZoneOrAreaId);
cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@TotalDiscount", entity.TotalDiscount);
cmd.Parameters.AddWithValue("@TotalPaid", entity.TotalPaid);
cmd.Parameters.AddWithValue("@GrandTotal", entity.GrandTotal);
cmd.Parameters.AddWithValue("@Date", entity.Date);
cmd.Parameters.AddWithValue("@PackUnitPrice", entity.PackUnitPrice);
cmd.Parameters.AddWithValue("@PackQuantity", entity.PackQuantity);
cmd.Parameters.AddWithValue("@EventName", entity.EventName);
cmd.Parameters.AddWithValue("@EventAamount", entity.EventAamount);
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
/// Delete Sales
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_Sales");
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
/// Delete Sales
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,Sales entity)
{
try
{
var cmd = new SqlCommand("sp_Sales");
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
/// Get All Sales
/// </summary>
/// <returns>List ofSales</returns>
public async Task<IEnumerable<Sales>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_Sales");
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
/// Get Sales by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Sales Object</returns>
public async Task<Sales> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_Sales");
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
/// Data Mapping for Sales
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>Sales Object</returns>
public Sales Mapping(SqlDataReader reader)
{
try
{
Sales oSales = new Sales();
oSales.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oSales.InvoiecNo = Helper.ColumnExists(reader, "InvoiecNo") ? reader["InvoiecNo"].ToString() : "";
oSales.ProductId = Helper.ColumnExists(reader, "ProductId") ? ((reader["ProductId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductId"])) : 0 ;
oSales.CustomerId = Helper.ColumnExists(reader, "CustomerId") ? ((reader["CustomerId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CustomerId"])) : 0 ;
oSales.MarketId = Helper.ColumnExists(reader, "MarketId") ? ((reader["MarketId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["MarketId"])) : 0;
                oSales.ZoneOrAreaId = Helper.ColumnExists(reader, "ZoneOrAreaId") ? ((reader["ZoneOrAreaId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ZoneOrAreaId"])) : 0 ;
oSales.EmployeeId = Helper.ColumnExists(reader, "EmployeeId") ? ((reader["EmployeeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["EmployeeId"])) : 0 ;
oSales.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
oSales.TotalDiscount = Helper.ColumnExists(reader, "TotalDiscount") ? ((reader["TotalDiscount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalDiscount"])) : 0;
oSales.TotalPaid = Helper.ColumnExists(reader, "TotalPaid") ? ((reader["TotalPaid"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPaid"])) : 0;
oSales.GrandTotal = Helper.ColumnExists(reader, "GrandTotal") ? ((reader["GrandTotal"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["GrandTotal"])) : 0;
oSales.Date = Helper.ColumnExists(reader, "Date") ? reader["Date"].ToString() : "";
oSales.PackUnitPrice = Helper.ColumnExists(reader, "PackUnitPrice") ? ((reader["PackUnitPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["PackUnitPrice"])) : 0;
oSales.PackQuantity = Helper.ColumnExists(reader, "PackQuantity") ? ((reader["PackQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["PackQuantity"])) : 0;
oSales.EventName = Helper.ColumnExists(reader, "EventName") ? reader["EventName"].ToString() : "";
oSales.EventAamount = Helper.ColumnExists(reader, "EventAamount") ? ((reader["EventAamount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["EventAamount"])) : 0;
oSales.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oSales.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oSales.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oSales.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oSales.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oSales.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oSales.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oSales.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oSales.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
oSales.CustomerName = Helper.ColumnExists(reader, "CustomerName") ? reader["CustomerName"].ToString() : "";
oSales.EmployeeName = Helper.ColumnExists(reader, "EmployeeName") ? reader["EmployeeName"].ToString() : "";
oSales.ZoneOrAreaName = Helper.ColumnExists(reader, "ZoneOrAreaName") ? reader["ZoneOrAreaName"].ToString() : "";
oSales.MarketName = Helper.ColumnExists(reader, "MarketName") ? reader["MarketName"].ToString() : "";
       return oSales;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name Sales
/// </summary>
/// <returns>List ofSales</returns>
public async Task<IEnumerable<Sales>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_Sales");
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
