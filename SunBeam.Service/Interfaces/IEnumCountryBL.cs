using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
    public interface IEnumCountryBL
    {
        Task<string> InsertEnumCountry(EnumCountry entity);
        Task<string> UpdateEnumCountry(EnumCountry entity);
        Task<string> IsDeleteEnumCountry(string[] IdList, EnumCountry entity);
        Task<string> DeleteEnumCountry(int Id);
        Task<IEnumerable<EnumCountry>> GetAllEnumCountry();
        Task<EnumCountry> GetEnumCountryById(int Id);
        Task<IEnumerable<EnumCountry>> DropDownEnumCountry();
    }
}
