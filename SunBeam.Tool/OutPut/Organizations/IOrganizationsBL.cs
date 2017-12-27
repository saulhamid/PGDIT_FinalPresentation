using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IOrganizationsBL
{
Task<string> InsertOrganizations(Organizations entity);
Task<string> UpdateOrganizations(Organizations entity);
Task<string> IsDeleteOrganizations(string[] IdList,Organizations entity);
Task<string> DeleteOrganizations(int Id);
Task<IEnumerable<Organizations>> GetAllOrganizations();
Task<Organizations> GetOrganizationsById(int Id);
Task<IEnumerable<Organizations>> DropDownOrganizations();
  }
}
