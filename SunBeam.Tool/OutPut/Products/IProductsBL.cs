using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IProductsBL
{
Task<string> InsertProducts(Products entity);
Task<string> UpdateProducts(Products entity);
Task<string> IsDeleteProducts(string[] IdList,Products entity);
Task<string> DeleteProducts(int Id);
Task<IEnumerable<Products>> GetAllProducts();
Task<Products> GetProductsById(int Id);
Task<IEnumerable<Products>> DropDownProducts();
  }
}
