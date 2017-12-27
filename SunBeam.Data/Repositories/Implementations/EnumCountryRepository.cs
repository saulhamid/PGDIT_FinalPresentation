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


    public class EnumCountryRepository : DBGeneric<EnumCountry>, IRepository<EnumCountry>
    {

        protected ILogger Logger { get; set; }

        public EnumCountryRepository(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Insert EnumCountry
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Insert(EnumCountry entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_EnumCountry");
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
        /// Update EnumCountry
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Update(EnumCountry entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_EnumCountry");
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
        /// Delete EnumCountry
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> Delete(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_EnumCountry");
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
        /// Delete EnumCountry
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDelete(int Id, EnumCountry entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_EnumCountry");
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
        /// Get All EnumCountry
        /// </summary>
        /// <returns>List ofEnumCountry</returns>
        public async Task<IEnumerable<EnumCountry>> GetAll()
        {
            try
            {
                var cmd = new SqlCommand("sp_EnumCountry");
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
        /// Get EnumCountry by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>EnumCountry Object</returns>
        public async Task<EnumCountry> GetById(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_EnumCountry");
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
        /// Data Mapping for EnumCountry
        /// </summary>
        /// <param name="sqldatareader"></param>
        /// <returns>EnumCountry Object</returns>
        public EnumCountry Mapping(SqlDataReader reader)
        {
            try
            {
                EnumCountry oEnumCountry = new EnumCountry();
                oEnumCountry.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0;
                oEnumCountry.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
                oEnumCountry.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
                oEnumCountry.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
                oEnumCountry.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
                oEnumCountry.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
                oEnumCountry.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
                oEnumCountry.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
                oEnumCountry.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
                oEnumCountry.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
                oEnumCountry.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
                return oEnumCountry;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get Id, Name EnumCountry
        /// </summary>
        /// <returns>List ofEnumCountry</returns>
        public async Task<IEnumerable<EnumCountry>> Dropdown()
        {
            try
            {
                var cmd = new SqlCommand("sp_EnumCountry");
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
