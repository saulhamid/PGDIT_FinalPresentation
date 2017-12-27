using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductSizeBL
{
Task<string> InsertProductSize(ProductSize entity);
Task<string> UpdateProductSize(ProductSize entity);
Task<string> IsDeleteProductSize(string[] IdList,ProductSize entity);
Task<string> DeleteProductSize(int Id);
Task<IEnumerable<ProductSize>> GetAllProductSize();
Task<ProductSize> GetProductSizeById(int Id);
Task<IEnumerable<ProductSize>> DropDownProductSize();
  }
}
