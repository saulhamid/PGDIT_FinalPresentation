using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IPaymentTypeBL
{
Task<string> InsertPaymentType(PaymentType entity);
Task<string> UpdatePaymentType(PaymentType entity);
Task<string> IsDeletePaymentType(string[] IdList,PaymentType entity);
Task<string> DeletePaymentType(int Id);
Task<IEnumerable<PaymentType>> GetAllPaymentType();
Task<PaymentType> GetPaymentTypeById(int Id);
Task<IEnumerable<PaymentType>> DropDownPaymentType();
  }
}
