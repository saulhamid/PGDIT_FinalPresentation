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


public class PaymentTypeRepository : DBGeneric<PaymentType>, IRepository<PaymentType>
{

protected ILogger Logger { get; set; }

public PaymentTypeRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert PaymentType
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(PaymentType entity)
{
try
{
var cmd = new SqlCommand("sp_PaymentType");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@Name", entity.Name);
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
/// Update PaymentType
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(PaymentType entity)
{
try
{
var cmd = new SqlCommand("sp_PaymentType");
cmd.Parameters.AddWithValue("@Id", entity.Id);
cmd.Parameters.AddWithValue("@Name", entity.Name);
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
/// Delete PaymentType
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> Delete(int Id)
{
try
{
var cmd = new SqlCommand("sp_PaymentType");
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
/// Delete PaymentType
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDelete(int Id,PaymentType entity)
{
try
{
var cmd = new SqlCommand("sp_PaymentType");
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
/// Get All PaymentType
/// </summary>
/// <returns>List ofPaymentType</returns>
public async Task<IEnumerable<PaymentType>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_PaymentType");
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
/// Get PaymentType by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>PaymentType Object</returns>
public async Task<PaymentType> GetById(int Id)
{
try
{
var cmd = new SqlCommand("sp_PaymentType");
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
/// Data Mapping for PaymentType
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>PaymentType Object</returns>
public PaymentType Mapping(SqlDataReader reader)
{
try
{
PaymentType oPaymentType = new PaymentType();
oPaymentType.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0 ;
oPaymentType.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
oPaymentType.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
oPaymentType.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
oPaymentType.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
oPaymentType.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
oPaymentType.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
oPaymentType.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
oPaymentType.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
oPaymentType.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
oPaymentType.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
return oPaymentType;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Id, Name PaymentType
/// </summary>
/// <returns>List ofPaymentType</returns>
public async Task<IEnumerable<PaymentType>> Dropdown()
{
try
{
var cmd = new SqlCommand("sp_PaymentType");
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
