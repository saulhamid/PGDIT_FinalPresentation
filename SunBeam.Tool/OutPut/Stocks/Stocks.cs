using System;
namespace SunBeam.Domain.Models
{
    public class Stocks
    {
      public int Id { get; set; }
      public int ProductId { get; set; }
      public decimal TotalReplace { get; set; }
      public decimal TotalReturn { get; set; }
      public decimal TotalDiscount { get; set; }
      public decimal TotalSlup { get; set; }
      public decimal StockQuantity { get; set; }
      public decimal TotalQuantity { get; set; }
      public decimal TotalPaid { get; set; }
      public decimal TotalPrice { get; set; }
      public decimal GrandTotal { get; set; }
      public string Date { get; set; }
      public decimal FinalUnitPrice { get; set; }
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
