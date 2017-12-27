using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IPurcheaseReturnDetailsBL
{
Task<string> InsertPurcheaseReturnDetails(PurcheaseReturnDetails entity);
Task<string> UpdatePurcheaseReturnDetails(PurcheaseReturnDetails entity);
Task<string> IsDeletePurcheaseReturnDetails(string[] IdList,PurcheaseReturnDetails entity);
Task<string> DeletePurcheaseReturnDetails(int Id);
Task<IEnumerable<PurcheaseReturnDetails>> GetAllPurcheaseReturnDetails();
Task<PurcheaseReturnDetails> GetPurcheaseReturnDetailsById(int Id);
Task<IEnumerable<PurcheaseReturnDetails>> DropDownPurcheaseReturnDetails();
  }
}
