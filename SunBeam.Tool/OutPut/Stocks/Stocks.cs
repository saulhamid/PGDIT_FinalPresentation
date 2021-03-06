using System;
namespace SunBeam.Domain.Models
{
    public class Stocks
    {
      public int Id { get; set; }
      public int ProductId { get; set; }
      public decimal Replace { get; set; }
      public decimal Return { get; set; }
      public decimal Discount { get; set; }
      public decimal Slup { get; set; }
      public decimal Quantity { get; set; }
      public decimal TotalPaid { get; set; }
      public decimal TotalPrice { get; set; }
      public decimal GrandTotal { get; set; }
      public string Date { get; set; }
      public decimal UnitPrice { get; set; }
      public decimal OpeningQuantity { get; set; }
      public string Remarks { get; set; }
      public bool StockStutes { get; set; }
      public bool IsActive { get; set; }
      public bool IsArchive { get; set; }
      public string CreatedBy { get; set; }
      public string CreatedAt { get; set; }
      public string CreatedFrom { get; set; }
      public string LastUpdateBy { get; set; }
      public string LastUpdateAt { get; set; }
      public string LastUpdateFrom { get; set; }
    }
}
