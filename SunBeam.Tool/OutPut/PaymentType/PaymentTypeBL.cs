using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


public class PaymentTypeBL : IPaymentTypeBL
{

protected ILogger logger { get; set; }

public PaymentTypeBL(ILogger logger)
{
this.logger = logger;
}

/// <summary>
/// Insert PaymentType
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertPaymentType(PaymentType entity)
{
try
{
var result = await new PaymentTypeRepository(logger).Insert(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update PaymentType
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdatePaymentType(PaymentType entity)
{
try
{
var result = await new PaymentTypeRepository(logger).Update(entity);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete PaymentType
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> IsDeletePaymentType(string[] IdList, PaymentType entity)
{
string result = string.Empty;
try
{
 for (int i = 0; i < IdList.Length - 1; i++)
{
result = await new PaymentTypeRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
/// Delete PaymentType
/// </summary>
/// <param name="Id"></param>
/// <returns>Message</returns>
public async Task<string> DeletePaymentType(int Id)
{
string result = string.Empty;
try
{
result = await new PaymentTypeRepository(logger).Delete(Id);
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
return result;
}

/// <summary>
/// Get All PaymentType
/// </summary>
/// <returns>List ofPaymentType</returns>
public async Task<IEnumerable<PaymentType>> GetAllPaymentType()
{
try
{
var result = await new PaymentTypeRepository(logger).GetAll();
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get PaymentType by Id
/// </summary>
/// <param name="Id"></param>
/// <returns>PaymentType Object</returns>
public async Task<PaymentType> GetPaymentTypeById(int Id)
{
try
{
var result = await new PaymentTypeRepository(logger).GetById(Id);
return result;
}
catch (Exception ex)
{
logger.Error(ex.Message);
throw ex;
}
}


/// <summary>
/// Get Id , Name PaymentType
/// </summary>
/// <returns>List ofPaymentType</returns>
public async Task<IEnumerable<PaymentType>> DropDownPaymentType()
{
try
{
var result = await new PaymentTypeRepository(logger).Dropdown();
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
