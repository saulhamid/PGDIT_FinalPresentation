using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IUserRolesBL
{
Task<string> InsertUserRoles(UserRoles entity);
Task<string> UpdateUserRoles(UserRoles entity);
Task<string> IsDeleteUserRoles(string[] IdList,UserRoles entity);
Task<string> DeleteUserRoles(int Id);
Task<IEnumerable<UserRoles>> GetAllUserRoles();
Task<UserRoles> GetUserRolesById(int Id);
Task<IEnumerable<UserRoles>> DropDownUserRoles();
  }
}
