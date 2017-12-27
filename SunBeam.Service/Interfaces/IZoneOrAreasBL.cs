using SunBeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBeam.Service.Interfaces
{
public interface IZoneOrAreasBL
{
Task<string> InsertZoneOrAreas(ZoneOrAreas entity);
Task<string> UpdateZoneOrAreas(ZoneOrAreas entity);
Task<string> IsDeleteZoneOrAreas(string[] IdList,ZoneOrAreas entity);
Task<string> DeleteZoneOrAreas(int Id);
Task<IEnumerable<ZoneOrAreas>> GetAllZoneOrAreas();
Task<ZoneOrAreas> GetZoneOrAreasById(int Id);
Task<IEnumerable<ZoneOrAreas>> DropDownZoneOrAreas();
  }
}
