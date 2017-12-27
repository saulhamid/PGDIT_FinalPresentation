using System;
namespace SunBeam.Domain.Models
{
    public class Sales
    {
      public int Id { get; set; }
      public string InvoiecNo { get; set; }
      public int ProductId { get; set; }
      public int CustomerId { get; set; }
      public int ZoneOrAreaId { get; set; }
      public int EmployeeId { get; set; }
      public string DiscountRemarks { get; set; }
      public decimal Discount { get; set; }
      public decimal TotalDiscount { get; set; }
      public decimal TotalPaid { get; set; }
      public decimal GrandTotal { get; set; }
      public string Date { get; set; }
      public decimal PackUnitPrice { get; set; }
      public decimal PackQuantity { get; set; }
      public string EventName { get; set; }
      public decimal EventAamount { get; set; }
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
