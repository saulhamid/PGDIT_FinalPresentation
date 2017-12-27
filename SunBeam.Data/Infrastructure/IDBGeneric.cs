using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunBeam.Data.Infrastructure
{
   public interface IDBGeneric<TEntity> where TEntity : class
    {
        //Execute Inline Query
        Task<IEnumerable<TEntity>> GetAllExecuteText(string strText);
        Task<TEntity> GetByIDExecuteText(string strText);
        Task<int> ExecuteText(string strText);
        Task<dynamic> GetResultByExecuteText(string strText);
        //End of Execute Inline Query

        //Execute Stored Procedure
        Task<dynamic> ExecuteStoredProc(SqlCommand cmd);
        Task<TEntity> GetByExecuteStoredProc(SqlCommand cmd);
        Task<IEnumerable<TEntity>> GetAllExecuteStoredProc(SqlCommand cmd);
        Task<Tuple<string, int, bool, dynamic>> GetResultByExecuteStoredProc(SqlCommand cmd);
    }
}
