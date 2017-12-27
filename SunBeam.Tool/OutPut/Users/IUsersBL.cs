using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IUsersBL
{
Task<string> InsertUsers(Users entity);
Task<string> UpdateUsers(Users entity);
Task<string> IsDeleteUsers(string[] IdList,Users entity);
Task<string> DeleteUsers(int Id);
Task<IEnumerable<Users>> GetAllUsers();
Task<Users> GetUsersById(int Id);
Task<IEnumerable<Users>> DropDownUsers();
  }
}
