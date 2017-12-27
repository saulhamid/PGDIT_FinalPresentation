using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IEnumDistricBL
{
Task<string> InsertEnumDistric(EnumDistric entity);
Task<string> UpdateEnumDistric(EnumDistric entity);
Task<string> IsDeleteEnumDistric(string[] IdList,EnumDistric entity);
Task<string> DeleteEnumDistric(int Id);
Task<IEnumerable<EnumDistric>> GetAllEnumDistric();
Task<EnumDistric> GetEnumDistricById(int Id);
Task<IEnumerable<EnumDistric>> DropDownEnumDistric();
  }
}
