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


    public class ProductColorRepository : DBGeneric<ProductColor>, IRepository<ProductColor>
    {

        protected ILogger Logger { get; set; }

        public ProductColorRepository(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Insert ProductColor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Insert(ProductColor entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_ProductColor");
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Code", entity.Code);
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
        /// Update ProductColor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Update(ProductColor entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_ProductColor");
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Code", entity.Code);
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
        /// Delete ProductColor
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> Delete(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_ProductColor");
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
        /// Delete ProductColor
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDelete(int Id, ProductColor entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_ProductColor");
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
        /// Get All ProductColor
        /// </summary>
        /// <returns>List ofProductColor</returns>
        public async Task<IEnumerable<ProductColor>> GetAll()
        {
            try
            {
                var cmd = new SqlCommand("sp_ProductColor");
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
        /// Get ProductColor by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>ProductColor Object</returns>
        public async Task<ProductColor> GetById(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_ProductColor");
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
        /// Data Mapping for ProductColor
        /// </summary>
        /// <param name="sqldatareader"></param>
        /// <returns>ProductColor Object</returns>
        public ProductColor Mapping(SqlDataReader reader)
        {
            try
            {
                ProductColor oProductColor = new ProductColor();
                oProductColor.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0;
                oProductColor.Code = Helper.ColumnExists(reader, "Code") ? reader["Code"].ToString() : "";
                oProductColor.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
                oProductColor.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
                oProductColor.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
                oProductColor.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
                oProductColor.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
                oProductColor.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
                oProductColor.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
                oProductColor.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
                oProductColor.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
                oProductColor.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
                return oProductColor;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get Id, Name ProductColor
        /// </summary>
        /// <returns>List ofProductColor</returns>
        public async Task<IEnumerable<ProductColor>> Dropdown()
        {
            try
            {
                var cmd = new SqlCommand("sp_ProductColor");
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
