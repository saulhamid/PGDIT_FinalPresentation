using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface ICustomersBL
{
Task<string> InsertCustomers(Customers entity);
Task<string> UpdateCustomers(Customers entity);
Task<string> IsDeleteCustomers(string[] IdList,Customers entity);
Task<string> DeleteCustomers(int Id);
Task<IEnumerable<Customers>> GetAllCustomers();
Task<Customers> GetCustomersById(int Id);
Task<IEnumerable<Customers>> DropDownCustomers();
  }
}
