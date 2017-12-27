using System;
namespace SunBeam.Domain.Models
{
    public class PurcheaseReturns
    {
      public int Id { get; set; }
      public int SupplierId { get; set; }
      public int EmployeeId { get; set; }
      public int PurchaseId { get; set; }
      public decimal Discount { get; set; }
      public decimal TotalPaid { get; set; }
      public string InvoiceNo { get; set; }
      public string Date { get; set; }
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
