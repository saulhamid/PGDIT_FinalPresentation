using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IUOMBL
{
Task<string> InsertUOM(UOM entity);
Task<string> UpdateUOM(UOM entity);
Task<string> IsDeleteUOM(string[] IdList,UOM entity);
Task<string> DeleteUOM(int Id);
Task<IEnumerable<UOM>> GetAllUOM();
Task<UOM> GetUOMById(int Id);
Task<IEnumerable<UOM>> DropDownUOM();
  }
}
