using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class EnumDivisionBL : IEnumDivisionBL
{

protected ILogger logger { get; set; }

public EnumDivisionBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert EnumDivision
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertEnumDivision(EnumDivision entity)
{
try
{
var result = await new EnumDivisionRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update EnumDivision
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateEnumDivision(EnumDivision entity)
{
try
{
var result = await new EnumDivisionRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete EnumDivision
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteEnumDivision(string[] IdList, EnumDivision entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new EnumDivisionRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete EnumDivision
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteEnumDivision(int Id)
{
string result = string.Empty;
try
{
result = await new EnumDivisionRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All EnumDivision
/// </summary>
/// <returns>List ofEnumDivision</returns>
public async Task<IEnumerable<EnumDivision>> GetAllEnumDivision()
{
try
{
var result = await new EnumDivisionRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get EnumDivision by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>EnumDivision Object</returns>
public async Task<EnumDivision> GetEnumDivisionById(int Id)
{
try
{
var result = await new EnumDivisionRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name EnumDivision
/// </summary>
/// <returns>List ofEnumDivision</returns>
public async Task<IEnumerable<EnumDivision>> DropDownEnumDivision()
{
try
{
var result = await new EnumDivisionRepository(logger).Dropdown();
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
