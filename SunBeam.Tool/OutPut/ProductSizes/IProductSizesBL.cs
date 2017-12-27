using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductSizesBL
{
Task<string> InsertProductSizes(ProductSizes entity);
Task<string> UpdateProductSizes(ProductSizes entity);
Task<string> IsDeleteProductSizes(string[] IdList,ProductSizes entity);
Task<string> DeleteProductSizes(int Id);
Task<IEnumerable<ProductSizes>> GetAllProductSizes();
Task<ProductSizes> GetProductSizesById(int Id);
Task<IEnumerable<ProductSizes>> DropDownProductSizes();
  }
}
