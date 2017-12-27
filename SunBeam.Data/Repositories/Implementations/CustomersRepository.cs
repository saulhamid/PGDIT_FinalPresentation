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


    public class CustomersRepository : DBGeneric<Customers>, IRepository<Customers>
    {

        protected ILogger Logger { get; set; }

        public CustomersRepository(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Insert Customers
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Insert(Customers entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_Customers");
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Code", entity.Code);
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@CountryId", entity.CountryId);
                cmd.Parameters.AddWithValue("@DivisionId", entity.DivisionId);
                cmd.Parameters.AddWithValue("@DistrictId", entity.DistrictId);
                cmd.Parameters.AddWithValue("@Mobile", entity.Mobile);
                cmd.Parameters.AddWithValue("@PermanentAddress", entity.PermanentAddress);
                cmd.Parameters.AddWithValue("@PresentAddress", entity.PresentAddress);
                cmd.Parameters.AddWithValue("@PABX", entity.PABX);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@FAX", entity.FAX);
                cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
                cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
                cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
                cmd.Parameters.AddWithValue("@CreatedFrom", entity.CreatedFrom);
               

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
        /// Update Customers
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> Update(Customers entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_Customers");
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Code", entity.Code);
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@CountryId", entity.CountryId);
                cmd.Parameters.AddWithValue("@DivisionId", entity.DivisionId);
                cmd.Parameters.AddWithValue("@DistrictId", entity.DistrictId);
                cmd.Parameters.AddWithValue("@Mobile", entity.Mobile);
                cmd.Parameters.AddWithValue("@PermanentAddress", entity.PermanentAddress);
                cmd.Parameters.AddWithValue("@PresentAddress", entity.PresentAddress);
                cmd.Parameters.AddWithValue("@PABX", entity.PABX);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@FAX", entity.FAX);
                cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
                cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
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
        /// Delete Customers
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> Delete(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_Customers");
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
        /// Delete Customers
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDelete(int Id, Customers entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_Customers");
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
        /// Get All Customers
        /// </summary>
        /// <returns>List ofCustomers</returns>
        public async Task<IEnumerable<Customers>> GetAll()
        {
            try
            {
                var cmd = new SqlCommand("sp_Customers");
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
        /// Get Customers by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Customers Object</returns>
        public async Task<Customers> GetById(int Id)
        {
            try
            {
                var cmd = new SqlCommand("sp_Customers");
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
        /// Customer Filter
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<IEnumerable<Customers>> CustomerFilter(Customers entity ,string spName)
        {
            try
            {
                var cmd = new SqlCommand(spName);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Code", entity.Code);
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@CountryId", entity.CountryId);
                cmd.Parameters.AddWithValue("@DivisionId", entity.DivisionId);
                cmd.Parameters.AddWithValue("@DistrictId", entity.DistrictId);
                cmd.Parameters.AddWithValue("@Mobile", entity.Mobile);
                cmd.Parameters.AddWithValue("@PermanentAddress", entity.PermanentAddress);
                cmd.Parameters.AddWithValue("@PresentAddress", entity.PresentAddress);
                cmd.Parameters.AddWithValue("@PABX", entity.PABX);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@FAX", entity.FAX);
                cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
                cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
                cmd.Parameters.AddWithValue("@IsArchive", entity.IsArchive);
                cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
                cmd.Parameters.AddWithValue("@CreatedFrom", entity.CreatedFrom);
                cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);
                cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@pOptions", 1);
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
        /// Data Mapping for Customers
        /// </summary>
        /// <param name="sqldatareader"></param>
        /// <returns>Customers Object</returns>
        public Customers Mapping(SqlDataReader reader)
        {
            try
            {
                Customers oCustomers = new Customers();
                oCustomers.Id = Helper.ColumnExists(reader, "Id") ? ((reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"])) : 0;
                oCustomers.Code = Helper.ColumnExists(reader, "Code") ? reader["Code"].ToString() : "";
                oCustomers.Name = Helper.ColumnExists(reader, "Name") ? reader["Name"].ToString() : "";
                oCustomers.CountryId = Helper.ColumnExists(reader, "CountryId") ? ((reader["CountryId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CountryId"])) : 0;
                oCustomers.DivisionId = Helper.ColumnExists(reader, "DivisionId") ? ((reader["DivisionId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DivisionId"])) : 0;
                oCustomers.DistrictId = Helper.ColumnExists(reader, "DistrictId") ? ((reader["DistrictId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DistrictId"])) : 0;
                oCustomers.Mobile = Helper.ColumnExists(reader, "Mobile") ? reader["Mobile"].ToString() : "";
                oCustomers.PermanentAddress = Helper.ColumnExists(reader, "PermanentAddress") ? reader["PermanentAddress"].ToString() : "";
                oCustomers.PresentAddress = Helper.ColumnExists(reader, "PresentAddress") ? reader["PresentAddress"].ToString() : "";
                oCustomers.PABX = Helper.ColumnExists(reader, "PABX") ? reader["PABX"].ToString() : "";
                oCustomers.Email = Helper.ColumnExists(reader, "Email") ? reader["Email"].ToString() : "";
                oCustomers.FAX = Helper.ColumnExists(reader, "FAX") ? reader["FAX"].ToString() : "";
                oCustomers.Remarks = Helper.ColumnExists(reader, "Remarks") ? reader["Remarks"].ToString() : "";
                oCustomers.IsActive = Helper.ColumnExists(reader, "IsActive") ? ((reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"])) : false;
                oCustomers.IsArchive = Helper.ColumnExists(reader, "IsArchive") ? ((reader["IsArchive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsArchive"])) : false;
                oCustomers.CreatedBy = Helper.ColumnExists(reader, "CreatedBy") ? reader["CreatedBy"].ToString() : "";
                oCustomers.CreatedAt = Helper.ColumnExists(reader, "CreatedAt") ? reader["CreatedAt"].ToString() : "";
                oCustomers.CreatedFrom = Helper.ColumnExists(reader, "CreatedFrom") ? reader["CreatedFrom"].ToString() : "";
                oCustomers.LastUpdateBy = Helper.ColumnExists(reader, "LastUpdateBy") ? reader["LastUpdateBy"].ToString() : "";
                oCustomers.LastUpdateAt = Helper.ColumnExists(reader, "LastUpdateAt") ? reader["LastUpdateAt"].ToString() : "";
                oCustomers.LastUpdateFrom = Helper.ColumnExists(reader, "LastUpdateFrom") ? reader["LastUpdateFrom"].ToString() : "";
                return oCustomers;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get Id, Name Customers
        /// </summary>
        /// <returns>List ofCustomers</returns>
        public async Task<IEnumerable<Customers>> Dropdown()
        {
            try
            {
                var cmd = new SqlCommand("sp_Customers");
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
