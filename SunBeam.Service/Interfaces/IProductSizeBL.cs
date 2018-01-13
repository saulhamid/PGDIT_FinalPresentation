using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductSizeBL
{
Task<string> InsertProductSize(ProductSizes entity);
Task<string> UpdateProductSize(ProductSizes entity);
Task<string> IsDeleteProductSize(string[] IdList,ProductSizes entity);
Task<string> DeleteProductSize(int Id);
Task<IEnumerable<ProductSizes>> GetAllProductSize();
Task<ProductSizes> GetProductSizeById(int Id);
Task<IEnumerable<ProductSizes>> DropDownProductSize();
  }
}
