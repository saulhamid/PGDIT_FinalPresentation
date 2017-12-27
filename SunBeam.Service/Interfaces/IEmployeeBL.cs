using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IEmployeeBL
{
Task<string> InsertEmployee(Employee entity);
Task<string> UpdateEmployee(Employee entity);
Task<string> IsDeleteEmployee(string[] IdList,Employee entity);
Task<string> DeleteEmployee(int Id);
Task<IEnumerable<Employee>> GetAllEmployee();
Task<Employee> GetEmployeeById(int Id);
Task<IEnumerable<Employee>> DropDownEmployee();
  }
}
