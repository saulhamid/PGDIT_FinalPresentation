using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IPurchasesBL
{
Task<string> InsertPurchases(Purchases entity);
Task<string> UpdatePurchases(Purchases entity);
Task<string> IsDeletePurchases(string[] IdList,Purchases entity);
Task<string> DeletePurchases(int Id);
Task<IEnumerable<Purchases>> GetAllPurchases();
Task<Purchases> GetPurchasesById(int Id);
Task<IEnumerable<Purchases>> DropDownPurchases();
  }
}
