using System;
namespace SunBeam.Domain.Models
{
    public class StockDetails
    {
      public int Id { get; set; }
      public int SalesId { get; set; }
      public int SalesReturnId { get; set; }
      public int PurcheaseId { get; set; }
      public int PurcheaseReturnId { get; set; }
      public int StockId { get; set; }
      public decimal StockReplace { get; set; }
      public decimal TransReplace { get; set; }
      public decimal TotalReplace { get; set; }
      public decimal StockReturn { get; set; }
      public decimal TransReturn { get; set; }
      public decimal TotalReturn { get; set; }
      public decimal StockDiscount { get; set; }
      public decimal TransDiscount { get; set; }
      public decimal TotalDiscount { get; set; }
      public decimal TransSlup { get; set; }
      public decimal StockSlup { get; set; }
      public decimal TotalSlup { get; set; }
      public decimal StockQuantity { get; set; }
      public decimal TransQuantity { get; set; }
      public decimal TotalQuantity { get; set; }
      public decimal TotalPaid { get; set; }
      public decimal StockPrice { get; set; }
      public decimal TransPrice { get; set; }
      public decimal TotalPrice { get; set; }
      public string Remarks { get; set; }
      public bool StockStutes { get; set; }
      public string Date { get; set; }
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
