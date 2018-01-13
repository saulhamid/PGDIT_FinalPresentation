using SunBeam.Domain.Models;

namespace SunBeam.Domain.ViewModel
{
   public class StockVM:Stocks
    {
        public int PurcheaseId { get; set; }
        public int SalesId { get; set; }
        public int PurcheaseReturnId { get; set; }
        public int SalesReturnId { get; set; }
        public string ProductName { get; set; }
    }
}
