using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductTypeBL
{
Task<string> InsertProductType(ProductType entity);
Task<string> UpdateProductType(ProductType entity);
Task<string> IsDeleteProductType(string[] IdList,ProductType entity);
Task<string> DeleteProductType(int Id);
Task<IEnumerable<ProductType>> GetAllProductType();
Task<ProductType> GetProductTypeById(int Id);
Task<IEnumerable<ProductType>> DropDownProductType();
  }
}
