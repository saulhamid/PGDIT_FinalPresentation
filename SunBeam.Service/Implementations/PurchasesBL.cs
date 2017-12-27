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


    public class PurchasesBL : IPurchasesBL
    {
        protected ILogger logger { get; set; }
        public PurchasesBL(ILogger logger)
        {
            this.logger = logger;
        }
        /// <summary>
        /// Insert Purchases
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> InsertPurchases(Purchases entity)
        {
                var result = string.Empty;
                using (TransactionScope txScope = new TransactionScope())
                {
                try
                {
                    IEnumerable<Purchases> pud = new List<Purchases>();
                     pud = new PurchasesRepository(logger).GetAll().Result;
                    if (pud.Any(c=>c.InvoiecNo.Equals(entity.InvoiecNo)))
                    {
                        throw new ArgumentNullException("Already this InvoiecNo is exist!", "");
                    }
                    var pudid = 1;
                    if (pud.Any())
                    {
                        pudid = pud.Last().Id + 1;
                    }
                    entity.Id = pudid;
                    result = await new PurchasesRepository(logger).Insert(entity);
                    foreach (var data in entity.PurcheaseDetails)
                    {
                        data.PurchaseId = pudid;
                        result = await new PurcheaseDetailsRepository(logger).Insert(data);
                        var stockdata = new StocksRepository(logger).GetAll().Result.FirstOrDefault(c => c.ProductId.Equals(data.ProductId));
                        if (stockdata != null)
                        {
                            if (stockdata.Quantity < data.Quantity)
                            {
                                stockdata.Quantity = decimal.Add(stockdata.Quantity, data.Quantity); ;
                            }
                            else if (stockdata.Quantity > data.Quantity)
                            {
                                stockdata.Quantity = decimal.Subtract(stockdata.Quantity, data.Quantity);
                            }
                            stockdata.FinalUnitPrice = data.UnitePrice;
                            result = await new StocksRepository(logger).Update(stockdata);
                        }
                        else
                        {
                            Stocks svm = new Stocks { ProductId = data.ProductId, FinalUnitPrice = data.UnitePrice, Quantity = data.Quantity };
                            result = await new StocksRepository(logger).Insert(svm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    result = "Fail~" + ex.Message.ToString();
                    throw ex;
                }
                finally {
                    txScope.Complete();
                }
            }
                return result;
        }

        /// <summary>
        /// Update Purchases
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> UpdatePurchases(Purchases entity)
        {
            var result = string.Empty;
            try
            {
                using (TransactionScope txScope = new TransactionScope())
                {
                    //Insert in Purchease
                    result = await new PurchasesRepository(logger).Update(entity);
                    var purd = new PurcheaseDetailsRepository(logger).GetAll().Result.Where(c => c.PurchaseId.Equals(entity.Id));
                    //Delete in PurcheaseDetail
                    foreach (var data in purd) {
                        var stockdata = new StocksRepository(logger).GetAll().Result.FirstOrDefault(c=>c.ProductId.Equals(data.ProductId));
                        if (stockdata != null)
                        {
                            stockdata.Quantity = stockdata.Quantity - data.Quantity;
                            result = await new StocksRepository(logger).Update(stockdata);
                        }
                        result = await new PurcheaseDetailsRepository(logger).Delete(data.Id);
                    }
                    foreach (PurcheaseDetails datas  in entity.PurcheaseDetails.ToList())
                    {
                        var stockdata = new StocksRepository(logger).GetAll().Result.FirstOrDefault(c => c.ProductId.Equals(datas.ProductId));
                        if (stockdata != null)
                        {
                            if (stockdata.Quantity < datas.Quantity)
                            {
                               var Quantity =decimal.Add(stockdata.Quantity, datas.Quantity);
                                stockdata.Quantity = Quantity;
                            }
                            else if (stockdata.Quantity > datas.Quantity)
                            {
                                stockdata.Quantity = decimal.Subtract(stockdata.Quantity, datas.Quantity);
                            }
                            stockdata.FinalUnitPrice = datas.UnitePrice;
                            result = await new StocksRepository(logger).Update(stockdata);
                        }
                        else {
                            Stocks svm = new Stocks { ProductId = datas.ProductId, FinalUnitPrice = datas.UnitePrice, Quantity = datas.Quantity };
                            result = await new StocksRepository(logger).Insert(svm);
                        }
                        datas.PurchaseId = entity.Id;
                        result = await new PurcheaseDetailsRepository(logger).Insert(datas);
                    }
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
        /// Delete Purchases
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDeletePurchases(string[] IdList, Purchases entity)
        {
            string result = string.Empty;
            try
            {
                for (int i = 0; i < IdList.Length - 1; i++)
                {
                    result = await new PurchasesRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
        /// Delete Purchases
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> DeletePurchases(int Id)
        {
            string result = string.Empty;
            try
            {
                result = await new PurchasesRepository(logger).Delete(Id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Get All Purchases
        /// </summary>
        /// <returns>List ofPurchases</returns>
        public async Task<IEnumerable<Purchases>> GetAllPurchases()
        {
            dynamic result=null;
            try
            {
                 result = await new PurchasesRepository(logger).GetAll();

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get Purchases by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Purchases Object</returns>
        public async Task<Purchases> GetPurchasesById(int Id)
        {
            Purchases result = null;
            try
            {
                using (TransactionScope txScope = new TransactionScope())
                {
                    result = await new PurchasesRepository(logger).GetById(Id);
                    result.PurcheaseDetails = new PurcheaseDetailsRepository(logger).GetAll().Result.Where(c => c.PurchaseId.Equals(Id));
                    txScope.Complete();
                    txScope.Dispose();
                };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }


        /// <summary>
        /// Get Id , Name Purchases
        /// </summary>
        /// <returns>List ofPurchases</returns>
        public async Task<IEnumerable<Purchases>> DropDownPurchases()
        {
            try
            {
                var result = await new PurchasesRepository(logger).Dropdown();
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
