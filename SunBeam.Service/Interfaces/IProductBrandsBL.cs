using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductBrandsBL
{
Task<string> InsertProductBrands(ProductBrand entity);
Task<string> UpdateProductBrands(ProductBrand entity);
Task<string> IsDeleteProductBrands(string[] IdList,ProductBrand entity);
Task<string> DeleteProductBrands(int Id);
Task<IEnumerable<ProductBrand>> GetAllProductBrands();
Task<ProductBrand> GetProductBrandsById(int Id);
Task<IEnumerable<ProductBrand>> DropDownProductBrands();
  }
}
