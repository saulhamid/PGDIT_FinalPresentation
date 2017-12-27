using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IEnumDivisionBL
{
Task<string> InsertEnumDivision(EnumDivision entity);
Task<string> UpdateEnumDivision(EnumDivision entity);
Task<string> IsDeleteEnumDivision(string[] IdList,EnumDivision entity);
Task<string> DeleteEnumDivision(int Id);
Task<IEnumerable<EnumDivision>> GetAllEnumDivision();
Task<EnumDivision> GetEnumDivisionById(int Id);
Task<IEnumerable<EnumDivision>> DropDownEnumDivision();
  }
}
