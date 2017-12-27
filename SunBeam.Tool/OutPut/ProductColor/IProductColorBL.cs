using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductColorBL
{
Task<string> InsertProductColor(ProductColor entity);
Task<string> UpdateProductColor(ProductColor entity);
Task<string> IsDeleteProductColor(string[] IdList,ProductColor entity);
Task<string> DeleteProductColor(int Id);
Task<IEnumerable<ProductColor>> GetAllProductColor();
Task<ProductColor> GetProductColorById(int Id);
Task<IEnumerable<ProductColor>> DropDownProductColor();
  }
}
