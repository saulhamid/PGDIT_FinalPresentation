using System;
namespace SunBeam.Domain.Models
{
    public class PurcheaseDetails : BaseEntity
    {
      public int Id { get; set; }
      public int PurchaseId { get; set; }
      public int ProductId { get; set; }
      public string ProductName { get; set; }
      public decimal UnitePrice { get; set; }
      public string Date { get; set; }
      public decimal Quantity { get; set; }
      public decimal Discount { get; set; }
      public decimal Slup { get; set; }
      public decimal TotalPrice { get; set; }
      public bool ProReturn { get; set; }
        public Products Products { get; set; }

    }
}
