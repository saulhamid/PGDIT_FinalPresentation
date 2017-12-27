using System;
namespace SunBeam.Domain.Models
{
    public class Purchases
    {
      public int Id { get; set; }
      public string InvoiecNo { get; set; }
      public int SupplierId { get; set; }
      public int EmployeeId { get; set; }
      public string Date { get; set; }
      public string CouponName { get; set; }
      public decimal CouponAmunt { get; set; }
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
