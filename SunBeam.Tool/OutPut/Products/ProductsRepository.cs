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


public class ProductsRepository : DBGeneric<Products>, IRepository<Products>
{

protected ILogger Logger { get; set; }

public ProductsRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Products
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(Products entity)
{
try
{
var cmd = new SqlCommand("sp_Products");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@Code", entity.Code);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@UOMId", entity.UOMId);
cmd.Parameters.AddWithValue("@ProductBrandId", entity.ProductBrandId);
cmd.Parameters.AddWithValue("@ProductCatagoriesId", entity.ProductCatagoriesId);
cmd.Parameters.AddWithValue("@ProductColorId", entity.ProductColorId);
cmd.Parameters.AddWithValue("@ProductSizeId", entity.ProductSizeId);
cmd.Parameters.AddWithValue("@ProductTypeId", entity.ProductTypeId);
cmd.Parameters.AddWithValue("@SupplierName", entity.SupplierName);
cmd.Parameters.AddWithValue("@SupplierId", entity.SupplierId);
cmd.Parameters.AddWithValue("@MinimumStock", entity.MinimumStock);
cmd.Parameters.AddWithValue("@OtherCost", entity.OtherCost);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@UnitePrice", entity.UnitePrice);
cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
cmd.Parameters.AddWithValue("@OpeningQuantity", entity.OpeningQuantity);
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
/// Update Products
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(Products entity)
{
try
{
var cmd = new SqlCommand("sp_Products");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@Code", entity.Code);
cmd.Parameters.AddWithValue("@Name", entity.Name);
cmd.Parameters.AddWithValue("@UOMId", entity.UOMId);
cmd.Parameters.AddWithValue("@ProductBrandId", entity.ProductBrandId);
cmd.Parameters.AddWithValue("@ProductCatagoriesId", entity.ProductCatagoriesId);
cmd.Parameters.AddWithValue("@ProductColorId", entity.ProductColorId);
cmd.Parameters.AddWithValue("@ProductSizeId", entity.ProductSizeId);
cmd.Parameters.AddWithValue("@ProductTypeId", entity.ProductTypeId);
cmd.Parameters.AddWithValue("@SupplierName", entity.SupplierName);
cmd.Parameters.AddWithValue("@SupplierId", entity.SupplierId);
cmd.Parameters.AddWithValue("@MinimumStock", entity.MinimumStock);
cmd.Parameters.AddWithValue("@OtherCost", entity.OtherCost);
cmd.Parameters.AddWithValue("@Discount", entity.Discount);
cmd.Parameters.AddWithValue("@UnitePrice", entity.UnitePrice);
cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
cmd.Parameters.AddWithValue("@OpeningQuantity", entity.OpeningQuantity);
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
/// Delete Products
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_Products");
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
/// Delete Products
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,Products entity)
{
try
{
var cmd = new SqlCommand("sp_Products");
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
/// Get All Products
/// </summary>
/// <returns>List ofProducts</returns>
public async Task<IEnumerable<Products>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_Products");
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
/// Get Products by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>Products Object</returns>
public async Task<Products> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_Products");
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
/// Data Mapping for Products
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>Products Object</returns>
public Products Mapping(SqlDataReader reader)
{
try
{
Products oProducts = new Products();
oProducts.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oProducts.Code = Helper.ColumnExists(reader, "Code") ? reader["Code"].ToString() : "";
oProducts.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
oProducts.UOMId = Helper.ColumnExists(reader, "UOMId") ? ((reader["UOMId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UOMId"])) : 0 ;
oProducts.ProductBrandId = Helper.ColumnExists(reader, "ProductBrandId") ? ((reader["ProductBrandId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductBrandId"])) : 0 ;
oProducts.ProductCatagoriesId = Helper.ColumnExists(reader, "ProductCatagoriesId") ? ((reader["ProductCatagoriesId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductCatagoriesId"])) : 0 ;
oProducts.ProductColorId = Helper.ColumnExists(reader, "ProductColorId") ? ((reader["ProductColorId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductColorId"])) : 0 ;
oProducts.ProductSizeId = Helper.ColumnExists(reader, "ProductSizeId") ? ((reader["ProductSizeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductSizeId"])) : 0 ;
oProducts.ProductTypeId = Helper.ColumnExists(reader, "ProductTypeId") ? ((reader["ProductTypeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductTypeId"])) : 0 ;
oProducts.SupplierName = Helper.ColumnExists(reader, "SupplierName") ? reader["SupplierName"].ToString() : "";
oProducts.SupplierId = Helper.ColumnExists(reader, "SupplierId") ? ((reader["SupplierId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplierId"])) : 0 ;
oProducts.MinimumStock = Helper.ColumnExists(reader, "MinimumStock") ? ((reader["MinimumStock"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["MinimumStock"])) : 0 ;
oProducts.OtherCost = Helper.ColumnExists(reader, "OtherCost") ? ((reader["OtherCost"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["OtherCost"])) : 0;
oProducts.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
oProducts.UnitePrice = Helper.ColumnExists(reader, "UnitePrice") ? ((reader["UnitePrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["UnitePrice"])) : 0;
oProducts.Quantity = Helper.ColumnExists(reader, "Quantity") ? ((reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Quantity"])) : 0;
oProducts.OpeningQuantity = Helper.ColumnExists(reader, "OpeningQuantity") ? ((reader["OpeningQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["OpeningQuantity"])) : 0;
oProducts.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oProducts.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oProducts.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oProducts.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oProducts.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oProducts.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oProducts.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oProducts.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oProducts.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oProducts;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name Products
/// </summary>
/// <returns>List ofProducts</returns>
public async Task<IEnumerable<Products>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_Products");
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
