using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductBrandsBL
{
Task<string> InsertProductBrands(ProductBrands entity);
Task<string> UpdateProductBrands(ProductBrands entity);
Task<string> IsDeleteProductBrands(string[] IdList,ProductBrands entity);
Task<string> DeleteProductBrands(int Id);
Task<IEnumerable<ProductBrands>> GetAllProductBrands();
Task<ProductBrands> GetProductBrandsById(int Id);
Task<IEnumerable<ProductBrands>> DropDownProductBrands();
  }
}
