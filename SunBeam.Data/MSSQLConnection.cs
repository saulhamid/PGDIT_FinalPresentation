using System;
using System.Data.SqlClient;
using System.Configuration;

namespace SunBeam.Data
{
    public static class MSSQLConnection
    {
        public static SqlConnection MSSQLConn()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conn;
        }
    }
}
