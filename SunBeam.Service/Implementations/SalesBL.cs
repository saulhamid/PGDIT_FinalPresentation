using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;

namespace SunBeam.Service.Interfaces
{


    public class SalesBL : ISalesBL
    {

        protected ILogger logger { get; set; }

        public SalesBL(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Insert Sales
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> InsertSales(Sales entity)
        {
            var result = String.Empty;
            using (TransactionScope txScope = new TransactionScope())
            {
                try
                {
                    IEnumerable<Sales> sad = new List<Sales>();
                    sad = new SalesRepository(logger).GetAll().Result;

                    if (sad.Any(c => c.InvoiecNo.Equals(entity.InvoiecNo)))
                    {
                        throw new ArgumentNullException("Already this InvoiecNo is exist!", "");
                    }
                    var sadid = 1;
                    if (sad.Any())
                    {
                        sadid = sad.Last().Id + 1;
                    }
                    entity.Id = sadid;
                    result = await new SalesRepository(logger).Insert(entity);
                    foreach (var data in entity.SalesDetails)
                    {
                        data.SalesId = sadid;
                        result = await new SalesDetailsRepository(logger).Insert(data);
                        var stockdata = new StocksRepository(logger).GetAll().Result.FirstOrDefault(c => c.ProductId.Equals(data.ProductId));
                        if (stockdata != null)
                        {
                            stockdata.Quantity = decimal.Subtract(stockdata.Quantity, data.SalesQuantity);
                        }
                        result = await new StocksRepository(logger).Update(stockdata);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    throw ex;
                }
                finally
                {
                    txScope.Complete();
                }
                return result;
            }
        }

        /// <summary>
        /// Update Sales
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> UpdateSales(Sales entity)
        {
            var result = String.Empty;
            using (TransactionScope txScope = new TransactionScope())
            {
                try
                {
                    result = await new SalesRepository(logger).Update(entity);
                    var purd = new SalesDetailsRepository(logger).GetAll().Result.Where(c => c.SalesId.Equals(entity.Id));
                    //Delete in PurcheaseDetail
                    foreach (var data in purd)
                    {
                        var stockdata = new StocksRepository(logger).GetAll().Result.FirstOrDefault(c => c.ProductId.Equals(data.ProductId));
                        if (stockdata != null)
                        {
                            stockdata.Quantity =decimal.Subtract(stockdata.Quantity ,data.SalesQuantity);
                            result = await new StocksRepository(logger).Update(stockdata);
                        }
                        result = await new SalesDetailsRepository(logger).Delete(data.Id);
                    }
                    foreach (var data in entity.SalesDetails)
                    {
                        data.SalesId = entity.Id;
                        result = await new SalesDetailsRepository(logger).Insert(data);
                        var stockdata = new StocksRepository(logger).GetAll().Result.FirstOrDefault(c => c.ProductId.Equals(data.ProductId));
                        if (stockdata != null)
                        {
                            stockdata.Quantity = decimal.Add(stockdata.Quantity, data.SalesQuantity);
                            result = await new StocksRepository(logger).Update(stockdata);
                        }
                       
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    throw ex;
                }
                finally
                {
                    txScope.Complete();
                }
            }
        }

        /// <summary>
        /// Delete Sales
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDeleteSales(string[] IdList, Sales entity)
        {
            string result = string.Empty;
            try
            {
                for (int i = 0; i < IdList.Length - 1; i++)
                {
                    result = await new SalesRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
        /// Delete Sales
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> DeleteSales(int Id)
        {
            string result = string.Empty;
            try
            {
                result = await new SalesRepository(logger).Delete(Id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Get All Sales
        /// </summary>
        /// <returns>List ofSales</returns>
        public async Task<IEnumerable<Sales>> GetAllSales()
        {
            try
            {
                var result = await new SalesRepository(logger).GetAll();
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get Sales by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Sales Object</returns>
        public async Task<Sales> GetSalesById(int Id)
        {
            try
            {
                Sales result = new Sales();
                using (TransactionScope txScope = new TransactionScope())
                {
                    result = await new SalesRepository(logger).GetById(Id);
                    result.SalesDetails = new SalesDetailsRepository(logger).GetAll().Result.Where(c => c.SalesId.Equals(Id));
                    txScope.Complete();
                }
                    return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }


        /// <summary>
        /// Get Id , Name Sales
        /// </summary>
        /// <returns>List ofSales</returns>
        public async Task<IEnumerable<Sales>> DropDownSales()
        {
            try
            {
                var result = await new SalesRepository(logger).Dropdown();
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
