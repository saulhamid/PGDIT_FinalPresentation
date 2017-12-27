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


    public class PurcheaseDetailsRepository : DBGeneric<PurcheaseDetails>, IRepository<PurcheaseDetails>
    {

        protected ILogger Logger { get; set; }

        public PurcheaseDetailsRepository(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Insert PurcheaseDetails
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Insert(PurcheaseDetails entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_PurcheaseDetails");
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@PurchaseId", entity.PurchaseId);
                cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
                cmd.Parameters.AddWithValue("@UnitePrice", entity.UnitePrice);
                cmd.Parameters.AddWithValue("@Date", entity.Date);
                cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
                cmd.Parameters.AddWithValue("@Discount", entity.Discount);
                cmd.Parameters.AddWithValue("@Slup", entity.Slup);
                cmd.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
                cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
                cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
                cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
                cmd.Parameters.AddWithValue("@CreatedFrom", entity.CreatedFrom);
                cmd.Parameters.AddWithValue("@CreatedAtBy", entity.CreatedAt);
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
        /// Update PurcheaseDetails
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Update(PurcheaseDetails entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_PurcheaseDetails");
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@PurchaseId", entity.PurchaseId);
                cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
                cmd.Parameters.AddWithValue("@UnitePrice", entity.UnitePrice);
                cmd.Parameters.AddWithValue("@Date", entity.Date);
                cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
                cmd.Parameters.AddWithValue("@Discount", entity.Discount);
                cmd.Parameters.AddWithValue("@Slup", entity.Slup);
                cmd.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
                cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
                cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
                cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
                cmd.Parameters.AddWithValue("@CreatedFrom", entity.CreatedFrom);
                cmd.Parameters.AddWithValue("@CreatedAtBy", entity.CreatedAt);
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
        /// Delete PurcheaseDetails
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> Delete(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_PurcheaseDetails");
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
        /// Delete PurcheaseDetails
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDelete(int Id, PurcheaseDetails entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_PurcheaseDetails");
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
        /// Get All PurcheaseDetails
        /// </summary>
        /// <returns>List ofPurcheaseDetails</returns>
        public async Task<IEnumerable<PurcheaseDetails>> GetAll()
        {
            try
            {
                var cmd = new SqlCommand("sp_PurcheaseDetails");
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
        /// Get PurcheaseDetails by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>PurcheaseDetails Object</returns>
        public async Task<PurcheaseDetails> GetById(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_PurcheaseDetails");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@pOptions", 6);
                PurcheaseDetails result = await GetByDataReaderProc(cmd);
                result.Products = await new ProductsRepository(Logger).GetById(result.ProductId);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Data Mapping for PurcheaseDetails
        /// </summary>
        /// <param name="sqldatareader"></param>
        /// <returns>PurcheaseDetails Object</returns>
        public PurcheaseDetails Mapping(SqlDataReader reader)
        {
            try
            {
                PurcheaseDetails oPurcheaseDetails = new PurcheaseDetails();
                oPurcheaseDetails.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0;
                oPurcheaseDetails.PurchaseId = Helper.ColumnExists(reader, "PurchaseId") ? ((reader["PurchaseId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PurchaseId"])) : 0;
                oPurcheaseDetails.ProductId = Helper.ColumnExists(reader, "ProductId") ? ((reader["ProductId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductId"])) : 0;
                oPurcheaseDetails.UnitePrice = Helper.ColumnExists(reader, "UnitePrice") ? ((reader["UnitePrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["UnitePrice"])) : 0;
                oPurcheaseDetails.Date = Helper.ColumnExists(reader, "Date") ? reader["Date"].ToString() : "";
                oPurcheaseDetails.Quantity = Helper.ColumnExists(reader, "Quantity") ? ((reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Quantity"])) : 0;
                oPurcheaseDetails.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
                oPurcheaseDetails.Slup = Helper.ColumnExists(reader, "Slup") ? ((reader["Slup"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Slup"])) : 0;
                oPurcheaseDetails.TotalPrice =decimal.Subtract(decimal.Multiply(oPurcheaseDetails.Quantity, oPurcheaseDetails.UnitePrice),oPurcheaseDetails.Discount);
                oPurcheaseDetails.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
                oPurcheaseDetails.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
                oPurcheaseDetails.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
                oPurcheaseDetails.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
                oPurcheaseDetails.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
                oPurcheaseDetails.CreatedAt = Helper.ColumnExists(reader, "CreatedAtBy") ? reader["CreatedAtBy"].ToString() : "";
                oPurcheaseDetails.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
                oPurcheaseDetails.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
                oPurcheaseDetails.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
                oPurcheaseDetails.ProductName = Helper.ColumnExists(reader, "ProductName") ? reader["ProductName"].ToString() : "";
                oPurcheaseDetails.ProductCode = Helper.ColumnExists(reader, "ProductCode") ? reader["ProductCode"].ToString() : "";
                return oPurcheaseDetails;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get Id, Name PurcheaseDetails
        /// </summary>
        /// <returns>List ofPurcheaseDetails</returns>
        public async Task<IEnumerable<PurcheaseDetails>> Dropdown()
        {
            try
            {
                var cmd = new SqlCommand("sp_PurcheaseDetails");
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
