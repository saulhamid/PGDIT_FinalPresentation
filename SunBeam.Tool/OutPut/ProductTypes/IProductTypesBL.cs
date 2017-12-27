using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductTypesBL
{
Task<string> InsertProductTypes(ProductTypes entity);
Task<string> UpdateProductTypes(ProductTypes entity);
Task<string> IsDeleteProductTypes(string[] IdList,ProductTypes entity);
Task<string> DeleteProductTypes(int Id);
Task<IEnumerable<ProductTypes>> GetAllProductTypes();
Task<ProductTypes> GetProductTypesById(int Id);
Task<IEnumerable<ProductTypes>> DropDownProductTypes();
  }
}
