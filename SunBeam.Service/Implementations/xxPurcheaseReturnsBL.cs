using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using SunBeam.Domain.ViewModel;

namespace SunBeam.Service.Interfaces
{


    public class xxPurcheaseReturnsBL : IPurcheaseReturnsBL
    {

        protected ILogger logger { get; set; }
        public xxPurcheaseReturnsBL(ILogger logger)
        {
            this.logger = logger;
        }
        /// <summary>
        /// Insert PurcheaseReturns
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> InsertPurcheaseReturns(PurcheaseReturns entity)
        {
            var result = string.Empty;
            StockVM stockdata = new StockVM();
            StocksRepository stocksRepository = new StocksRepository(logger);
            try
            {
              
            using (TransactionScope txScope = new TransactionScope())
            {
                    var pud = new PurcheaseReturnsRepository(logger).GetAll();
                    var pudid = 1;
                    if (pud != null)
                    {
                        pudid = pud.Id + 1;
                    }
                    entity.Id = pudid;
                    result = await new PurcheaseReturnsRepository(logger).Insert(entity);
                    foreach (var data in entity.PurcheaseReturnDetails)
                    {
                        data.PurchaseReturnId = pudid;
                        result = await new PurcheaseReturnDetailsRepository(logger).Insert(data);
                        
                        stockdata = new StocksRepository(logger).GetAll().Result.FirstOrDefault(c => c.ProductId == data.ProductId);
                        if (stockdata != null)
                        {
                            stockdata.Quantity = decimal.Subtract(stockdata.Quantity, data.Quantity);
                            result = await new StocksRepository(logger).Update(stockdata);
                        }
                    }
                    txScope.Complete();
                    txScope.Dispose();
                }
            return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                result = "Fail~" + ex.Message.ToString();
                throw ex;
            }
            finally
            {
               
            }
        }

        /// <summary>
        /// Update PurcheaseReturns
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> UpdatePurcheaseReturns(PurcheaseReturns entity)
        {
            try
            {
                var result = await new PurcheaseReturnsRepository(logger).Update(entity);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Delete PurcheaseReturns
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDeletePurcheaseReturns(string[] IdList, PurcheaseReturns entity)
        {
            string result = string.Empty;
            try
            {
                for (int i = 0; i < IdList.Length - 1; i++)
                {
                    result = await new PurcheaseReturnsRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
        /// Delete PurcheaseReturns
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> DeletePurcheaseReturns(int Id)
        {
            string result = string.Empty;
            try
            {
                result = await new PurcheaseReturnsRepository(logger).Delete(Id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Get All PurcheaseReturns
        /// </summary>
        /// <returns>List ofPurcheaseReturns</returns>
        public async Task<IEnumerable<PurcheaseReturns>> GetAllPurcheaseReturns()
        {
            try
            {
                var result = await new PurcheaseReturnsRepository(logger).GetAll();
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get PurcheaseReturns by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>PurcheaseReturns Object</returns>
        public async Task<PurcheaseReturns> GetPurcheaseReturnsById(int Id)
        {
            try
            {
                var result = await new PurcheaseReturnsRepository(logger).GetById(Id);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }


        /// <summary>
        /// Get Id , Name PurcheaseReturns
        /// </summary>
        /// <returns>List ofPurcheaseReturns</returns>
        public async Task<IEnumerable<PurcheaseReturns>> DropDownPurcheaseReturns()
        {
            try
            {
                var result = await new PurcheaseReturnsRepository(logger).Dropdown();
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
