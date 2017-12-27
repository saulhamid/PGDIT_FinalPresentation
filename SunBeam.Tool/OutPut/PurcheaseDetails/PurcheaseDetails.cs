using System;
namespace SunBeam.Domain.Models
{
    public class PurcheaseDetails
    {
      public int Id { get; set; }
      public int PurchaseId { get; set; }
      public int ProductId { get; set; }
      public string ProductName { get; set; }
      public string ProductCode { get; set; }
      public decimal UnitePrice { get; set; }
      public string Date { get; set; }
      public decimal Quantity { get; set; }
      public decimal Discount { get; set; }
      public decimal Slup { get; set; }
      public decimal TotalPrice { get; set; }
      public string Remarks { get; set; }
      public bool IsActive { get; set; }
      public bool IsArchive { get; set; }
      public string CreatedAt { get; set; }
      public string CreatedFrom { get; set; }
      public string CreatedAtBy { get; set; }
      public string LastUpdateBy { get; set; }
      public string LastUpdateAt { get; set; }
      public string LastUpdateFrom { get; set; }
    }
}
