using SunBeam.Common.Log;
using SunBeam.Data.Repositories.Implementations;
using SunBeam.Data.Repositories.Interfaces;
using SunBeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SunBeam.Service.Interfaces
{


    public class EnumCountryBL : IEnumCountryBL
    {

        protected ILogger logger { get; set; }
        protected IRepository<EnumCountry> IRepository { get; set; }
        public EnumCountryBL(ILogger logger, IRepository<EnumCountry> IRepository)
        {
            this.logger = logger;
            this.IRepository = IRepository;
        }

        /// <summary>
        /// Insert EnumCountry
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> InsertEnumCountry(EnumCountry entity)
        {
            try
            {
                var result = await new EnumCountryRepository(logger).Insert(entity);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Update EnumCountry
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Message</returns>
        public async Task<string> UpdateEnumCountry(EnumCountry entity)
        {
            try
            {
                var result = await new EnumCountryRepository(logger).Update(entity);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Delete EnumCountry
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> IsDeleteEnumCountry(string[] IdList, EnumCountry entity)
        {
            string result = string.Empty;
            try
            {
                for (int i = 0; i < IdList.Length - 1; i++)
                {
                    result = await new EnumCountryRepository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);
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
        /// Delete EnumCountry
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Message</returns>
        public async Task<string> DeleteEnumCountry(int Id)
        {
            string result = string.Empty;
            try
            {
                result = await new EnumCountryRepository(logger).Delete(Id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Get All EnumCountry
        /// </summary>
        /// <returns>List ofEnumCountry</returns>
        public async Task<IEnumerable<EnumCountry>> GetAllEnumCountry()
        {
            try
            {
                var result = await IRepository.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get EnumCountry by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>EnumCountry Object</returns>
        public async Task<EnumCountry> GetEnumCountryById(int Id)
        {
            try
            {
                var result = await new EnumCountryRepository(logger).GetById(Id);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }


        /// <summary>
        /// Get Id , Name EnumCountry
        /// </summary>
        /// <returns>List ofEnumCountry</returns>
        public async Task<IEnumerable<EnumCountry>> DropDownEnumCountry()
        {
            try
            {
                var result = await new EnumCountryRepository(logger).Dropdown();
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
