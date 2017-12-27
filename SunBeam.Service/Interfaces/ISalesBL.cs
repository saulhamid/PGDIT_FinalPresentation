using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface ISalesBL
{
Task<string> InsertSales(Sales entity);
Task<string> UpdateSales(Sales entity);
Task<string> IsDeleteSales(string[] IdList,Sales entity);
Task<string> DeleteSales(int Id);
Task<IEnumerable<Sales>> GetAllSales();
Task<Sales> GetSalesById(int Id);
Task<IEnumerable<Sales>> DropDownSales();
  }
}
