using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IStockDetailsBL
{
Task<string> InsertStockDetails(StockDetails entity);
Task<string> UpdateStockDetails(StockDetails entity);
Task<string> IsDeleteStockDetails(string[] IdList,StockDetails entity);
Task<string> DeleteStockDetails(int Id);
Task<IEnumerable<StockDetails>> GetAllStockDetails();
Task<StockDetails> GetStockDetailsById(int Id);
Task<IEnumerable<StockDetails>> DropDownStockDetails();
  }
}
