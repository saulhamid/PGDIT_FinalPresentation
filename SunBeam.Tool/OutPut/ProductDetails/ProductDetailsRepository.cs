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


public class ProductDetailsRepository : DBGeneric<ProductDetails>, IRepository<ProductDetails>
{

protected ILogger Logger { get; set; }

public ProductDetailsRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert ProductDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(ProductDetails entity)
{
try
{
var cmd = new SqlCommand("sp_ProductDetails");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
cmd.Parameters.AddWithValue("@UOMId", entity.UOMId);
cmd.Parameters.AddWithValue("@ProductBrandId", entity.ProductBrandId);
cmd.Parameters.AddWithValue("@ProductCatagoriesId", entity.ProductCatagoriesId);
cmd.Parameters.AddWithValue("@ProductColorId", entity.ProductColorId);
cmd.Parameters.AddWithValue("@ProductSizeId", entity.ProductSizeId);
cmd.Parameters.AddWithValue("@ProductTypeId", entity.ProductTypeId);
cmd.Parameters.AddWithValue("@SupplierId", entity.SupplierId);
cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
cmd.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
cmd.Parameters.AddWithValue("@OpenQuantity", entity.OpenQuantity);
cmd.Parameters.AddWithValue("@MinimumStock", entity.MinimumStock);
cmd.Parameters.AddWithValue("@OtherCost", entity.OtherCost);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
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
/// Update ProductDetails
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(ProductDetails entity)
{
try
{
var cmd = new SqlCommand("sp_ProductDetails");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
cmd.Parameters.AddWithValue("@UOMId", entity.UOMId);
cmd.Parameters.AddWithValue("@ProductBrandId", entity.ProductBrandId);
cmd.Parameters.AddWithValue("@ProductCatagoriesId", entity.ProductCatagoriesId);
cmd.Parameters.AddWithValue("@ProductColorId", entity.ProductColorId);
cmd.Parameters.AddWithValue("@ProductSizeId", entity.ProductSizeId);
cmd.Parameters.AddWithValue("@ProductTypeId", entity.ProductTypeId);
cmd.Parameters.AddWithValue("@SupplierId", entity.SupplierId);
cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
cmd.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
cmd.Parameters.AddWithValue("@OpenQuantity", entity.OpenQuantity);
cmd.Parameters.AddWithValue("@MinimumStock", entity.MinimumStock);
cmd.Parameters.AddWithValue("@OtherCost", entity.OtherCost);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
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
/// Delete ProductDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_ProductDetails");
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
/// Delete ProductDetails
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,ProductDetails entity)
{
try
{
var cmd = new SqlCommand("sp_ProductDetails");
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
/// Get All ProductDetails
/// </summary>
/// <returns>List ofProductDetails</returns>
public async Task<IEnumerable<ProductDetails>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_ProductDetails");
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
/// Get ProductDetails by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ProductDetails Object</returns>
public async Task<ProductDetails> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_ProductDetails");
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
/// Data Mapping for ProductDetails
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>ProductDetails Object</returns>
public ProductDetails Mapping(SqlDataReader reader)
{
try
{
ProductDetails oProductDetails = new ProductDetails();
oProductDetails.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oProductDetails.ProductId = Helper.ColumnExists(reader, "ProductId") ? ((reader["ProductId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductId"])) : 0 ;
oProductDetails.UOMId = Helper.ColumnExists(reader, "UOMId") ? ((reader["UOMId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UOMId"])) : 0 ;
oProductDetails.ProductBrandId = Helper.ColumnExists(reader, "ProductBrandId") ? ((reader["ProductBrandId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductBrandId"])) : 0 ;
oProductDetails.ProductCatagoriesId = Helper.ColumnExists(reader, "ProductCatagoriesId") ? ((reader["ProductCatagoriesId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductCatagoriesId"])) : 0 ;
oProductDetails.ProductColorId = Helper.ColumnExists(reader, "ProductColorId") ? ((reader["ProductColorId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductColorId"])) : 0 ;
oProductDetails.ProductSizeId = Helper.ColumnExists(reader, "ProductSizeId") ? ((reader["ProductSizeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductSizeId"])) : 0 ;
oProductDetails.ProductTypeId = Helper.ColumnExists(reader, "ProductTypeId") ? ((reader["ProductTypeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductTypeId"])) : 0 ;
oProductDetails.SupplierId = Helper.ColumnExists(reader, "SupplierId") ? ((reader["SupplierId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplierId"])) : 0 ;
oProductDetails.Quantity = Helper.ColumnExists(reader, "Quantity") ? ((reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Quantity"])) : 0;
oProductDetails.UnitPrice = Helper.ColumnExists(reader, "UnitPrice") ? ((reader["UnitPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["UnitPrice"])) : 0;
oProductDetails.OpenQuantity = Helper.ColumnExists(reader, "OpenQuantity") ? ((reader["OpenQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["OpenQuantity"])) : 0;
oProductDetails.MinimumStock = Helper.ColumnExists(reader, "MinimumStock") ? ((reader["MinimumStock"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["MinimumStock"])) : 0 ;
oProductDetails.OtherCost = Helper.ColumnExists(reader, "OtherCost") ? ((reader["OtherCost"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["OtherCost"])) : 0;
oProductDetails.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
oProductDetails.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oProductDetails.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oProductDetails.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oProductDetails.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oProductDetails.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oProductDetails.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oProductDetails.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oProductDetails.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oProductDetails;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name ProductDetails
/// </summary>
/// <returns>List ofProductDetails</returns>
public async Task<IEnumerable<ProductDetails>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_ProductDetails");
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
