using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface ISuppliersBL
{
Task<string> InsertSuppliers(Suppliers entity);
Task<string> UpdateSuppliers(Suppliers entity);
Task<string> IsDeleteSuppliers(string[] IdList,Suppliers entity);
Task<string> DeleteSuppliers(int Id);
Task<IEnumerable<Suppliers>> GetAllSuppliers();
Task<Suppliers> GetSuppliersById(int Id);
Task<IEnumerable<Suppliers>> DropDownSuppliers();
  }
}
