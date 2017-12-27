using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IPurcheaseReturnsBL
{
Task<string> InsertPurcheaseReturns(PurcheaseReturns entity);
Task<string> UpdatePurcheaseReturns(PurcheaseReturns entity);
Task<string> IsDeletePurcheaseReturns(string[] IdList,PurcheaseReturns entity);
Task<string> DeletePurcheaseReturns(int Id);
Task<IEnumerable<PurcheaseReturns>> GetAllPurcheaseReturns();
Task<PurcheaseReturns> GetPurcheaseReturnsById(int Id);
Task<IEnumerable<PurcheaseReturns>> DropDownPurcheaseReturns();
  }
}
