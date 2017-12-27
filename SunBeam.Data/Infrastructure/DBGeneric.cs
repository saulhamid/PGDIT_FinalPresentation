using SunBeam.Common.Log;
using SunBeam.Common.Utility;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SunBeam.Data.Infrastructure
{
  public class DBGeneric<TEntity> where TEntity : class
    {
        private static SqlConnection con = MSSQLConnection.MSSQLConn();
        public Logger logger { get; set; }
        public DBGeneric()
        {
            logger = new Logger();
        }
        #region Execute Inline Query
        /// <summary>
        /// Get All
        /// </summary>
        /// <param name="strText"> sql Query</param>
        /// <returns> result </returns>
        public virtual async Task<SqlDataReader> GetDataReader(string strText)
        {
            SqlDataReader sqlreader;
            try
            {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(strText);
                cmd.Connection = con;
                sqlreader = cmd.ExecuteReader();
                try
                {
                    while (sqlreader.Read())
                    {
                        return await Task.FromResult(sqlreader);
                    }
                }
                finally
                {
                    sqlreader.Close();
                }
            }
            finally
            {
                con.Close();
            }
            return await Task.FromResult(sqlreader);
        }

        /// <summary>
        /// ExecuteText (Only execute)
        /// </summary>
        /// <param name="strText">sql query</param>
        /// <returns>result</returns>
        public virtual async Task<int> ExecuteText(string strText)
        {
            try
            {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(strText);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                return await Task.FromResult(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
                //return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// GetReult
        /// </summary>
        /// <param name="strText">sql query</param>
        /// <returns>result</returns>
        public virtual async Task<dynamic> GetResultByExecuteText(string strText)
        {
            dynamic record = null;
            try
            {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(strText);
                cmd.Connection = con;
                var reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = (reader[0] == DBNull.Value) ? 0 : reader[0];
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                con.Close();
            }
            return await Task.FromResult(record);
        }
        #endregion  Execute Inline Query


        #region Execute Stored Procedure 

        /// <summary>
        /// ExecuteNonQueryProc
        /// </summary>
        /// <param name="cmd"> sql command</param>
        /// <returns>result</returns>
        public virtual async Task<string> ExecuteNonQueryProc(SqlCommand cmd)
        {
            try
            {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                await Task.FromResult(cmd.ExecuteNonQuery());
                return (string)cmd.Parameters["@Msg"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
                //return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Get By ExecuteStore Procedure
        /// </summary>
        /// <param name="cmd">sql command</param>
        /// <returns>result Tentity</returns>
        public async Task<IEnumerable<TEntity>> GetDataReaderProc(SqlCommand cmd)
        {
            var list = new List<TEntity>();
            try
            {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                try
                {
                    //list = DynamicMappingList<TEntity>(reader);

                    while (reader.Read())
                    {
                        list.Add(PopulateRecord(reader, typeof(TEntity).Name));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return await Task.FromResult(list);
        }
        public virtual async Task<TEntity> GetByDataReaderProc(SqlCommand cmd)
        {
            //var list = new List<TEntity>();
            TEntity record = null;
            try
            {
                if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
                try
                {
                    //record = DynamicMapping<TEntity>(reader);
                    while (reader.Read())
                    {
                        record = PopulateRecord(reader, typeof(TEntity).Name);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return await Task.FromResult(record);
        }
        #endregion Execute Stored Procedure

        public virtual dynamic PopulateRecord(SqlDataReader sqldatareader, string TableName)
        {
            try
            {
                switch (TableName)
                {
                  
                    case "EnumCountry": return new EnumCountryRepository(logger).Mapping(sqldatareader);
                    case "ProductColor": return new ProductColorRepository(logger).Mapping(sqldatareader);
                    case "Customers": return new CustomersRepository(logger).Mapping(sqldatareader);
                    case "Employee": return new EmployeeRepository(logger).Mapping(sqldatareader);
                    case "ZoneOrAreas": return new ZoneOrAreasRepository(logger).Mapping(sqldatareader);
                    case "Markets": return new MarketsRepository(logger).Mapping(sqldatareader); 
                    case "ProductBrand": return new ProductBrandsRepository(logger).Mapping(sqldatareader); 
                    case "ProductSize": return new ProductSizeRepository(logger).Mapping(sqldatareader);
                    case "ProductType": return new ProductTypesRepository(logger).Mapping(sqldatareader);
                    case "UOM": return new UOMRepository(logger).Mapping(sqldatareader);
                    case "Products": return new ProductsRepository(logger).Mapping(sqldatareader);
                    case "Suppliers": return new SuppliersRepository(logger).Mapping(sqldatareader);
                    case "ProductCategory": return new ProductCategorysRepository(logger).Mapping(sqldatareader);
                    case "Purchases": return new PurchasesRepository(logger).Mapping(sqldatareader);
                    case "PurcheaseDetails": return new PurcheaseDetailsRepository(logger).Mapping(sqldatareader);
                    case "Stocks": return new StocksRepository(logger).Mapping(sqldatareader);
                    case "PurcheaseReturns": return new PurcheaseReturnsRepository(logger).Mapping(sqldatareader);
                    case "PurcheaseReturnDetails": return new PurcheaseReturnDetailsRepository(logger).Mapping(sqldatareader);
                    case "Sales": return new SalesRepository(logger).Mapping(sqldatareader);
                    case "SalesDetails": return new SalesDetailsRepository(logger).Mapping(sqldatareader); 
                    case "StockDetails": return new StockDetailsRepository(logger).Mapping(sqldatareader); 
                    default: return null;
                }
            }
            catch (Exception ex)
            {
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
                //Logger.Error(ex.Message);
                throw ex;
            }
        }
    }
}

