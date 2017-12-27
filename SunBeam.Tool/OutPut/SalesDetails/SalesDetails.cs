using System;
namespace SunBeam.Domain.Models
{
    public class SalesDetails
    {
      public int Id { get; set; }
      public int SalesId { get; set; }
      public int ProductId { get; set; }
      public string ProductName { get; set; }
      public string ProductCode { get; set; }
      public decimal Discount { get; set; }
      public decimal UnitePrice { get; set; }
      public string Date { get; set; }
      public decimal Slup { get; set; }
      public decimal Bonus { get; set; }
      public decimal AssaignQuantity { get; set; }
      public decimal SalesQuantity { get; set; }
      public decimal Return { get; set; }
      public decimal Replace { get; set; }
      public decimal TotalSlupPrice { get; set; }
      public decimal WithOurDiscountPrice { get; set; }
      public decimal TotalAmount { get; set; }
      public string Remarks { get; set; }
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
