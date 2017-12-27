using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface ISalesDetailsBL
{
Task<string> InsertSalesDetails(SalesDetails entity);
Task<string> UpdateSalesDetails(SalesDetails entity);
Task<string> IsDeleteSalesDetails(string[] IdList,SalesDetails entity);
Task<string> DeleteSalesDetails(int Id);
Task<IEnumerable<SalesDetails>> GetAllSalesDetails();
Task<SalesDetails> GetSalesDetailsById(int Id);
Task<IEnumerable<SalesDetails>> DropDownSalesDetails();
  }
}
