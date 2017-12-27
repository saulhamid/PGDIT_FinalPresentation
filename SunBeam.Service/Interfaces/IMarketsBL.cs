using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IMarketsBL
{
Task<string> InsertMarkets(Markets entity);
Task<string> UpdateMarkets(Markets entity);
Task<string> IsDeleteMarkets(string[] IdList,Markets entity);
Task<string> DeleteMarkets(int Id);
Task<IEnumerable<Markets>> GetAllMarkets();
Task<Markets> GetMarketsById(int Id);
Task<IEnumerable<Markets>> DropDownMarkets();
  }
}
