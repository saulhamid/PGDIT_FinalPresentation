using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductTypesBL
{
Task<string> InsertProductTypes(ProductType entity);
Task<string> UpdateProductTypes(ProductType entity);
Task<string> IsDeleteProductTypes(string[] IdList,ProductType entity);
Task<string> DeleteProductTypes(int Id);
Task<IEnumerable<ProductType>> GetAllProductTypes();
Task<ProductType> GetProductTypesById(int Id);
Task<IEnumerable<ProductType>> DropDownProductTypes();
  }
}
