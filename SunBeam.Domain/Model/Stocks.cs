using System;
namespace SunBeam.Domain.Models
{
    public class Stocks:BaseEntity
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
      public bool StockStutes { get; set; }
    
    }
}
