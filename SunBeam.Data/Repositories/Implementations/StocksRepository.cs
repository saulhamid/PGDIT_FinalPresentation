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
using SunBeam.Domain.ViewModel;

namespace SunBeam.Data.Repositories.Implementations
{


    public class StocksRepository : DBGeneric<StockVM>, IRepository<StockVM>
    {

        protected ILogger Logger { get; set; }

        public StocksRepository(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Insert Stocks
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Insert(StockVM entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_Stocks");
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
                cmd.Parameters.AddWithValue("@Replace", entity.Replace);
                cmd.Parameters.AddWithValue("@Return", entity.Return);
                cmd.Parameters.AddWithValue("@Discount", entity.Discount);
                cmd.Parameters.AddWithValue("@Slup", entity.Slup);
                cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
                cmd.Parameters.AddWithValue("@TotalPaid", entity.TotalPaid);
                cmd.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
                cmd.Parameters.AddWithValue("@GrandTotal", entity.GrandTotal);
                cmd.Parameters.AddWithValue("@Date", entity.Date);
                cmd.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
                cmd.Parameters.AddWithValue("@OpeningQuantity", entity.OpeningQuantity);
                cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
                cmd.Parameters.AddWithValue("@StockStutes", entity.StockStutes);
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
        /// Update Stocks
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Update(StockVM entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_Stocks");
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
                cmd.Parameters.AddWithValue("@Replace", entity.Replace);
                cmd.Parameters.AddWithValue("@Return", entity.Return);
                cmd.Parameters.AddWithValue("@Discount", entity.Discount);
                cmd.Parameters.AddWithValue("@Slup", entity.Slup);
                cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
                cmd.Parameters.AddWithValue("@TotalPaid", entity.TotalPaid);
                cmd.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
                cmd.Parameters.AddWithValue("@GrandTotal", entity.GrandTotal);
                cmd.Parameters.AddWithValue("@Date", entity.Date);
                cmd.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
                cmd.Parameters.AddWithValue("@OpeningQuantity", entity.OpeningQuantity);
                cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
                cmd.Parameters.AddWithValue("@StockStutes", entity.StockStutes);
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
        /// Delete Stocks
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> Delete(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_Stocks");
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
        /// Delete Stocks
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDelete(int Id, StockVM entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_Stocks");
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
        /// Get All Stocks
        /// </summary>
        /// <returns>List ofStocks</returns>
        public async Task<IEnumerable<StockVM>> GetAll()
        {
            try
            {
                var cmd = new SqlCommand("sp_Stocks");
                cmd.Parameters.AddWithValue("@pOptions", 8);
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
        /// Get Stocks by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Stocks Object</returns>
        public async Task<StockVM> GetById(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_Stocks");
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
        /// Data Mapping for Stocks
        /// </summary>
        /// <param name="sqldatareader"></param>
        /// <returns>Stocks Object</returns>
        public StockVM Mapping(SqlDataReader reader)
        {
            try
            {
                StockVM oStocks = new StockVM();
                oStocks.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0;
                oStocks.ProductId = Helper.ColumnExists(reader, "ProductId") ? ((reader["ProductId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductId"])) : 0;
                oStocks.Replace = Helper.ColumnExists(reader, "Replace") ? ((reader["Replace"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Replace"])) : 0;
                oStocks.Return = Helper.ColumnExists(reader, "Return") ? ((reader["Return"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Return"])) : 0;
                oStocks.Discount = Helper.ColumnExists(reader, "Discount") ? ((reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"])) : 0;
                oStocks.Slup = Helper.ColumnExists(reader, "Slup") ? ((reader["Slup"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Slup"])) : 0;
                oStocks.Quantity = Helper.ColumnExists(reader, "Quantity") ? ((reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Quantity"])) : 0;
                oStocks.TotalPaid = Helper.ColumnExists(reader, "TotalPaid") ? ((reader["TotalPaid"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPaid"])) : 0;
                oStocks.TotalPrice = Helper.ColumnExists(reader, "TotalPrice") ? ((reader["TotalPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPrice"])) : 0;
                oStocks.GrandTotal = Helper.ColumnExists(reader, "GrandTotal") ? ((reader["GrandTotal"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["GrandTotal"])) : 0;
                oStocks.Date = Helper.ColumnExists(reader, "Date") ? reader["Date"].ToString() : "";
                oStocks.UnitPrice = Helper.ColumnExists(reader, "UnitPrice") ? ((reader["UnitPrice"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["UnitPrice"])) : 0;
                oStocks.OpeningQuantity = Helper.ColumnExists(reader, "OpeningQuantity") ? ((reader["OpeningQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["OpeningQuantity"])) : 0;
                oStocks.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
                oStocks.StockStutes = Helper.ColumnExists(reader, "StockStutes") ? ((reader["StockStutes"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StockStutes"])) : false;
                oStocks.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
                oStocks.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
                oStocks.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
                oStocks.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
                oStocks.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
                oStocks.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
                oStocks.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
                oStocks.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
                oStocks.PurcheaseId = Helper.ColumnExists(reader, "PurcheaseId") ? ((reader["PurcheaseId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PurcheaseId"])) : 0;
                oStocks.SalesId = Helper.ColumnExists(reader, "SalesId") ? ((reader["SalesId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SalesId"])) : 0;
                oStocks.ProductName = Helper.ColumnExists(reader, "ProductName") ? reader["ProductName"].ToString() : "";

                return oStocks;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get Id, Name Stocks
        /// </summary>
        /// <returns>List ofStocks</returns>
        public async Task<IEnumerable<StockVM>> Dropdown()
        {
            try
            {
                var cmd = new SqlCommand("sp_Stocks");
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
