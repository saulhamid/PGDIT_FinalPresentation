using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunBeam.Data.Repositories.Interfaces
{
   public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<string> Insert(T Entity);
        Task<string> IsDelete(int Id, T Entity);
        Task<string> Delete(int Id);
        Task<string> Update(T Entity);
        T Mapping(SqlDataReader sqldatareader);
    }
}
