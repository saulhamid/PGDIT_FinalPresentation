// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SunBeam.Web.DependencyResolution
{
    using Common.Log;
    using Service.Interfaces;
    using StructureMap;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors
        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            //For(typeof(IDBGeneric<>)).Use(typeof(DBGeneric<>));
            For(typeof(Common.Log.ILogger)).Use(typeof(Logger));
            For<ICustomersBL>().Use<CustomersBL>();
            For<IEnumCountryBL>().Use<EnumCountryBL>();
            For<IEmployeeBL>().Use<EmployeeBL>();
            For<IZoneOrAreasBL>().Use<ZoneOrAreasBL>();
            For<IMarketsBL>().Use<MarketsBL>(); 
            For<IProductBrandsBL>().Use<ProductBrandsBL>(); 
            For<IProductSizeBL>().Use<ProductSizeBL>(); 
            For<IProductTypesBL>().Use<ProductTypesBL>();
            For<IProductBrandsBL>().Use<ProductBrandsBL>();
            For<IUOMBL>().Use<UOMBL>();
            For<IProductsBL>().Use<ProductsBL>();
            For<ISuppliersBL>().Use<SuppliersBL>();
            For<IProductCategorysBL>().Use<ProductCategorysBL>();
            For<IProductColorBL>().Use<ProductColorBL>();
            For<IPurchasesBL>().Use<PurchasesBL>();
            For<IPurcheaseDetailsBL>().Use<PurcheaseDetailsBL>();
            For<IStocksBL>().Use<StocksBL>();
            For<IStocksBL>().Use<StocksBL>();
            //For<IPurcheaseReturnsBL>().Use<PurcheaseReturnsBL>();
            For<ISalesBL>().Use<SalesBL>();
            For<ISalesDetailsBL>().Use<SalesDetailsBL>();
            For<IStockDetailsBL>().Use<StockDetailsBL>(); 
            For<IUsersBL>().Use<UsersBL>();
            //  For<IDBGeneric<typeof>> ().Use< Data.Infrastructure.DBGeneric < typeof>> ();
        }

        #endregion
    }
}