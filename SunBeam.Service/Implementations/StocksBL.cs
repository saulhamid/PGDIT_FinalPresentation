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
    public class StocksBL : IStocksBL
    {
        protected ILogger logger { get; set; }

        public StocksBL(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Insert Stocks
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> InsertStocks(StockVM entity)
        {
            var result = string.Empty;
            try
            {
                StockDetails stockdetail = new StockDetails();
                var dataProduct = new StocksRepository(logger).GetAll().Result.FirstOrDefault(c => c.ProductId.Equals(entity.ProductId));
                stockdetail.StockQuantity = dataProduct.Quantity;
                stockdetail.TransQuantity = decimal.Subtract(dataProduct.Quantity, entity.Quantity);
                stockdetail.TotalQuantity = entity.Quantity;
                stockdetail.Date = entity.Date;
                stockdetail.PurcheaseId = entity.PurcheaseId;
                stockdetail.SalesId = entity.SalesId;
                stockdetail.PurcheaseReturnId = entity.PurcheaseReturnId;
                stockdetail.SalesReturnId = entity.SalesReturnId;
                stockdetail.StockStutes = entity.StockStutes;
                result = await new StockDetailsBL(logger).InsertStockDetails(stockdetail);
                result = await new StocksRepository(logger).Insert(entity);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Update Stocks
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> UpdateStocks(StockVM entity)
        {
            try
            {
                var result = await new StocksRepository(logger).Update(entity);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Delete Stocks
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDeleteStocks(string[] IdList, StockVM entity)
        {
            string result = string.Empty;
            try
            {
                for (int i = 0; i < IdList.Length - 1; i++)
                {
                    result = await new StocksRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
        /// Delete Stocks
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> DeleteStocks(int Id)
        {
            string result = string.Empty;
            try
            {
                result = await new StocksRepository(logger).Delete(Id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Get All Stocks
        /// </summary>
        /// <returns>List ofStocks</returns>
        public async Task<IEnumerable<StockVM>> GetAllStocks()
        {
            try
            {
                var result = await new StocksRepository(logger).GetAll();
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Get Stocks by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Stocks Object</returns>
        public async Task<StockVM> GetStocksById(int Id)
        {
            try
            {
                var result = await new StocksRepository(logger).GetById(Id);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Get Id , Name Stocks
        /// </summary>
        /// <returns>List ofStocks</returns>
        public async Task<IEnumerable<StockVM>> DropDownStocks()
        {
            try
            {
                var result = await new StocksRepository(logger).Dropdown();
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
