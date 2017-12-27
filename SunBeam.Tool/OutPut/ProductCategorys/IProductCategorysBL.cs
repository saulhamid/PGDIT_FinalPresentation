using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductCategorysBL
{
Task<string> InsertProductCategorys(ProductCategorys entity);
Task<string> UpdateProductCategorys(ProductCategorys entity);
Task<string> IsDeleteProductCategorys(string[] IdList,ProductCategorys entity);
Task<string> DeleteProductCategorys(int Id);
Task<IEnumerable<ProductCategorys>> GetAllProductCategorys();
Task<ProductCategorys> GetProductCategorysById(int Id);
Task<IEnumerable<ProductCategorys>> DropDownProductCategorys();
  }
}
