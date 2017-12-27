using System;
using System.Data.SqlClient;

namespace SunBeam.Common.Utility
{
    public static class Helper
    {
        public static bool ColumnExists(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))    //reader.GetName(i) == columnName
                {
                    return true;
                }
            }
            return false;
        }
    }
}
