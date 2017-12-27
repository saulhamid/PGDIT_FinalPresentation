using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IUsersBL
{
Task<string> InsertUsers(User entity);
Task<string> UpdateUsers(User entity);
Task<string> IsDeleteUsers(string[] IdList,User entity);
Task<string> DeleteUsers(int Id);
Task<IEnumerable<User>> GetAllUsers();
Task<User> GetUsersById(int Id);
Task<IEnumerable<User>> DropDownUsers();
  }
}
