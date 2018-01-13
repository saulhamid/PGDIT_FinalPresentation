using SunBeam.Domain.Models;
using SunBeam.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IStocksBL
{
Task<string> InsertStocks(StockVM entity);
Task<string> UpdateStocks(StockVM entity);
Task<string> IsDeleteStocks(string[] IdList, StockVM entity);
Task<string> DeleteStocks(int Id);
Task<IEnumerable<StockVM>> GetAllStocks();
Task<StockVM> GetStocksById(int Id);
Task<IEnumerable<StockVM>> DropDownStocks();
  }
}
