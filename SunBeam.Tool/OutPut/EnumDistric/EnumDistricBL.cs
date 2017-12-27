using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class EnumDistricBL : IEnumDistricBL
{

protected ILogger logger { get; set; }

public EnumDistricBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert EnumDistric
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertEnumDistric(EnumDistric entity)
{
try
{
var result = await new EnumDistricRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update EnumDistric
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateEnumDistric(EnumDistric entity)
{
try
{
var result = await new EnumDistricRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete EnumDistric
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteEnumDistric(string[] IdList, EnumDistric entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new EnumDistricRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete EnumDistric
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteEnumDistric(int Id)
{
string result = string.Empty;
try
{
result = await new EnumDistricRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All EnumDistric
/// </summary>
/// <returns>List ofEnumDistric</returns>
public async Task<IEnumerable<EnumDistric>> GetAllEnumDistric()
{
try
{
var result = await new EnumDistricRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get EnumDistric by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>EnumDistric Object</returns>
public async Task<EnumDistric> GetEnumDistricById(int Id)
{
try
{
var result = await new EnumDistricRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name EnumDistric
/// </summary>
/// <returns>List ofEnumDistric</returns>
public async Task<IEnumerable<EnumDistric>> DropDownEnumDistric()
{
try
{
var result = await new EnumDistricRepository(logger).Dropdown();
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
