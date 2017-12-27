using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductCategorysBL
{
Task<string> InsertProductCategorys(ProductCategory entity);
Task<string> UpdateProductCategorys(ProductCategory entity);
Task<string> IsDeleteProductCategorys(string[] IdList,ProductCategory entity);
Task<string> DeleteProductCategorys(int Id);
Task<IEnumerable<ProductCategory>> GetAllProductCategorys();
Task<ProductCategory> GetProductCategorysById(int Id);
Task<IEnumerable<ProductCategory>> DropDownProductCategorys();
  }
}
