using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class UOMBL : IUOMBL
{

protected ILogger logger { get; set; }

public UOMBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert UOM
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertUOM(UOM entity)
{
try
{
var result = await new UOMRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update UOM
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateUOM(UOM entity)
{
try
{
var result = await new UOMRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete UOM
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeleteUOM(string[] IdList, UOM entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new UOMRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete UOM
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeleteUOM(int Id)
{
string result = string.Empty;
try
{
result = await new UOMRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All UOM
/// </summary>
/// <returns>List ofUOM</returns>
public async Task<IEnumerable<UOM>> GetAllUOM()
{
try
{
var result = await new UOMRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get UOM by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>UOM Object</returns>
public async Task<UOM> GetUOMById(int Id)
{
try
{
var result = await new UOMRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name UOM
/// </summary>
/// <returns>List ofUOM</returns>
public async Task<IEnumerable<UOM>> DropDownUOM()
{
try
{
var result = await new UOMRepository(logger).Dropdown();
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
