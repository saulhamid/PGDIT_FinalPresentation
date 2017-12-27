using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IStocksBL
{
Task<string> InsertStocks(Stocks entity);
Task<string> UpdateStocks(Stocks entity);
Task<string> IsDeleteStocks(string[] IdList,Stocks entity);
Task<string> DeleteStocks(int Id);
Task<IEnumerable<Stocks>> GetAllStocks();
Task<Stocks> GetStocksById(int Id);
Task<IEnumerable<Stocks>> DropDownStocks();
  }
}
