using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class ZoneOrAreasBL : IZoneOrAreasBL
{

protected ILogger logger { get; set; }

public ZoneOrAreasBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert ZoneOrAreas
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertZoneOrAreas(ZoneOrAreas entity)
{
try
{
var result = await new ZoneOrAreasRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update ZoneOrAreas
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateZoneOrAreas(ZoneOrAreas entity)
{
try
{
var result = await new ZoneOrAreasRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete ZoneOrAreas
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteZoneOrAreas(string[] IdList, ZoneOrAreas entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new ZoneOrAreasRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
}
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Delete ZoneOrAreas
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteZoneOrAreas(int Id)
{
string result = string.Empty;
try
{
result = await new ZoneOrAreasRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All ZoneOrAreas
/// </summary>
/// <returns>List ofZoneOrAreas</returns>
public async Task<IEnumerable<ZoneOrAreas>> GetAllZoneOrAreas()
{
try
{
var result = await new ZoneOrAreasRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get ZoneOrAreas by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>ZoneOrAreas Object</returns>
public async Task<ZoneOrAreas> GetZoneOrAreasById(int Id)
{
try
{
var result = await new ZoneOrAreasRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name ZoneOrAreas
/// </summary>
/// <returns>List ofZoneOrAreas</returns>
public async Task<IEnumerable<ZoneOrAreas>> DropDownZoneOrAreas()
{
try
{
var result = await new ZoneOrAreasRepository(logger).Dropdown();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}
}


}
