using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IPurcheaseDetailsBL
{
Task<string> InsertPurcheaseDetails(PurcheaseDetails entity);
Task<string> UpdatePurcheaseDetails(PurcheaseDetails entity);
Task<string> IsDeletePurcheaseDetails(string[] IdList,PurcheaseDetails entity);
Task<string> DeletePurcheaseDetails(int Id);
Task<IEnumerable<PurcheaseDetails>> GetAllPurcheaseDetails();
Task<PurcheaseDetails> GetPurcheaseDetailsById(int Id);
Task<IEnumerable<PurcheaseDetails>> DropDownPurcheaseDetails();
  }
}
