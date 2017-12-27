using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductDetailsBL
{
Task<string> InsertProductDetails(ProductDetails entity);
Task<string> UpdateProductDetails(ProductDetails entity);
Task<string> IsDeleteProductDetails(string[] IdList,ProductDetails entity);
Task<string> DeleteProductDetails(int Id);
Task<IEnumerable<ProductDetails>> GetAllProductDetails();
Task<ProductDetails> GetProductDetailsById(int Id);
Task<IEnumerable<ProductDetails>> DropDownProductDetails();
  }
}
